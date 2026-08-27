using UnityEngine;
using System.Collections.Generic;

//Entity but pure c# class. Abstract class -> split into ally and enemy 
//Missing Energy/Health system
public abstract class Unit
{
    protected Sprite Portrait { get; set; }
    protected string Name { get; set; }
    protected  Faction Faction { get; set; }
    protected int Level { get; set; }
    protected int XpToNextLevel { get; set; }
    protected int TotalXp { get; set; }
    
    protected Dictionary<Stat, Tier> StatGrowths { get; set; }
    protected Dictionary<Element, Affinity> Affinities { get; set; }
    
    //stats
    protected int Health { get; set; }
    protected int Energy { get; set; }
    protected int Strength { get; set; }
    protected int Defense { get; set; }
    protected int Tech { get; set; } 
    protected int Resistance { get; set; }
    protected int Speed { get; set; } 
    protected int Luck {get; set;}
    protected int Precision {get; set;}
    protected int Evasion {get; set;}

    protected float HealthRemaining { get; set; } 
    protected float EnergyRemaining { get; set; }

    protected int currentTile; 

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

   public void SetStatHealth(int value) { Health = value; }
   public void SetStatEnergy(int value) { Energy = value; }
   public void SetStatStrength(int value) { Strength = value; }
   public void  SetStatDefense(int value) { Defense = value; }
   public void SetStatTech(int value) { Tech = value; }
   public void SetStatResistance(int value) { Resistance = value; }
   public void  SetStatSpeed(int value) { Speed = value; }
   public void SetStatLuck(int value) { Luck = value; }
   public void SetStatPrecision(int value) { Precision = value; }
   public void SetStatEvasion(int value) { Evasion = value; }

   public void setTile(int tile) {  currentTile = tile; }
   
   public abstract void ChangeHealthRemaining(int value);
   public abstract void ChangeEnergyRemaining(int value);



}
