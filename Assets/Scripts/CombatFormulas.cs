using UnityEngine;

public static class CombatFormulas
{
  public static void Damage(GameObject attacker, GameObject defender)
  {
    UnitStats attackerStats = attacker.GetComponent<UnitStats>();
    UnitStats defenderStats = defender.GetComponent<UnitStats>();
    bool crit = Crit(attacker, defender);
    bool miss = Miss(attacker, defender);
    float damage = 0f;

    if (attackerStats == null || defenderStats == null)
    {
      Debug.LogError("Missing UnitStats");
        return;
    }
    //Actual Damage
    //Physical
    if(attackerStats.damageCategoriesDealt[0] == UnitStats.damageCategory.Physical)
    {
      damage = attackerStats.Strength*(166f / (166f + defenderStats.Defense)) * Random.Range(0.9f, 1.1f); //Round up
    }
    //Elemental
    else if(attackerStats.damageCategoriesDealt[0] == UnitStats.damageCategory.Elemental)
    {
      damage = attackerStats.Magic*(166f / (166f + defenderStats.Resistance)) * Random.Range(0.9f, 1.1f); //Round up
    }
    //Dodge Chance
    if(miss == true)
    {
      damage = 0f;
      Debug.Log($"{attacker.name} missed!");
    }
    //Modifiers
    //Crit
    else if(crit == true)
    {
      damage = damage * 2f;
      Debug.Log($"{attacker.name} CRIT!");
    }
    //Blocking
    if(defenderStats.isBlocking == true)
    {
      damage = Mathf.Floor(damage * 0.5f);
      Debug.Log($"{defender.name} was blocking!");
    }
    //Vulnerability
    foreach (UnitStats.damageType vulnerability in defenderStats.activeVulnerabilties)
    {
      if (attackerStats.damageTypesDealt[0] == vulnerability)
      {
        damage = Mathf.Floor(damage * 1.5f);
        Debug.Log($"{defender.name} is vulnerable!");
        break;
      }
    }
    // //Tolerance
    foreach (UnitStats.damageType tolerance in defenderStats.activeTolerances)
    {
      if (attackerStats.damageTypesDealt[0] == tolerance)
      {
        damage = Mathf.Floor(damage * 0.67f);
        Debug.Log($"{defender.name} is tolerant!");
        break;
      }
    }

    defenderStats.Health -= Mathf.Ceil(damage);
    Debug.Log($"{attacker.name} dealt {Mathf.Ceil(damage)} damage to {defender.name}. {defender.name} has {defenderStats.Health} HP remaining.");
  }

  public static bool Crit(GameObject attacker, GameObject defender)
  {
    UnitStats attackerStats = attacker.GetComponent<UnitStats>();
    UnitStats defenderStats = defender.GetComponent<UnitStats>();
    bool crit = false;

    if (attackerStats == null || defenderStats == null)
    {
      Debug.LogError("Missing UnitStats");
        return false;
    }
    
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
    bool miss = false;

    if (attackerStats == null || defenderStats == null)
    {
      Debug.LogError("Missing UnitStats");
        return false;
    }

    float hitchance = (attackerStats.Precision / defenderStats.Finesse);
    //Debug.Log(hitchance);

    if(hitchance >= 1f) //If Precision > Finesse ie. hit > dodge chance
    {
      miss = false;
    }
    else if(hitchance < 1f && hitchance > 0f) //If Precision < Finesse but not 0
    {
      float randomhit = Random.Range(0f, 1f);
      if (randomhit <= hitchance)
      {
        miss = false;
      }
      else
      {
        miss = true;
      }
    }
    else //If Precision is under 0 (other values are covered by the above statements)
    {
      miss = true;
    }

    return miss;
  }
}
