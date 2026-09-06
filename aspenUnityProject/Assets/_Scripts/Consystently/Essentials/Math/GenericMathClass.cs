using UnityEngine;

namespace Consystently.Essentials.Math
{
    public static class GenericMathClass
    {
        public static int HexGridDistance(this Vector3Int from, Vector3Int to)
        {
            return (Mathf.Abs(from.x - to.x) + Mathf.Abs(from.y - to.y) + Mathf.Abs(from.z - to.z)) / 2;
        }
        
    }
}