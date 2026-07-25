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

  private UnitDataSO _unitData;
  private bool _showingAptitudes = false;
  private Dictionary<Stat, int> statData = new Dictionary<Stat, int>();

  public void DisplayUnitDetails(Entity entity)
  {
    _unitData = entity.UnitData ? entity.UnitData : null;
    if(_unitData)
    {
      _nameText.text = _unitData.Name;
      _levelText.text = $"Lv.{_unitData.Level}";
      _levelSlider.value = _unitData.Level; 

      // The TMP's MUST be in the same order that the stats are ordered!
      for (int i = 0; i < _statTexts.Count; i++)
      {
        Stat stat = (Stat)i;
        int val = Formulae.CalculateStat(stat, _unitData.AllStats[stat], _unitData.Level);
        _statTexts[i].text = val.ToString();
        statData.Add(stat, val);
      }
    }
  }

  public void UpdateLevel()
  {
    _unitData.Level = (int)_levelSlider.value;
    _levelText.text = $"Lv.{_unitData.Level}";
    for (int i = 0; i < _statTexts.Count; i++)
    {
      Stat stat = (Stat)i;
      int val = Formulae.CalculateStat(stat, _unitData.AllStats[stat], _unitData.Level);
      _statTexts[i].text = val.ToString();
      statData[stat] = val;
    }
  }

  public void ClearDetails()
  {
    _nameText.text = "Name";
    _levelText.text = "Lv.1";
    _levelSlider.value = 1;

    statData.Clear();

    foreach( TextMeshProUGUI tmp in _statTexts)
      tmp.text = 0.ToString();

    _aptitudesText.text = "Show Aptitudes";
    _showingAptitudes = false;
  }

  public void ToggleAptitudes()
  {
    if (_unitData)
    {
      // The TMP's MUST be in the same order that the stats are ordered!
      if(_showingAptitudes == false)
      {
        for (int i = 0; i < _statTexts.Count; i++)
        {
          Stat stat = (Stat)i;
          string aptitude = _unitData.AllStats[stat].ToString();
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
