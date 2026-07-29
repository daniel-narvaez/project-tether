using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TilePieceUI : MonoBehaviour
{
  [SerializeField] private Entity _pieceEntity;
  public Entity PieceEntity => _pieceEntity;

  [SerializeField] private Faction _faction;
  public Faction UnitFaction => _faction;
  
  public Image PieceImage { get; private set; }
  public bool PiecePlaced = false;

  [HideInInspector]
  public TileDetailsButtonUI Placement;

  public TileDetailsMapUI TileDetailsMap { get; private set; }
  public TileSelectionMapUI TileSelectionMap { get; private set; }

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
    else if(Placement)
    {
      Placement.RemovePiece(this);
    }
  }
}
