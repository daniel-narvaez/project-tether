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
        private GameObject[,] tiles = new GameObject[19, 4];
        
        //represents the positions within the tile - the indices cap at 3
        //used for determining the ordering of units when adding them to the tile
        private int[] unitPositions = new int[19];

        public GameObject this[int tile, int unitPosition]
        {
            get
            {
                return tiles[tile, unitPosition];
            }
        }

        //if replace not successful, return false. bool used for potential future conditional popups triggered by managers. 
        public bool changeUnit(int tile, int unitPosition, GameObject newUnit)
        {
            if (unitPosition > unitPositions[tile])
            {
                Debug.Log($"no unit to replace at ({tile}, {unitPosition})");
                return false;
            }
            tiles[tile, unitPosition] = newUnit;
            return true;
        }

        public bool addUnit(int tile, GameObject newUnit)
        {
            if (unitPositions[tile] >= 3)
            {
                Debug.Log($"max units at tile {tile}");
                return false;
            }
            tiles[tile,unitPositions[tile]] = newUnit;
            unitPositions[tile]++;
            return true;
        }
        
    }
}