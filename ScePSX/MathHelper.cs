using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScePSX
{
    public static class MathHelper
    {
        // Для целых чисел
        public static int Clamp(int value, int min, int max)
        {
            // Обработка случая, когда min > max (опционально)
            if (min > max)
                throw new ArgumentException("min cannot be greater than max.");

            return (value < min) ? min : (value > max) ? max : value;
        }

        // Для double
        public static double Clamp(double value, double min, double max)
        {
            if (min > max)
                throw new ArgumentException("min cannot be greater than max.");

            return (value < min) ? min : (value > max) ? max : value;
        }

        // Для float
        public static float Clamp(float value, float min, float max)
        {
            if (min > max)
                throw new ArgumentException("min cannot be greater than max.");

            return (value < min) ? min : (value > max) ? max : value;
        }

        // Добавьте другие типы по аналогии (long, short и т.д.)
    }
}
