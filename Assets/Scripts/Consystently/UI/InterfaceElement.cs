namespace Consystently.UI
{
  using UnityEngine;

  public class InterfaceElement : MonoBehaviour
  {
    // [SerializeField] protected GameObject parentPanel;
    [Header("Interface Element")]
    [SerializeField] protected string elementName;
    public string Name => elementName;

    /// <summary>
    /// The higher the Z-Index, the further the element is to the foreground. Cannot be 0, which is reserved for the
    /// </summary>
    // [Range(1, 99)]
    // [SerializeField] protected int zIndex;
    // public int ZIndex => zIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  }
}