using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    // *****************************************
    // DON'T CHANGE CLASS OR FUNCTION NAME
    // YOU CAN ADD FUNCTIONS IF YOU NEED TO
    // *****************************************
    public static class ModOfPow
    {
        #region YOUR CODE IS HERE
        /// <summary>
        /// Calculate Mod of Power (B^P mod M) in an efficient way
        /// </summary>
        /// <param name="B">Base</param>
        /// <param name="P">Power</param>
        /// <param name="M">Modulus</param>
        /// <returns>Result of B^P mod M </returns>
        /// 

        // fast power algorithm recursive using divide and conquer
        public static long solve(long B, long P, long M)
        {
            if (P == 0)
            {
                return 1;
            }
            if (P % 2 == 0)
            {
                long x = solve(B, P / 2, M);
                return (x * x) % M;
            }
            else
            {
                return (B * solve(B, P - 1, M)) % M;
            }
        }
        public static long ModOfPower(long B, long P, long M)
        {
          
            return solve(B, P, M);
            //REMOVE THIS LINE BEFORE START CODING
            //throw new NotImplementedException();
        }

        #endregion
    }
}
