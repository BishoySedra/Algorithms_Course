using Helpers;
using Problem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    class Program
    {
        /// <summary>
        /// Set by +ve value (in ms) for to be used as timeout for each case
        /// OR set it to -1 to read the expected timeout of each case from the testCaseFile
        /// </summary>
        //static int timeOutInMillisec = 20 ; //same value will be used for all test cases
        static int timeOutInMillisec = -1; //different value will be used for each test case (read from file)

        static void Main(string[] args)
        {
            Console.Write("\nEnter your choice: [1] Trial Cases [2] Sample Test Cases [3] Complete Test Cases... [any key for exit] ");
            ConsoleKeyInfo cki = Console.ReadKey();
            Console.WriteLine();
            while (cki.Key == ConsoleKey.D1 || cki.Key == ConsoleKey.D2 || cki.Key == ConsoleKey.D3)
            {
                IProblem problem = null;

                int hardniessLevelSelection = cki.KeyChar - '0';

                problem = new Problem.Problem();

                /********************/
                //GENERATE TEST CASES
                /********************/
               //problem.GenerateTestCases(HardniessLevel.Easy, 5,true, 1.0f);
               //problem.GenerateTestCases(HardniessLevel.Hard, 1,true,1.5f);

                //problem.GenerateTestCases(HardniessLevel.Easy, 5, true, 2);
                /*****************************************************************/

                ExcuteProblem(problem, hardniessLevelSelection, timeOutInMillisec);
                Console.WriteLine();
                Console.Write("\nEnter your choice: [1] Trial Cases [2] Sample Test Cases [3] Complete Test Cases... [any key for exit] ");
                cki = Console.ReadKey();
                Console.WriteLine();
            }
           
        }


        private static void ExcuteProblem(IProblem problem, int hardniessLevelSelection, int timeOutInMillisec)
        {
            switch (hardniessLevelSelection)
            {
                case 1:
                    problem.TryMyCode();
                    break;
                case 2:
                    problem.Run(HardniessLevel.Easy, timeOutInMillisec);
                    break;
                case 3:
                    problem.Run(HardniessLevel.Hard, timeOutInMillisec);
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
            
        }
    }
}
