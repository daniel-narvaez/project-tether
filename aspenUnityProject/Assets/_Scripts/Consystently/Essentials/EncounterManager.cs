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

        public void StartEncounter(EncounterSO encounterSO)
        {
            
        }

        public void StartEncounter(Encounter encounter)
        {
            
        }

    }
}