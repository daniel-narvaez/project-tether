using UnityEngine;

public class CombatSim : MonoBehaviour
{
  public GameObject Player;
  public GameObject Enemy;
  public GameObject Attacker;
  public GameObject Defender;

  void Start()
  {
    Debug.Log("1 for player attacking, 2 for enemy attacking");
  }
  
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Alpha1))
      {
        Attacker = Player;
        Defender = Enemy;
        Fight();
      }
    if (Input.GetKeyDown(KeyCode.Alpha2))
      {
        Attacker = Enemy;
        Defender = Player;
        Fight();
      }
  }

  public void Fight()
  {
    //UnitStats defenderStats = Defender.GetComponent<UnitStats>();
    CombatFormulas.PhysicalDamage(Attacker, Defender);

    //float damage = CombatFormulas.PhysicalDamage(Attacker, Defender);
    // bool crit = CombatFormulas.Crit(Attacker, Defender);
    // bool miss = CombatFormulas.Miss(Attacker, Defender);

    // if(miss == true)
    // {
    //   Debug.Log($"{Attacker.name} missed!");
    // }
    // else if(crit == true)
    // {
    //   Debug.Log($"{Attacker.name} CRIT!");
    // }
    
    // if(defenderStats.isBlocking == true)
    // {
    //   Debug.Log($"{Defender.name} was blocking!");
    // }

    // defenderStats.Health -= damage;

    // Debug.Log($"{Attacker.name} dealt {damage} damage to {Defender.name}. {Defender.name} has {defenderStats.Health} HP remaining.");
    // Debug.Log("1 for player attacking, 2 for enemy attacking");
  }
}
