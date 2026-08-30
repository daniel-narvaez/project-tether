using UnityEngine;

namespace Tether.CharacterSystems
{
    public interface IUnitController
    {
        public void Initialize(UnitDataSO baseStats);
        public void TakeDamage(int damage);
       
        //convert later to deal with tiles
        public void Move(int tile);
        public Unit GetData();

        public int GetTile();
        public void SetTile(int tile);
    }
}