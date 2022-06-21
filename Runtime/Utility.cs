using System.Runtime.CompilerServices;
using UnityEngine.Assertions;

namespace BBUnity.Math
{
    public static class Utility
    {
        /// <summary>
        /// Raises the provided value to a power of 2. 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Pow2(float value) => value * value;
        
        /// <summary>
        /// Raises the provided value to a power of 3. 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Pow3(float value) => Pow2(value) * value;
        
        /// <summary>
        /// Raises the provided value to a power of 4. 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Pow4(float value) => Pow3(value) * value;

        /// <summary>
        /// Inverts a normalised number.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Flip(float value)
        {
            Assert.IsTrue(value >= 0.0f && value <= 1.0f);
            return 1.0f - value;
        }
    }
}
