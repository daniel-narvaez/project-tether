using System.Collections.Generic;
using System.Linq;
using Consystently.UI;
using UnityEngine;

public class TileDetailsMapUI : VisualElement
{
  private List<TileDetailsButtonUI> _mapTiles;

  void Start()
  {
    _mapTiles ??= GetComponentsInChildren<TileDetailsButtonUI>().ToList();
  }

  public bool TryGetAvailableTileSlots(UnitPiece tilePiece, out List<TileSelectButtonUI> availableTiles)
  {
    availableTiles = new List<TileSelectButtonUI>();

    foreach (TileDetailsButtonUI tile in _mapTiles)
      if (tile.CheckForSlot(tilePiece))
        availableTiles.Add(tile.SelectButton);

    return availableTiles.Count > 0;
  }
}
