using UnityEngine;

[RequireComponent(typeof(ExperienceSystem), typeof(CombatClassSystem))]
public class Character : Entity
{
    ExperienceSystem _experienceSystem;
    CombatClassSystem _combatClassSystem;

    private void Awake()
    {
        _experienceSystem = GetComponent<ExperienceSystem>();
        _combatClassSystem = GetComponent<CombatClassSystem>();

        _experienceSystem.Intialize(Stats);
        _combatClassSystem.Intialize(Stats);
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
