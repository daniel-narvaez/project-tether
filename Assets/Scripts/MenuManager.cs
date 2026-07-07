namespace Consystently.UI
{
  using UnityEngine;
  using System.Collections.Generic;
  using Essentials;

  public class MenuManager : Manager<MenuManager>
  {
    // Only one Menu shall be active at a time.
    public Menu ActiveMenu;

    // All Menu Objects shall be added to this Hash Set.
    public HashSet<Menu> Menus = new HashSet<Menu>();
  }
}
