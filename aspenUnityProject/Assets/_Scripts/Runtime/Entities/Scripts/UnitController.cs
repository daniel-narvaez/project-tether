using System;
using UnityEngine;

namespace Tether.CharacterSystems
{
    public abstract class UnitController : MonoBehaviour
    {
        public event Action<Unit> OnUnitMove; 
        
        public abstract void Initialize(UnitDataSO baseStats);
        public abstract void TakeDamage(int damage);

        //convert later to deal with tiles
        public abstract void Move(Vector3Int tileCubeCoord);
        public abstract void Move(Vector3 position);
        
        //possibly refactor and make the data public 
        public abstract Unit GetData();
        

        public abstract Vector3Int GetTileCoords();
        public abstract void SetTile(Vector3Int tileCubeCoord);
    }
}