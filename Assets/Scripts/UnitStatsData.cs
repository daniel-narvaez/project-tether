using UnityEngine;

[CreateAssetMenu(fileName = "New Unit Stats Data", menuName = "Scriptable Objects/Units/Stats Data")]
public class UnitStatsData : ScriptableObject
{
  public FourDigitStat test;
  
  [Range(1, 9999)]
  [SerializeField] private int health;
  public int Health => health;

  [Range(1, 999)]
  [SerializeField] private int mana;
  public int Mana => mana;
  
  [Range(1, 999)]
  [SerializeField] private int strength;
  public int Strength => strength;
  
  [Range(1, 999)]
  [SerializeField] private int defense;
  public int Defense => defense;
  
  [Range(1, 999)]
  [SerializeField] private int magic;
  public int Magic => magic;
  
  [Range(1, 999)]
  [SerializeField] private int resistance;
  public int Resistance => resistance;
  
  [Range(1, 999)]
  [SerializeField] private int precision;
  public int Precision => precision;
  
  [Range(1, 999)]
  [SerializeField] private int finesse;
  public int Finesse => finesse;
  
  [Range(1, 999)]
  [SerializeField] private int speed;
  public int Speed => speed;
  
  [Range(1, 999)]
  [SerializeField] private int luck;
  public int Luck => luck;
  
}
