using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Consystently.UI;

public class TileSelectionMapUI : VisualElement
{
  public UnitPiece SelectedPiece { get; private set; }
  private List<TileSelectButtonUI> _mapTiles;

  private void Start()
  {
    _mapTiles ??= GetComponentsInChildren<TileSelectButtonUI>().ToList();
  }

  public void SetAvailableTiles(UnitPiece tilePiece, List<TileSelectButtonUI> availableTiles)
  {
    SelectedPiece = tilePiece;
    foreach (TileSelectButtonUI selectButton in _mapTiles.Except(availableTiles))
      selectButton.ButtonComp.interactable = false;

    Panel.Menu.OpenPanel(Panel);
  }

  public void ClearSelection()
  {
    SelectedPiece = null;
    _mapTiles.ForEach((x) => x.ButtonComp.interactable = true);
  }
}