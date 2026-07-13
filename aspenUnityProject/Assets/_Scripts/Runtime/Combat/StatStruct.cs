using System.Collections.Generic;

public struct StatStruct
{
  public int Health { get; private set; }
  public int Energy { get; private set; }
  public int Strength { get; private set; }
  public int Defense { get; private set; }
  public int Tech { get; private set; }
  public int Resistance { get; private set; }
  public int Precision { get; private set; }
  public int Finesse { get; private set; }
  public int Speed { get; private set; }
  public int Luck { get; private set; }

  public Dictionary<Stat, int> All => new Dictionary<Stat, int>() {
    {Stat.HP, Health},
    {Stat.EN, Energy},
    {Stat.STR, Strength},
    {Stat.DEF, Defense},
    {Stat.TEC, Tech},
    {Stat.RES, Resistance},
    {Stat.PRC, Precision},
    {Stat.FIN, Finesse},
    {Stat.SPE, Speed},
    {Stat.LCK, Luck}
  };

  /// <summary>
  /// Constructor for a stat struct.
  /// </summary>
  /// <param name="hp">Health</param>
  /// <param name="en">Energy</param>
  /// <param name="str">Strength</param>
  /// <param name="def">Defense</param>
  /// <param name="tec">Tech</param>
  /// <param name="res">Resistance</param>
  /// <param name="prc">Precision</param>
  /// <param name="fin">Finesse</param>
  /// <param name="spe">Speed</param>
  /// <param name="lck">Luck</param>
  public StatStruct(int hp, int en, int str, int def, int tec, int res, int prc, int fin, int spe, int lck)
  {
    Health = hp;
    Energy = en;
    Strength = str;
    Defense = def;
    Tech = tec;
    Resistance = res;
    Precision = prc;
    Finesse = fin;
    Speed = spe;
    Luck = lck;
  }
}
