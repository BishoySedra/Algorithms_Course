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
        public override string ProblemName { get { return "ComputerMemory"; } }

        public override void TryMyCode()
        {
            string memoryState;
            int output, expected;

            
            memoryState = "0101";
            expected = 3; 
            output = PROBLEM_CLASS.RequiredFunction(memoryState);
            PrintCase(memoryState, output, expected);

            
            memoryState = "0000";
            expected = 0; 
            output = PROBLEM_CLASS.RequiredFunction(memoryState);
            PrintCase(memoryState, output, expected);

            
            memoryState = "0001";
            expected = 1; 
            output = PROBLEM_CLASS.RequiredFunction(memoryState);
            PrintCase(memoryState, output, expected);

            
            memoryState = "01010";
            expected = 4; 
            output = PROBLEM_CLASS.RequiredFunction(memoryState);
            PrintCase(memoryState, output, expected);


            memoryState = "1111";
            expected = 1; 
            output = PROBLEM_CLASS.RequiredFunction(memoryState);
            PrintCase(memoryState, output, expected);

            memoryState = "1010101010";
            expected = 10; 
            output = PROBLEM_CLASS.RequiredFunction(memoryState);
            PrintCase(memoryState, output, expected);
        }



        Thread tstCaseThr;
        bool caseTimedOut;
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
            string targetMem;
            int actualResult = -1;
            int output = -1;

            StreamReader s = new StreamReader(fileName);

            testCases = int.Parse(s.ReadLine());

            int totalCases = testCases;
            int correctCases = 0;
            int wrongCases = 0;
            int timeLimitCases = 0;
            bool readTimeFromFile = false;
            if (timeOutInMillisec == -1)
            {
                readTimeFromFile = true;
                //readTimeFromFile = false;
            }
            int i = 1;
            while (testCases-- > 0)
            {
                targetMem = s.ReadLine();
                N = targetMem.Length;
                
                actualResult = int.Parse(s.ReadLine());

                caseTimedOut = true;
                caseException = false;
                Stopwatch sw = null;
                {
                    tstCaseThr = new Thread(() =>
                    {
                        try
                        {
                            //int sum = 0;
                            int numOfRep = 1;
                            sw = Stopwatch.StartNew();
                            for (int x = 0; x < numOfRep; x++)
                            {
                                output = PROBLEM_CLASS.RequiredFunction(targetMem);

                            }
                            //output = sum / numOfRep;
                            sw.Stop();

                            //Console.WriteLine("n = {0}, m = {1}, time in ms = {2}", arr1.Length, arr2.Length, sw.ElapsedMilliseconds);
                        }
                        catch
                        {
                            caseException = true;
                            output = -1;

                        }
                        caseTimedOut = false;
                    });

                    if (readTimeFromFile)
                    {
                        timeOutInMillisec = int.Parse(s.ReadLine());
                    }
                    /*LARGE TIMEOUT FOR SAMPLE CASES TO ENSURE CORRECTNESS ONLY*/

                    if (level == HardniessLevel.Easy)
                    {
                        timeOutInMillisec = 1000; //Large Value 
                    }
                    /*=========================================================*/
                    tstCaseThr.Start();
                    tstCaseThr.Join(timeOutInMillisec);
                }

                //Console.WriteLine("time = {0}, timeOutInMillisec = {1}", sw.ElapsedMilliseconds, timeOutInMillisec);
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

                else if (output == actualResult)
                {
                    Console.WriteLine("Test Case {0} Passed!", i);
                    //Console.WriteLine(" your answer = " + output + ", correct answer = " + actualResult);
                    correctCases++;
                }
                else                    //WrongAnswer
                {
                    Console.WriteLine("Wrong Answer in Case {0}.", i);
                    wrongCases++;
                }

                i++;
            }
            s.Close();
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
        private void PrintCase(string memoryState, int output, int expected)
        {
            Console.WriteLine($"Memory State: {memoryState}, Expected Operations: {expected}, Returned Operations: {output}");
            if (expected != output)
            {
                Console.WriteLine("WRONG");
            }
            else
            {
                Console.WriteLine("CORRECT");
            }
        }
        #endregion

    }
}
