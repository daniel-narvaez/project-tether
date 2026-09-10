using UnityEngine;

namespace Consystently.Essentials.Math
{
    public static class GenericMathClass
    {
        public static int HexGridDistance(this Vector3Int from, Vector3Int to)
        {
            return (Mathf.Abs(from.x - to.x) + Mathf.Abs(from.y - to.y) + Mathf.Abs(from.z - to.z)) / 2;
        }

        public static CubeCoordDirections GetDirection(this Vector2 vector)
        {
            switch (vector.x, vector.y)
            {
                case(1f,1f):
                    return CubeCoordDirections.NE;
                case(1f,-1f):
                    return CubeCoordDirections.SE;
                case(-1f,-1f):
                    return CubeCoordDirections.SW;
                case(-1f, 1f):
                    return CubeCoordDirections.NW;
                case(0f, 1f):
                    return CubeCoordDirections.N;
                case(0f,-1f):
                    return CubeCoordDirections.S;
                case(1f, 0f):
                    return CubeCoordDirections.NE;
                case(-1f, 0f):
                    return CubeCoordDirections.SW;
                default:
                    return CubeCoordDirections.N;
            }
        }
    }
}