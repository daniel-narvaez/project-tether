using UnityEngine;

namespace Consystently.Essentials
{
    public class EnemyState : BattleState
    {
        public EnemyState(CombatManager combatManager) : base(combatManager) {}

        public override void Enter()
        {
            Debug.Log("enemy phase entered");
            combatManager.ResetCurrentTile();
        }

        public override void Update()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}