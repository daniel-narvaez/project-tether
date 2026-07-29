using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit Base Data", menuName = "Scriptable Objects/Unit/Base Data")]
public class UnitDataSO : ScriptableObject
{
  [Header("ID")]
  [Space(10)]
  [SerializeField] private string _unitName;
  
  public string Name => _unitName;

  [Header("Progress")]
  [Space(10)]
  [Range(1, 99)]
  [SerializeField] public int Level;

  [HideInInspector] public int ExpToNextLevel;

  [HideInInspector] public int TotalExpGained;

  [Space(5)]
  [Tooltip("The last recorded value of this unit's remaining HP, as a percentage.")]
  [Range(0.00f, 100.00f)]
  [SerializeField] public float RemainingHealth = 100.00f;

  [Space(5)]
  [Tooltip("The last recorded value of this unit's remaining EN, as a percentage.")]
  [Range(0.00f, 100.00f)]
  [SerializeField] public float RemainingEnergy = 100.00f;
  
  [Header("Base Aptitudes")]
  [Space(10)]
  [Tooltip("HP: Total amount of damage a unit can sustain before falling in battle.")]
  [SerializeField] private Tier _health;

  /// <summary>
  /// HP: Total amount of damage a unit can sustain before falling in battle.
  /// </summary>
  public Tier Health => _health;


  [Space(5)]
  [Tooltip("EN: Total amount of resources a unit can spend to use special abilities.")]
  [SerializeField] private Tier _energy;

  /// <summary>
  /// EN: Total amount of resources a unit can spend to use special abilities.
  /// </summary>
  public Tier Energy => _energy;


  [Space(5)]
  [Tooltip("STR: A unit's physical power.")]
  [SerializeField] private Tier _strength;

  /// <summary>
  /// STR: A unit's physical power.
  /// </summary>
  public Tier Strength => _strength;


  [Space(5)]
  [Tooltip("DEF: A unit's durability against physical power.")]
  [SerializeField] private Tier _defense;

  /// <summary>
  /// DEF: A unit's durability against physical power.
  /// </summary>
  public Tier Defense => _defense;


  [Space(5)]
  [Tooltip("TEC: A unit's technical power.")]
  [SerializeField] private Tier _tech;

  /// <summary>
  /// TEC: A unit's technical power.
  /// </summary>
  public Tier Tech => _tech;


  [Space(5)]
  [Tooltip("RES: A unit's durability against technical power.")]
  [SerializeField] private Tier _resistance;

  /// <summary>
  /// RES: A unit's durability against technical power.
  /// </summary>
  public Tier Resistance => _resistance;


  [Space(5)]
  [Tooltip("SPE: How often a unit moves during battle.")]
  [SerializeField] private Tier _speed;

  /// <summary>
  /// SPE: How often a unit moves during battle.
  /// </summary>
  public Tier Speed => _speed;


  [Space(5)]
  [Tooltip("LCK: A unit's affinity for chance.")]
  [SerializeField] private Tier _luck;
  
  /// <summary>
  /// LCK: A unit's affinity for chance.
  /// </summary>
  public Tier Luck => _luck;


  [Space(5)]
  [Tooltip("PRC: A unit's accuracy for targeting attacks & abilities.")]
  [SerializeField] private Tier _precision;

  /// <summary>
  /// PRC: A unit's accuracy for targeting attacks & abilities.
  /// </summary>
  public Tier Precision => _precision;


  [Space(5)]
  [Tooltip("EVA: A unit's evasiveness to incoming attacks & abilities.")]
  [SerializeField] private Tier _evasion;

  /// <summary>
  /// EVA: A unit's evasiveness to incoming attacks & abilities.
  /// </summary>
  public Tier Evasion => _evasion;

  public Dictionary<Stat, Tier> Aptitudes => new Dictionary<Stat, Tier>()
  {
    { Stat.HP, _health },
    { Stat.EN, _energy },
    { Stat.STR, _strength },
    { Stat.DEF, _defense },
    { Stat.TEC, _tech },
    { Stat.RES, _resistance },
    { Stat.SPE, _speed },
    { Stat.LCK, _luck },
    { Stat.PRC, _precision },
    { Stat.EVA, _evasion },
  };

  [Header("Affinities")]
  [Space(10)]
  [Tooltip("This unit's affinity to Blunt damage.")]
  [SerializeField] private Affinity _blunt;
  /// <summary>
  /// This unit's affinity to Blunt damage.
  /// </summary>
  public Affinity Blunt => _blunt;


  [Space(5)]
  [Tooltip("This unit's affinity to Slash damage.")]
  [SerializeField] private Affinity _slash;
  /// <summary>
  /// This unit's affinity to Slash damage.
  /// </summary>
  public Affinity Slash => _slash;


  [Space(5)]
  [Tooltip("This unit's affinity to Pierce damage.")]
  [SerializeField] private Affinity _pierce;
  /// <summary>
  /// This unit's affinity to Pierce damage.
  /// </summary>
  public Affinity Pierce => _pierce;


  [Space(5)]
  [Tooltip("This unit's affinity to Blast damage.")]
  [SerializeField] private Affinity _blast;
  /// <summary>
  /// This unit's affinity to Blast damage.
  /// </summary>
  public Affinity Blast => _blast;


  [Space(5)]
  [Tooltip("This unit's affinity to Water damage.")]
  [SerializeField] private Affinity _water;
  /// <summary>
  /// This unit's affinity to Water damage.
  /// </summary>
  public Affinity Water => _water;


  [Space(5)]
  [Tooltip("This unit's affinity to Earth damage.")]
  [SerializeField] private Affinity _earth;
  /// <summary>
  /// This unit's affinity to Earth damage.
  /// </summary>
  public Affinity Earth => _earth;


  [Space(5)]
  [Tooltip("This unit's affinity to Wind damage.")]
  [SerializeField] private Affinity _wind;
  /// <summary>
  /// This unit's affinity to Wind damage.
  /// </summary>
  public Affinity Wind => _wind;


  [Space(5)]
  [Tooltip("This unit's affinity to Fire damage.")]
  [SerializeField] private Affinity _fire;
  /// <summary>
  /// This unit's affinity to Fire damage.
  /// </summary>
  public Affinity Fire => _fire;

  public Dictionary<Element, Affinity> Affinities => new Dictionary<Element, Affinity>()
  {
    { Element.Blunt, _blunt },
    { Element.Slash, _slash },
    { Element.Pierce, _pierce },
    { Element.Blast, _blast },
    { Element.Water, _water },
    { Element.Earth, _earth },
    { Element.Wind, _wind },
    { Element.Fire, _fire },
  };
}