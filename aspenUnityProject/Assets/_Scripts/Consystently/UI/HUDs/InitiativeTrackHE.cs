using UnityEngine;

namespace Consystently.UI
{
  public class InitiativeTrackHE : HUDElement
  {
    [Header("Initiative Track")]
    [SerializeField] protected RectTransform zeroPanel;
    [SerializeField] protected RectTransform content;
    [SerializeField] protected InitiativeSlot slotPrefab;

    public InitiativeSlot[] initiativeSlots { get; protected set; } = new InitiativeSlot[16];

    protected void Start()
    {
      for (int i = 0; i < initiativeSlots.Length; i++)
      {
        initiativeSlots[i] = Instantiate(slotPrefab, i == 0 ? zeroPanel : content);
        initiativeSlots[i].Initialize(i);
      }

      //initiativeSlots[0].GetComponent<RectTransform>()
    }
  }
}
