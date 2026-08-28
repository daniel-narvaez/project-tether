using UnityEngine;
using System.Collections.Generic;

//Entity but pure c# class. Abstract class -> split into ally and enemy 
//Missing Energy/Health system
public abstract class Unit
{
    public Sprite Portrait { get; private set; }
    public string Name { get; set; }
    public Faction Faction { get; protected set; }
    public int Level { get; protected set; }
    public int XpToNextLevel { get; protected set; }
    public int TotalXp { get; protected set; }
    
    protected Dictionary<Stat, Tier> StatGrowths { get; set; }
    protected Dictionary<Element, Affinity> Affinities { get; set; }
    
    //stats
    public int Health { get; protected set; }
    public int Energy { get; protected set; }
    public int Strength { get; protected set; }
    public int Defense { get; protected set; }
    public int Tech { get; protected set; } 
    public int Resistance { get; protected set; }
    public int Speed { get; protected set; } 
    public int Luck {get; protected set;}
    public int Precision {get; protected set;}
    public int Evasion {get; protected set;}

    public float HealthRemaining { get; protected set; } 
    public float EnergyRemaining { get; protected set; }

    public int CurrentTile { get; protected set; }

//   public event Action HasDied;

   //level will draw from save
   protected Unit(UnitDataSO unit)
   {
       Portrait =  unit.Portrait;
       Name = unit.Name;
       //Fill in faction in child
       Level = unit.Level;
       XpToNextLevel = unit.ExPtsToNextLevel;
       TotalXp = unit.TotalExPtsGained;

       StatGrowths = unit.Aptitudes;
       Affinities = unit.Affinities;

   }

   //placeholder
  
   protected void SetFaction(Faction value) { Faction = value; }

   public abstract void ChangeHealthRemaining(int value);
   public abstract void ChangeEnergyRemaining(int value);



}
