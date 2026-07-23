using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class MapTileButtonUI : MonoBehaviour
{
  private Party _party = Party.Neutral;
  private List<Image> _slotImages = new List<Image>();
  public Dictionary<Image, TilePieceUI> UnitSlots = new Dictionary<Image, TilePieceUI>();

  void Start()
  {
    _slotImages ??= transform.GetComponentsInChildren<Image>().ToList();
    Reset();
  }

  public void Reset()
  {
    _party = Party.Neutral;

    UnitSlots.Clear();
    foreach (Image image in _slotImages)
    {
      image.sprite = null;
      UnitSlots.Add(image, null);
    }
  }
  
  public bool CheckForSlot(TilePieceUI tilePiece)
  {
    if (_party != Party.Neutral && tilePiece.UnitParty != _party)
      return false;
    else if (UnitSlots.Values.Any(s => s != null))
      return false;
    else 
      return true;
  }

}
