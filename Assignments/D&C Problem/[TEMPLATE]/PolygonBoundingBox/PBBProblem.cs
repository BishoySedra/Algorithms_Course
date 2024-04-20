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
        public override string ProblemName { get { return "PolygonBoundingBox"; } }

        public override void TryMyCode()
        {
            Point[] pts = null;
            int N = 0;
            BoundingBox outputVal, expectedVal;

            {
                N = 4;
                pts = new Point[N];
                pts[0].X = 4.5; pts[0].Y = 1;
                pts[1].X = 5.5; pts[1].Y = 1.5;
                pts[2].X = 7.0; pts[2].Y = 3;
                pts[3].X = 5.0; pts[3].Y = 2;
                expectedVal.minX = 4.5;
                expectedVal.maxX = 7;
                expectedVal.minY = 1;
                expectedVal.maxY = 3;
                outputVal = PROBLEM_CLASS.RequiredFunction(pts, N);
                PrintCase(pts, N, outputVal, expectedVal);
            }

            {
                N = 6;
                pts = new Point[N];
                pts[0].X = 11; pts[0].Y = 6;
                pts[1].X = 12; pts[1].Y = 5;
                pts[2].X = 13; pts[2].Y = 5.5;
                pts[3].X = 14; pts[3].Y = 5.8;
                pts[4].X = 13.5; pts[4].Y = 6.5;
                pts[5].X = 12.5; pts[5].Y = 7;

                expectedVal.minX = 11;
                expectedVal.maxX = 14;
                expectedVal.minY = 5;
                expectedVal.maxY = 7;
                outputVal = PROBLEM_CLASS.RequiredFunction(pts, N);
                PrintCase(pts, N, outputVal, expectedVal);
            }
        }


        Thread tstCaseThr;
        bool caseTimedOut ;
        bool caseException;

        protected override void RunOnSpecificFile(string fileName, HardniessLevel level, int timeOutInMillisec)
        {
            int testCases;
            int N = 0;
            Point[] pts = null;
            BoundingBox output = new BoundingBox();
            BoundingBox actualResult ;
            int j=0;

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
            float maxTime = float.MinValue;
            float avgTime = 0;
            for (int i = 1; i <= testCases; i++)
            {
                N = br.ReadInt32();
                pts = new Point[N];

                for (j = 0; j < N; j++)
                {
                    pts[j].X = br.ReadDouble();
                    pts[j].Y = br.ReadDouble();
                }
                actualResult.minX = br.ReadDouble();
                actualResult.maxX = br.ReadDouble();
                actualResult.minY = br.ReadDouble();
                actualResult.maxY = br.ReadDouble();

                if (readTimeFromFile)
                {
                    timeOutInMillisec = int.Parse(br.ReadString().Split(':')[1]);
                }

                Console.WriteLine("\n===============================");
                Console.WriteLine("CASE#{0}: N = {1}", i, N);
                Console.WriteLine("===============================");

                //for (int c = 0; c < 2; c++)
                {
                    caseTimedOut = true;
                    Stopwatch sw = null;
                    caseException = false;
                    {
                        tstCaseThr = new Thread(() =>
                        {
                            try
                            {
                                BoundingBox sum = new BoundingBox();

                                int numOfRep = 50;
                                sw = Stopwatch.StartNew();
                                for (int x = 0; x < numOfRep; x++)
                                {
                                    output = PROBLEM_CLASS.RequiredFunction(pts, N);
                                    sum.minX += output.minX;
                                    sum.maxX += output.maxX;
                                    sum.minY += output.minY;
                                    sum.maxY += output.maxY;

                                }
                                output.minX = sum.minX / numOfRep;
                                output.maxX = sum.maxX / numOfRep;
                                output.minY = sum.minY / numOfRep;
                                output.maxY = sum.maxY / numOfRep;

                                sw.Stop();
                               //Console.WriteLine("time = {0} ms", sw.ElapsedMilliseconds);
                                //Console.WriteLine("output = {0}", output);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                caseException = true;
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

                    //Console.WriteLine($"N = {N},timeOutInMillisec = {timeOutInMillisec}, actualTime = {sw.ElapsedMilliseconds} ");
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
                    else if (CheckOutput(output, actualResult))    //Passed
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
                            if (!caseException)
                            {
                                PrintCase(pts, N, output, actualResult, false);
                            }
                            else
                            {
                                Console.WriteLine("Exception is occur");
                            }
                        }
                        else
                        {
                            Console.Write("expect value = "); PrintOutput(output);
                            Console.Write("output value = "); PrintOutput(actualResult);
                        }
                        wrongCases++;
                    }
                }
            }
            s.Close();
            br.Close();
            //for (int c = 0; c < 2; c++)
            {
                Console.WriteLine("EVALUATION:");
                Console.WriteLine("# correct = {0}", correctCases);
                Console.WriteLine("# time limit = {0}", timeLimitCases);
                Console.WriteLine("# wrong = {0}", wrongCases);
                //Console.WriteLine("\nFINAL EVALUATION (%), AVG TIME, MAX TIME = {0} {1} {2}", Math.Round((float)correctCasesPart1 / totalCases * 100, 0), correctCasesPart1 == 0 ? -1 : Math.Round(avgTime / (float)correctCasesPart1, 2), correctCasesPart1 == 0 ? -1 : maxTime);
                //Console.WriteLine("\nFINAL EVALUATION (%) = {0}", Math.Round((float)correctCases / totalCases * 100, 0));
                //Console.WriteLine("AVERAGE EXECUTION TIME (ms) = {0}", Math.Round(avgTime / (float)correctCases, 2));
                //Console.WriteLine("MAX EXECUTION TIME (ms) = {0}", maxTime); 
            }
            Console.WriteLine("\nFINAL EVALUATION: (%) = {0}", Math.Round((float)correctCases / totalCases * 100, 0));

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
    
        private static void PrintNums(Point[] pts)
        {
            int N = pts.Length;

            for (int i = 0 ; i < N; i++)
            {
                Console.Write("({0}, {1}) ", pts[i].X, pts[i].Y);
            }
            Console.WriteLine();
        }
        private static void PrintOutput(BoundingBox box)
        {
            Console.WriteLine("minX = {0}, maxX = {1}, minY = {2}, maxY = {3}", box.minX, box.maxX, box.minY, box.maxY);
        }
        private void PrintCase(Point[] pts, int N, BoundingBox outputVal, BoundingBox expectedVal, bool check = true)
        {
            Console.WriteLine("N = {0}", N);
            Console.Write("Points (X, Y) = "); PrintNums(pts);
            Console.Write("expected value = "); PrintOutput(expectedVal);
            Console.Write("output value = "); PrintOutput(outputVal);

            if (check)
            {
                if (!CheckOutput(outputVal, expectedVal))
                {
                    Console.WriteLine("WRONG output");
                }
                else
                {
                    Console.WriteLine("CORRECT output");
                }
            }
            Console.WriteLine();
        }

        private bool CheckOutput(BoundingBox outBox, BoundingBox expectedBox)
        {
            if (Math.Round(outBox.minX, 5) == Math.Round(expectedBox.minX, 5) && Math.Round(outBox.maxX, 5) == Math.Round(expectedBox.maxX, 5) &&
                Math.Round(outBox.minY, 5) == Math.Round(expectedBox.minY, 5) && Math.Round(outBox.maxY, 5) == Math.Round(expectedBox.maxY, 5))
                return true;
            return false;
        }
        #endregion
   
    }
}
