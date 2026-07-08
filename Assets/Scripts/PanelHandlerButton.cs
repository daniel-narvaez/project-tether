namespace Consystently.UI
{
  using UnityEngine;

  public class PanelHandlerButton : Button_IE, IPanelHandler
  {
    [SerializeField] protected Panel targetPanel;

    /// <summary>
    /// If true, the previous panel will automatically close when a new panel opens. Leave false for a pop-up effect!
    /// </summary>
    [SerializeField] protected bool Autoclose = false;

    void IPanelHandler.OpenPanel(Panel newPanel)
    {
      targetPanel.RootMenu.OpenPanel(targetPanel);
    }

    void IPanelHandler.ClosePanel(Panel panel)
    {
      targetPanel.RootMenu.OpenPanel(targetPanel);
    }
  }
}