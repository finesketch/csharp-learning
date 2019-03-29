using System;

namespace csharp_learning.Dynamicprogrammingandrecursion
{
    public class BottomUp
    {
        public int Product1ToN(int n)
        {
            // We assume n >= 1
            int result = 1;

            for (int num = 1; num <= n; num++)
            {
                result *= num;
            }

            return result;
        }
    }
}
