using UnityEngine;

public class ExperienceSystem : MonoBehaviour, IIntialize
{
    StatsSO _stats;
    int level;

    public void Intialize(StatsSO stats)
    {
        _stats = stats;
        level = _stats.Level;
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
