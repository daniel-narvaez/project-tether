namespace Consystently.UI
{
  using TMPro;
  using UnityEngine;
  
  [RequireComponent(typeof(TextMeshProUGUI))]
  public class Text_IE : InterfaceElement
  {
    [SerializeField] protected TextMeshProUGUI textMesh;
    public TextMeshProUGUI TextMesh => textMesh;

    protected void Awake()
    {
      textMesh ??= GetComponent<TextMeshProUGUI>();
    }
  }
}
