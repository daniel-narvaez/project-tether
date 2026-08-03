using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using Consystently.UI;
using Unity.VisualScripting;

[RequireComponent(typeof(Button))]
public class BattlefieldTile : VisualElement
{
  public Button ButtonComp { get; private set; }
  private Faction _faction = Faction.Neutral;

  public Stack<UnitPieceSlot> VacantSlots { get; private set; } = new Stack<UnitPieceSlot>();
  public List<UnitPieceSlot> FilledSlots { get; private set; } = new List<UnitPieceSlot>();



  private List<Image> _slotImages;
  public Dictionary<UnitPiece, Image> UnitSlots = new Dictionary<UnitPiece, Image>();
  
  void Start()
  {
    ButtonComp ??= GetComponent<Button>();
    ButtonComp.image.alphaHitTestMinimumThreshold = 0.5f;
    _slotImages ??= transform.GetComponentsInChildren<Image>().ToList();
    _slotImages.Remove(GetComponent<Image>());
    Reset();
  }

  public void Reset()
  {
    _faction = Faction.Neutral;
    UnitSlots.Clear();
  }
  
  public bool CheckForSlot(UnitPiece tilePiece)
  {
    if (_faction != Faction.Neutral && tilePiece.Faction != _faction)
      return false;
    else if (UnitSlots.Count == 4)
      return false;
    else if (UnitSlots.Keys.Contains(tilePiece))
      return false;
    else 
      return true;
  }

  public void PlacePiece(UnitPiece tilePiece)
  {
    Image slot = _slotImages[0];
    _slotImages.RemoveAt(0);

    slot.sprite = tilePiece.Icon.sprite;
    slot.color = tilePiece.Icon.color;
    UnitSlots.Add(tilePiece, slot);

    if (_faction == Faction.Neutral)
      _faction = tilePiece.Faction;

    tilePiece.PiecePlaced = true;
    tilePiece.tile = this;
  }

  public void ReplacePiece(UnitPiece current, UnitPiece replacement)
  {
    if (UnitSlots.Count != 1 && current.Faction != replacement.Faction)
      return;
    
    if (current.tile && current.tile == this)
      RemovePiece(current);
    if (replacement.tile && replacement.tile != this)
      replacement.tile.RemovePiece(replacement);
    
    PlacePiece(replacement);
  }

  public void RemovePiece(UnitPiece tilePiece)
  {
    if (UnitSlots.ContainsKey(tilePiece))
    {
      UnitSlots[tilePiece].sprite = null;
      UnitSlots[tilePiece].color = Color.clear;

      _slotImages.Add(UnitSlots[tilePiece]);

      UnitSlots.Remove(tilePiece);


      tilePiece.tile = null;
      tilePiece.PiecePlaced = false;
    }

    if (UnitSlots.Count == 0)
      _faction = Faction.Neutral;
  }
}
