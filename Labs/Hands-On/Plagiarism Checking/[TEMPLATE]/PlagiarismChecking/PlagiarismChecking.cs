using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    public static class PlagiarismChecking
    {
        #region YOUR CODE IS HERE
        //Your Code is Here:
        //==================
        /// <summary>
        /// Given the matching pairs and a query pair, find the min number of connections between the nodes of the given pair (if any)
        /// </summary>
        /// <param name="matches">array of matching pairs</param>
        /// <param name="query">query pair</param>
        /// <returns>min number of connections between the nodes of the query pair (if any)</returns>
        public static int CheckPlagiarism(Tuple<string, string>[] matches, Tuple<string, string> query)
        {
            //REMOVE THIS LINE BEFORE START CODING
            //throw new NotImplementedException();

            // Create an adjacency list to represent connections between nodes
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
            
            foreach (var match in matches)
            {
                if (!graph.ContainsKey(match.Item1))
                    graph[match.Item1] = new List<string>();
                graph[match.Item1].Add(match.Item2);

                if (!graph.ContainsKey(match.Item2))
                    graph[match.Item2] = new List<string>();
                graph[match.Item2].Add(match.Item1);
            }

            Queue<string> queue = new Queue<string>();
            HashSet<string> visited = new HashSet<string>();
            queue.Enqueue(query.Item1);
            visited.Add(query.Item1);
            int connections = 0;

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                for (int i = 0; i < levelSize; i++)
                {
                    string current = queue.Dequeue();
                    if (current == query.Item2)
                        return connections;

                    foreach (var neighbor in graph[current])
                    {
                        if (!visited.Contains(neighbor))
                        {
                            queue.Enqueue(neighbor);
                            visited.Add(neighbor);
                        }
                    }
                }
                connections++;
            }

            return 0; // No connection found
        }


    }

    #endregion
}









