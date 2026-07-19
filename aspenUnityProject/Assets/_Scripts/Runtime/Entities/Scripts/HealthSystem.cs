using UnityEngine;

namespace Denever27.CharacterSystems
{
    public class HealthSystem : MonoBehaviour, IIntializer
    {
        UnitStatsSO _stats;
        float _currentHealth;
        float _maxHealth;

        public void Intialize(UnitStatsSO stats)
        {
            _stats = stats;
            _maxHealth = (float) _stats.Health;
            _currentHealth = _maxHealth;
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
