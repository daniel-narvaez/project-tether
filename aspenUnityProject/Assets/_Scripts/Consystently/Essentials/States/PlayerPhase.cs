using UnityEngine;

namespace Consystently.Essentials
{
    public class PlayerPhase : BattlePhase
    {
        public PlayerPhase(CombatManager combatManager) : base(combatManager) { }

        public override void Enter()
        {
           Debug.Log("player phase entered"); 
        }

        public override void Update()
        {
            //wrapper function in loop for stuff that does the actual state changing 
        }

        public override void Exit()
        {
           combatManager.ChangePhase(); 
        }
    }
}