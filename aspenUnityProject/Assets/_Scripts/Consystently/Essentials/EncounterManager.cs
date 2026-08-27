using _Scripts.Runtime.Misc;

namespace Consystently.Essentials
{
    public class EncounterManager : Manager<EncounterManager>
    {
        private EncounterSO encounterSo;
        private Encounter encounter = new Encounter();
        
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

        public Encounter GetEncounter()
        {
            return encounter;
        }

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

    }
}