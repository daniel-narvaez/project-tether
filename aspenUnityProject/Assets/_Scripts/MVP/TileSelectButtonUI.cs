using Consystently.UI;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class TileSelectButtonUI : VisualElement
{
  [SerializeField] private BattlefieldTile _detailsButton;
  public BattlefieldTile DetailsButton => _detailsButton;
  private TileSelectionMapUI _tileSelectionMap;

  public Button ButtonComp { get; private set; }

  public void Start()
  {
    _tileSelectionMap ??= GetComponentInParent<TileSelectionMapUI>();

    ButtonComp ??= GetComponent<Button>();
    ButtonComp.onClick.AddListener(PlacePiece);
    ButtonComp.image.alphaHitTestMinimumThreshold = 0.5f;
  }

  public void PlacePiece()
  {
    Panel.Menu.ClosePanel(Panel);
    _detailsButton.PlacePiece(_tileSelectionMap.SelectedPiece);
  }
}
