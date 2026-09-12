using System;
using System.Numerics;
using UnityEngine;
using Consystently.Essentials.Math;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;

namespace Consystently.Essentials
{
    //the state when the player is selecting a tile for an action (e.g., attacking, viewing, etc.)
    public class SelectTileState : ActionState
    {
        public SelectTileState(CombatManager combatManager, PlayerState battleState) : base(combatManager, battleState) {}

        public override void Enter()
        {
            Debug.Log("Enabled again");
            CombatManager.Input.Enable();
            CombatManager.Input.TileSelect.Confirm.performed += CombatManager.SelectTile;
            CombatManager.Input.TileSelect.Exit.performed += ((PlayerState)BattleState).PopState;
            CombatManager.Input.TileSelect.Move.started += OnMove;
        }

        public override void Update()
        {
            /*
            Vector2 move = CombatManager.Input.TileSelect.Move.ReadValue<Vector2>();
            if (move != Vector2.zero)
            {
                CombatManager.MoveTileSelector(move.GetDirection());
            }
            */
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            Vector2 move = context.ReadValue<Vector2>();
            CombatManager.MoveTileSelector(move.GetDirection());
            Debug.Log("makes no sense");
        }

        public override void Exit()
        {
            Debug.Log("This should be disabled");
            CombatManager.Input.TileSelect.Confirm.performed -= CombatManager.SelectTile;
            CombatManager.Input.TileSelect.Exit.performed -= ((PlayerState)BattleState).PopState;
            CombatManager.Input.TileSelect.Move.started -= OnMove;
            CombatManager.Input.Disable();
        }
    }
}