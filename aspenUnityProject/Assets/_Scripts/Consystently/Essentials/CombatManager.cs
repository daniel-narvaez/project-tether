using System;
using System.Collections.Generic;
using _Scripts.Runtime.Misc;
using Tether.CharacterSystems;
using TileSystem;
using UnityEngine;

namespace Consystently.Essentials
{
    /*will not be a traditional manager because it does not 
    need to be static. EncounterManager will be static and the one 
    to send the data over to CombatManager. CombatManager will exist
    in the battle scene only. The UIManager will need a reference to the CombatManager 
    */
    public class CombatManager : MonoBehaviour
    {
        //need to input data into the empty husk gameObjects 
        private UnitDataSO[,] initializerData;
        
        //no use in mvp
        //private TileSO[] tiles;
        
        //used for instantiating the models
        private Encounter encounter; 
        

        [SerializeField] private Transform tilesParent;
        private readonly TileController[] tileControllers = new TileController[19];
        
        private readonly Vector3Int[] directions = new Vector3Int[] {
            new Vector3Int(0,-1,1), //SE 
            new Vector3Int(-1,0,1), //S
            new Vector3Int(-1,1,0), //SW
            new Vector3Int(0, 1,-1), //NW
            new Vector3Int(1, 0,-1), //N
            new Vector3Int(1, -1, 0) //NE
        };
        
        public Dictionary<Vector3Int, int> TileCubeCoords { get; private set; }= new Dictionary<Vector3Int, int>();
        
        //sliding window using currentUnitTurn for displaying it 
        //least to greatest
        //make sure it has references and not copies of the objects, so changes are reflected
        public List<UnitController> TurnOrder { get; private set; }= new List<UnitController>();
        private BattlePhase[] phases = new BattlePhase[2];
        private BattlePhase currentPhase;  
        
        #region miscStateManagementVariables
        //probably not the best way of implementing this 
        public int TotalAllies { get; private set; }
        public int TotalEnemies { get; private set; }
        public int CurrentUnitTurn { get; private set; }
        public int SelectedTile { get; private set; }
        public int CurrentTile { get; private set; }
        #endregion
         
        
        //combat manager will sub to each unit and read their deaths. Have this action so ui managers don't have to 
        //sub to each unit themselves 
        //use arrays for unitsDead because damage is dealt to entire tiles at a time. have whatever handles animations process unit deaths by iterating
        //TODO: implement the proper response to unit death. For each unit that dies, add them to an array. 
        public static event Action<Unit[]> unitsDead;
        
        //animation/tile update handled per unit at the instant they move. Perhaps also camera class  
        public static event Action<UnitController> unitMoved;
        public static event Action<BattlePhase> battlePhaseChanged; 
        
        void Start()
        {
            encounter = EncounterManager.Instance.GetEncounter();
            initializerData = EncounterManager.Instance.GetInitializerData();
            SortTiles(tilesParent.GetComponentsInChildren<TileController>());
            CreateObjects(); 
            TurnOrder.Sort((a,b) => a.GetData().Speed.CompareTo(b.GetData().Speed));
            GenerateCoords();
            phases[0] = new PlayerPhase(this);
            phases[1] = new EnemyPhase(this);
            ValidateData();
        }

        void Update()
        {
            currentPhase.Update(); 
        }

        //Correct order is not guaranteed by GetComponentsInChildren
        private void SortTiles(TileController[] tiles)
        {
            foreach (TileController tileController in tiles)
            {
                tileControllers[tileController.Num()] = tileController;
            } 
        }
        
        //TODO: subscribe to units 
        //TODO: subscribe to uimanager's actions
        
        //ui class queries static events subscription combat manager is referenced in combat ui ? 

        #region setupRelatedStuff


