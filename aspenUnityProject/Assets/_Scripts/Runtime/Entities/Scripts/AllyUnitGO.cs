using UnityEngine;

public class AllyUnitGO : MonoBehaviour {
   private AllyUnit stats;
   [SerializeField] private PlayableCharacterUnitSO baseStats;

   private void Awake()
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
      stats.ChangeHealthRemaining(damage); 
   }
   
}
