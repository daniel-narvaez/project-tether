using UnityEngine;
using UnityEngine.Rendering;

namespace _Scripts.Runtime.Misc
{
    //for creating new encounters within the game.
    //EncounterSO encounters are premade and should not be modified in-game.
    //EncounterManager will use account for both EncounterSOs and this class, but mainly SOs will be used.  
    //This will be used for the MVP demo, as the player will create encounters during runtime. 
    public class Encounter
    {
        //19 tiles, max 4 units per tile
        private UnitDataSO[,] tiles = new UnitDataSO[19, 4];
        
        //represents the positions within the tile - the indices cap at 3
        //used for determining the ordering of units when adding them to the tile
        private int[] unitPositions = new int[19];
        
        public UnitDataSO this[int tile, int unitPosition]
        {
            get => tiles[tile, unitPosition];
        }

        //if replace not successful, return false. bool used for potential future conditional popups triggered by managers. 
        public bool changeUnit(int tile, int unitPosition, UnitDataSO newUnit)
        {
            if (unitPosition > unitPositions[tile])
            {
                Debug.Log($"no unit to replace at ({tile}, {unitPosition})");
                return false;
            }
            tiles[tile, unitPosition] = newUnit;
            return true;
        }

        public bool addUnit(int tile, UnitDataSO newUnit)
        {
            if (unitPositions[tile] > 3)
            {
                Debug.Log($"max units at tile {tile}");
                return false;
            }
            tiles[tile,unitPositions[tile]] = newUnit;
            for (int i = unitPositions[tile]+1; i < 4; i++)
            {
                if (tiles[tile, i] != null)
                {
                    unitPositions[tile]++;
                    break;
                }
            }
            return true;
        }

        public bool removeUnit(int tile, int unitPosition)
        {
            if (unitPositions[tile] > 3 || tiles[tile, unitPosition] == null)
            {
                Debug.Log($"no unit to remove at ({tile}, {unitPosition})");
                return false;
            }
            tiles[tile,unitPositions[tile]] = null;
            unitPositions[tile] = unitPosition;
            return true;
        }
        
    }
}