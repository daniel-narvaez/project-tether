using UnityEngine;

//this script must be dragged to an object before making it a prefab and dragging the prefab to a unit SO.
public class AllyUnitGO : MonoBehaviour {
   private AllyUnit stats;

   //to be called by the combat maanager 
   public void initialize(PlayableCharacterUnitSO baseStats)
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
   
}