        void CreateObjects()
        {
            for (int tile = 0; tile < encounter.TotalTiles(); tile++)
            {
                if (encounter.UnitCountAtTile(tile) < 1) 
                    continue; 
                for (int unit = 0; unit < encounter.MaxUnitsPerTile(); unit++)
                {
                    if (unit > encounter.UnitCountAtTile(tile) - 1)
                        break;
                    GameObject newTempObject = Instantiate(encounter[tile,unit], tileControllers[tile].Position(), Quaternion.Euler(-90f,0,0));
                    //set up controllers after object instantiation so objects don't override each other's data
                    //the newly cloned object does not share the same reference as the original prefab, so there is no overriding
                    if (initializerData[tile, unit].Faction == Faction.Ally)
                    {
                        tileControllers[tile].AddUnit(newTempObject.GetComponent<AllyUnitController>());
                        TotalAllies++;
                    }
                    else if (initializerData[tile, unit].Faction == Faction.Enemy)
                    {
                        tileControllers[tile].AddUnit(newTempObject.GetComponent<EnemyUnitController>());
                        TotalEnemies++;
                    }
                    else 
                        Debug.Log("neutral units not yet implemented");
//                    Debug.Log($"{tile}: {unit}, {tileControllers[tile].UnitCount()}");
                    tileControllers[tile].GetUnitAt(unit).Initialize(initializerData[tile,unit]);
                    tileControllers[tile].GetUnitAt(unit).SetTile(tile);
                    TurnOrder.Add(tileControllers[tile].GetUnitAt(unit));
                }
                tileControllers[tile].RepositionUnits(10f);
            }
        }

        //starts at tile 0 and spirals outwards to get the cube coords for every tile 
        //coords are for determining proper tile selection when the user moves across the field 
        //3r(r+1)+1=tiles formula for generic implementation if additional rings are added
        //for reference, tile 18 should be (2,0,-2) 
        //We could possibly merge the createObjects with this function 
        void GenerateCoords()
        {
            int tile = 0;
            Vector3Int currentPos = new Vector3Int(0, 0, 0);
            for (int ring = 0; ring <= 2; ring++)
            {
               TileCubeCoords.Add(currentPos, tile);
               currentPos += directions[(int)CubeCoordDirections.NE];
               tile++;
               TileCubeCoords.Add(currentPos, tile);
               for (int southEasts = ring - 1; southEasts > 0; southEasts--)
               {
                   currentPos += directions[(int)CubeCoordDirections.SE];
                   tile++;
                   TileCubeCoords.Add(currentPos, tile);
               }
               for (int direction = 1; direction < directions.Length; direction++)
               {
                   for (int times = ring; times > 0; times--)
                   {
                       currentPos += directions[direction];
                       tile++;
                       TileCubeCoords.Add(currentPos, tile);
                   }
               }
            }
        } 

        //debug tool
        //TODO:
        //FINISH STAT SYSTEM; health will be at zero when printed
        void ValidateData()
        {
            for (int tile = 0; tile < encounter.TotalTiles(); tile++)
            {
                if (encounter.UnitCountAtTile(tile) < 1) 
                    continue; 
                for (int unit = 0; unit < encounter.MaxUnitsPerTile(); unit++)
                {
                    if (unit > encounter.UnitCountAtTile(tile) - 1)
                        break;
                    Debug.Log($"{tileControllers[tile].GetUnitAt(unit).GetData().Name}:  {tileControllers[tile].GetUnitAt(unit).GetData().Strength}");
                    
                }
            }
        }
        #endregion
        
        public void ChangePhase()
        {
            if (TurnOrder[CurrentUnitTurn].GetData().Faction == Faction.Ally)
            {
                currentPhase = phases[0];
                battlePhaseChanged?.Invoke(currentPhase);                
            }
            else if (TurnOrder[CurrentUnitTurn].GetData().Faction==Faction.Enemy)
            {
                currentPhase = phases[1];
                battlePhaseChanged?.Invoke(currentPhase);
            }
        } 
        
    }
}