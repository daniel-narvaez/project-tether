using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class UnitSim : MonoBehaviour
{
  public UnitDataSO Data;
  public UnitPieceSlot Slot { get; private set; }
  public UnitPiece Piece { get; private set; }

  [Space(5)]
  [SerializeField] private Image _portrait;
  [SerializeField] private TextMeshProUGUI _name;
  [SerializeField] private TextMeshProUGUI _class;
  [SerializeField] private TextMeshProUGUI _level;
  [Space(5)]
  [SerializeField] private UnitDetailsUI _unitDetailsPanel;
  public Button ButtonComp { get; private set; }
  private UnityAction _displayDetails;

  private void Awake()
  {
    ButtonComp ??= GetComponent<Button>();

    Slot ??= GetComponentInChildren<UnitPieceSlot>();
    Slot.SetSim(this);

    Piece ??= GetComponentInChildren<UnitPiece>();
    Piece.SetSim(this);

    UpdateDetails(Data);
  }

  public void UpdateDetails (UnitDataSO unitData)
  {
    if (Data = unitData)
    {
      if(Data.Portrait)
        _portrait.sprite = Data.Portrait;

      _name.text = Data.Name;

      if(_level)
        _level.text = $"Lv.{Data.Level}";
    }

    ButtonComp.interactable = Data;
    if (ButtonComp.interactable && Data)
    {
      _displayDetails = () => {
        _unitDetailsPanel.DisplayUnitDetails(Data);
        _unitDetailsPanel.OnLevelUpdated += UpdateDetails;
      };

      ButtonComp.onClick.AddListener(_displayDetails);
    }
    else if (_displayDetails != null)
    {
      ButtonComp.onClick.RemoveListener(_displayDetails);
      _displayDetails = null;
    }
  }

  public void ClearDetails()
  {
    Data = null;
    ButtonComp.interactable = Data;

    if(_portrait)
      _portrait.sprite = null;

    _name.text = "Name";
    
    if(_level)
      _level.text = "Lv.";

    Piece.ReturnPiece();
  }
}
