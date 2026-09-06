namespace Consystently.Essentials
{
    public abstract class BattlePhase : State
    {
        private CombatManager combatManager;

        protected BattlePhase(CombatManager combatManager)
        {
            this.combatManager = combatManager; 
        }

        public abstract void Enter();
        public abstract void Update();
        public abstract void Exit(); 
    }
}