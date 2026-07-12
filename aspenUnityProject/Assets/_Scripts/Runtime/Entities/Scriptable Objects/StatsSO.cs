using System.Security.Cryptography;
using UnityEngine;

[CreateAssetMenu(fileName ="New Stats", menuName = "Stats")]
public class StatsSO : ScriptableObject
{
    [SerializeField] int _health;
    [SerializeField] int _mana;
    [SerializeField] int _strength;
    [SerializeField] int _defense;
    [SerializeField] int _magic;
    [SerializeField] int _resistance;
    [SerializeField] int _speed;
    [SerializeField] int _precision;
    [SerializeField] int _evasion;
    [SerializeField] int _luck;
    [SerializeField] int _level = 1;

    public int Health => _health;
    public void SetHealth(int health) => _health = health;
    public int Mana => _mana;
    public void SetMana(int mana) => _mana = mana;
    public int Strength => _strength;
    public void SetStrength(int strength) => _strength = strength;
    public int Defense => _defense;
    public void SetDefense(int defense) => _defense = defense;
    public int Magic => _magic;
    public void SetMagic(int magic) => _magic = magic;
    public int Resistance => _resistance;
    public void SetResistance(int resistance) => _resistance = resistance;
    public int Speed => _speed;
    public void SetSpeed(int speed) => _speed = speed;
    public int Precision => _precision;
    public void SetPrecision(int precision) => _precision = precision;
    public int Evasion => _evasion;
    public void SetEvasion(int evasion) => _evasion = evasion;
    public int Luck => _luck;
    public void SetLuck(int luck) => _luck = luck;
    public int Level => _level;
        
    public void SetLevel(int level) => _level = level;

}
