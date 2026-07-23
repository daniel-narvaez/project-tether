using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MinimapUI : MonoBehaviour
{
  private List<MapTileButtonUI> _mapTiles = new List<MapTileButtonUI>();

  void Start()
  {
    _mapTiles ??= GetComponentsInChildren<MapTileButtonUI>().ToList();
  }

  public bool TryGetAvailableTileSlots(TilePieceUI tilePiece)
  {
    List<MapTileButtonUI> availableTiles = new List<MapTileButtonUI>();

    foreach (MapTileButtonUI tile in _mapTiles)
    {
      if (tile.CheckForSlot(tilePiece))
        availableTiles.Add(tile);
    }

    return availableTiles.Count > 0;
  }
}
