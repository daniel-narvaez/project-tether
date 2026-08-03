using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using Consystently.UI;
using Unity.VisualScripting;

[RequireComponent(typeof(Button))]
public class TileDetailsButtonUI : VisualElement
{
  [SerializeField] private TileSelectButtonUI _selectButton;
  public TileSelectButtonUI SelectButton => _selectButton;

  public Button ButtonComp { get; private set; }

  private Faction _faction = Faction.Neutral;

  public Stack<TilePieceUI> tilePieces;
  private List<Image> _slotImages;
  public Dictionary<TilePieceUI, Image> UnitSlots = new Dictionary<TilePieceUI, Image>();
  
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
  
  public bool CheckForSlot(TilePieceUI tilePiece)
  {
    if (_faction != Faction.Neutral && tilePiece.UnitFaction != _faction)
      return false;
    else if (UnitSlots.Count == 4)
      return false;
    else if (UnitSlots.Keys.Contains(tilePiece))
      return false;
    else 
      return true;
  }

  public void PlacePiece(TilePieceUI tilePiece)
  {
    Image slot = _slotImages[0];
    _slotImages.RemoveAt(0);

    slot.sprite = tilePiece.PieceImage.sprite;
    slot.color = tilePiece.PieceImage.color;
    UnitSlots.Add(tilePiece, slot);

    if (_faction == Faction.Neutral)
      _faction = tilePiece.UnitFaction;

    tilePiece.PiecePlaced = true;
    tilePiece.Placement = this;
  }

  public void ReplacePiece(TilePieceUI current, TilePieceUI replacement)
  {
    if (UnitSlots.Count != 1 && current.UnitFaction != replacement.UnitFaction)
      return;
    
    if (current.Placement && current.Placement == this)
      RemovePiece(current);
    if (replacement.Placement && replacement.Placement != this)
      replacement.Placement.RemovePiece(replacement);
    
    PlacePiece(replacement);
  }

  public void RemovePiece(TilePieceUI tilePiece)
  {
    if (UnitSlots.ContainsKey(tilePiece))
    {
      UnitSlots[tilePiece].sprite = null;
      UnitSlots[tilePiece].color = Color.clear;

      _slotImages.Add(UnitSlots[tilePiece]);

      UnitSlots.Remove(tilePiece);


      tilePiece.Placement = null;
      tilePiece.PiecePlaced = false;
    }

    if (UnitSlots.Count == 0)
      _faction = Faction.Neutral;
  }
}
