namespace Consystently.UI
{
  using UnityEngine;
  using UnityEngine.UI;

  [RequireComponent(typeof(Image))]
  public class Image_IE : InterfaceElement
  {
    [Header("Image")]
    public Image ImageComp { get; protected set; }

    protected void Awake()
    {
      ImageComp ??= GetComponent<Image>();
    }
  }
}