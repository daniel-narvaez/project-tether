using UnityEngine;

public class UnitStat
{
  [SerializeField] protected string statName;
  public string Name => statName;

  [Range (1, 99999)]
  public int value { get; private set; }
}

public class FourDigitStat : UnitStat
{
  [Range(1, 9999)]
  public int Value => value;
}