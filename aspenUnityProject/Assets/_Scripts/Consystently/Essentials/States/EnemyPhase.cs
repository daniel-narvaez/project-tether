using UnityEngine;

namespace Consystently.Essentials
{
    public class EnemyPhase : BattlePhase
    {
        public EnemyPhase(CombatManager combatManager) : base(combatManager) {}

        public override void Enter()
        {
            Debug.Log("enemy phase entered");
        }

        public override void Update()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}