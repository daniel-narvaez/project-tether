using System;
using Consystently.Essentials;
using UnityEngine;
using UnityEngine.UI;

public class CombatUIController : MonoBehaviour
{
    [SerializeField] private GameObject playerActionsContainer;

    [SerializeField] private GameObject firstButton;
    [SerializeField] private GameObject cursor;

    public static event Action<CombatActions> PlayerAction;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        CombatManager.battlePhaseChanged += ToggleUserActions;
    }

    void OnDisable()
    {
        CombatManager.battlePhaseChanged -= ToggleUserActions;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleUserActions(BattleState bs)
    {
        if (bs is PlayerState)
            playerActionsContainer.SetActive(true);
        else 
            playerActionsContainer.SetActive(false); 
    }
    

    public void TrySelection()
    {
        playerActionsContainer.SetActive(false);
        cursor.SetActive(true);
//        playerActionsContainer.SetActive(bp is PlayerPhase);
    }

    //buttons on the combat panel will use this function
    public void SendAction(int action)
    {
        CombatActions pAction = (CombatActions)action; 
        if(pAction != CombatActions.Defend)
            TrySelection();
        PlayerAction?.Invoke(pAction);
    }

}
