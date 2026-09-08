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
        CombatManager.battlePhaseChanged += TrySelection;
        CombatManager.selectionCancelled += ResetActions;
    }

    void OnDisable()
    {
        CombatManager.battlePhaseChanged -= TrySelection;
        CombatManager.selectionCancelled -= ResetActions;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TrySelection(BattleState bp)
    {
        playerActionsContainer.SetActive(false);
        if (bp is PlayerState)
        {
            cursor.SetActive(true);
        }
//        playerActionsContainer.SetActive(bp is PlayerPhase);
    }

    public void ResetActions()
    {
        playerActionsContainer.SetActive(true);
    }

    public void SendPlayerAction(PlayerActions action)
    {
        PlayerAction?.Invoke(action);
    }
    

}
