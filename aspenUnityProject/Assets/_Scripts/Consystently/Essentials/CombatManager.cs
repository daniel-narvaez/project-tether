using System;
using System.Collections.Generic;
using _Scripts.Runtime.Misc;
using Tether.CharacterSystems;
using TileSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using Debug = UnityEngine.Debug;

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
        
        private Encounter encounter; 
        [SerializeField] private Transform tilesParent;
        public InputSystem_Actions Input { get; private set; }
        private readonly TileController[] tileControllers = new TileController[19];

        #region directions
        private readonly Vector3Int[] directions = new Vector3Int[] {
            new Vector3Int(0,-1,1), //SE 
            new Vector3Int(-1,0,1), //S
            new Vector3Int(-1,1,0), //SW
            new Vector3Int(0, 1,-1), //NW
            new Vector3Int(1, 0,-1), //N
            new Vector3Int(1, -1, 0) //NE
        };
        #endregion
        
        //forgot why I made this an int 
        public Dictionary<Vector3Int, int> TileCubeCoords { get; private set; }= new Dictionary<Vector3Int, int>();
        
        //make sure it has references and not copies of the objects, so changes are reflected
        public List<UnitController> TurnOrder { get; private set; }= new List<UnitController>();
        public List<UnitController> DeadUnits {get; private set;}= new List<UnitController>();
        
        //TODO: add an enum for this if we ever have more than just enemy/ally turns 
        private readonly BattleState[] phases = new BattleState[2];
        private BattleState currentState;  
        
        #region miscStateManagementVariables
        
        //need totals for defeat/win checks
        public int TotalAllies { get; private set; }
        public int TotalEnemies { get; private set; }
        public int CurrentUnitTurn { get; private set; }
        private Vector3Int SelectedTile { get; set; }
        public Vector3Int CurrentTile { get; private set; } = new Vector3Int(0, 0, 0);
        public CombatActions ReceivedAction { get; private set; }
        public int ActionSelection { get; private set; }
        
        #endregion
         
        //TODO: sub to each unit themselves 
        //use arrays for unitsDead because damage is dealt to entire tiles at a time. have whatever handles animations process unit deaths by iterating
        //TODO: implement the proper response to unit death. For each unit that dies, add them to an array. 
        public static event Action<Unit[]> unitsDead;
        
        //animation/tile update handled per unit at the instant they move. Perhaps also camera class  
        public static event Action<UnitController> unitMoved;
        
        //we may want sounds when the cursor moves around 
        public static event Action<Vector3> hoverTileChanged;  
        public static event Action<BattleState, UnitController> battlePhaseChanged;

        private void Awake()
        {
            Input = new InputSystem_Actions();
        }

        void OnEnable()
        {
            encounter = EncounterManager.Instance.GetEncounter();
            initializerData = EncounterManager.Instance.GetInitializerData();
            SortTiles(tilesParent.GetComponentsInChildren<TileController>());
            GenerateCoords();
            CreateObjects(); 
            TurnOrder.Sort((a,b) => b.GetData().Speed.CompareTo(a.GetData().Speed));
            phases[0] = new PlayerState(this);
            phases[1] = new EnemyState(this);
            CombatUI.PlayerAction += HandleAction;
            CombatUI.PlayerSelectiveAction += HandleAction;
            ChangeTurn(); 
            ValidateData();
        }

        private void OnDisable()
        {
            CombatUI.PlayerAction -= HandleAction;
            CombatUI.PlayerSelectiveAction -= HandleAction;
            Input.Disable();
        }

        void Update()
        {
           currentState?.Update(); 
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
                    tileControllers[tile].GetUnitAt(unit).SetTile(tileControllers[tile].tileCoordinate);
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
            Debug.Log($"tile: {tile}, {currentPos}");
            TileCubeCoords.Add(currentPos, tile);
            tileControllers[tile].tileCoordinate = currentPos;
            for (int ring = 1; ring <= 2; ring++)
            {
               currentPos += directions[(int)CubeCoordDirections.NE];
               tile++;
               Debug.Log($"tile: {tile}, {currentPos}");
               TileCubeCoords.Add(currentPos, tile);
               tileControllers[tile].tileCoordinate = currentPos;
               for (int southEasts = ring - 1; southEasts > 0; southEasts--)
               {
                   currentPos += directions[(int)CubeCoordDirections.SE];
                   tile++;
                   Debug.Log($"tile: {tile}, {currentPos}");
                   TileCubeCoords.Add(currentPos, tile);
                   tileControllers[tile].tileCoordinate = currentPos;
               }
               for (int direction = (int)CubeCoordDirections.S; direction < directions.Length; direction++)
               {
                   for (int times = ring; times > 0; times--)
                   {
                       currentPos += directions[direction];
                       tile++;
                       Debug.Log($"tile: {tile}, {currentPos}");
                       TileCubeCoords.Add(currentPos, tile);
                       Debug.Log($"tilecontrollers size: {tileControllers.Length}");
                       tileControllers[tile].tileCoordinate = currentPos;
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
                    Debug.Log($"{tileControllers[tile].GetUnitAt(unit).GetData().Name}:  {tileControllers[tile].GetUnitAt(unit).GetData().Speed}");
                    
                }
            }
        }
        #endregion
        
        //dead are kept because lazy deletion. Also, there may or may not be a revive feature, so their order being kept is good.
        //I am also not sure if deletion is better because deletion would require searching and result in the entire list shifting. 
        private void ChangeTurn()
        {
            if (DeadUnits.Count >= (TotalAllies + TotalEnemies))
            {
                Debug.Log("All units dead.");
                return;
            }
            if (CurrentUnitTurn > TurnOrder.Count - 1)
                CurrentUnitTurn = 0;
            while (TurnOrder[CurrentUnitTurn].IsDead)
            {
                CurrentUnitTurn++;
                if (CurrentUnitTurn > TurnOrder.Count - 1)
                    CurrentUnitTurn = 0;
            }
            if (TurnOrder[CurrentUnitTurn].GetData().Faction == Faction.Ally && currentState != phases[0])
            {
                currentState?.Exit();
                currentState = phases[0];
            }
            else if (TurnOrder[CurrentUnitTurn].GetData().Faction==Faction.Enemy && currentState != phases[1])
            {
                currentState?.Exit();
                currentState = phases[1];
            }
            else
            {
                battlePhaseChanged?.Invoke(currentState, TurnOrder[CurrentUnitTurn]);
                return;
            }
            CurrentUnitTurn++;
            currentState.Enter();
            battlePhaseChanged?.Invoke(currentState, TurnOrder[CurrentUnitTurn]);
        } 
        
        //refactor to take a runtime attack class if we need to modify attacks in-game for whatever reason
        //all attacks target tiles, not individual units 
        public void DoBattle(Vector3Int attackerPos, UnitController attacker, Vector3Int targetPos)
        {
            
        }

        //functions for camera/ui movement/whatever 
        public void MoveTileSelector(CubeCoordDirections direction)
        {
            Vector3Int projectedTile = CurrentTile + directions[(int)direction];            
            if(TileCubeCoords.TryGetValue(projectedTile, out _))
            {
                CurrentTile = projectedTile;
                hoverTileChanged?.Invoke(tileControllers[TileCubeCoords[CurrentTile]].Position());
            }
        }

        /*
        pushes the inner states of the player/enemy turn states 
        the player's selectTileState will tell this manager when to 
        execute the SelectTile function. 
        I opted for states because the player may undo actions.
        Usually, the first requirement after selecting a combat action
        is selecting a tile. 
        */
        private void HandleAction(CombatActions action)
        {
            ReceivedAction = action;
            Debug.Log("hello 2");
            switch(action)
            {
               case CombatActions.Attack:
                   currentState.PushState();
                   break;
               case CombatActions.Defend:
                   //unit defend function 
                   break;
               case CombatActions.Move:
                   currentState.PushState();
                   break;
              case CombatActions.View:
                    currentState.PushState();                   
                   break;
                default:
                    Debug.Log($"Unknown action: {action}");
                    break;
            }
        }

        //action requires selection like for ability/item
        private void HandleAction(CombatActions action, int selection)
        {
            ReceivedAction = action;
            ActionSelection = selection;
            switch (action)
            {
               case CombatActions.Ability:
                   currentState.PushState();
                   break;
               case CombatActions.Item:
                   Debug.Log($"unknown action: {action}" );
                   break;
            }
        }
        

        public TileController GetSelectedTileController()
        {
            return tileControllers[TileCubeCoords[TurnOrder[CurrentUnitTurn].GetTileCoords()]];
        }

        public void ResetCurrentTile()
        {
            SelectedTile = TurnOrder[CurrentUnitTurn].GetTileCoords();
            CurrentTile = SelectedTile;
        }

        //
        //TODO: finish switch 
        //attack is basic attack with no ability selection. Add new doBattle function with no ability 
        public void SelectTile(InputAction.CallbackContext context)
        {
            SelectedTile = CurrentTile;
            switch (ReceivedAction)
            {
               case CombatActions.Attack:
                   break;
               case CombatActions.Move:
                   break;
               case CombatActions.Ability:
                   break;
               case CombatActions.Item:
                   Debug.Log("items are not implemented in mvp");
                   break;
               case CombatActions.View:
                   break;
               default:
                   Debug.Log("Unknown action");
                   break;
            }
        }
        
        

        public void FinishSelection()
        { 
           ResetCurrentTile();
           //effectively tells the combat UI to reset the player turn 
           battlePhaseChanged?.Invoke(currentState, TurnOrder[CurrentUnitTurn]);
        }

        public UnitController GetCurrentUnit()
        {
            return TurnOrder[CurrentUnitTurn];
        }


    }
}