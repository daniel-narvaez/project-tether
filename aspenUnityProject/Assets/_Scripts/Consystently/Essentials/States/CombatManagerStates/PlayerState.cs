using UnityEngine;

namespace Consystently.Essentials
{
    public class PlayerState : BattleState
    {
        public PlayerState(CombatManager combatManager) : base(combatManager) { }

        public override void Enter()
        {
           Debug.Log("player phase entered"); 
           combatManager.ResetCurrentTile();
        }

        public override void Update()
        {
            //wrapper function in loop for stuff that does the actual state changing 
        }

        public override void Exit()
        {
        }
    }
}