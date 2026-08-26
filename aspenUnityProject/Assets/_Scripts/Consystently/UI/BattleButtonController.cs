using Consystently.Essentials;
using UnityEngine;
using UnityEngine.UI;

namespace Consystently.UI
{
    //ad hoc solution 
    public class BattleButtonController : MonoBehaviour
    {
        private Button combatButton;

        void OnEnable()
        {
            combatButton = GameObject.Find("BattleButton").GetComponent<Button>();
            Debug.Log("battle button controller enabled");
            if(combatButton == null)
                Debug.Log("WHERE IS THE BUTTON");
            combatButton.onClick.AddListener(OnButtonClicked);
        }

        void OnDisable()
        {
            Debug.Log("battle button controller disabled");
            combatButton.onClick.RemoveAllListeners();
        }

        void OnButtonClicked()
        {
            //GameManager.Instance.ChangeGameState(new CombatGameState(GameManager.Instance));
            Debug.Log("battle button clicked");
        }
    }
}