using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class TileDetailsUI : MonoBehaviour
{
  [SerializeField] private List<UnitButtonUI> unitButtons;
  public void DisplayTileDetails(TileDetailsButtonUI tileDetails)
  {
    List<TilePieceUI> units = tileDetails.UnitSlots.Keys.ToList();
    for (int i = 0; i < unitButtons.Count; i++)
    {
      if (i < units.Count)
        unitButtons[i].UpdateDetails(units[i].PieceEntity, units[i].PieceImage);
      else
        unitButtons[i].UpdateDetails(null,  null);
    }
  }
}
