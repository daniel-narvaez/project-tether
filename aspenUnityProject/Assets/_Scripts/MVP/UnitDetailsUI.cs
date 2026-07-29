using System;
using System.Collections.Generic;
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
  [SerializeField] private List<TextMeshProUGUI> _equipmentTexts;

  public event Action<Entity> OnLevelUpdated;

  private Entity _entity;
  private bool _showingAptitudes = false;
  private Dictionary<Stat, int> statData = new Dictionary<Stat, int>();

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
      _statTexts[i].text = val.ToString();
      if (statData.ContainsKey(stat))
        statData[stat] = val;
      else
        statData.Add(stat, val);
    }

    OnLevelUpdated?.Invoke(_entity);
  }

  public void ClearDetails()
  {
    _nameText.text = "Name";
    _levelText.text = "Lv.1";

    statData.Clear();

    foreach( TextMeshProUGUI tmp in _statTexts)
      tmp.text = 0.ToString();

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
          _statTexts[i].text = statData[stat].ToString();
        }
        _aptitudesText.text = "Show Aptitudes";
        _showingAptitudes = false;
      }
    }
  }
}
