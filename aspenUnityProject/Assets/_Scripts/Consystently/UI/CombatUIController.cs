using System;
using Consystently.Essentials;
using UnityEngine;

public class CombatUIController : MonoBehaviour
{
    [SerializeField] private GameObject playerActionsContainer;

    [SerializeField] private GameObject firstButton;
    [SerializeField] private GameObject cursor;

    public static event Action<PlayerActions> PlayerAction;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        CombatManager.selectionCancelled += ResetActions;
    }

    void OnDisable()
    {
        CombatManager.selectionCancelled -= ResetActions;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TrySelection()
    {
        playerActionsContainer.SetActive(false);
        cursor.SetActive(true);
//        playerActionsContainer.SetActive(bp is PlayerPhase);
    }

    public void ResetActions()
    {
        playerActionsContainer.SetActive(true);
    }

    //TODO: add way of resetting actions panel 
    public void SendAction(int action)
    {
        PlayerActions pAction = (PlayerActions)action; 
        if(pAction != PlayerActions.Defend)
            TrySelection();
        PlayerAction?.Invoke(pAction);
    }

}
