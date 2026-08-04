using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Consystently.UI;

public class TileDetails : Panel
{
  public static TileDetails Instance { get; private set; }
  public List<UnitSim> Sims { get; private set; }

  protected override void Awake()
  {
    base.Awake();
    Instance ??= this;
    Sims ??= GetComponentsInChildren<UnitSim>().ToList();
    Debug.Log(Sims.Count);
  }

  public void DisplayTileDetails(BattlefieldTile tile)
  {
    Menu.OpenPanel(this);

    List<UnitPieceSlot> slots = tile.FilledSlots;
    Debug.Log(slots.Count);
    for (int i = 0; i < Sims.Count; i++)
    {
      if (i < slots.Count)
        Sims[i].UpdateDetails(slots[i].Piece.Sim.Data);
      else
        Sims[i].UpdateDetails(null);
    }
  }
}
