using UnityEngine;

namespace Consystently.UI
{
  public class Menu : MonoBehaviour
  {

    protected virtual void Awake()
    {
      MenuManager.Instance.Menus.Add(this);
    }

    protected virtual void OnDestroy()
    {
      MenuManager.Instance.Menus.Remove(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  }
}


