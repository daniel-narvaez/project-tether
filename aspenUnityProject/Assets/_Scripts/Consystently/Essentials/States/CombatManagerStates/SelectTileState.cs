using UnityEngine;

namespace Consystently.Essentials
{
    public class SelectTileState : BattleState 
    {
        SelectTileState(CombatManager combatManager) : base(combatManager) {}

        public override void Enter()
        {
            combatManager.Input.Enable();
            combatManager.Input.TileSelect.Confirm.performed += combatManager.SelectTile;
            combatManager.Input.TileSelect.Exit.performed += combatManager.CancelSelection; 

        }

        public override void Update()
        {
            Vector2 move = combatManager.Input.TileSelect.Move.ReadValue<Vector2>();
        }

        public override void Exit()
        {
            combatManager.Input.TileSelect.Confirm.performed -= combatManager.SelectTile;
            combatManager.Input.TileSelect.Exit.performed -= combatManager.CancelSelection;
            combatManager.Input.Disable();
        }
    }
}