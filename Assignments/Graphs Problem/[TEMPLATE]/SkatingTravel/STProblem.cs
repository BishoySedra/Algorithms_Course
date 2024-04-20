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
        public override string ProblemName { get { return "SkatingTravel"; } }

        public override void TryMyCode()
        {            
            //Case1
            Dictionary<string, int> vertices1 = new Dictionary<string, int>();
            vertices1["S"] = 10;
            vertices1["A1"] = 8;
            vertices1["A2"] = 9;
            vertices1["A3"] = 4;
            vertices1["A4"] = 12;
            vertices1["T"] = 2;
            Dictionary<KeyValuePair<string,string>, int> edges1 = new Dictionary<KeyValuePair<string,string>, int>();
            KeyValuePair<string, string> connection11 = new KeyValuePair<string, string>("S", "A2");
            KeyValuePair<string, string> connection12 = new KeyValuePair<string, string>("S", "A1");
            KeyValuePair<string, string> connection13 = new KeyValuePair<string, string>("S", "A4");
            KeyValuePair<string, string> connection14 = new KeyValuePair<string, string>("A3", "A1");
            KeyValuePair<string, string> connection15 = new KeyValuePair<string, string>("A3", "T");
            KeyValuePair<string, string> connection16 = new KeyValuePair<string, string>("A2", "T");
            KeyValuePair<string, string> connection17 = new KeyValuePair<string, string>("A4", "T");
            edges1[connection11] = 9;
            edges1[connection12] = 5;
            edges1[connection13] = 2;
            edges1[connection14] = 3;
            edges1[connection15] = 1;
            edges1[connection16] = 4;
            edges1[connection17] = 3;

  
            int expected1 = 9;
            int output1 = PROBLEM_CLASS.RequiredFunction(vertices1, edges1, "S");
            
            PrintCase(vertices1, edges1, output1, expected1);

            //Case2
            Dictionary<string, int> vertices2 = new Dictionary<string, int>();
            vertices2["S"] = 12;
            vertices2["A1"] = 8;
            vertices2["A2"] = 2;
            vertices2["A3"] = 9;
            vertices2["T"] = 4;
            Dictionary<KeyValuePair<string, string>, int> edges2 = new Dictionary<KeyValuePair<string, string>, int>();
            KeyValuePair<string, string> connection21 = new KeyValuePair<string, string>("S", "A1");
            KeyValuePair<string, string> connection22 = new KeyValuePair<string, string>("A2", "A1");
            KeyValuePair<string, string> connection23 = new KeyValuePair<string, string>("T", "A2");
            KeyValuePair<string, string> connection24 = new KeyValuePair<string, string>("S", "T");
            KeyValuePair<string, string> connection25 = new KeyValuePair<string, string>("A3", "S");
            KeyValuePair<string, string> connection26 = new KeyValuePair<string, string>("A3", "T");
            edges2[connection21] = 1;
            edges2[connection22] = 1;
            edges2[connection23] = 1;
            edges2[connection24] = 12;
            edges2[connection25] = 5;
            edges2[connection26] = 6;

          
            int expected2 = 11;
            int output2 = PROBLEM_CLASS.RequiredFunction(vertices2, edges2, "S");
            PrintCase(vertices2, edges2, output2, expected2);


            //case 3
            Dictionary<string, int> vertices3 = new Dictionary<string, int>();
            vertices3["S"] = 100;
            vertices3["A1"] = 40;
            vertices3["A2"] = 35;
            vertices3["A3"] = 30;
            vertices3["T"] = 20;
            Dictionary<KeyValuePair<string, string>, int> edges3 = new Dictionary<KeyValuePair<string, string>, int>();
            KeyValuePair<string, string> connection31 = new KeyValuePair<string, string>("S", "A1");
            KeyValuePair<string, string> connection32 = new KeyValuePair<string, string>("S", "T");
            KeyValuePair<string, string> connection33 = new KeyValuePair<string, string>("S", "A3");
            KeyValuePair<string, string> connection34 = new KeyValuePair<string, string>("A1", "A2");
            KeyValuePair<string, string> connection35 = new KeyValuePair<string, string>("A2", "T");
            KeyValuePair<string, string> connection36 = new KeyValuePair<string, string>("A1", "T");
            KeyValuePair<string, string> connection37 = new KeyValuePair<string, string>("A3", "A1");
            edges3[connection31] = 10;
            edges3[connection32] = 20;
            edges3[connection33] = 6;
            edges3[connection34] = 2;
            edges3[connection35] = 2;
            edges3[connection36] = 6;
            edges3[connection37] = 1;

            int expected3 = 14;
            int output3 = PROBLEM_CLASS.RequiredFunction(vertices3, edges3, "S");
            PrintCase(vertices3, edges3, output3, expected3);


            //case 4
            Dictionary<string, int> vertices4 = new Dictionary<string, int>();
            vertices4["S"] = 20;
            vertices4["A1"] = 18;
            vertices4["A2"] = 16;
            vertices4["A3"] = 16;
            vertices4["A4"] = 9;
            vertices4["A5"] = 14;
            vertices4["T"] = 5;
            Dictionary<KeyValuePair<string, string>, int> edges4 = new Dictionary<KeyValuePair<string, string>, int>();
            KeyValuePair<string, string> connection41 = new KeyValuePair<string, string>("S", "A1");
            KeyValuePair<string, string> connection42 = new KeyValuePair<string, string>("S", "A3");
            KeyValuePair<string, string> connection43 = new KeyValuePair<string, string>("A1", "A2");
            KeyValuePair<string, string> connection44 = new KeyValuePair<string, string>("S", "A2");
            KeyValuePair<string, string> connection45 = new KeyValuePair<string, string>("A2", "T");
            KeyValuePair<string, string> connection46 = new KeyValuePair<string, string>("A2", "A5");
            KeyValuePair<string, string> connection47 = new KeyValuePair<string, string>("A3", "A4");
            KeyValuePair<string, string> connection48 = new KeyValuePair<string, string>("A4", "A5");
            KeyValuePair<string, string> connection49 = new KeyValuePair<string, string>("A4", "T");
            KeyValuePair<string, string> connection410 = new KeyValuePair<string, string>("A5", "T");
            edges4[connection41] = 8;
            edges4[connection42] = 2;
            edges4[connection43] = 10;
            edges4[connection44] = 30;
            edges4[connection45] = 1;
            edges4[connection46] = 6;
            edges4[connection47] = 6;
            edges4[connection48] = 3;
            edges4[connection49] = 7;
            edges4[connection410] = 2;

            int expected4 = 15;
            int output4 = PROBLEM_CLASS.RequiredFunction(vertices4, edges4, "S");
            PrintCase(vertices4, edges4, output4, expected4);


            //case 5
            Dictionary<string, int> vertices5 = new Dictionary<string, int>();
            vertices5["S"] = 29;
            vertices5["A1"] = 27;
            vertices5["A2"] = 18;
            vertices5["A3"] = 18;
            vertices5["A4"] = 25;
            vertices5["A5"] = 22;
            vertices5["A6"] = 32;
            vertices5["T"] = 14;
            Dictionary<KeyValuePair<string, string>, int> edges5 = new Dictionary<KeyValuePair<string, string>, int>();
            KeyValuePair<string, string> connection51 = new KeyValuePair<string, string>("S", "A1");
            KeyValuePair<string, string> connection52 = new KeyValuePair<string, string>("S", "A2");
            KeyValuePair<string, string> connection53 = new KeyValuePair<string, string>("S", "A3");
            KeyValuePair<string, string> connection54 = new KeyValuePair<string, string>("S", "A4");
            KeyValuePair<string, string> connection55 = new KeyValuePair<string, string>("S", "A5");
            KeyValuePair<string, string> connection56 = new KeyValuePair<string, string>("S", "A6");
            KeyValuePair<string, string> connection57 = new KeyValuePair<string, string>("A1", "A2");
            KeyValuePair<string, string> connection58 = new KeyValuePair<string, string>("A2", "A3");
            KeyValuePair<string, string> connection59 = new KeyValuePair<string, string>("A3", "T");
            KeyValuePair<string, string> connection510 = new KeyValuePair<string, string>("A2", "T");
            KeyValuePair<string, string> connection511 = new KeyValuePair<string, string>("A4", "A5");
            KeyValuePair<string, string> connection512 = new KeyValuePair<string, string>("A5", "T");
            KeyValuePair<string, string> connection513 = new KeyValuePair<string, string>("A6", "T");
            KeyValuePair<string, string> connection514 = new KeyValuePair<string, string>("A5", "A3");

            edges5[connection51] = 2;
            edges5[connection52] = 10;
            edges5[connection53] = 45;
            edges5[connection54] = 1;
            edges5[connection55] = 6;
            edges5[connection56] = 2;
            edges5[connection57] = 2;
            edges5[connection58] = 3;
            edges5[connection59] = 1;
            edges5[connection510] = 8;
            edges5[connection511] = 2;
            edges5[connection512] = 7;
            edges5[connection513] = 3;
            edges5[connection514] = 3;

            int expected5 = 7;
            int output5 = PROBLEM_CLASS.RequiredFunction(vertices5, edges5, "S");
            PrintCase(vertices5, edges5, output5, expected5);



            //case 6
            Dictionary<string, int> vertices6 = new Dictionary<string, int>();
            vertices6["S"] = 29;
            vertices6["A1"] = 27;
            vertices6["A2"] = 19;
            vertices6["A3"] = 18;
            vertices6["A4"] = 25;
            vertices6["A5"] = 22;
            vertices6["A6"] = 32;
            vertices6["T"] = 18;
            Dictionary<KeyValuePair<string, string>, int> edges6 = new Dictionary<KeyValuePair<string, string>, int>();
            KeyValuePair<string, string> connection61 = new KeyValuePair<string, string>("S", "A1");
            KeyValuePair<string, string> connection62 = new KeyValuePair<string, string>("S", "A2");
            KeyValuePair<string, string> connection63 = new KeyValuePair<string, string>("S", "A3");
            KeyValuePair<string, string> connection64 = new KeyValuePair<string, string>("S", "A4");
            KeyValuePair<string, string> connection65 = new KeyValuePair<string, string>("S", "A5");
            KeyValuePair<string, string> connection66 = new KeyValuePair<string, string>("S", "A6");
            KeyValuePair<string, string> connection67 = new KeyValuePair<string, string>("A1", "A2");
            KeyValuePair<string, string> connection68 = new KeyValuePair<string, string>("A2", "A3");
            KeyValuePair<string, string> connection69 = new KeyValuePair<string, string>("A3", "T");
            KeyValuePair<string, string> connection610 = new KeyValuePair<string, string>("A2", "T");
            KeyValuePair<string, string> connection611 = new KeyValuePair<string, string>("A4", "A5");
            KeyValuePair<string, string> connection612 = new KeyValuePair<string, string>("A5", "T");
            KeyValuePair<string, string> connection613 = new KeyValuePair<string, string>("A6", "T");
            KeyValuePair<string, string> connection614 = new KeyValuePair<string, string>("A5", "A3");

            edges6[connection61] = 2;
            edges6[connection62] = 10;
            edges6[connection63] = 45;
            edges6[connection64] = 1;
            edges6[connection65] = 6;
            edges6[connection66] = 2;
            edges6[connection67] = 2;
            edges6[connection68] = 3;
            edges6[connection69] = 8;
            edges6[connection610] = 8;
            edges6[connection611] = 2;
            edges6[connection612] = 10;
            edges6[connection613] = 3;
            edges6[connection614] = 3;

            int expected6 = 12;
            int output6 = PROBLEM_CLASS.RequiredFunction(vertices6, edges6, "S");
            PrintCase(vertices6, edges6, output6, expected6);
           
        }

        

        Thread tstCaseThr;
        bool caseTimedOut ;
        bool caseException;

        protected override void RunOnSpecificFile(string fileName, HardniessLevel level, int timeOutInMillisec)
        {
          
            int testCases;
            int actualResult = -1;
            int output = -1;

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
                int v = int.Parse(line);
                line = sr.ReadLine();
                int e = int.Parse(line);
                //string startVertex = sr.ReadLine();

                //line = sr.ReadLine();
                //string[] vertices = line.Split(',');
                var vertices= new Dictionary<string,int>(v);
                for (int j = 0; j < v; j++)
                {
                    line = sr.ReadLine();
                    string[] lineParts = line.Split(',');
                    vertices[lineParts[0]] = int.Parse(lineParts[1]);
                }
                var edges = new Dictionary<KeyValuePair<string, string>, int> (e);
                for (int j = 0; j < e; j++)
                {
                    line = sr.ReadLine();
                    string[] lineParts = line.Split(',');
                    KeyValuePair<string, string> edge_connection = new KeyValuePair<string, string>(lineParts[0], lineParts[1]);
                    edges[edge_connection] = int.Parse(lineParts[2]);
                }
                line = sr.ReadLine();
                //string[] results = line.Split(',');

                actualResult = int.Parse(line);
                caseTimedOut = true;
                caseException = false;
                {
                    tstCaseThr = new Thread(() =>
                    {
                        try
                        {
                            Stopwatch sw = Stopwatch.StartNew();
                            output = PROBLEM_CLASS.RequiredFunction(vertices, edges, "S");
                            sw.Stop();
                            //PrintCase(vertices,edges, output, actualResult);
                            Console.WriteLine("|V| = {0}, |E| = {1}, time in ms = {2}", vertices.Count, edges.Count, sw.ElapsedMilliseconds);
                            Console.WriteLine("{0}", output);

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            caseException = true;
                            output = -1;
                        }
                        caseTimedOut = false;
                    });

                    //StartTimer(timeOutInMillisec);
                    if (readTimeFromFile)
                    {
                        timeOutInMillisec = int.Parse(sr.ReadLine().Split(':')[1]);
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

                if (caseTimedOut && level== HardniessLevel.Hard)       //Timedout
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
                Console.WriteLine("================================");

                GC.Collect();
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
        private static void PrintCase(Dictionary<string, int> vertices, Dictionary<KeyValuePair<string, string>, int> edges, int output, int expected)
        {
            foreach (var vertex in vertices) {
                Console.Write("{0}  ", vertex.Key);
            }

            foreach (var edge in edges)
            {
                KeyValuePair<string, string> edge_connection = new KeyValuePair<string, string>(edge.Key.Key,edge.Key.Value);
                Console.WriteLine("{0}, {1}", edge_connection.Key, edge_connection.Value);
            }

            if (output == expected)    //Passed
            {
                Console.WriteLine("CORRECT");
                Console.WriteLine("Output: {0}, Expected: {1}", output, expected);
            }
            else                    //WrongAnswer
            {
                Console.WriteLine("WRONG");
                Console.WriteLine("Output: {0}, Expected: {1}", output, expected);
            }

            //Console.Write("Vertices: ");
            //for (int i = 0; i < vertices.Length; i++)
            //{
            //    Console.Write("{0}  ", vertices[i]);
            //}
            //Console.WriteLine();
            //Console.WriteLine("Edges: ");
            //for (int i = 0; i < edges.Length; i++)
            //{
            //    Console.WriteLine("{0}, {1}", edges[i].Key, edges[i].Value);
            //}
            //Console.WriteLine("Outputs: # backward = {0}, # forward = {1}, # cross = {2}", output[0], output[1], output[2]);
            //Console.WriteLine("Expected: # backward = {0}, # forward = {1}, # cross = {2}", expected[0], expected[1], expected[2]);
            //if (output[0] == expected[0] && output[1] == expected[1] && output[2] == expected[2])    //Passed
            //{
            //    Console.WriteLine("CORRECT");
            //}
            //else                    //WrongAnswer
            //{
            //    Console.WriteLine("WRONG");
            //}
            //Console.WriteLine();
        }
        #endregion
   
    }

}
