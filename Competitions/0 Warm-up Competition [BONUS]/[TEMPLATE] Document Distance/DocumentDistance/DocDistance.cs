﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DocumentDistance
{
    class DocDistance
    {
        // *****************************************
        // DON'T CHANGE CLASS OR FUNCTION NAME
        // YOU CAN ADD FUNCTIONS IF YOU NEED TO
        // *****************************************
        /// <summary>
        /// Write an efficient algorithm to calculate the distance between two documents
        /// </summary>
        /// <param name="doc1FilePath">File path of 1st document</param>
        /// <param name="doc2FilePath">File path of 2nd document</param>
        /// <returns>The angle (in degree) between the 2 documents</returns>
        /// 

        public static bool IsAlphaNumeric(char letter)
        {
            return char.IsLetterOrDigit(letter);
        }

        public static void Fill_dic(string value, ref Dictionary<string, double> words_doc)
        {
            if (words_doc.TryGetValue(value, out double count))
            {
                words_doc[value] = count + 1;
            }
            else
            {
                words_doc[value] = 1;
            }
            //if (words_doc.ContainsKey(value))
            //{
            //    words_doc[value]++;
            //}
            //else { 
            //    words_doc[value] = 1;
            //}
        }

        private static readonly object lockObject = new object();
        public static void ProcessDocument(string docContent, ref Dictionary<string, double> frequencyDictionary, ref HashSet<string> words)
        {
            StringBuilder temp = new StringBuilder();

            foreach (char letter in docContent)
            {
                if (IsAlphaNumeric(letter))
                {
                    temp.Append(letter);
                    continue;
                }

                if (temp.Length > 0)
                {
                    string word = temp.ToString();
                    if (!string.IsNullOrEmpty(word)) // Check for null or empty key
                    {
                        lock (lockObject)
                        {
                            if (frequencyDictionary.TryGetValue(word, out double count))
                            {
                                frequencyDictionary[word] = count + 1;
                            }
                            else
                            {
                                frequencyDictionary[word] = 1;
                            }
                        }
                        lock (lockObject)
                        {
                            words.Add(word);
                        }
                    }
                    temp.Clear();
                }
            }

            if (temp.Length > 0)
            {
                string word = temp.ToString();
                if (!string.IsNullOrEmpty(word)) // Check for null or empty key
                {
                    lock (lockObject)
                    {
                        if (frequencyDictionary.TryGetValue(word, out double count))
                        {
                            frequencyDictionary[word] = count + 1;
                        }
                        else
                        {
                            frequencyDictionary[word] = 1;
                        }
                    }
                    lock (lockObject)
                    {
                        words.Add(word);
                    }
                }
            }
        }

        public static double CalculateDistance(string doc1FilePath, string doc2FilePath)
        {
            // TODO comment the following line THEN fill your code here
            //throw new NotImplementedException();

            //Console.WriteLine("\ninput: " + doc1FilePath + " " + doc2FilePath);

            if (doc1FilePath == doc2FilePath)
            {
                return 0.0;
            }

            string doc1Content = File.ReadAllText(doc1FilePath);
            string doc2Content = File.ReadAllText(doc2FilePath);

            if (string.IsNullOrEmpty(doc1Content) || string.IsNullOrEmpty(doc2Content))
            {
                return 90;
            }

            // Start splitting and calculating frequency of each word in each doc

            doc1Content = doc1Content.ToLower();
            doc2Content = doc2Content.ToLower();

            Dictionary<string, double> frequency_d1 = new Dictionary<string, double>(),
                                       frequency_d2 = new Dictionary<string, double>();
            HashSet<string> words = new HashSet<string>();

            // start the two tasks in parallel
            Task task1 = Task.Run(() => ProcessDocument(doc1Content, ref frequency_d1, ref words));
            Task task2 = Task.Run(() => ProcessDocument(doc2Content, ref frequency_d2, ref words));

            // Wait for both tasks to complete
            Task.WaitAll(task1, task2);

            // End splitting and calculating frequency of each word in each doc

            // Start calculating the distance

            double product = 0.0, d1_sum_square = 0.0, d2_sum_square = 0.0;

            foreach (var word in words)
            {
                frequency_d1.TryGetValue(word, out double d1Count);
                frequency_d2.TryGetValue(word, out double d2Count);

                product += d1Count * d2Count;
                d1_sum_square += d1Count * d1Count;
                d2_sum_square += d2Count * d2Count;
            }

            if (product != 0 && d1_sum_square == product && d2_sum_square == product)
            {
                return 0;
            }

            if (product == 0 || d1_sum_square == 0 || d2_sum_square == 0)
            {
                return 90;
            }

            double result = (Math.Acos(product / (Math.Sqrt(d1_sum_square) * Math.Sqrt(d2_sum_square)))) * (180 / Math.PI);

            // End calculating the distance

            return result;
        }
    }
}
