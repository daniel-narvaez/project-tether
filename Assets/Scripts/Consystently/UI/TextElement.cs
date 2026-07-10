namespace Consystently.UI
{
  using TMPro;
  using UnityEngine;
  
  [RequireComponent(typeof(TextMeshProUGUI))]
  public class Text_IE : InterfaceElement
  {
    [Header("Text")]
    public TextMeshProUGUI TextMeshComp { get; private set;}

    protected void Awake()
    {
      TextMeshComp ??= GetComponent<TextMeshProUGUI>();
    }
  }
}
