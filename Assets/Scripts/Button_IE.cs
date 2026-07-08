namespace Consystently.UI
{ 
  using UnityEngine;
  using UnityEngine.UI;

  [RequireComponent(typeof(Image))]  
  [RequireComponent(typeof(Button))]
  public class Button_IE : InterfaceElement
  {
    [Header("Button")]

    public Image BackgroundImage { get; protected set; }
    public Button ButtonComp { get; protected set; }

    protected virtual void Awake()
    {
      BackgroundImage ??= GetComponentInChildren<Image>();
      ButtonComp ??= GetComponent<Button>();
    }
  }
}
