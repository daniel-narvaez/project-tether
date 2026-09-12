using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "CombatClass", menuName = "Scriptable Objects/Misc/Combat Class")]
public class CombatClassSO : ScriptableObject
{
    
    //TODO: add stat modifier later 
    [SerializeField] private Element[] defaultAttackElements;
    public Element[] DefaultAttackElements => defaultAttackElements;

    [SerializeField] private string className;
    public string ClassName => className;
    
    [SerializeField] private string classDescription;
    public string ClassDescription => classDescription;
}
