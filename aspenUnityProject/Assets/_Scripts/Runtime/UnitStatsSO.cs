using UnityEngine;

[CreateAssetMenu(fileName = "New Unit Stats", menuName = "Scriptable Objects/Units/Stats")]
public class UnitStatsSO : ScriptableObject
{
  [Tooltip("HP: Total amount of damage a unit can sustain before falling in battle.")]
  [Range(1, 9999)]
  [SerializeField] private int health;

  /// <summary>
  /// HP: Total amount of damage a unit can sustain before falling in battle.
  /// </summary>
  public int Health => health;



  [Tooltip("EN: Total amount of resources a unit can spend to use special abilities.")]
  [Range(1, 999)]
  [SerializeField] private int energy;

  /// <summary>
  /// EN: Total amount of resources a unit can spend to use special abilities.
  /// </summary>
  public int Energy => energy;


  
  [Tooltip("STR: A unit's physical power.")]
  [Range(1, 999)]
  [SerializeField] private int strength;

  /// <summary>
  /// STR: A unit's physical power.
  /// </summary>
  public int Strength => strength;


  
  [Tooltip("DEF: A unit's durability against physical power.")]
  [Range(1, 999)]
  [SerializeField] private int defense;

  /// <summary>
  /// DEF: A unit's durability against physical power.
  /// </summary>
  public int Defense => defense;


  
  [Tooltip("TEC: A unit's technical power.")]
  [Range(1, 999)]
  [SerializeField] private int tech;

  /// <summary>
  /// TEC: A unit's technical power.
  /// </summary>
  public int Tech => tech;


  
  [Tooltip("RES: A unit's durability against technical power.")]
  [Range(1, 999)]
  [SerializeField] private int resistance;

  /// <summary>
  /// RES: A unit's durability against technical power.
  /// </summary>
  public int Resistance => resistance;


  
  [Tooltip("PRC: A unit's accuracy for targeting attacks & abilities.")]
  [Range(1, 999)]
  [SerializeField] private int precision;

  /// <summary>
  /// PRC: A unit's accuracy for targeting attacks & abilities.
  /// </summary>
  public int Precision => precision;


  
  [Tooltip("FIN: A unit's evasiveness to incoming attacks & abilities.")]
  [Range(1, 999)]
  [SerializeField] private int finesse;

  /// <summary>
  /// FIN: A unit's evasiveness to incoming attacks & abilities.
  /// </summary>
  public int Finesse => finesse;


  
  [Tooltip("SPE: How often a unit moves during battle.")]
  [Range(1, 999)]
  [SerializeField] private int speed;

  /// <summary>
  /// SPE: How often a unit moves during battle.
  /// </summary>
  public int Speed => speed;


  
  [Tooltip("LCK: A unit's affinity for chance.")]
  [Range(1, 999)]
  [SerializeField] private int luck;
  
  /// <summary>
  /// LCK: A unit's affinity for chance.
  /// </summary>
  public int Luck => luck;
}
