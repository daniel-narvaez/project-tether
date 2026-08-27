using System.Collections.Generic;
using _Scripts.Runtime.Misc;
using Tether.CharacterSystems;
using UnityEngine;

namespace Consystently.Essentials
{
    public class EncounterManager : Manager<EncounterManager>
    {
        private EncounterSO encounterSo;
        
        
        //initial unit formation generated from BattlefieldMap for the mvp 
        private Encounter encounter = new Encounter();
        
        //determine the positions of the unit controllers (which will store unit data such as position)
        private IUnitController[,] unitControllers = new IUnitController[19,4];
        
        void Start()
        {
            GameManager.Instance.ChangedGameState += HandleState;
        }

        void OnDisable()
        {
            GameManager.Instance.ChangedGameState -= HandleState; 
        }

        void HandleState(GameState gameState)
        {
            //switch statement here if it ever becomes useful
        }

        //getters may or may not have expanded functions down the line
        public EncounterSO GetEncounterSo()
        {
            return encounterSo;
        }
        //returns 2d Unit array (for the data) 

        public Encounter GetEncounter()
        {
            return encounter;
        }

        //called from EnemyUnitController
        public void StartEncounter(EncounterSO encounterSo)
        {
           this.encounterSo = encounterSo; 
           GameManager.Instance.ChangeGameState(new CombatGameState(GameManager.Instance)); 
        }

        public void StartEncounter(Encounter encounter)
        {
           this.encounter = encounter; 
           GameManager.Instance.ChangeGameState(new CombatGameState(GameManager.Instance)); 
        }

        public void StartEncounter()
        {
            GameManager.Instance.ChangeGameState(new CombatGameState(GameManager.Instance));
        }

        //for mvp primarily 
        public void GenerateEncounter(List<BattlefieldTile> tiles)
        {
           Debug.Log($"tiles length: {tiles.Count}");
           for (int tile = 0; tile < tiles.Count; tile++)
           {
               if (tiles[tile].FilledSlots.Count < 1)
                   continue; 
               Debug.Log($"tiles length: {tile} {tiles[tile].FilledSlots.Count}");
               List<UnitPieceSlot> FilledSlots = tiles[tile].FilledSlots;
               
               for (int unit = 0; unit < FilledSlots.Count; unit++)
               {
                   Debug.Log(FilledSlots[unit].Piece.Sim.Data);
               }
           }
        }

    }
}