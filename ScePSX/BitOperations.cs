namespace ScePSX
{
    internal class BitOperations
    {
        public static int LeadingZeroCount(uint value)
        {
            if (value == 0) return 32;
            int count = 0;
            while ((value & 0x80000000) == 0)
            {
                count++;
                value <<= 1;
            }
            return count;
        }
    }
}