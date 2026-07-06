using UnityEngine;

public static class CombatFormulas
{
  public static void PhysicalDamage(GameObject attacker, GameObject defender)
  {
    UnitStats attackerStats = attacker.GetComponent<UnitStats>();
    UnitStats defenderStats = defender.GetComponent<UnitStats>();
    bool crit = Crit(attacker, defender);
    bool miss = Miss(attacker, defender);

    if (attackerStats == null || defenderStats == null)
      {
        Debug.LogError("Missing UnitStats");
          return;
      }
    
    //Actual Damage
    float damage = attackerStats.Strength*(166f / (166f + defenderStats.Defense)) * Random.Range(0.9f, 1.1f); //Round up
    //float damage = Mathf.Floor(attackerStats.Strength*(166f / (166f + defenderStats.Defense))* Random.Range(0.9f, 1.1f) ); //Round down
    
    if(miss == true)
    {
      damage = 0f;
      Debug.Log($"{attacker.name} missed!");
    }
    else if(crit == true)
    {
      damage = damage * 2f;
      Debug.Log($"{attacker.name} CRIT!");
    }
    
    if(defenderStats.isBlocking == true)
    {
      damage = Mathf.Floor(damage * 0.5f);
      Debug.Log($"{defender.name} was blocking!");
    }

    //return Mathf.Ceil(damage);
    defenderStats.Health -= Mathf.Ceil(damage);

    Debug.Log($"{attacker.name} dealt {Mathf.Ceil(damage)} damage to {defender.name}. {defender.name} has {defenderStats.Health} HP remaining.");
  }

  public static bool Crit(GameObject attacker, GameObject defender)
  {
    UnitStats attackerStats = attacker.GetComponent<UnitStats>();
    UnitStats defenderStats = defender.GetComponent<UnitStats>();

    if (attackerStats == null || defenderStats == null)
      {
        Debug.LogError("Missing UnitStats");
          return false;
      }

    bool crit = false;
    
    int critsuccess = Random.Range(1, 21); //random number between 1-20 as 21 falls out of the range of Random.Range
    if(critsuccess == 20)
    {
      crit = true; //5% chance of success
    }
    else
    {
      crit = false;
    }

    return crit;
  }

  public static bool Miss(GameObject attacker, GameObject defender)
  {
    UnitStats attackerStats = attacker.GetComponent<UnitStats>();
    UnitStats defenderStats = defender.GetComponent<UnitStats>();

    if (attackerStats == null || defenderStats == null)
      {
        Debug.LogError("Missing UnitStats");
          return false;
      }
    
    bool miss = false; //Temporary garunteed hits until formula is given

    return miss;
  }
}
