using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace DocumentDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            long nCases;
            double actualResult;
            StreamReader sr;
            TextReader origConsole = Console.In;
            Console.WriteLine("Document Distance:\n[1] Sample test cases\n[2] Complete testing\n");
            Console.Write("\nEnter your choice [1-2]: ");
            char choice = (char)Console.ReadLine()[0];
            switch (choice)
            {
                case '1':
                    #region SAMPLE CASES
                    bool wrongIndicesFlag = false;
                    sr = new StreamReader("Sample.txt");
                    Console.SetIn(sr);
                    nCases = int.Parse(Console.ReadLine());
                    for (int i = 0; i < nCases; i++)
                    {
                        string D1FilePath = Console.ReadLine();
                        string D2FilePath = Console.ReadLine();
                        
                        Console.Write("Case " + (i + 1).ToString() + ": ");

                        List<int> car1_items = new List<int>();
                        List<int> car2_items = new List<int>();
                        Stopwatch sw = Stopwatch.StartNew();
                        actualResult = DocDistance.CalculateDistance(D1FilePath, D2FilePath);
                        sw.Stop();

                        double expectedResult = double.Parse(Console.ReadLine());
                        if (Math.Round(expectedResult, 2) != Math.Round(actualResult, 2))
                        {
                            Console.WriteLine("Wrong Answer! " + "\n" + "Your answer = " + Math.Round(actualResult, 2));
                            Console.WriteLine("Correct Answer = " + expectedResult);
                            sr.Close();
                            return;
                        }
                        Console.WriteLine(" COMPLETELY succeed");
                    }
                    sr.Close();

                    Console.SetIn(origConsole);
                    Console.WriteLine("Sample cases are finished");
                    Console.WriteLine("\n");
                    Console.WriteLine("You should run Complete Testing... ");
                    Console.Write("\nDo you want to run Complete Testing now (y/n)? ");
                    choice = (char)Console.ReadLine()[0];
                    if (choice == 'n' || choice == 'N')
                        break;
                    else if (choice == 'y' || choice == 'Y')
                        goto CompleteTest; 
                    else
                    {
                        Console.WriteLine("Invalid Choice!");
                        break;
                    }
                    #endregion
                case '2':
                    #region COMPLETE CASES
                CompleteTest:
                    Console.WriteLine("\nComplete Testing is running now...");
                    sr = new StreamReader("complete.txt");
                    Console.SetIn(sr);
                    nCases = int.Parse(Console.ReadLine());
                    double totalTime = 0;
                    double maxTime = 0;
                    
                    for (int i = 0; i < nCases; i++)
                    {
                        string D1FilePath = Console.ReadLine();
                        string D2FilePath = Console.ReadLine();

                        Console.Write("Case " + (i + 1).ToString() + ": ");

                        List<int> car1_items = new List<int>();
                        List<int> car2_items = new List<int>();
                        Stopwatch sw = Stopwatch.StartNew();
                        actualResult = DocDistance.CalculateDistance(D1FilePath, D2FilePath);
                        sw.Stop();
                        if (sw.ElapsedMilliseconds > maxTime)
                            maxTime = sw.ElapsedMilliseconds;
                        totalTime += sw.ElapsedMilliseconds;
                        double expectedResult = double.Parse(Console.ReadLine());
                        if (Math.Round(expectedResult,2) != Math.Round(actualResult,2))
                        {
                            Console.WriteLine("Wrong Answer! " + "\n" + "Your answer = " + Math.Round(actualResult,2));
                            Console.WriteLine("Correct Answer = " + expectedResult);
                            //sr.Close();
                            //return;
                        }
                        if (sw.ElapsedMilliseconds > 20000)
                        {
                            Console.WriteLine("Time limit exceed: case # " + (i + 1));
                            sr.Close();
                            return;
                        }
                        Console.WriteLine(" COMPLETELY succeed");
                    }
                    sr.Close();
                    Console.WriteLine("\n");
                    Console.WriteLine("Complete test is finished");
                    Console.WriteLine("\n");

                    Console.WriteLine("Average execution time (ms) = " + Math.Round(totalTime / nCases, 2)) ;
                    Console.WriteLine("Max execution time (ms) = " + Math.Round(maxTime, 2));
                    break;
                    #endregion
            }
        }
    }
}
