using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class UnitButtonUI : MonoBehaviour
{
  public UnitDataSO UnitData;
  public TilePieceUI TilePiece { get; private set; }
  [Space(5)]
  [SerializeField] private Image _portraitImage;
  [SerializeField] private TextMeshProUGUI _nameText;
  [SerializeField] private TextMeshProUGUI _levelText;
  [Space(5)]
  [SerializeField] private Image _tilePieceImage;
  [SerializeField] private UnitDetailsUI _unitDetailsPanel;
  public Button ButtonComp { get; private set; }
  private UnityAction _displayDetails;

  private void Awake()
  {
    ButtonComp ??= GetComponent<Button>();
    TilePiece ??= GetComponentInChildren<TilePieceUI>();
    UpdateDetails(UnitData, _tilePieceImage);
  }

  public void UpdateDetails (UnitDataSO unitData)
  {
    UpdateDetails(UnitData, _tilePieceImage);
  }

  public void UpdateDetails (UnitDataSO unitData, Image tilePiece)
  {
    if (UnitData = unitData)
    {
      if(UnitData.Portrait)
        _portraitImage.sprite = UnitData.Portrait;

      _nameText.text = UnitData.Name;

      if(_levelText)
        _levelText.text = $"Lv.{UnitData.Level}";
    }

    ButtonComp.interactable = UnitData;
    if (ButtonComp.interactable && UnitData)
    {
      _displayDetails = () => {
        _unitDetailsPanel.DisplayUnitDetails(UnitData);
        _unitDetailsPanel.OnLevelUpdated += UpdateDetails;
      };

      ButtonComp.onClick.AddListener(_displayDetails);
    }
    else if (_displayDetails != null)
    {
      ButtonComp.onClick.RemoveListener(_displayDetails);
      _displayDetails = null;
    }

    if(tilePiece)
    {
      _tilePieceImage.sprite = tilePiece.sprite;
      _tilePieceImage.color = tilePiece.color;
    }
  }

  public void ClearDetails()
  {
    UnitData = null;
    ButtonComp.interactable = UnitData;

    if(_portraitImage)
      _portraitImage.sprite = null;

    _nameText.text = "Name";
    
    if(_levelText)
      _levelText.text = "Lv.";

    TilePiece.ReturnPiece();
  }
}
