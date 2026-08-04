using System.Collections.Generic;
using System.Linq;
using Consystently.UI;
using UnityEngine;

public class BattlefieldMap : VisualElement
{
  public static BattlefieldMap Instance { get; private set; }
  public List<BattlefieldTile> Tiles { get; private set; }

  [Header("Selection")]
  [SerializeField] ButtonVE _cancelButton;

  private void Awake()
  {
    Instance ??= this;
    Tiles ??= GetComponentsInChildren<BattlefieldTile>().ToList();
  }

  public void GetAvailableTileSlots(UnitPiece piece)
  {
    List<BattlefieldTile> availableTiles = new List<BattlefieldTile>();

    foreach (BattlefieldTile tile in Tiles)
      if (tile.CheckForSlot(piece))
        availableTiles.Add(tile);

    if(availableTiles.Count > 0)
      SetAvailableTiles(availableTiles);
    else
      Debug.LogWarning("No available tiles found.");
  }

  public void SetAvailableTiles(List<BattlefieldTile> tiles)
  {
    Debug.Log("Do the thing!");
  }
}
