namespace Consystently.Essentials
{
    public class EncounterManager : Manager<EncounterManager>
    {
        
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
    }
}