using Tether.CharacterSystems;
using UnityEngine;

//this script must be dragged to an object before making it a prefab and dragging the prefab to a unit SO.
public class AllyUnitController : MonoBehaviour, IUnitController {
   private AllyUnit stats;
   private int tile; 

   //to be called by the combat maanager 
   public void Initialize(UnitDataSO baseStats)
   {
      stats = new AllyUnit(baseStats);
   }

   /*
    TODO:
    add movement that is disabled on combat game state  
   */
   private void Update()
   {
      
   }

   public void TakeDamage(int damage)
   {
      stats?.ChangeHealthRemaining(damage); 
   }

   //will differ from SetTile in that it will consider game logic with conditionals 
   public void Move(int tile)
   {
   }

   public void Move(Vector3 position)
   {
     transform.position = position; 
   }
   
   public Unit GetData()
   {
      return stats; 
   }

   public int GetTile()
   {
      return tile;
   }

   public void SetTile(int newTile)
   {
      this.tile = newTile;
   }
}
