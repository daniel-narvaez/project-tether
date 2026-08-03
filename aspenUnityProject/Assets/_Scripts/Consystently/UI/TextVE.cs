namespace Consystently.UI
{
  using TMPro;
  using UnityEngine;
  
  [RequireComponent(typeof(TextMeshProUGUI))]
  public class TextVE : VisualElement
  {
    [Header("Text")]
    public TextMeshProUGUI TextMeshComp { get; private set;}

    protected void Awake()
    {
      TextMeshComp ??= GetComponent<TextMeshProUGUI>();
    }
  }
}
