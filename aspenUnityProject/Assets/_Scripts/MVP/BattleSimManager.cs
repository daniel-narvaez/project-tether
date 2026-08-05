using System.Collections.Generic;
using Consystently.Essentials;
using UnityEngine;

public class BattleSimManager : Manager<BattleSimManager>
{
  public Dictionary<UnitSim, bool> PlayerSims { get; private set; } = new Dictionary<UnitSim, bool>();
  public Dictionary<UnitSim, bool> EnemySims { get; private set; } = new Dictionary<UnitSim, bool>();
  public List<BattlefieldTile> Tiles { get; private set; }

  public void UpdateSimStatus(UnitSim sim)
  {
    switch(sim.Data?.Faction)
    {
      case Faction.Ally:
        if (PlayerSims.ContainsKey(sim))
         PlayerSims[sim] = sim.Button.interactable;
        else
          PlayerSims.Add(sim, sim.Button.interactable);
      break;
      case Faction.Enemy:
      default:
        if (EnemySims.ContainsKey(sim))
         EnemySims[sim] = sim.Button.interactable;
        else
          EnemySims.Add(sim, sim.Button.interactable);
      break;
    }
  }

  public bool AtleastTwoFactionsPlaced()
  {
    return true;
  }

  public bool AllSimPiecesPlaced()
  {
    return true;
  }

  public void StartBattleSim()
  {
    
  }
}
