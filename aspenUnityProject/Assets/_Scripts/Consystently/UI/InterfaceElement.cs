namespace Consystently.UI
{
  using UnityEngine;

  public class InterfaceElement : MonoBehaviour
  {
    public Panel RootPanel { get; private set; }

    [Header("Interface Element")]
    [SerializeField] protected string elementName;
    public string Name => elementName;

    public void AssignRootPanel(Panel rootPanel) => RootPanel ??= rootPanel;
  }
}