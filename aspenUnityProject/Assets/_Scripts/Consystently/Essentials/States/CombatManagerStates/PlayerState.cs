using System.Collections.Generic;
using UnityEngine;

namespace Consystently.Essentials
{
    public class PlayerState : BattleState
    {
        private Stack<BattleState>  stateStack = new Stack<BattleState>();
        
        //TODO: possibly add new state class for individual unit selection
        private List<BattleState> states  = new List<BattleState>();
        private int stateToPush; 

        public PlayerState(CombatManager combatManager) : base(combatManager)
        {
           states.Add(new SelectTileState(combatManager)); 
        }

        public override void Enter()
        {
           Debug.Log("player phase entered"); 
           combatManager.ResetCurrentTile();
           stateStack.Clear();
           stateToPush = 0;
        }

        public override void Update()
        {
            //wrapper function in loop for stuff that does the actual state changing 
        }

        public override void Exit()
        {
            stateStack.Clear();
            stateToPush = 0;
        }

        public void PopState()
        {
           stateStack.Pop(); 
           stateToPush = stateStack.Count;
        }

        public void PushState()
        {
           stateStack.Push(states[stateToPush]);
           stateToPush= stateStack.Count;
        }
        
    }
}