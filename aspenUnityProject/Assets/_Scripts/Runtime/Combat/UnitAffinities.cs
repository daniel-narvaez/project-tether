using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Affinities
{
  [Tooltip("The unit's affinity to Blunt damage.")]
  [SerializeField] private Affinity _bluntAffinity;
  /// <summary>
  /// The unit's affinity to Blunt damage.
  /// </summary>
  public Affinity BluntAffinity => _bluntAffinity;


  [Space(10)]
  [Tooltip("The unit's affinity to Slash damage.")]
  [SerializeField] private Affinity _slashAffinity;
  /// <summary>
  /// The unit's affinity to Slash damage.
  /// </summary>
  public Affinity SlashAffinity => _slashAffinity;


  [Space(10)]
  [Tooltip("The unit's affinity to Pierce damage.")]
  [SerializeField] private Affinity _pierceAffinity;
  /// <summary>
  /// The unit's affinity to Pierce damage.
  /// </summary>
  public Affinity PierceAffinity => _pierceAffinity;


  [Space(10)]
  [Tooltip("The unit's affinity to Blast damage.")]
  [SerializeField] private Affinity _blastAffinity;
  /// <summary>
  /// The unit's affinity to Blast damage.
  /// </summary>
  public Affinity BlastAffinity => _blastAffinity;


  [Space(10)]
  [Tooltip("The unit's affinity to Water damage.")]
  [SerializeField] private Affinity _waterAffinity;
  /// <summary>
  /// The unit's affinity to Water damage.
  /// </summary>
  public Affinity WaterAffinity => _waterAffinity;


  [Space(10)]
  [Tooltip("The unit's affinity to Earth damage.")]
  [SerializeField] private Affinity _earthAffinity;
  /// <summary>
  /// The unit's affinity to Earth damage.
  /// </summary>
  public Affinity EarthAffinity => _earthAffinity;


  [Space(10)]
  [Tooltip("The unit's affinity to Wind damage.")]
  [SerializeField] private Affinity _windAffinity;
  /// <summary>
  /// The unit's affinity to Wind damage.
  /// </summary>
  public Affinity WindAffinity => _windAffinity;


  [Space(10)]
  [Tooltip("The unit's affinity to Fire damage.")]
  [SerializeField] private Affinity _fireAffinity;
  /// <summary>
  /// The unit's affinity to Fire damage.
  /// </summary>
  public Affinity FireAffinity => _fireAffinity;

  /// <summary>
  /// 0 = Blunt, 1 = Slash, 2 = Pierce, 3 = Blast, 4 = Water, 5 = Earth, 6 = Wind, 7 = Fire
  /// </summary>
  /// <returns>A list of all the elements for an attack, an ability, a unit's vulnerabilities, or a unit's tolerances</returns>
  public Dictionary<Element, Affinity> All => new Dictionary<Element, Affinity>() { 
    {Element.Blunt, _bluntAffinity}, 
    {Element.Slash, _slashAffinity}, 
    {Element.Pierce, _pierceAffinity}, 
    {Element.Blast, _blastAffinity}, 
    {Element.Water, _waterAffinity}, 
    {Element.Earth, _earthAffinity}, 
    {Element.Wind, _windAffinity}, 
    {Element.Fire, _fireAffinity}
  };
}
