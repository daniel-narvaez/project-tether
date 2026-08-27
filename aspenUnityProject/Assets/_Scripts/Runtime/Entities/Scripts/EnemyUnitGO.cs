using System;
using Unity.VisualScripting;
using UnityEngine;

//this script must be attached to the object before converting it to a prefab and dragging it to an SO
namespace Tether.CharacterSystems
{
    public class EnemyUnitGO : MonoBehaviour
    {
        private EnemyUnit stats;
        
        //encounters to be passed upon player collision 
        [SerializeField] private EncounterSO[] encounters; 
        
        //to be called by the combat manager. Will pass in encounter data and initialize the units. 
        public void Initialize(EnemyUnitSO baseStats)
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