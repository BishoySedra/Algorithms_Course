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
        /// Calculates the minimum number of operations required to change the computer's memory.
        /// </summary>
        /// <param name="mem">The target memory state as a string.</param>
        /// <returns>The minimum number of operations required.</returns>
        static public int RequiredFunction(string mem)
        {
            int answer = 0, n = mem.Length;

            // first, get the '1' char index
            int start = 0, i;
            for (i = 0; i < n; i++)
            {
                if (mem[i] == '1')
                {
                    start = i;
                    break;
                }
            }

            if (mem[start] != '1')
            {
                return answer;
            }

            answer = 1;

            // second, looping through starting from start index
            char current = '1';
            for (i = start; i < n; i++)
            {
                if (mem[i] != current)
                {
                    answer++;
                    current = mem[i];
                }
            }

            return answer;
            //REMOVE THIS LINE BEFORE START CODING
            //throw new NotImplementedException();
        }
        #endregion
    }
}