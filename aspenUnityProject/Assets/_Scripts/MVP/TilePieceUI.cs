using UnityEngine;

public class TilePieceUI : MonoBehaviour
{
  [SerializeField] private Party _party;
  public Party UnitParty => _party;
  
  public bool PiecePlaced { get; private set; } = false;

  public void PlacePiece(MinimapUI minimap)
  {
    if(PiecePlaced)
     return;

    if(minimap.TryGetAvailableTileSlots(this))
    {
      // Open Tile Selection
      Debug.Log("Open Tile Selection Panel");
    }
    else
    {
      Debug.LogWarning("No available tiles found.");
    }
  }

  public void SelectTile()
  {
    
  }

  public void ReturnPiece()
  {
    
  }
}
