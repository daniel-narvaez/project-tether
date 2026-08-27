using System;
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
    }
}