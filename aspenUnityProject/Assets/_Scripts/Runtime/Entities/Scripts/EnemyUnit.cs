using System;

public class EnemyUnit : Unit
{
   public EnemyUnit(UnitDataSO unit) : base(unit)
   {
      SetFaction(Faction.Enemy);
   }

   public override void ChangeHealthRemaining(int value)
   {
      HealthRemaining -= value; 
   }

   //can modify depending on difficulty desired 
   public override void ChangeEnergyRemaining(int value)
   {
      EnergyRemaining -= value;
   }
    
   
}
