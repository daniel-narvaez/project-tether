using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Tether.CharacterSystems
{
    public class EnemyUnitGO : MonoBehaviour
    {
        private EnemyUnit stats;
        [SerializeField] private EnemyUnitSO baseStats;
        
        //encounters to be passed upon player collision 
        [SerializeField] private EncounterSO[] encounters; 

        private void Awake()
        {
            stats = new EnemyUnit(baseStats);
        }
    
        /*TODO:
            Add collision function wherein the enemy unit 
            calls EncounterManager.Instance.StartEncounter, passing a random encounter from encounters 
            I am not sure if events should be used for passing important data, so use a direct function
        */
    }
}