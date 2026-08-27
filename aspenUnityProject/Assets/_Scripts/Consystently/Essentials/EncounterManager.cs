using _Scripts.Runtime.Misc;
using Tether.CharacterSystems;
using UnityEngine;

namespace Consystently.Essentials
{
    public class EncounterManager : Manager<EncounterManager>
    {
        private EncounterSO encounterSo;
        private Encounter encounter = new Encounter();
        
        //initial unit formation generated from BattlefieldMap - will be used to
        //determine the positions of the unit controllers (which will store unit data such as position)
        private GameObject[,] initialObjectFormation = new GameObject[19,4];
        private IUnitController[,] unitControllers = new IUnitController[19,4];
        
        void OnEnable()
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

        //called from EnemyUnitGO
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

        public void ResetEncounter()
        {
            encounter = new Encounter(); 
        }

    }
}