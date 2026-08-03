using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TilePieceUI : MonoBehaviour
{
  public UnitButtonUI UnitButton { get; private set; }
  public Faction UnitFaction => UnitButton.UnitData.Faction;
  
  public Image PieceImage { get; private set; }

  [HideInInspector]
  public bool PiecePlaced = false;

  [HideInInspector]
  public TileDetailsButtonUI Placement;

  public TileDetailsMapUI TileDetailsMap { get; private set; }
  public TileSelectionMapUI TileSelectionMap { get; private set; }

  void Awake()
  {
    UnitButton ??= GetComponentInParent<UnitButtonUI>();
  }
  void Start()
  {
    TileDetailsMap = FindFirstObjectByType<TileDetailsMapUI>();
    TileSelectionMap = FindFirstObjectByType<TileSelectionMapUI>();

    PieceImage ??= GetComponent<Image>();
    PieceImage.alphaHitTestMinimumThreshold = 0.5f;
  }

  public void TogglePiece()
  {
    if(!PiecePlaced)
    {
      if(TileDetailsMap.TryGetAvailableTileSlots(this, out List<TileSelectButtonUI> availableTiles))
      {
        TileSelectionMap.SetAvailableTiles(this, availableTiles);
      }
      else
      {
        Debug.LogWarning("No available tiles found.");
      }
    }
    else
      ReturnPiece();
  }

  public void ReturnPiece()
  {
    if(Placement)
      Placement.RemovePiece(this);
  }
}
