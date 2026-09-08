using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Consystently.Essentials
{
    public class PlayerState : BattleState
    {
        private Stack<ActionState>  stateStack = new Stack<ActionState>();
        
        //TODO: possibly add new state class for individual unit selection
        private List<ActionState> states  = new List<ActionState>();

        public PlayerState(CombatManager combatManager) : base(combatManager)
        {
           states.Add(new SelectTileState(combatManager, this)); 
        }

        public override void Enter()
        {
           Debug.Log("player phase entered"); 
           CombatManager.ResetCurrentTile();
           stateStack.Clear();
        }

        public override void Update()
        {
            //wrapper function in loop for stuff that does the actual state changing 
        }

        public override void Exit()
        {
            stateStack.Clear();
        }

        public void PopState(InputAction.CallbackContext context)
        {
           stateStack.Pop().Exit();
           if (states.Count == 0)
           {
               CombatManager.FinishSelection(); 
           }
        }

        public override void PushState()
        {
           stateStack.Push(states[stateStack.Count]);
        }
        
    }
}