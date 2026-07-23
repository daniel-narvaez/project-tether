using System.Collections.Generic;
using System.Linq;
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
    [Header("Game Menu")]
    [SerializeField] protected string menuName;
    public string Name => menuName;

    [SerializeField] protected Panel defaultPanel;
    public Panel DefaultPanel => defaultPanel;

    public HashSet<Panel> PanelSet = new HashSet<Panel>();

    public Stack<Panel> PanelStack = new Stack<Panel>();

    public bool Opened { get; protected set; } = true;

    protected virtual void Start()
    {
      MenuManager.Instance.AddMenuToSet(this);
      Close();
    }

    protected virtual void OnDestroy()
    {
      MenuManager.Instance.RemoveMenuFromSet(this);
    }

    public bool Open()
    {
      if (Opened)
      {
        Debug.LogWarning($"{menuName} is already open.");
        return false;
      }
      else if (!defaultPanel)
      {  
        Debug.LogError($"Default Panel has not been assigned.");
        return false;
      }
      else
      {
        ClearStack();
        OpenPanel(defaultPanel);
        Opened = true;
        gameObject.SetActive(true);
        Debug.Log($"{menuName} successfully opened.");
        return true;
      }
    }

    public bool Close()
    {
      if (!Opened)
      {
        Debug.LogWarning($"{menuName} is already closed.");
        return false;
      }
      else
      {
        ClearStack();
        Opened = false;
        gameObject.SetActive(false);
        Debug.Log($"{menuName} successfully closed.");
        return true;
      }
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
      if (!PanelStack.Contains(newPanel))
      {
        Debug.Log($"Opening {newPanel.Name} panel...");
        if (newPanel.Open())
        {
          if(PanelStack.Count > 0) 
            PanelStack.Peek().Hide();
          
          PanelStack.Push(newPanel);
          newPanel.StackIndex = PanelStack.Count;
        }
      }
      else
        Debug.LogWarning($"{newPanel.Name} panel is already in the open in the panel stack.");
    }

    public void ClosePanel (Panel panel)
    {
      if (PanelStack.Peek() == panel)
      {
        Debug.Log($"Closing {panel.Name} panel...");
        if(panel.Close())
        {
          PanelStack.Pop();
          panel.StackIndex = 1;

          if(PanelStack.Count > 0) 
            PanelStack.Peek().Show();
        }
      }
      else
        Debug.LogWarning($"{panel.Name} panel is not at the top of the panel stack.");
    }

    public void ClearStack ()
    {
      foreach (Panel panel in PanelStack.Reverse())
        ClosePanel(panel);
    }
  }
}


