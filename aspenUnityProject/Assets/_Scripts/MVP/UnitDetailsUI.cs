using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitDetailsUI : MonoBehaviour
{
  [SerializeField] private TextMeshProUGUI _nameText;
  [Space(10)]
  [SerializeField] private TextMeshProUGUI _levelText;
  [SerializeField] private Slider _levelSlider;
  [Space(10)]
  [SerializeField] private TextMeshProUGUI _aptitudesText;
  [Space(10)]
  [SerializeField] private List<TextMeshProUGUI> _statTexts;
  [Space (10)]
  [SerializeField] private List<TextMeshProUGUI> _affinityTexts;

  public event Action<Entity> OnLevelUpdated;

  private Entity _entity;
  private bool _showingAptitudes = false;
  public Dictionary<Stat, int> StatData = new Dictionary<Stat, int>();
  public Dictionary<Element, Affinity> AffinityData = new Dictionary<Element, Affinity>();

  private void Awake()
  {
    _statTexts = _statTexts.OrderBy(x => x.gameObject.name).ToList();
    _affinityTexts = _affinityTexts.OrderBy(x => x.gameObject.name).ToList();
  }
  public void DisplayUnitDetails(Entity entity)
  {
    if(entity)
    {
      _entity = entity;
      _levelSlider.value = _entity.UnitData.Level;
      UpdateData();
    }
  }

  public void UpdateData()
  {
    UnitDataSO unitData = _entity.UnitData;
    
    _nameText.text = unitData.Name;

    unitData.Level = (int)_levelSlider.value;
    _levelText.text = $"Lv.{unitData.Level}";

    // The TMP's MUST be in the same order that the stats are ordered!
    for (int i = 0; i < _statTexts.Count; i++)
    {
      Stat stat = (Stat)i;
      int val = Formulae.CalculateStat(stat, unitData.Aptitudes[stat], unitData.Level);
      _statTexts[i].text = _showingAptitudes ? unitData.Aptitudes[stat].ToString() : val.ToString();
      if (StatData.ContainsKey(stat))
        StatData[stat] = val;
      else
        StatData.Add(stat, val);
    }
    
    AffinityData = unitData.Affinities;
    for (int i = 0; i < _affinityTexts.Count; i++)
    {
      Element element = (Element)i;
      _affinityTexts[i].text = unitData.Affinities[element].ToString();
    }

    OnLevelUpdated?.Invoke(_entity);
  }

  public void ClearDetails()
  {
    _nameText.text = "Name";
    _levelText.text = "Lv.1";

    StatData.Clear();
    AffinityData.Clear();

    foreach(TextMeshProUGUI tmp in _statTexts)
      tmp.text = 0.ToString();

    foreach(TextMeshProUGUI tmp in _affinityTexts)
      tmp.text = Affinity.Neutral.ToString();

    _aptitudesText.text = "Show Aptitudes";
    _showingAptitudes = false;
  }

  public void ToggleAptitudes()
  {
    if (_entity.UnitData)
    {
      // The TMP's MUST be in the same order that the stats are ordered!
      if(_showingAptitudes == false)
      {
        for (int i = 0; i < _statTexts.Count; i++)
        {
          Stat stat = (Stat)i;
          string aptitude = _entity.UnitData.Aptitudes[stat].ToString();
          _statTexts[i].text = aptitude;
        }
        _aptitudesText.text = "Show Values";
        _showingAptitudes = true;
      }
      else
      {
        for (int i = 0; i < _statTexts.Count; i++)
        {
          Stat stat = (Stat)i;
          _statTexts[i].text = StatData[stat].ToString();
        }
        _aptitudesText.text = "Show Aptitudes";
        _showingAptitudes = false;
      }
    }
  }
}
