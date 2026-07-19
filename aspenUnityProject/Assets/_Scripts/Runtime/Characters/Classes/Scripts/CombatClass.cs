using UnityEngine;

public abstract class CombatClass
{
    CombatClassType _classType;
    public CombatClassType ClassType => _classType;

    public virtual void AddClassStatBuff(UnitStatsSO stats) { }
    public virtual void RemoveClassStatBuff(UnitStatsSO stats) { }

    protected void SeClassType(CombatClassType classType) => _classType = classType;
}