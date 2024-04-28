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
using GraphGenerator;

namespace Problem
{

    public class Problem : ProblemBase, IProblem
    {
        #region ProblemBase Methods
        public override string ProblemName { get { return "PlagiarismChecking"; } }

        public override void TryMyCode()
        {            

           
        }

        

        Thread tstCaseThr;
        bool caseTimedOut ;
        bool caseException;

        protected override void RunOnSpecificFile(string fileName, HardniessLevel level, int timeOutInMillisec)
        {
            int testCases;
            int actualResult = int.MinValue;
            int output = int.MinValue;

            FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read);

            StreamReader sr = new StreamReader(file);
            string line = sr.ReadLine();
            testCases = int.Parse(line);
   
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
                line = sr.ReadLine();
                string[] lineParts = line.Split(',');
                var query = new Tuple<string, string>(lineParts[0], lineParts[1]);
                int e = int.Parse(sr.ReadLine());
                
                var matches = new Tuple<string, string>[e];
                for (int j = 0; j < e; j++)
                {
                    line = sr.ReadLine();
                    lineParts = line.Split(',');
                    matches[j] = new Tuple<string, string>(lineParts[0], lineParts[1]);
                }
                line = sr.ReadLine();
                actualResult = int.Parse(line);
                caseTimedOut = true;
                caseException = false;
                {
                    tstCaseThr = new Thread(() =>
                    {
                        try
                        {
                            Stopwatch sw = Stopwatch.StartNew();
                            output = PlagiarismChecking.CheckPlagiarism(matches, query);
                            sw.Stop();
                            //PrintCase(vertices,matches, output, actualResult);
                            Console.WriteLine("|E| = {0}, time in ms = {1}", matches.Length, sw.ElapsedMilliseconds);
                            Console.WriteLine("{0}", output);
                        }
                        catch
                        {
                            caseException = true;
                            output = int.MinValue;
                        }
                        caseTimedOut = false;
                    });

                    //StartTimer(timeOutInMillisec);
                    if (readTimeFromFile)
                    {
                        timeOutInMillisec = int.Parse(sr.ReadLine().Split(':')[1]);
                    }
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
                    Console.WriteLine(" your answer = {0}, correct answer = {1}", output, actualResult);
                    wrongCases++;
                }

                i++;
            }
            file.Close();
            sr.Close();
            Console.WriteLine();
            Console.WriteLine("# correct = {0}", correctCases);
            Console.WriteLine("# time limit = {0}", timeLimitCases);
            Console.WriteLine("# wrong = {0}", wrongCases);
            Console.WriteLine("\nFINAL EVALUATION (%) = {0}", Math.Round((float)correctCases / totalCases * 100, 0)); 
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
        private static void PrintCase(Tuple<string, string>[] edges, Tuple<string, string> query, int output, int expected)
        {
            Console.WriteLine("Edges: ");
            for (int i = 0; i < edges.Length; i++)
            {
                Console.WriteLine("{0}, {1}", edges[i].Item1, edges[i].Item2);
            }

            Console.WriteLine("QUERY: {0}, {1}", query.Item1, query.Item2);

            Console.WriteLine("Output: {0}", output);
            Console.WriteLine("Expected: {0}", expected);
            if (output == expected)    //Passed
            {
                Console.WriteLine("CORRECT");
            }
            else                    //WrongAnswer
            {
                Console.WriteLine("WRONG");
            }
            Console.WriteLine();
        }
        
        #endregion
   
    }
}
