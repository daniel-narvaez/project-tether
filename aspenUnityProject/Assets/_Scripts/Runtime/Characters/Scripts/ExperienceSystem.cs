using UnityEngine;

public class ExperienceSystem : MonoBehaviour, IIntializer
{
    UnitStatsSO _stats;
    int level;

    public void Intialize(UnitStatsSO stats)
    {
        _stats = stats;
        // level = _stats.Level;
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
