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

  public event Action<UnitDataSO> OnLevelUpdated;

  public UnitDataSO UnitData { get; private set; }
  private bool _showingAptitudes = false;
  public Dictionary<Stat, int> StatData = new Dictionary<Stat, int>();
  public Dictionary<Element, Affinity> AffinityData = new Dictionary<Element, Affinity>();

  private void Awake()
  {
    _statTexts = _statTexts.OrderBy(x => x.gameObject.name).ToList();
    _affinityTexts = _affinityTexts.OrderBy(x => x.gameObject.name).ToList();
  }

  public void DisplayUnitDetails(UnitSim unitButton) => DisplayUnitDetails(unitButton.Data);

  public void DisplayUnitDetails(UnitDataSO unitData)
  {
    if(unitData)
    {
      UnitData = unitData;
      _levelSlider.value = unitData.Level;
      UpdateData();
    }
  }

  public void UpdateData()
  { 
    UnitDataSO data = UnitData;
    
    _nameText.text = data.Name;

    data.Level = (int)_levelSlider.value;
    _levelText.text = $"Lv.{data.Level}";

    // The TMP's MUST be in the same order that the stats are ordered!
    for (int i = 0; i < _statTexts.Count; i++)
    {
      Stat stat = (Stat)i;
      int val = Formulae.CalculateStat(stat, data.Aptitudes[stat], data.Level);
      _statTexts[i].text = _showingAptitudes ? data.Aptitudes[stat].ToString() : val.ToString();
      if (StatData.ContainsKey(stat))
        StatData[stat] = val;
      else
        StatData.Add(stat, val);
    }
    
    AffinityData = data.Affinities;
    for (int i = 0; i < _affinityTexts.Count; i++)
    {
      Element element = (Element)i;
      _affinityTexts[i].text = data.Affinities[element].ToString();
    }

    OnLevelUpdated?.Invoke(UnitData);
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

    OnLevelUpdated = null;
  }

  public void ToggleAptitudes()
  {
    if (UnitData)
    {
      // The TMP's MUST be in the same order that the stats are ordered!
      if(_showingAptitudes == false)
      {
        for (int i = 0; i < _statTexts.Count; i++)
        {
          Stat stat = (Stat)i;
          string aptitude = UnitData.Aptitudes[stat].ToString();
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
