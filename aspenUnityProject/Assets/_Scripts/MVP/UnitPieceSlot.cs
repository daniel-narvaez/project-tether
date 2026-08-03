using UnityEngine;

public class UnitPieceSlot : MonoBehaviour
{
  public UnitPiece Piece;
  public UnitSim Sim { get; private set; }

  public void SetSim(UnitSim sim) => Sim ??= sim;

  public void TryMovePiece()
  {
    //If this slot belongs to a sim, return the sim's piece to the slot.
    if(Sim.Piece && !Piece)
      ReturnPiece();
    else
      BattlefieldMap.Instance.GetAvailableTileSlots(Piece);
  }

  public void ReturnPiece() => Sim.Piece.Move(this);
}
