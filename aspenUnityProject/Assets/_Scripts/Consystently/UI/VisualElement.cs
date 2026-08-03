namespace Consystently.UI
{
  using UnityEngine;


  public class VisualElement : MonoBehaviour
  {
    public Panel RootPanel { get; private set; }

    [Header("Visual Element")]
    [SerializeField] protected string elementName;
    public string Name => elementName;

    public void AssignRootPanel(Panel rootPanel) => RootPanel ??= rootPanel;
  }
}