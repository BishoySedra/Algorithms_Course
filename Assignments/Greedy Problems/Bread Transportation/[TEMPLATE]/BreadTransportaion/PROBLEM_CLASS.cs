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
    public static class PROBLEM_CLASS
    {
        #region YOUR CODE IS HERE 

        //Your Code is Here:
        //==================
        /// <summary>
        /// Write a function to calculate the minimum work units for bread transportation among houses
        /// </summary>
        /// <param name="N">Number of houses in city </param>
        /// <param name="DemandPerHouse">Array containing bread demand per house </param>
        /// <returns>Minimum work units needed to destribute bread among neighbourhood</returns>
        static public  Int64 RequiredFunction(int N,int[] DemandPerHouse)
        {

            // create dynamic array to store the sum of the demand of the houses
            int[] prefixArray = new int[N];
            prefixArray[0] = DemandPerHouse[0];

            for (int i = 1; i < N; i++) {
                prefixArray[i] = prefixArray[i - 1] + DemandPerHouse[i];
            }

            Int64 sum = 0;
            for (int i = 0; i < N; i++)
            {
                sum += Math.Abs(prefixArray[i]);
            }

            return sum;

            //REMOVE THIS LINE BEFORE START CODING
            //throw new NotImplementedException();
        }
        #endregion
    }
}
