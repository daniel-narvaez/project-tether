using UnityEngine;
using UnityEngine.Rendering;

enum TestStats
{
    Health,
    Defense,
    Strength
}

[CreateAssetMenu(fileName = "New Combat Class", menuName = "Combat Class")]
public class CombatClassSO : ScriptableObject
{
    [SerializeField] CombatClassType _classType;

    SerializedDictionary<TestStats, int> _statBuffDict = new SerializedDictionary<TestStats, int>();
    //SerializedDictionary<int, SkillSO> _skillDict = new SerializedDictionary<int, SkillSO>();


    public string ReadName() => _classType.ToString();

    public void AddStatBuff()
    {
        // Iterate through the dict to apply the stat buff
    }

    public void RemoveStatBuff()
    {
        // Iterate through the dict to remove the stat buff
    }
}
