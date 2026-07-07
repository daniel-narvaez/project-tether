using System.Collections.Generic;
using UnityEngine;

namespace Consystently.UI
{
  public class GameMenu : MonoBehaviour
  {
    [SerializeField] protected string menuName;
    public string Name => menuName;

    [SerializeField] protected Text_IE nameDisplayText;

    // Only one Panel shall be active at a time.
    public Panel_IE ActivePanel;

    public HashSet<Panel_IE> Panels = new HashSet<Panel_IE>();

    protected const int zIndex = 0;

    protected virtual void Start()
    {
      if(nameDisplayText)
        nameDisplayText.TextMesh.text = menuName;

      MenuManager.Instance.AddMenuToSet(this);
    }

    protected virtual void OnDestroy()
    {
      MenuManager.Instance.RemoveMenuFromSet(this);
    }

    public void AddPanelToSet (Panel_IE panel)
    {
      if (!Panels.Contains(panel))
      {
        Panels.Add(panel);
        Debug.Log ($"{panel.Name} has been added to the Parent Game Menu's hash set.");
      }
      else
        Debug.LogWarning($"Add failed. {panel.Name} is already present in the Parent Game Menu's hash set!");
    }

    public void RemovePanelFromSet (Panel_IE panel)
    {
      if (Panels.Contains(panel))
      {
        Panels.Remove(panel);
        Debug.Log ($"{panel.Name} has been removed the Parent Game Menu's hash set.");
      }
      else
        Debug.LogWarning($"Remove failed. {panel.Name} was not found in the Parent Game Menu's hash set!");
    }
  }
}


