using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace BBUnity.Math
{
    public static class Easing
    {
        #region Smooth Start
        
        /// <summary>
        /// Easing function which modifies a normalised t value to start smoothly and end linearly.
        /// Results in a smooth start up to the 1st order derivative (e.g. position)
        /// Also known as EaseInQuad.
        /// </summary>
        /// <param name="t">Assumed to be in the range of [0-1]</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SmoothStart2(float t) => Utility.Pow2(t);
        
        /// <summary>
        /// Easing function which modifies a normalised t value to start smoothly and end linearly.
        /// Results in a smooth start up to the 2nd order derivative (e.g. velocity)
        /// Also known as EaseInCubic.
        /// </summary>
        /// <param name="t">Assumed to be in the range of [0-1]</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SmoothStart3(float t) => Utility.Pow3(t);
        
        /// <summary>
        /// Easing function which modifies a normalised t value to start smoothly and end linearly.
        /// Results in a smooth start up to the 3rd order derivative (e.g. acceleration)
        /// Also known as EaseInQuartic.
        /// </summary>
        /// <param name="t">Assumed to be in the range of [0-1]</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SmoothStart4(float t) => Utility.Pow4(t);
        
        #endregion

        #region Smooth Stop

        /// <summary>
        /// Easing function which modifies a normalised t value to start linearly and stop smoothly.
        /// Results in a smooth stop up to the 1st order derivative (e.g. position)
        /// Also known as EaseOutQuad.
        /// </summary>
        /// <param name="t">Assumed to be in the range of [0-1]</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SmoothStop2(float t) => Utility.Flip(Utility.Pow2(Utility.Flip(t)));
        
        /// <summary>
        /// Easing function which modifies a normalised t value to start linearly and stop smoothly.
        /// Results in a smooth stop up to the 2nd order derivative (e.g. velocity)
        /// Also known as EaseOutCubic.
        /// </summary>
        /// <param name="t">Assumed to be in the range of [0-1]</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SmoothStop3(float t) => Utility.Flip(Utility.Pow3(Utility.Flip(t)));
        
        /// <summary>
        /// Easing function which modifies a normalised t value to start linearly and stop smoothly.
        /// Results in a smooth stop up to the 3rd order derivative (e.g. acceleration)
        /// Also known as EaseOutQuartic.
        /// </summary>
        /// <param name="t">Assumed to be in the range of [0-1]</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SmoothStop4(float t) => Utility.Flip(Utility.Pow4(Utility.Flip(t)));

        #endregion
        
        #region Smooth Step

        /// <summary>
        /// Easing function which modifies a normalised t value to start and end smoothly
        /// Results in a smooth start and stop up to the 1st order derivative (e.g. position)
        /// </summary>
        /// <param name="t">Assumed to be in the range of [0-1]</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SmoothStep2(float t) => math.lerp(SmoothStart2(t), SmoothStop2(t), t);
        
        /// <summary>
        /// Easing function which modifies a normalised t value to start and end smoothly
        /// Results in a smooth start and stop up to the 2nd order derivative (e.g. velocity)
        /// </summary>
        /// <param name="t">Assumed to be in the range of [0-1]</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SmoothStep3(float t) => math.lerp(SmoothStart3(t), SmoothStop3(t), t);
        
        /// <summary>
        /// Easing function which modifies a normalised t value to start and end smoothly
        /// Results in a smooth start and stop up to the 3rd order derivative (e.g. acceleration)
        /// </summary>
        /// <param name="t">Assumed to be in the range of [0-1]</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SmoothStep4(float t) => math.lerp(SmoothStart4(t), SmoothStop4(t), t);

        #endregion
    }
}
