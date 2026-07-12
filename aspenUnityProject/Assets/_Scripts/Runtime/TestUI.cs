using UnityEngine;
using TMPro;

public class TestUI : MonoBehaviour
{
    [SerializeField] GameObject _playerPrefab;
    [SerializeField] TextMeshProUGUI _playerText;
    [SerializeField] TextMeshProUGUI _classText;

    StatsSO _stats;
    CombatClassSystem _combatClassSystem;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _stats = _playerPrefab.GetComponent<Character>().Stats as StatsSO;
        _combatClassSystem = _playerPrefab.GetComponent<CombatClassSystem>();

        _playerText.text = $"Level: {_stats.Level}\nHealth: {_stats.Health}\nMana: {_stats.Mana}\nStrength: {_stats.Strength}\nDefense: {_stats.Defense}\nMagic: {_stats.Magic}\nResistance: {_stats.Resistance}\nSpeed: {_stats.Speed}\nPrecision: {_stats.Precision}\nEvasion: {_stats.Evasion}\nLuck: {_stats.Luck}";

    }

    private void Update()
    {
        string text = _combatClassSystem.SelectedClass == null ? "None" : _combatClassSystem.SelectedClass.ClassType.ToString();
        _classText.text = $"Class: {text}";
    }

    public void ForceAddClass()
    {
        _combatClassSystem.AddClass(CombatClassType.Breacher);
    }

    public void ForceSwitchclass()
    {
        _combatClassSystem.SwitchClass(CombatClassType.Breacher);
    }
}
