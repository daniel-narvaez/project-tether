using System;
using Unity.VisualScripting;
using UnityEngine;

//this script must be attached to the object before converting it to a prefab and dragging it to a unit SO. 
namespace Tether.CharacterSystems
{
    public class EnemyUnitController : MonoBehaviour, IUnitController
    {
        private EnemyUnit stats;
        private int tile; 
        
        //encounters to be passed upon player collision 
        [SerializeField] private EncounterSO[] encounters; 
        
        //to be called by the combat manager. Will pass in encounter data and initialize the units. 
        public void Initialize(UnitDataSO baseStats)
        {
            stats = new EnemyUnit(baseStats);
            Debug.Log($"{gameObject.name} initialized with stats instance ID: {stats.GetHashCode()}"); 
        }

        public void TakeDamage(int damage)
        {
            
        }

        public void Move(int newTile)
        {
            tile = newTile; 
        }

        public Unit GetData()
        {
            return stats; 
        }

        public int GetTile()
        {
            return tile;
        }

        public void SetTile(int tile)
        {
            this.tile = tile;
        }
    
        /*TODO:
            Add collision function wherein the enemy unit 
            calls EncounterManager.Instance.StartEncounter, passing a random encounter from encounters 
            I am not sure if events should be used for passing important data, so use a direct function
        */
    }
}