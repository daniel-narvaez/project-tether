using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileDetailsUI : MonoBehaviour
{
  [SerializeField] private List<UnitSim> _unitButtons;
  // private Stack<UnitButtonUI> buttonStack = new Stack<UnitButtonUI>();

  // private void Awake()
  // {
  //   // Alphabetize and reverse the order of the enemy buttons, then put them into a stack
  //   foreach(UnitButtonUI unitButton in _unitButtons.OrderBy(x => x.gameObject.name))
  //     buttonStack.Push(unitButton);
  // }

  public void DisplayTileDetails(TileDetailsButtonUI tileDetails)
  {
    List<UnitPiece> units = tileDetails.UnitSlots.Keys.ToList();
    for (int i = 0; i < _unitButtons.Count; i++)
    {
      if (i < units.Count)
        _unitButtons[i].UpdateDetails(units[i].UnitButton.UnitData, units[i].PieceImage);
      else
        _unitButtons[i].UpdateDetails(null,  null);
    }
  }
}
