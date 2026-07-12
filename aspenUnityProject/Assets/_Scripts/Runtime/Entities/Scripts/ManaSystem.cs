using UnityEngine;

namespace Denever27.CharacterSystems
{
    public class ManaSystem : MonoBehaviour, IIntialize
    {
        StatsSO _stats;
        float _currentMana;
        float _maxMana;


        public void Intialize(StatsSO stats)
        {
            _stats = stats;
            _maxMana = (float)_stats.Mana;
            _currentMana = _maxMana;
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
 
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
