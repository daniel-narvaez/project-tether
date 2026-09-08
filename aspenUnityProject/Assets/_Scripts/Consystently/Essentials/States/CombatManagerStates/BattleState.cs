using UnityEngine.InputSystem;

namespace Consystently.Essentials
{
    public abstract class BattleState : State
    {
        protected CombatManager CombatManager { get; private set; }

        protected BattleState(CombatManager combatManager)
        {
            CombatManager = combatManager; 
        }

        public abstract void Enter();
        public abstract void Update();
        public abstract void Exit(); 
        public abstract void PushState();

    }
}