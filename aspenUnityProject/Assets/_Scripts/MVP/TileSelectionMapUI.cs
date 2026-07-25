using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Consystently.UI;

public class TileSelectionMapUI : InterfaceElement
{
  public TilePieceUI SelectedPiece { get; private set; }
  private List<TileSelectButtonUI> _mapTiles;

  private void Start()
  {
    _mapTiles ??= GetComponentsInChildren<TileSelectButtonUI>().ToList();
  }

  public void SetAvailableTiles(TilePieceUI tilePiece, List<TileSelectButtonUI> availableTiles)
  {
    SelectedPiece = tilePiece;
    foreach (TileSelectButtonUI selectButton in _mapTiles.Except(availableTiles))
      selectButton.ButtonComp.interactable = false;

    RootPanel.RootMenu.OpenPanel(RootPanel);
  }

  public void ClearSelection()
  {
    SelectedPiece = null;
    _mapTiles.ForEach((x) => x.ButtonComp.interactable = true);
  }
}