using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        /// Fill this function to calculate the minimum imbalance of items
        /// </summary>
        /// <param name="items">array of integers (items' weights)</param>
        /// <param name="N">chambers count (half of the items count) </param>
        /// <returns>the minimum imbalance</returns>
        public static int RequiredFunction(int[] items, int N)
        {
            int items_size = items.Length;

            double AM = 0;
            foreach (int item in items) {
                AM += item;
            }

            AM /= N;

            int rounded_AM = (int)Math.Round(AM);

            // sort the items
            Array.Sort(items);

            int left = 0;
            int right = items_size - 1;
            int mid = left + (right - left) / 2;

            int result = 0;

            if (items_size % 2 != 0) { 
                result += Math.Abs(items[right] - rounded_AM);
            }

            for (int start_1 = mid - 1, start_2 = mid; start_2 < items_size; start_1--, start_2++) {
                if (start_1 < 0) {
                    break;
                }

                result += Math.Abs((items[start_1] + items[start_2]) - rounded_AM);
            }

            return result;
            //REMOVE THIS LINE BEFORE START CODING
            //throw new NotImplementedException();
        }

        #endregion

    }

}
