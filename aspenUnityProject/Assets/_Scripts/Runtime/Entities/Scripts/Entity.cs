using UnityEngine;
using Denever27.CharacterSystems;

[RequireComponent(typeof(HealthSystem), typeof(EnergySystem))]
public abstract class Entity : MonoBehaviour
{
    [SerializeField] UnitStatsSO _stats;
    protected HealthSystem _healthSystem;
    protected EnergySystem _energySystem;

    private void Awake()
    {
        _healthSystem = GetComponent<HealthSystem>();
        _energySystem = GetComponent<EnergySystem>();

        _healthSystem.Intialize(_stats);
        _energySystem.Intialize(_stats);
    }

    public UnitStatsSO Stats => _stats;
}
