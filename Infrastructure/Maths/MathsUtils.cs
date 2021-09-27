using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Maths
{
    public static class MathsUtils
    {
        public static double Round(double value)
        {
            return Math.Round(value, 2);
        }
        public static double RoundNearest(double value)
        {
            bool end = false;
            double result = 0;

            while (!end)
            {
                if (Round((value + result) * 100) % 5 == 0)
                    end = true;
                else
                    result += 0.01;
            }
            return result;
        }
    }
}
