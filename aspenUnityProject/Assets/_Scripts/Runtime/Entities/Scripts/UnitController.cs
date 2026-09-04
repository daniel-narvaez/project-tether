using System;
using UnityEngine;

namespace Tether.CharacterSystems
{
    public abstract class UnitController : MonoBehaviour
    {
        public event Action<Unit> OnUnitMove; 
        public event Action<Unit> OnUnitDestroyed;
        
        public abstract void Initialize(UnitDataSO baseStats);
        public abstract void TakeDamage(int damage);

        //convert later to deal with tiles
        public abstract void Move(int tile);
        public abstract void Move(Vector3 position);
        public abstract Unit GetData();

        public abstract int GetTile();
        public abstract void SetTile(int tile);
    }
}