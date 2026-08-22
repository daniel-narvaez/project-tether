using System.Collections.Generic;
using Consystently.Essentials;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/*
 * 
 * Make it to where, when a unit is removed from the board, it is also removed from the dict (do this shit at a later point)
 * 
 */

public class BattleSimManager : Manager<BattleSimManager>
{
    public Dictionary<UnitSim, BattlefieldTile> PlayerSims { get; private set; } = new Dictionary<UnitSim, BattlefieldTile>();
    public Dictionary<UnitSim, BattlefieldTile> EnemySims { get; private set; } = new Dictionary<UnitSim, BattlefieldTile>();

    public HashSet<UnitPiece> PlayerPieces = new HashSet<UnitPiece>();
    public HashSet<UnitPiece> EnemyPieces = new HashSet<UnitPiece>();

    [SerializeField] Button _battleButton;

    private void Start()
    {
      _battleButton.interactable = false;
    }

    public void ActivateSim(UnitSim sim)
    {
      PlayerSims.TryAdd(sim, null);

      _battleButton.interactable = AtLeastTwoFactionsPlaced();
    }

    public void DeactivateSim(UnitSim sim)
    {
        switch (sim.Data.Faction)
        {
            case Faction.Ally:
                PlayerSims.Remove(sim);
                break;
            case Faction.Enemy:
                EnemySims.Remove(sim);
                break;
        }

        _battleButton.interactable = AtLeastTwoFactionsPlaced();
    }

    //public void UpdateSimStatus2(UnitPieceSlot sim)
    //{
    //    UnitSim currPiece = sim.Piece.Sim;

    //    switch (currPiece.Data?.Faction)
    //    {
    //        case Faction.Ally:
    //            if (PlayerSims.ContainsKey(currPiece))
    //                PlayerSims[currPiece] = currPiece.Button.interactable;
    //            else
    //                PlayerSims.Add(currPiece, currPiece.Button.interactable);

    //            break;
    //        case Faction.Enemy:
    //        default:
    //            if (EnemySims.ContainsKey(currPiece))
    //                EnemySims[currPiece] = currPiece.Button.interactable;
    //            else
    //                EnemySims.Add(currPiece, currPiece.Button.interactable);

    //            break;
    //    }
    //}

    public bool AtLeastTwoFactionsPlaced() => (PlayerSims.Count + EnemySims.Count) >= 2;

    public bool AllSimPiecesPlaced()
    {
        return true;
    }

    public void StartBattleSim()
    {
        //Debug.Log($"Number of factions on field: {ListOfEnitiesOnField.Count}");

        Debug.Log($"Player Sims on Field: {PlayerSims.Count}");
        Debug.Log($"Enemy Sims on Field: {EnemySims.Count}");

        if (AtLeastTwoFactionsPlaced())
        {
            Debug.Log("Enough Factions are placed. Start Battle");
        }
        else
        {
            Debug.LogWarning("Two Factions must be placed on the filed");
        }
    }
}
