using UnityEngine;
using System; 

namespace Consystently.Essentials
{
    //the state when the player is selecting a tile for an action (e.g., attacking, viewing, etc.)
    public class SelectTileState : ActionState
    {
        public SelectTileState(CombatManager combatManager, PlayerState battleState) : base(combatManager, battleState) {}

        public override void Enter()
        {
            CombatManager.Input.Enable();
            CombatManager.Input.TileSelect.Confirm.performed += CombatManager.SelectTile;
            CombatManager.Input.TileSelect.Exit.performed += ((PlayerState)BattleState).PopState; 

        }

        public override void Update()
        {
            Vector2 move = CombatManager.Input.TileSelect.Move.ReadValue<Vector2>();
        }

        public override void Exit()
        {
            CombatManager.Input.TileSelect.Confirm.performed -= CombatManager.SelectTile;
            CombatManager.Input.TileSelect.Exit.performed -= ((PlayerState)BattleState).PopState;
            CombatManager.Input.Disable();
        }
    }
}