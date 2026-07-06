using UnityEngine;

public class CombatSim : MonoBehaviour
{
  public GameObject Player;
  public GameObject Enemy;
  public GameObject Attacker;
  public GameObject Defender;

  void Start()
  {
    Debug.Log("1 for player physical attacking, 2 for enemy physical attacking, 3 for player magic attacking, 4 for enemy magic attacking");
  }
  
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Alpha1))
      {
        Attacker = Player;
        Defender = Enemy;
        PhysicalFight();
      }
    if (Input.GetKeyDown(KeyCode.Alpha2))
      {
        Attacker = Enemy;
        Defender = Player;
        PhysicalFight();
      }
    if (Input.GetKeyDown(KeyCode.Alpha3))
      {
        Attacker = Player;
        Defender = Enemy;
        MagicFight();
      }
    if (Input.GetKeyDown(KeyCode.Alpha4))
      {
        Attacker = Enemy;
        Defender = Player;
        MagicFight();
      }
  }

  public void PhysicalFight()
  {
    CombatFormulas.PhysicalDamage(Attacker, Defender);
  }

  public void MagicFight()
  {
    CombatFormulas.MagicalDamage(Attacker, Defender);
  }
}
