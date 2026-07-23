namespace Consystently.UI
{
  using TMPro;
  using UnityEngine;
  using UnityEngine.UI;
 
  [RequireComponent(typeof(Button), typeof(Image))]
  public class Button_IE : InterfaceElement
  {
    [Header("Button")]
    [SerializeField] protected Image _iconChild;
    public Image IconChild => _iconChild;
    [SerializeField] protected TextMeshProUGUI _textChild;
    public TextMeshProUGUI TextChild => _textChild;

    public Image BackgroundImage { get; protected set; }
    public Button ButtonComp { get; protected set; }

    protected virtual void Awake()
    {
      BackgroundImage ??= GetComponentInChildren<Image>();
      ButtonComp ??= GetComponent<Button>();

      if(elementName == string.Empty)
        elementName = _textChild.text;

      ButtonComp.interactable = ButtonComp.onClick.GetPersistentEventCount() > 0;
    }
  }
}
