using UnityEngine;

namespace Scripts.Utils
{
    public static class MathHelper
    {
        public static Vector2 RadianToVector2(float radian)
        {
            return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
        }
  
        public static Vector2 DegreeToVector2(float degree)
        {
            return RadianToVector2(degree * Mathf.Deg2Rad);
        }

        public static float Vector2ToRadian(Vector2 vector)
        {
            return Mathf.Atan2(vector.y, vector.x);
        }

        public static float Vector2ToDegree(Vector2 vector)
        {
            return Vector2ToRadian(vector) * Mathf.Rad2Deg;
        }
    }
}