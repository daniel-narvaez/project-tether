namespace Consystently.UI
{
  using UnityEngine;
  using System.Collections.Generic;
  using Essentials;

  [RequireComponent(typeof(InterfaceFunctions))]
  public class MenuManager : Manager<MenuManager>
  {
    // Only one Menu shall be active at a time.
    public GameMenu ActiveMenu { get; protected set; }

    // All Menu Objects shall be added to this List.
    public List<GameMenu> MenuSet { get; protected set; } = new List<GameMenu>();

    public void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
        // if (!ActiveMenu)
          OpenMenu(MenuSet.Find(item => item.Name == "Main Menu"));
    }

    public void AddMenuToSet (GameMenu menu)
    {
      if (!MenuSet.Contains(menu))
      {
        MenuSet.Add(menu);
        Debug.Log ($"{menu.Name} has been added to the Menu Manager's hash set.");
      }
      else
        Debug.LogWarning($"Add failed. {menu.Name} is already present in the Menu Manager's hash set!");
    }

    public void RemoveMenuFromSet (GameMenu menu)
    {
      if (MenuSet.Contains(menu))
      {
        MenuSet.Remove(menu);
        Debug.Log ($"{menu.Name} has been removed the Menu Manager's hash set.");
      }
      else
        Debug.LogWarning($"Remove failed. {menu.Name} was not found in the Menu Manager's hash set!");
    }

    public void OpenMenu (GameMenu gameMenu)
    {
      if (ActiveMenu != gameMenu)
      {
        Debug.Log($"Opening {gameMenu.Name}...");
        if(gameMenu.Open())
        {
          CloseActiveMenu();
          ActiveMenu = gameMenu;
        }
      }
    }

    public void CloseActiveMenu ()
    {
      if (ActiveMenu)
      {
        Debug.Log($"Closing {ActiveMenu.Name}...");
        if(ActiveMenu.Close())
          ActiveMenu = null;
      }
    }
  }
}
