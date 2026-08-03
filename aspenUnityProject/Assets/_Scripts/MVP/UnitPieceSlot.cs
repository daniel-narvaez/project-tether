using UnityEngine;

public class UnitPieceSlot : MonoBehaviour
{
  public UnitPiece Piece;
  public UnitSim Sim { get; private set; }

  public void SetSim(UnitSim sim) => Sim ??= sim;
}
