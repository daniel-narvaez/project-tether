using UnityEngine;
using UnityEngine.InputSystem;

namespace Consystently.Essentials
{
    public class EnemyState : BattleState
    {
        public EnemyState(CombatManager combatManager) : base(combatManager) {}

        public override void Enter()
        {
            Debug.Log("enemy phase entered");
            CombatManager.ResetCurrentTile();
        }

        public override void Update()
        {
            
        }

        public override void Exit()
        {
            
        }

        public override void PushState()
        {
            
        }

        public void PopState()
        {
            
        }
    }
}