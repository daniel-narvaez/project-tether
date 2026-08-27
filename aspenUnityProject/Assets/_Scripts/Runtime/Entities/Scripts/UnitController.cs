using UnityEngine;

namespace Tether.CharacterSystems
{
    public interface IUnitController
    {
        public void Initialize(UnitDataSO baseStats);
        public void TakeDamage(int damage);
       
        //convert later to deal with tiles
        public void Move(Vector3 translation); 
    }
}