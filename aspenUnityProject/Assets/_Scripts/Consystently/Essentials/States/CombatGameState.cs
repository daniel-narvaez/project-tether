using UnityEngine;

namespace Consystently.Essentials
{
    public class CombatGameState : GameState
    {
       public CombatGameState (GameManager gameManager) : base(gameManager) { }
       public override void Enter()
       {
           Debug.Log("combat game state entered");
       }
       public override void Update()
       {
           
       }

       public override void Exit()
       {
       }
    }
}