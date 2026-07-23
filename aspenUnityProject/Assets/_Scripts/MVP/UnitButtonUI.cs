using TMPro;
using UnityEngine;

public class UnitButtonUI : MonoBehaviour
{
  [SerializeField] private Entity _entity;
  [SerializeField] private TextMeshProUGUI _nameText;
  [SerializeField] private TextMeshProUGUI _levelText;

  private void Start()
  {
    UnitDataSO data = _entity.UnitData ? _entity.UnitData : null;

    if(data)
    {
      _nameText.text = data.Name;

      if (_levelText)
        _levelText.text = $"Lv.{data.Level}";
    }
  }
}
