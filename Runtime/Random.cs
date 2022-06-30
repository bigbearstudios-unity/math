using Unity.Mathematics;
using UnityEngine.Assertions;

namespace BBUnity.Mathematics
{
    /// <summary>
    /// Lightweight, fast, but sufficiently random pseudorandom number generator.
    /// Based on a GDC 2017 talk by Squirrel Eiserloh: "Math for Game Programmers: Noise-Based RNG"
    /// https://youtu.be/LWFzPP8ZbdU
    ///
    /// Internally uses a quality hashing function to generate the random values. 
    ///
    /// ------------------------------------------------------------
    ///
    /// The class being a struct (a value type) rather than a class also allows the object to be used in the Job system,
    /// while the use of Unity.Mathematics allows the code to be burst compiled and vectorized much more efficiently.
    /// 
    /// </summary>
    public struct Random
    {
        //------------------------------------------------------------ State management

        public Random(uint seed)
        {
            m_seed = seed;
            m_position = 0;
        }
        
        /// <summary>
        /// Useful for jumping around within the random sequence.
        /// Maybe not all data is needed to be generated at this time, and you know you can skip ahead X number of values.
        /// Rather than actually generate those values, just jump the internal state forwards.
        /// </summary>
        public void Advance(uint offset)
        {
            m_position += offset;
        }
        
        /// <summary>
        /// Useful for jumping around within the random sequence.
        /// </summary>
        public void Rewind(uint offset)
        {
            m_position -= offset;
        }

        //------------------------------------------------------------ Standard Accessors
        public uint NextUint() => new Hash(m_seed).Eat(m_position++).Avalanche();
        public int NextInt() => (int)NextUint();
        public byte NextByte() => (byte)(NextUint() & byte.MaxValue);
        public sbyte NextSbyte() => (sbyte)NextByte();
        public float NextFloat() => (float)NextUint() / uint.MaxValue;
        public double NextDouble() => (double)NextUint() / uint.MaxValue;
        public bool NextBool() => (NextUint() % 2) == 0;
        
        //------------------------------------------------------------ Range Accessors

        public uint RangeUint(uint min, uint max)
        {
            Assert.IsTrue(min < max, "min must be lower than max!");
            var range = max - min;
            var rand = NextUint() % range;
            return min + rand;
        }
        
        public int RangeInt(int min, int max)
        {
            Assert.IsTrue(min < max, "min must be lower than max!");
            var range = (uint)(max - min);
            var rand = NextUint() % range;
            return (int)(min + rand);
        }
        
        public byte RangeByte(byte min, byte max)
        {
            Assert.IsTrue(min < max, "min must be lower than max!");
            var range = (uint)(max - min);
            var rand = NextUint() % range;
            return (byte)(min + rand);
        }
        
        public sbyte RangeSbyte(sbyte min, sbyte max)
        {
            Assert.IsTrue(min < max, "min must be lower than max!");
            var range = (uint)(max - min);
            var rand = NextUint() % range;
            return (sbyte)(min + rand);
        }
        
        public float RangeFloat(float min, float max) => math.lerp(min, max, NextFloat());
        public double RangeDouble(double min, double max) => math.lerp(min, max, NextDouble());

        //------------------------------------------------------------ Special Accessors

        public bool Chance(float chanceToReturnTrue)
        {
            Assert.IsTrue(chanceToReturnTrue >= 0.0f && chanceToReturnTrue <= 1.0f, "chanceToReturnTrue must be between 0 and 1.");
            return NextFloat() < chanceToReturnTrue;
        }
        
        public bool Chance(double chanceToReturnTrue)
        {
            Assert.IsTrue(chanceToReturnTrue >= 0.0f && chanceToReturnTrue <= 1.0f, "chanceToReturnTrue must be between 0 and 1.");
            return NextDouble() < chanceToReturnTrue;
        }

        //------------------------------------------------------------ Private State
        
        private readonly uint m_seed;
        private uint m_position;
    }
}