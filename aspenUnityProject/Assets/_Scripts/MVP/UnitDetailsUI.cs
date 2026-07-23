using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnitDetailsUI : MonoBehaviour
{
  private UnitDataSO _unitData;
  [SerializeField] private TextMeshProUGUI _nameText;
  [SerializeField] private TextMeshProUGUI _levelText;
  [SerializeField] private TextMeshProUGUI _aptitudesText;
  [Space(10)]
  [SerializeField] private List<TextMeshProUGUI> _statTexts;
  [Space (10)]
  [SerializeField] private List<TextMeshProUGUI> _equipmentTexts;

  private bool _showingAptitudes = false;

  public void DisplayUnitDetails(Entity entity)
  {
    _unitData = entity.UnitData ? entity.UnitData : null;

    if(_unitData)
    {
      _nameText.text = _unitData.Name;
      _levelText.text = $"Lv.{_unitData.Level}";

      // The TMP's MUST be in the same order that the stats are ordered!
      for (int i = 0; i < _statTexts.Count; i++)
      {
        Stat stat = (Stat)i;
        int val = Formulae.CalculateStat(stat, _unitData.AllStats[stat], _unitData.Level);
        _statTexts[i].text = val.ToString();
      }
    }
  }

  public void ClearDetails()
  {
    _nameText.text = "Name";
    _levelText.text = "Lv.1";

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
          int val = Formulae.CalculateStat(stat, _unitData.AllStats[stat], _unitData.Level);
          _statTexts[i].text = val.ToString();
        }
        _aptitudesText.text = "Show Aptitudes";
        _showingAptitudes = false;
      }
    }
  }
}
