namespace Consystently.UI
{
  using System.Collections.Generic;
  using UnityEngine;
  
  public class Panel_IE : InterfaceElement
  {
    [Header("Panel")]
    [SerializeField] protected GameMenu rootMenu;
    public GameMenu RootMenu => rootMenu;

    public HashSet<InterfaceElement> elements { get; protected set; } = new HashSet<InterfaceElement>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      if (transform.root.gameObject.TryGetComponent(out GameMenu gameMenu))
      {
        rootMenu ??= gameMenu;
        rootMenu.AddPanelToSet(this);
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
  }
}