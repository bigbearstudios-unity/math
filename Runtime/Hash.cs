using Unity.Mathematics;

namespace BBUnity.Mathematics
{
    /// <summary>
    /// Minimal implementation of the xxHash algorithm. https://github.com/Cyan4973/xxHash
    /// Diverges from the original algorithm once more than 16 bytes of data has been Consumed.
    ///
    /// Based heavily on the implementation from https://catlikecoding.com/unity/tutorials/pseudorandom-noise/hashing/
    ///
    /// ------------------------------------------------------------
    ///
    /// Purpose of the interface is to allow you to combine together a seed and several key pieces of information
    /// to be able to calculate a unique, deterministic, cross platform hash from the result.
    ///
    /// xxHash was chosen for it's speed and built in ability to combine these multiple input parameters.
    ///
    /// The class being a struct (a value type) rather than a class also allows the object to be used in the Job system,
    /// while the use of Unity.Mathematics allows the code to be burst compiled and vectorized much more efficiently.
    ///
    /// ------------------------------------------------------------
    /// 
    /// Example usages:
    ///
    /// var townTheme = new Hash(levelSeed).Eat(townID).Avalanche()
    /// var worldHeight = new Hash(levelSeed).Eat(xCoord).Eat(yCoord).Avalanche()
    /// var hairStyle = new Hash(levelSeed).Eat(townID).Eat(npcID).Eat(hairSlot).Avalanche()
    /// 
    /// </summary>
    public struct Hash
    {
        //------------------------------------------------------------ Public Interface
        
        public Hash(uint seed)
        {
            m_accumulator = seed + PRIME_E;
        }

        public Hash Eat(uint data)
        {
            m_accumulator = math.ror(m_accumulator + data * PRIME_C, 17) * PRIME_D;
            return this;
        }
        
        public Hash Eat(byte data)
        {
            m_accumulator = math.ror(m_accumulator + data * PRIME_E, 11) * PRIME_A;
            return this;
        }

        public uint Avalanche()
        {
            var avalanche = m_accumulator;
            avalanche ^= avalanche >> 15;
            avalanche *= PRIME_B;
            avalanche ^= avalanche >> 13;
            avalanche *= PRIME_C;
            avalanche ^= avalanche >> 16;
            return avalanche;
        }

        public static implicit operator uint(Hash hash) => hash.Avalanche();

        //------------------------------------------------------------ Private State
        
        private uint m_accumulator;
        
        //------------------------------------------------------------ Constant
        
        private const uint PRIME_A = 0b10011110001101110111100110110001;
        private const uint PRIME_B = 0b10000101111010111100101001110111;
        private const uint PRIME_C = 0b11000010101100101010111000111101;
        private const uint PRIME_D = 0b00100111110101001110101100101111;
        private const uint PRIME_E = 0b00010110010101100110011110110001;
    }
}
