using UnityEngine;

[CreateAssetMenu(fileName = "New Unit Base Data", menuName = "Scriptable Objects/Unit/Base Data")]
public class UnitDataSO : ScriptableObject
{
  [Header("Progress")]
  [Space(10)]
  [Range(1, 99)]
  [SerializeField] public int Level;

  [HideInInspector] public int ExpToNextLevel;

  [HideInInspector] public int TotalExpGained;

  [Space(5)]
  [Tooltip("The last recorded value of this unit's remaining HP, as a percentage.")]
  [Range(0.00f, 100.00f)]
  [SerializeField] public float RemainingHealth;

  [Space(5)]
  [Tooltip("The last recorded value of this unit's remaining EN, as a percentage.")]
  [Range(0.00f, 100.00f)]
  [SerializeField] public float RemainingEnergy;
  
  [Header("Base Stats")]
  [Space(10)]
  [Tooltip("HP: Total amount of damage a unit can sustain before falling in battle.")]
  [SerializeField] private Tier _health;

  /// <summary>
  /// HP: Total amount of damage a unit can sustain before falling in battle.
  /// </summary>
  public Tier Health => _health;


  [Space(10)]
  [Tooltip("EN: Total amount of resources a unit can spend to use special abilities.")]
  [SerializeField] private Tier _energy;

  /// <summary>
  /// EN: Total amount of resources a unit can spend to use special abilities.
  /// </summary>
  public Tier Energy => _energy;


  [Space(10)]
  [Tooltip("STR: A unit's physical power.")]
  [SerializeField] private Tier _strength;

  /// <summary>
  /// STR: A unit's physical power.
  /// </summary>
  public Tier Strength => _strength;


  [Space(10)]
  [Tooltip("DEF: A unit's durability against physical power.")]
  [SerializeField] private Tier _defense;

  /// <summary>
  /// DEF: A unit's durability against physical power.
  /// </summary>
  public Tier Defense => _defense;


  [Space(10)]
  [Tooltip("TEC: A unit's technical power.")]
  [SerializeField] private Tier _tech;

  /// <summary>
  /// TEC: A unit's technical power.
  /// </summary>
  public Tier Tech => _tech;


  [Space(10)]
  [Tooltip("RES: A unit's durability against technical power.")]
  [SerializeField] private Tier _resistance;

  /// <summary>
  /// RES: A unit's durability against technical power.
  /// </summary>
  public Tier Resistance => _resistance;


  [Space(10)]
  [Tooltip("SPE: How often a unit moves during battle.")]
  [SerializeField] private Tier _speed;

  /// <summary>
  /// SPE: How often a unit moves during battle.
  /// </summary>
  public Tier Speed => _speed;


  [Space(10)]
  [Tooltip("LCK: A unit's affinity for chance.")]
  [SerializeField] private Tier _luck;
  
  /// <summary>
  /// LCK: A unit's affinity for chance.
  /// </summary>
  public Tier Luck => _luck;


  [Space(10)]
  [Tooltip("PRC: A unit's accuracy for targeting attacks & abilities.")]
  [SerializeField] private Tier _precision;

  /// <summary>
  /// PRC: A unit's accuracy for targeting attacks & abilities.
  /// </summary>
  public Tier Precision => _precision;


  [Space(10)]
  [Tooltip("EVA: A unit's evasiveness to incoming attacks & abilities.")]
  [SerializeField] private Tier _evasion;

  /// <summary>
  /// EVA: A unit's evasiveness to incoming attacks & abilities.
  /// </summary>
  public Tier Evasion => _evasion;
}