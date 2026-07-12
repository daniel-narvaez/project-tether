using UnityEngine;
using Denever27.CharacterSystems;

[RequireComponent(typeof(HealthSystem), typeof(ManaSystem))]
public abstract class Entity : MonoBehaviour
{
    [SerializeField] StatsSO _stats;
    protected HealthSystem _healthSystem;
    protected ManaSystem _maanaSystem;

    private void Awake()
    {
        _healthSystem = GetComponent<HealthSystem>();
        _maanaSystem = GetComponent<ManaSystem>();

        _healthSystem.Intialize(_stats);
        _maanaSystem.Intialize(_stats);
    }

    public StatsSO Stats => _stats;
}
