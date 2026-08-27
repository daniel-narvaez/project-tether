using _Scripts.Runtime.Misc;
using FMODUnity;
using UnityEngine;

namespace Consystently.Essentials
{
    /*will not be a traditional manaager because it does not 
    need to be static. EncounterManager will be static and the one 
    to send the data over to CombatManager. CombatManager will exist
    in the battle scene only 
    */
    public class CombatManager : MonoBehaviour
    {
        private EncounterSO encounterSo;
        private Encounter encounter; 
        
        //TODO:
        //have the manager check if there is SO data. If there is none, use encounter 
        void Start()
        {
            //encounter = EncounterManager.Instance.GetEncounter();
        }
    }
}