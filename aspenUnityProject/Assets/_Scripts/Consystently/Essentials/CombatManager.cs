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
        
        //sliding window for displaying it
        //least to greatest
        //make sure it has references and not copies of the objects, so changes are reflected
        private readonly List<IUnitController> turnOrder = new  List<IUnitController>();
        
        

        //combat manager will sub to each unit and read their deaths. Have this action so ui managers don't have to 
        //sub to each unit themselves 
        //use arrays for unitsDead because damage is dealt to entire tiles at a time. have whatever handles animations process unit deaths by iterating
        //TODO: implement the proper response to unit death. For each unit that dies, add them to an array. 
        private Action<Unit[]> unitsDead;
        
        //animation/tile update handled per unit at the instant they move 
        private Action<IUnitController> unitMoved;
        
        void Start()
        {
            encounter = EncounterManager.Instance.GetEncounter();
            initializerData = EncounterManager.Instance.GetInitializerData();
            SortTiles(tilesParent.GetComponentsInChildren<TileController>());
            CreateObjects(); 
            turnOrder.Sort((a,b) => a.GetData().Speed.CompareTo(b.GetData().Speed));
            ValidateData();
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
                        tileControllers[tile].AddUnit(newTempObject.GetComponent<AllyUnitController>());
                    else if (initializerData[tile, unit].Faction == Faction.Enemy)
                        tileControllers[tile].AddUnit(newTempObject.GetComponent<EnemyUnitController>());
                    else 
                        Debug.Log("neutral units not yet implemented");
//                    Debug.Log($"{tile}: {unit}, {tileControllers[tile].UnitCount()}");
                    tileControllers[tile].GetUnitAt(unit).Initialize(initializerData[tile,unit]);
                    tileControllers[tile].GetUnitAt(unit).SetTile(tile);
                    turnOrder.Add(tileControllers[tile].GetUnitAt(unit));
                }
                tileControllers[tile].RepositionUnits(10f);
            }
        }

        void GetTiles()
        {
            
        }

        public List<IUnitController> GetTurnOrder()
        {
            return turnOrder;
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
                    Debug.Log($"{tileControllers[tile].GetUnitAt(unit).GetData().Name}:  {tileControllers[tile].GetUnitAt(unit).GetData().Name}");
                    
                }
            }
        }
    }
}