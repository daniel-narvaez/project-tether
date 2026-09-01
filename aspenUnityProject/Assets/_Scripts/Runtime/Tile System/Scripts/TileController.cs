using System.Collections.Generic;
using Tether.CharacterSystems;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace TileSystem
{
    public class TileController : MonoBehaviour
    {
       private Tile tileData;

        [SerializeField, Range(0,18)]
        private int tileNum; 
        
        //change to array if positions ever matter. Everything else so far has been an array because
        //I assumed early on that specific positions within the tile mattered (they don't currently) 
        private List<IUnitController> unitControllers = new List<IUnitController>();


        public void Initialize(TileSO baseData)
        {
            tileData = new Tile(baseData);
        }
            

        public bool AddUnit(IUnitController unitController)
        {
            if (unitControllers.Contains(unitController) || unitControllers.Count >= 4)
                return false;
            unitControllers.Add(unitController);
            return true;
        }

        public IUnitController GetUnitAt(int position)
        {
            if (unitControllers.Count == 0 ||  position > unitControllers.Count - 1)
                return null;
            
            return  unitControllers[position];
        }
        
        //returns deleted controller so the controller can be moved to a different TileController
        //by the CombatManager
        public IUnitController RemoveUnit(IUnitController unitController)
        {
            IUnitController removed = unitController;
            unitControllers.Remove(unitController);
            return removed;
        }

        public Vector3 Position()
        {
            return transform.position; 
        }

        //. . . triangle box 
        public void RepositionUnits(float offset)
        {
            int count = unitControllers.Count;
            if (count <= 1)
                return;
            for (int unit = 0; unit < count; unit++)
            {
                float angle = (2f * Mathf.PI * unit) / count;
               unitControllers[unit].Move(transform.position + new Vector3(offset * Mathf.Cos(angle), 0, offset * Mathf.Sin(angle)));
            }
        }

        public int Num()
        {
            return tileNum;
        }

        public int UnitCount()
        {
            return unitControllers.Count;
        }
            
    }
}