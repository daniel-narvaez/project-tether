using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UnitButtonUI : MonoBehaviour
{
  [SerializeField] private Entity _unitEntity;
  [Space(5)]
  [SerializeField] private TextMeshProUGUI _nameText;
  [SerializeField] private TextMeshProUGUI _levelText;
  [Space(5)]
  [SerializeField] private Image _tilePiece;
  public Button ButtonComp { get; private set; }
  public UnitDetailsUI UnitDetailsPanel { get; private set; }
  private UnityAction _displayDetails;

  private void Awake()
  {
    UnitDetailsPanel ??= FindFirstObjectByType<UnitDetailsUI>();
    ButtonComp ??= GetComponent<Button>();
    UpdateDetails(_unitEntity, _tilePiece);
  }

  private void OnEnable() => UnitDetailsPanel.OnLevelUpdated += UpdateDetails;
  private void OnDisable() => UnitDetailsPanel.OnLevelUpdated -= UpdateDetails;

  public void UpdateDetails(Entity entity)
  {
    if (entity == _unitEntity && _tilePiece)
      UpdateDetails(_unitEntity, _tilePiece);
  }
  public void UpdateDetails (Entity entity, Image tilePiece)
  {
    _unitEntity = entity ? entity : null;
    UnitDataSO data = _unitEntity?.UnitData ? _unitEntity.UnitData : null;

    _nameText.text = data ? data.Name : string.Empty;
    _levelText.text = data ? $"Lv.{data.Level}" : string.Empty;
    ButtonComp.interactable = data;
    if (ButtonComp.interactable && entity && data)
    {
      _displayDetails = () => UnitDetailsPanel.DisplayUnitDetails(entity);
      ButtonComp.onClick.AddListener(_displayDetails);
    }
    else if (_displayDetails != null)
    {
      ButtonComp.onClick.RemoveListener(_displayDetails);
      _displayDetails = null;
    }

    _tilePiece.sprite = tilePiece ? tilePiece.sprite : null;
    _tilePiece.color = tilePiece ? tilePiece.color : Color.clear;
  }
}
