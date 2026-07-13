using UnityEngine;

namespace Denever27.CharacterSystems
{
    public class EnergySystem : MonoBehaviour, IIntializer
    {
        UnitStatsSO _stats;
        float _currentEnergy;
        float _maxEnergy;


        public void Intialize(UnitStatsSO stats)
        {
            _stats = stats;
            _maxEnergy = (float)_stats.Energy;
            _currentEnergy = _maxEnergy;
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
