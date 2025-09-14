using UnityEngine;

namespace Unvurn.Unity.Math
{
    public static class QuaternionConversionExtensions
    {
        /// <summary>
        ///   <see cref="Quaternion"/> &#8594; <see cref="Vector4"/>変換。
        /// </summary>
        /// <param name="self">変換元の<see cref="Quaternion"/>。</param>
        /// <returns>変換後の<see cref="Vector4"/>。</returns>
        public static Vector4 ToVector4(this Quaternion self)
        {
            return new Vector4(self.x, self.y, self.z, self.w);
        }

        /// <summary>
        ///   <see cref="Vector4"/> &#8594; <see cref="Quaternion"/>変換。
        /// </summary>
        /// <param name="self">変換元の<see cref="Vector4"/>。</param>
        /// <returns>変換後の<see cref="Quaternion"/>。</returns>
        public static Quaternion ToQuaternion(this Vector4 self)
        {
            return new Quaternion(self.x, self.y, self.z, self.w);
        }
    }
}
