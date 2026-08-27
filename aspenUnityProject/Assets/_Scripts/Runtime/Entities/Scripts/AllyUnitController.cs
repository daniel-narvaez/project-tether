using Tether.CharacterSystems;
using UnityEngine;

//this script must be dragged to an object before making it a prefab and dragging the prefab to a unit SO.
public class AllyUnitController : MonoBehaviour, IUnitController {
   private AllyUnit stats;

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

   public void Move(Vector3 translation)
   {
      
   }
   
}
