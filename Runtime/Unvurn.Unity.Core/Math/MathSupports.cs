using UnityEngine;

namespace Unvurn.Unity.Math
{
    public static class MathSupports
    {
        public static float AngleNormalize(float angle)
        {
            return angle > 180 ? (angle - 360) : angle;
        }

        public static Vector3 AngleNormalize(Vector3 angles)
        {
            return new Vector3(AngleNormalize(angles.x), AngleNormalize(angles.y), AngleNormalize(angles.z));
        }
    }
}
