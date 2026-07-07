namespace Consystently.UI
{
  using UnityEngine;
  using System;
  using System.Collections.Generic;
  using Essentials;
  using UnityEditor;

  public class MenuManager : Manager<MenuManager>
  {
    // Only one Menu shall be active at a time.
    public GameMenu ActiveMenu;

    // All Menu Objects shall be added to this Hash Set.
    public HashSet<GameMenu> Menus { get; protected set; } = new HashSet<GameMenu>();

    public void AddMenuToSet (GameMenu menu)
    {
      if (!Menus.Contains(menu))
      {
        Menus.Add(menu);
        Debug.Log ($"{menu.Name} has been added to the Menu Manager's hash set.");
      }
      else
        Debug.LogWarning($"Add failed. {menu.Name} is already present in the Menu Manager's hash set!");
    }

    public void RemoveMenuFromSet (GameMenu menu)
    {
      if (Menus.Contains(menu))
      {
        Menus.Remove(menu);
        Debug.Log ($"{menu.Name} has been removed the Menu Manager's hash set.");
      }
      else
        Debug.LogWarning($"Remove failed. {menu.Name} was not found in the Menu Manager's hash set!");
    }

    public void OpenMenu (GameMenu newMenu)
    {
      if (!Menus.Contains(newMenu))
      {
        Debug.LogWarning($"{newMenu.Name} was not found in the Menu Manager's hash set!");
        return;
      }

      if (ActiveMenu != newMenu)
      {
        Debug.Log($"Closing {ActiveMenu.Name}, opening {newMenu.Name}...");
        ActiveMenu = newMenu;
      }
    }

    public void CloseActiveMenu ()
    {
      if (ActiveMenu)
      {
        Debug.Log($"Closing {ActiveMenu.Name}...");
      }
    }
  }
}
