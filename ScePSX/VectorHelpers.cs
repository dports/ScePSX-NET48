using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ScePSX
{
    internal class VectorHelpers
    {
        public static Vector<int> ShiftLeft(Vector<int> vector, int shift)
        {
            int[] elements = new int[Vector<int>.Count];
            for (int i = 0; i < Vector<int>.Count; i++)
            {
                elements[i] = vector[i] << shift;
            }
            return new Vector<int>(elements);
        }

        public static Vector<int> ShiftRight(Vector<int> vector, int shift)
        {
            int[] elements = new int[Vector<int>.Count];
            for (int i = 0; i < Vector<int>.Count; i++)
            {
                elements[i] = vector[i] >> shift;
            }
            return new Vector<int>(elements);
        }
    }
}
