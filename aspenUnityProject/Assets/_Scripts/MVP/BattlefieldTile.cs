using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using Consystently.UI;
using Unity.VisualScripting;

[RequireComponent(typeof(Button))]
public class BattlefieldTile : MonoBehaviour
{
  public Button Button { get; private set; }
  public Faction Faction { get; private set; } = Faction.Neutral;

  public Stack<UnitPieceSlot> VacantSlots { get; private set; } = new Stack<UnitPieceSlot>();
  public List<UnitPieceSlot> FilledSlots { get; private set; } = new List<UnitPieceSlot>();



  private List<Image> _slotImages;
  public Dictionary<UnitPiece, Image> UnitSlots = new Dictionary<UnitPiece, Image>();

  void Awake()
  {
    foreach(UnitPieceSlot slot in GetComponentsInChildren<UnitPieceSlot>().OrderByDescending(s => s.gameObject.name))
      VacantSlots.Push(slot);

    Button ??= GetComponent<Button>();
    Button.image.alphaHitTestMinimumThreshold = 0.5f;
  }
  
  void Start()
  {
    _slotImages ??= transform.GetComponentsInChildren<Image>().ToList();
    _slotImages.Remove(GetComponent<Image>());
    Reset();
  }

  public void Reset()
  {
    Faction = Faction.Neutral;
    UnitSlots.Clear();
  }
  
  public bool CheckForSlot(UnitPiece piece)
  {
    if (Faction != Faction.Neutral && piece.Faction != Faction)
      return false;
    else if (FilledSlots.Count == 4)
      return false;
    else if (FilledSlots.Contains(piece.Slot))
      return false;
    else 
      return true;
  }

  public void PlacePiece(UnitPiece piece)
  {
    if(VacantSlots.TryPop(out UnitPieceSlot result))
      piece.Move(result);

    if (Faction == Faction.Neutral)
      Faction = piece.Faction;
  }


  public void RemovePiece(UnitPiece piece)
  {
    if (piece.Slot && FilledSlots.Contains(piece.Slot))
    {
      UnitPieceSlot last = FilledSlots.Last();
      last.Sim.ReturnPiece();

      if(last != piece.Slot)
      {
        int index = FilledSlots.IndexOf(piece.Slot);

        for(int i = index; i < FilledSlots.Count - 1; i++)
        {
          UnitPieceSlot current = FilledSlots[i];
          UnitPieceSlot next = FilledSlots[i + 1];

          next.Piece.Move(current);
        }
      }
    }

    if (UnitSlots.Count == 0)
      Faction = Faction.Neutral;
  }

  // public void ReplacePiece(UnitPiece current, UnitPiece replacement)
  // {
  //   if (UnitSlots.Count != 1 && current.Faction != replacement.Faction)
  //     return;
    
  //   if (current.Tile && current.Tile == this)
  //     RemovePiece(current);
  //   if (replacement.Tile && replacement.Tile != this)
  //     replacement.Tile.RemovePiece(replacement);
    
  //   PlacePiece(replacement);
  // }
}
