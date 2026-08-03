using Consystently.UI;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class TileSelectButtonUI : VisualElement
{
  [SerializeField] private TileDetailsButtonUI _detailsButton;
  public TileDetailsButtonUI DetailsButton => _detailsButton;
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
    RootPanel.RootMenu.ClosePanel(RootPanel);
    _detailsButton.PlacePiece(_tileSelectionMap.SelectedPiece);
  }
}
