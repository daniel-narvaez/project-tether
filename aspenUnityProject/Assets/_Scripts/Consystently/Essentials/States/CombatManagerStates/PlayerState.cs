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
           stateStack.Clear();
        }

        public override void Update()
        {
            if(stateStack.Count > 0)
                stateStack.Peek().Update();
        }

        public override void Exit()
        {
            foreach (ActionState state in stateStack)
               state.Exit();
            stateStack.Clear();
        }

        public void PopState(InputAction.CallbackContext context)
        {
           if (stateStack.Count == 0)
                return;
           stateStack.Pop().Exit();
           if (stateStack.Count == 0)
               CombatManager.FinishSelection(); 
           else
               stateStack.Peek().Enter();
        }

        public override void PushState()
        {
            if (stateStack.Count > states.Count - 1)
            {
                Debug.Log("playerstate stack bug; how is this possible");
                return;
            }

            if (stateStack.Count > 0)
                stateStack.Peek().Exit(); 
            stateStack.Push(states[stateStack.Count]);
            stateStack.Peek().Enter();
        }
        
    }
}