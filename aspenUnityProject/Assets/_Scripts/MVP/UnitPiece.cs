using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UnitPiece : MonoBehaviour
{
  public UnitSim Sim { get; private set; }
  public UnitPieceSlot Slot { get; private set; }
  public Image Icon { get; private set; }
  public Sprite Sprite => Icon.sprite;
  public Color Color => Icon.color;
  public Faction Faction => Sim.Data.Faction;

  public void Awake()
  {
    Icon ??= GetComponent<Image>();
  }

  public void SetSim(UnitSim sim) => Sim ??= sim;

  public void Move(UnitPieceSlot newSlot)
  {
    if(!newSlot.Piece)
    {
      transform.parent = newSlot.transform;
      Slot = newSlot;
    }
  }

  public void Move(BattlefieldTile newTile)
  {
    
  }






















  [HideInInspector]
  public bool PiecePlaced = false;

  [HideInInspector]
  public BattlefieldTile tile;

  public TileDetailsMapUI TileDetailsMap { get; private set; }
  public TileSelectionMapUI TileSelectionMap { get; private set; }
  
  void Start()
  {
    TileDetailsMap = FindFirstObjectByType<TileDetailsMapUI>();
    TileSelectionMap = FindFirstObjectByType<TileSelectionMapUI>();


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
    if(tile)
      tile.RemovePiece(this);
  }
}
