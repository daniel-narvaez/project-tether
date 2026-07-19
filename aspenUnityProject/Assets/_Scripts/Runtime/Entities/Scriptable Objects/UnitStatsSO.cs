using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit Stats", menuName = "Scriptable Objects/Unit/Stats")]
public class UnitStatsSO : ScriptableObject
{

  [Tooltip("HP: Total amount of damage a unit can sustain before falling in battle.")]
  [Range(1, 9999)]
  [SerializeField] private int _health;

  /// <summary>
  /// HP: Total amount of damage a unit can sustain before falling in battle.
  /// </summary>
  public int Health => _health;


  [Space(10)]
  [Tooltip("EN: Total amount of resources a unit can spend to use special abilities.")]
  [Range(1, 999)]
  [SerializeField] private int _energy;

  /// <summary>
  /// EN: Total amount of resources a unit can spend to use special abilities.
  /// </summary>
  public int Energy => _energy;


  [Space(10)]
  [Tooltip("STR: A unit's physical power.")]
  [Range(1, 999)]
  [SerializeField] private int _strength;

  /// <summary>
  /// STR: A unit's physical power.
  /// </summary>
  public int Strength => _strength;


  [Space(10)]
  [Tooltip("DEF: A unit's durability against physical power.")]
  [Range(1, 999)]
  [SerializeField] private int _defense;

  /// <summary>
  /// DEF: A unit's durability against physical power.
  /// </summary>
  public int Defense => _defense;


  [Space(10)]
  [Tooltip("TEC: A unit's technical power.")]
  [Range(1, 999)]
  [SerializeField] private int _tech;

  /// <summary>
  /// TEC: A unit's technical power.
  /// </summary>
  public int Tech => _tech;


  [Space(10)]
  [Tooltip("RES: A unit's durability against technical power.")]
  [Range(1, 999)]
  [SerializeField] private int _resistance;

  /// <summary>
  /// RES: A unit's durability against technical power.
  /// </summary>
  public int Resistance => _resistance;


  [Space(10)]
  [Tooltip("SPE: How often a unit moves during battle.")]
  [Range(1, 999)]
  [SerializeField] private int _speed;

  /// <summary>
  /// SPE: How often a unit moves during battle.
  /// </summary>
  public int Speed => _speed;


  [Space(10)]
  [Tooltip("PRC: A unit's accuracy for targeting attacks & abilities.")]
  [Range(1, 999)]
  [SerializeField] private int precision;

  /// <summary>
  /// PRC: A unit's accuracy for targeting attacks & abilities.
  /// </summary>
  public int Precision => precision;


  [Space(5)]
  [Tooltip("EVA: A unit's evasiveness to incoming attacks & abilities.")]
  [Range(1, 999)]
  [SerializeField] private int _evasion;

  /// <summary>
  /// EVA: A unit's evasiveness to incoming attacks & abilities.
  /// </summary>
  public int Evasion => _evasion;


  [Space(10)]
  [Tooltip("LCK: A unit's affinity for chance.")]
  [Range(1, 999)]
  [SerializeField] private int _luck;
  
  /// <summary>
  /// LCK: A unit's affinity for chance.
  /// </summary>
  public int Luck => _luck;

  public Dictionary<Stat, int> All => new Dictionary<Stat, int>() {
    {Stat.HP, _health},
    {Stat.EN, _energy},
    {Stat.STR, _strength},
    {Stat.DEF, _defense},
    {Stat.TEC, _tech},
    {Stat.RES, _resistance},
    {Stat.PRC, precision},
    {Stat.EVA, _evasion},
    {Stat.SPE, _speed},
    {Stat.LCK, _luck}
  };

  public int Get(Stat stat) => All[stat];

  public int Change(Stat stat, int change) => All[stat] += change;

  public int Set(Stat stat, int newValue) => All[stat] = newValue;

  public Dictionary<Stat, int> ChangeAll(Dictionary<Stat, int> changes)
  {
    foreach (Stat s in changes.Keys)
      Change(s, changes[s]);

    return All;
  }

  public Dictionary<Stat, int> SetAll(Dictionary<Stat, int> newValues)
  {
    foreach (Stat s in newValues.Keys)
      Set(s, newValues[s]);

    return All;
  }
}
