using System.Collections.Generic;
using UnityEngine;

namespace Consystently.UI
{
  public interface IPanelHandler
  {
    protected void OpenPanel(Panel newPanel);
    protected void ClosePanel(Panel panel);
  }

  public class GameMenu : MonoBehaviour
  {
    [SerializeField] protected string menuName;
    public string Name => menuName;

    [SerializeField] protected Text_IE nameDisplayText;

    public HashSet<Panel> PanelSet = new HashSet<Panel>();

    public Stack<Panel> PanelStack = new Stack<Panel>();

    protected const int zIndex = 0;

    protected virtual void Start()
    {
      if(nameDisplayText)
        nameDisplayText.TextMeshComp.text = menuName;

      MenuManager.Instance.AddMenuToSet(this);
    }

    protected virtual void OnDestroy()
    {
      MenuManager.Instance.RemoveMenuFromSet(this);
    }

    public void AddPanelToSet (Panel panel)
    {
      if (!PanelSet.Contains(panel))
      {
        PanelSet.Add(panel);
        Debug.Log ($"{panel.Name} has been added to the Parent Game Menu's hash set.");
      }
      else
        Debug.LogWarning($"Add failed. {panel.Name} is already present in the Parent Game Menu's hash set!");
    }

    public void RemovePanelFromSet (Panel panel)
    {
      if (PanelSet.Contains(panel))
      {
        PanelSet.Remove(panel);
        Debug.Log ($"{panel.Name} has been removed the Parent Game Menu's hash set.");
      }
      else
        Debug.LogWarning($"Remove failed. {panel.Name} was not found in the Parent Game Menu's hash set!");
    }
    public void OpenPanel (Panel newPanel)
    {
      if (!PanelSet.Contains(newPanel))
      {
        Debug.LogWarning($"{newPanel.Name} was not found in the Game Menu's hash set!");
        return;
      }

      if (!newPanel.gameObject.activeInHierarchy)
      {
        Debug.Log($"Opening {newPanel.Name}...");
        newPanel.gameObject.SetActive(true);
      }
    }

    public void ClosePanel (Panel panel)
    {
      if (panel.gameObject.activeInHierarchy)
      {
        Debug.Log($"Closing {panel.Name}...");
        panel.gameObject.SetActive(false);
      }
    }
  }
}


