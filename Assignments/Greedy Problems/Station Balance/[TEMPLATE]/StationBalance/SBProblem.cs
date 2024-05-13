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
        public override string ProblemName { get { return "StationBalance"; } }

        public override void TryMyCode()
        {
            int N = 0;
            int output, expected;

            {
                N = 3;
                int[] items = { 8, 4, 6, 3, 1, 10 };
                expected = 1;
                output = PROBLEM_CLASS.RequiredFunction(items, N);
                PrintCase(items, N, output, expected);
            }
            {
                N = 4;
                int[] items = { 1, 1, 1, 1, 1, 1, 1, 1 };
                expected = 0;
                output = PROBLEM_CLASS.RequiredFunction(items, N);
                PrintCase(items, N, output, expected);
            }
            {
                N = 1;
                int[] items = { 1, 1000 };
                expected = 0;
                output = PROBLEM_CLASS.RequiredFunction(items, N);
                PrintCase(items, N, output, expected);
            }
            {
                N = 3;
                int[] items = { 4, 1, 2, 6, 3 };
                expected = 1;
                output = PROBLEM_CLASS.RequiredFunction(items, N);
                PrintCase(items, N, output, expected);
            }
            {
                N = 4;
                int[] items = { 1, 17, 16, 15, 16, 17, 30 };
                expected = 20;
                output = PROBLEM_CLASS.RequiredFunction(items, N);
                PrintCase(items, N, output, expected);
            }
        }

      

        Thread tstCaseThr;
        bool caseTimedOut ;
        bool caseException;

        protected override void RunOnSpecificFile(string fileName, HardniessLevel level, int timeOutInMillisec)
        {
            int testCases;
            int M = 0, N = 0;
            int[] numbers = null;
            int output = -1;
            int actualResult = -1;
            int j=0;

            Stream s = new FileStream(fileName, FileMode.Open);
            BinaryReader br = new BinaryReader(s);

            testCases = br.ReadInt32();

            int totalCases = testCases;
            int correctCases    = 0;
            int wrongCases      = 0;
            int timeLimitCases  = 0;
           
            bool readTimeFromFile = false;
            if (timeOutInMillisec == -1)
            {
                readTimeFromFile = true;
            }
            float maxTime = float.MinValue;
            float avgTime = 0;

            for (int i = 1; i <= testCases; i++)
            {
                N = br.ReadInt32();
                M = br.ReadInt32();
                numbers = new int[M];

                for (j = 0; j < M; j++)
                {
                    numbers[j] = br.ReadInt32();
                }
                actualResult = br.ReadInt32();
                if (readTimeFromFile)
                {
                    timeOutInMillisec = int.Parse(br.ReadString().Split(':')[1]);
                }

                Console.WriteLine("\n===========================");
                Console.WriteLine("CASE#{0}: M = {1}, N = {2}", i, M,N);
                Console.WriteLine("===========================");

                
                {
                    caseTimedOut = true;
                    Stopwatch sw = null;
                    caseException = false;
                    {
                        tstCaseThr = new Thread(() =>
                        {
                            try
                            {
                                sw = Stopwatch.StartNew();
                                    output = PROBLEM_CLASS.RequiredFunction(numbers, N);
                                sw.Stop();
                                //Console.WriteLine("time = {0} ms", sw.ElapsedMilliseconds);
                                //Console.WriteLine("output = {0}", output);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                caseException = true;
                                output = -1;
                            }
                            caseTimedOut = false;
                        });
                        
                        /*LARGE TIMEOUT FOR SAMPLE CASES TO ENSURE CORRECTNESS ONLY*/
                        if (level == HardniessLevel.Easy)
                        {
                            timeOutInMillisec = 100; //Large Value 
                        }
                        /*=========================================================*/
                        //StartTimer(timeOutInMillisec);
                        tstCaseThr.Start();
                        tstCaseThr.Join(timeOutInMillisec);
                    }

                    //Console.WriteLine("time = {0}, timeout = {1}", sw.ElapsedMilliseconds, timeOutInMillisec);
                    if (caseTimedOut)       //Timedout
                    {
                        tstCaseThr.Abort();
                        Console.WriteLine("Time Limit Exceeded in Case {0}.", i);
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

                        //maxTime = Math.Max(maxTime, sw.ElapsedMilliseconds);
                        //avgTime += sw.ElapsedMilliseconds;
                    }
                    else                    //WrongAnswer
                    {
                        Console.WriteLine("Wrong Answer in Case {0}.", i);
                        if (level == HardniessLevel.Easy)
                        {
                            PrintCase(numbers, N, output, actualResult, false);
                        }
                        wrongCases++;
                    }
                }
            }
            s.Close();
            br.Close();
            {
                Console.WriteLine("EVALUATION:");
                Console.WriteLine("# correct = {0}", correctCases);
                Console.WriteLine("# time limit = {0}", timeLimitCases);
                Console.WriteLine("# wrong = {0}", wrongCases);
                //Console.WriteLine("\nFINAL EVALUATION (%) = {0}", Math.Round((float)correctCases / totalCases * 100, 0));
                //Console.WriteLine("AVERAGE EXECUTION TIME (ms) = {0}", Math.Round(avgTime / (float)correctCases, 2));
                //Console.WriteLine("MAX EXECUTION TIME (ms) = {0}", maxTime); 
            }
            Console.WriteLine("\nFINAL EVALUATION: {0}", Math.Round((float)correctCases / totalCases * 100, 0));
                
        }

       

        protected override void OnTimeOut(DateTime signalTime)
        {
        }

        public override void GenerateTestCases(HardniessLevel level, int numOfCases, bool includeTimeInFile = false, float timeFactor = 1)
        {
            throw new NotImplementedException();
        }

        #endregion
        #region Helper Methods
        private static void PrintNums(int[] X)
        {

            int N = X.Length;

            for (int i = 0; i < N; i++)
            {
                Console.Write(X[i] + "  ");
            }
            Console.WriteLine();
        }
        private static void PrintCase(int[] arr, int N, long output, long expected, bool check = true)
        {
            Console.WriteLine("N: {0}", N);

            PrintNums(arr);
            Console.WriteLine();
            Console.WriteLine("Output = " + output);
            Console.WriteLine("Expected = " + expected);
            if (check)
            {
                if (output == expected)
                    Console.WriteLine("CORRECT");
                else
                    Console.WriteLine("WRONG");
            }
            Console.WriteLine();
        }
        #endregion
    }
}
