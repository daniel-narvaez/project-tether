namespace Consystently.UI
{
  using System.Collections.Generic;
  using UnityEngine;

  public class Panel : MonoBehaviour
  {
    [Header("Panel")]
    [SerializeField] protected string panelName;
    public string Name => panelName;
    [SerializeField] protected GameMenu rootMenu;
    public GameMenu RootMenu => rootMenu;

    /// <summary>
    /// This panel's index in its menu's panel stack. 0 is reserved for the menu itself.
    /// </summary>
    [Range(1, 99)]
    public int StackIndex;

    [SerializeField] protected bool hideInStack = true;

    public bool Opened { get; protected set; } = true;

    public HashSet<InterfaceElement> elements { get; protected set; } = new HashSet<InterfaceElement>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      if (transform.root.gameObject.TryGetComponent(out GameMenu gameMenu))
      {
        rootMenu ??= gameMenu;
        rootMenu.AddPanelToSet(this);
        Close();
      }
      else
      {
        Debug.LogError($"Game Menu not found. Disabling root game object...");
        transform.root.gameObject.SetActive(false);
      }
    }

    protected virtual void OnDestroy()
    {
      rootMenu.RemovePanelFromSet(this);
    }

    public bool Open ()
    {
      if (Opened)
      {
        Debug.LogWarning($"{panelName} panel is already open.");
        return false;
      }
      else
      {
        Show();
        Opened = true;
        Debug.Log($"{panelName} panel successfully opened.");
        return true;
      }
    }

    public bool Close ()
    {
      if (!Opened)
      {
        Debug.LogWarning($"{panelName} panel is already closed.");
        return false;
      }
      else
      {
        Hide();
        Opened = false;
        Debug.Log($"{panelName} panel successfully closed.");
        return true;
      }
    }

    public void Hide()
    {
      if(hideInStack)
      {
        gameObject.SetActive(false);
        Debug.Log($"{panelName} panel hidden.");
      }
    }

    public void Show()
    {
      if(hideInStack)
      {
        gameObject.SetActive(true);
        Debug.Log($"{panelName} panel shown.");
      }
    }
  }
}