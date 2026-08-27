using System;

public class EnemyUnit : Unit
{
   public event Action<EnemyUnit> HasDied;
   
   public EnemyUnit(UnitDataSO unit) : base(unit)
   {
      Faction = Faction.Enemy;
   }

   public override void ChangeHealthRemaining(int value)
   {
      HealthRemaining -= value; 
      if(HealthRemaining <= 0)
         HasDied?.Invoke(this);  
   }

   //can modify depending on difficulty desired 
   public override void ChangeEnergyRemaining(int value)
   {
      EnergyRemaining -= value;
   }
    
   
}
