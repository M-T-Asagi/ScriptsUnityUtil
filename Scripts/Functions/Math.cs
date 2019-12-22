using UnityEngine;

namespace AsagiHandyScripts
{
    static public class Math
    {
        static public Vector2Int GreatestCommonResolution(int maxOfPixels, Vector2Int originalResolution)
        {
            int gcd = GetGreatestCommonDivisor(originalResolution.x, originalResolution.y);

            Vector2Int aspect = originalResolution;
            aspect.x /= gcd;
            aspect.y /= gcd;

            float magni = Mathf.Sqrt((float)maxOfPixels / (float)(aspect.x * aspect.y));
            return new Vector2Int(Mathf.CeilToInt(aspect.x * magni), Mathf.CeilToInt(aspect.y * magni));
        }

        static public int GetGreatestCommonDivisor(int a, int b)
        {
            int big = Mathf.Max(a, b);
            int small = Mathf.Min(a, b);

            if (small == 0)
                return big;

            return GetGreatestCommonDivisor(small, big % small);
        }

        static public int PowInt(int x, int y)
        {
            int result = 1;
            for (int i = 0; i < y; i++)
            {
                result *= x;
            }
            return result;
        }
    }
}