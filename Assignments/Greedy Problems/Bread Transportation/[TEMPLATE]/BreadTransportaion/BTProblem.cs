using Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Problem
{

    public class Problem : ProblemBase, IProblem
    {
        #region ProblemBase Methods
        public override string ProblemName { get { return "BreadTransportation"; } }

        public override void TryMyCode()
        {
            /* WRITE 4~6 DIFFERENT CASES FOR TRACE, EACH WITH
             * 1) SMALL INPUT SIZE
             * 2) EXPECTED OUTPUT
             * 3) RETURNED OUTPUT FROM THE FUNCTION
             * 4) PRINT THE CASE 
             */
            int N = 0;
            Int64 output, expected;

            N = 5;
            int[] arr1 = { 5,-4,1,-3,1 };
            expected = 9;
            output = PROBLEM_CLASS.RequiredFunction(N, arr1);
            PrintCase(N, arr1, output, expected);

            N = 6;
            int[] arr2 = { -1000,-1000,-1000,1000,1000,1000 };
            expected = 9000;
            output = PROBLEM_CLASS.RequiredFunction(N, arr2);
            PrintCase(N, arr2, output, expected);

            N = 9;
            int[] arr3 = { 5,6,7,-3,-4,-8,-9,4,2 };
            expected = 71;
            output = PROBLEM_CLASS.RequiredFunction(N, arr3);
            PrintCase(N, arr3, output, expected);

            
            N = 10;
            int[] arr4 = {1,2,3,4,5,-5,-4,-3,-2,-1};
            expected = 55;
            output = PROBLEM_CLASS.RequiredFunction(N, arr4);
            PrintCase(N, arr4, output, expected);

            N = 9;
            int[] arr5 = {2,4,-9,-8,-4,-3,7,6,5};
            expected = 71;
            output = PROBLEM_CLASS.RequiredFunction(N, arr5);
            PrintCase(N, arr5, output, expected);
        }

        Thread tstCaseThr;
        bool caseTimedOut ;
        bool caseException;

        protected override void RunOnSpecificFile(string fileName, HardniessLevel level, int timeOutInMillisec)
        {
            /* READ THE TEST CASES FROM THE SPECIFIED FILE, FOR EACH CASE DO:
             * 1) READ ITS INPUT & EXPECTED OUTPUT
             * 2) READ ITS EXPECTED TIMEOUT LIMIT (IF ANY)
             * 3) CALL THE FUNCTION ON THE GIVEN INPUT USING THREAD WITH THE GIVEN TIMEOUT 
             * 4) CHECK THE OUTPUT WITH THE EXPECTED ONE
             */

            int testCases;
            int N = 0;
            int[] arr = null;
            Int64 output, actualResult;

            Stream s = new FileStream(fileName, FileMode.Open);
            BinaryReader br = new BinaryReader(s);

            testCases = br.ReadInt32();

            int totalCases = testCases;
            int correctCases = 0;
            int wrongCases = 0;
            int timeLimitCases = 0;
            bool readTimeFromFile = false;
            if (timeOutInMillisec == -1)
            {
                readTimeFromFile = true;
            }
            int i = 1;
            while (testCases-- > 0)
            {
                N = br.ReadInt32();
                arr = new int[N];
                for (int j = 0; j < N; j++)
                {
                    arr[j] = br.ReadInt32();
                }
                actualResult = br.ReadInt64();

                //Console.WriteLine("N = {0}, Res = {1}", N, actualResult);
                output = 0;
                caseTimedOut = true;
                caseException = false;
                Stopwatch sw = null;
                {
                    tstCaseThr = new Thread(() =>
                    {
                        try
                        {
                            Int64 sum = 0;
                            sw = Stopwatch.StartNew();
                            sum += PROBLEM_CLASS.RequiredFunction(N, arr);
                            output = sum;
                            sw.Stop();
                            //Console.WriteLine("N = {0}, time in ms = {1}", arr.Length, sw.ElapsedMilliseconds);
                        }
                        catch
                        {
                            caseException = true;
                            output = int.MinValue;
                        }
                        caseTimedOut = false;
                    });

                    if (readTimeFromFile)
                    {
                        timeOutInMillisec = br.ReadInt32();
                    }
                    /*LARGE TIMEOUT FOR SAMPLE CASES TO ENSURE CORRECTNESS ONLY*/
                    if (level == HardniessLevel.Easy)
                    {
                        timeOutInMillisec = 100; //Large Value 
                    }
                    /*=========================================================*/
                    tstCaseThr.Start();
                    tstCaseThr.Join(timeOutInMillisec);
                }
                //Console.WriteLine("N = {0}, time in ms = {1}, timeout = {2}", arr.Length, sw.ElapsedMilliseconds, timeOutInMillisec);
                if (caseTimedOut)       //Timedout
                {
                    Console.WriteLine("Time Limit Exceeded in Case {0}.", i);
                    tstCaseThr.Abort();
                    timeLimitCases++;
                }
                else if (caseException) //Exception 
                {
                    Console.WriteLine("Exception in Case {0}.", i);
                    wrongCases++;
                }
                else if (output == actualResult)    //Passed
                {
                    Console.WriteLine("Test Case {0} Passed!", i);
                    correctCases++;
                }
                else                    //WrongAnswer
                {
                    Console.WriteLine("Wrong Answer in Case {0}.", i);
                    Console.WriteLine(" your answer = " + output + ", correct answer = " + actualResult);
                    wrongCases++;
                }

                i++;
            }
            s.Close();
            br.Close();
            Console.WriteLine();
            Console.WriteLine("# correct = {0}", correctCases);
            Console.WriteLine("# time limit = {0}", timeLimitCases);
            Console.WriteLine("# wrong = {0}", wrongCases);
            Console.WriteLine("\nFINAL EVALUATION (%) = {0}", Math.Round((float)correctCases / totalCases * 100, 0));
        }

        protected override void OnTimeOut(DateTime signalTime)
        {
        }

        /// <summary>
        /// Generate a file of test cases according to the specified params
        /// </summary>
        /// <param name="level">Easy or Hard</param>
        /// <param name="numOfCases">Required number of cases</param>
        /// <param name="includeTimeInFile">specify whether to include the expected time for each case in the file or not</param>
        /// <param name="timeFactor">factor to be multiplied by the actual time</param>
        public override void GenerateTestCases(HardniessLevel level, int numOfCases, bool includeTimeInFile = false, float timeFactor = 1)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Helper Methods
        private static void PrintCase(int N, int[] arr, Int64 output, Int64 expected)
        {
            /* PRINT THE FOLLOWING
             * 1) INPUT
             * 2) EXPECTED OUTPUT
             * 3) RETURNED OUTPUT
             * 4) WHETHER IT'S CORRECT OR WRONG
             * */
            Console.WriteLine("N: {0}", N);

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Output = " + output);
            Console.WriteLine("Expected = " + expected);
            if (output != expected)
            {
                Console.WriteLine("WRONG");
            }
            else
            {
                Console.WriteLine("CORRECT");
            }

            Console.WriteLine();
        }

        
        #endregion

    }
}
