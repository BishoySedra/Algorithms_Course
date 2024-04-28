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
        public override string ProblemName { get { return "ModOfPower"; } }

        public override void TryMyCode()
        {
            long B, P, M, output, expected;

            //Small All
            B = 2;
            P = 6;
            M = 10;
            expected = 4;
            output = ModOfPow.ModOfPower(B, P, M);
            Console.WriteLine("{0}^{1} mod {2} = {3}\nExpected = {4}", B, P, M, output, expected);
            Console.WriteLine();

            //Small Power
            B = 10000;
            P = 3;
            M = 5;
            expected = 0;
            output = ModOfPow.ModOfPower(B, P, M);
            Console.WriteLine("{0}^{1} mod {2} = {3}\nExpected = {4}", B, P, M, output, expected);
            Console.WriteLine();

            //Small Base
            B = 3 ;
            P = 18132 ;
            M = 17;
            expected = 13;
            output = ModOfPow.ModOfPower(B, P, M);
            Console.WriteLine("{0}^{1} mod {2} = {3}\nExpected = {4}", B, P, M, output, expected);
            Console.WriteLine();

            //Zero Power
            B = 123456;
            P = 0;
            M = 2233;
            expected = 1;
            output = ModOfPow.ModOfPower(B, P, M);
            Console.WriteLine("{0}^{1} mod {2} = {3}\nExpected = {4}", B, P, M, output, expected);
            Console.WriteLine();

            //Zero Base
            B = 0;
            P = 12345;
            M = 1133;
            expected = 0;
            output = ModOfPow.ModOfPower(B, P, M);
            Console.WriteLine("{0}^{1} mod {2} = {3}\nExpected = {4}", B, P, M, output, expected);
            Console.WriteLine();

            //One Modulus
            B = 2;
            P = 10;
            M = 1;
            expected = 0;
            output = ModOfPow.ModOfPower(B, P, M);
            Console.WriteLine("{0}^{1} mod {2} = {3}\nExpected = {4}", B, P, M, output, expected);
            Console.WriteLine();

        }

        Thread tstCaseThr;
        bool caseTimedOut ;
        bool caseException;

        protected override void RunOnSpecificFile(string fileName, HardniessLevel level, int timeOutInMillisec)
        {
            int testCases;
            long B, P, M, output;

            Stream s = new FileStream(fileName, FileMode.Open);
            BinaryReader br = new BinaryReader(s);
   
            testCases = br.ReadInt32();

            int totalCases = testCases;
            int correctCases = 0;
            int wrongCases = 0;
            int timeLimitCases = 0;
 
            int i = 1;
            while (testCases-- > 0)
            {
                B = br.ReadInt64();
                P = br.ReadInt64();
                M = br.ReadInt64();
                var actualResult = br.ReadInt64();

                //Console.WriteLine("{0}^{1} mod {2} = {3}", B, P, M, actualResult);
                output = 0;
                caseTimedOut = true;
                caseException = false;
                {
                    tstCaseThr = new Thread(() =>
                    {
                        try
                        {
                            long sum = 0;
                            int numOfRep = 1;
                            Stopwatch sw = Stopwatch.StartNew();
                            for (int x = 0; x < numOfRep; x++)
                            {
                                sum += ModOfPow.ModOfPower(B, P, M);
                            }
                            output = sum / numOfRep;
                            sw.Stop();
                            //Console.WriteLine("P = {0}, time in ms = {1}", P, sw.ElapsedMilliseconds);
                        }
                        catch
                        {
                            caseException = true;
                            output = long.MinValue;
                        }
                        caseTimedOut = false;
                    });

                    //StartTimer(timeOutInMillisec);
                    tstCaseThr.Start();
                    tstCaseThr.Join(timeOutInMillisec);
                }

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

        public override void GenerateTestCases(HardniessLevel level, int numOfCases)
        {
            throw new NotImplementedException();
        }

        #endregion

   
    }
}
