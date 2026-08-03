using System.Collections.Generic;
using System.Linq;
using Consystently.UI;

public class BattlefieldMap : VisualElement
{
  public List<BattlefieldTile> Tiles { get; private set; }

  void Start()
  {
    Tiles ??= GetComponentsInChildren<BattlefieldTile>().ToList();
  }

  public bool TryGetAvailableTileSlots(UnitPiece tilePiece, out List<TileSelectButtonUI> availableTiles)
  {
    availableTiles = new List<TileSelectButtonUI>();

    foreach (BattlefieldTile tile in Tiles)
      if (tile.CheckForSlot(tilePiece))
        availableTiles.Add(tile.SelectButton);

    return availableTiles.Count > 0;
  }
}
