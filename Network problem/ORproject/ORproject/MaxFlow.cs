using System;
using System.Collections;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORproject
{
    public class MaxFlow
    {

        public int numberOfVertics;
        public int[] parent;
        public int[] previousParent; 

        // Create a visited array and mark all vertices as not visited
        private Boolean[] visited;

        private Queue<Int32> queue;
        public int[][] rGraph;
        public int[][] previousGraph;
        public int[][] basicGraph;
        //calculate to know the source "S" and sink "t" 
        private int source, destination;
        private int path_Flow = 0 , max_Flow = 0;

        public MaxFlow(int numberOfVertics, int[][] graph)
        {
            this.numberOfVertics = numberOfVertics;
            
            parent = new int[numberOfVertics ];
            
            visited = new Boolean[numberOfVertics];
            queue = new Queue<Int32>();
            
            setSource(graph);
            setDistination(graph);

            basicGraph = new int[numberOfVertics][];
            rGraph = new int[numberOfVertics][];
            previousGraph = new int[numberOfVertics][];

            CopyGraph(graph,rGraph);
            CopyGraph(graph,basicGraph);

            

        }
        public void copyParent(int[] basicMatrix, int[] matrix , int size)
        {
            matrix = new int[size];
            for (int i = 0; i < size; i++)
            {
                matrix[i] = basicMatrix[i];
            }


        }

        public void setSource(int[][] graph)
        {
            int sum;
            for (int j = 0; j < numberOfVertics; j++)
            {
                sum = -1;
                for (int i = 0; i < numberOfVertics; i++)
                {
                    sum += graph[i][j];
                    if (sum != -1)
                        break;
                }
                if (sum == -1)
                {
                    source = j;
                    break;
                }
                    
            }
            
        }

        public void setDistination(int[][] graph)
        {
            int sum;
            for (int i = 0; i < numberOfVertics; i++)
            {
                sum = -1;
                for (int j = 0; j < numberOfVertics ; j++)
                {
                    sum += graph[i][j];
                    if (sum != -1)
                        break;
                }
                if (sum == -1)
                {
                    destination = i;
                    break;
                }

            }

        }


        /*Returns true if there is a path from source 's' to sink 't' in
          residual graph. Also fills parent[] to store the path */

        public bool foundPath()
        {

            int u;

            for (int i = 0; i < numberOfVertics; i++)
            {
                visited[i] = false;
                parent[i] = -1;
            }
            //  enqueue source vertex and mark source vertex as visited
            queue.Enqueue(source);
            visited[source] = true;
            parent[source] = -1;

            while (queue.Count != 0)
            {
                u = queue.Dequeue();

                for (int v = 0; v < numberOfVertics; v++)
                {
                    if ((visited[v] == false) && (rGraph[u][v] > 0))
                    {

                        queue.Enqueue(v);
                        parent[v] = u;
                        visited[v] = true;

                    }
                }

            }
            // If we reached sink in BFS starting from source, then return
            // true, else false

            return (visited[destination] == true);
        }

      

        public void CopyGraph(int[][] graph,int[][] copyGraph)
        {
            
            for (int u = 0; u < numberOfVertics; u++)
            {
                copyGraph[u]=new int[numberOfVertics];
                for (int v = 0; v < numberOfVertics; v++)
                    copyGraph[u][v] = graph[u][v];
            }
        }

        // Create a residual graph and fill the residual graph with
        // given capacities in the original graph as residual capacities
        // in residual graph
        public void residualGraph()
        {
            int u, v;
            // Find minimum residual capacity of the edges along the
            // path filled by BFS.

            path_Flow = Int32.MaxValue;

            for (v = destination; v != source; v = parent[v])
            {
                u = parent[v];
                path_Flow = Math.Min(path_Flow, rGraph[u][v]);
            }

            // update residual capacities of the edges and reverse edges
            // along the path


            for (v = destination; v != source; v = parent[v])
            {
                u = parent[v];
                rGraph[u][v] -= path_Flow;
                rGraph[v][u] += path_Flow;
            }
            // Add path flow to overall flow
            max_Flow += path_Flow;

        }
        public int getPathMinValue()
        {
            return path_Flow;
        }

        public int getMaxFlow()
        {
            return max_Flow;
        }

        // Returns tne maximum flow from s to t in the given graph
     //   public int fordFulkerson()
      //  {
            //int u, v;
           // int max_Flow = 0; // There is no flow initially
         
            // Augment the flow while there is path from source to sink

        //    while (BFS())
          //  {
                // Find minimum residual capacity of the edges along the
                // path filled by BFS.

          //      path_Flow = Int32.MaxValue;

         //       for (v = destination; v != source; v = parent[v])
         //       {
          //          u = parent[v];
          //          path_Flow = Math.Min(path_Flow, rGraph[u][v]);
          //      }

               // CopyGraph(rGraph, previousGraph);


                // update residual capacities of the edges and reverse edges
                // along the path

               
          //      for (v = destination; v != source; v = parent[v])
            //    {
              //      u = parent[v];
                //    rGraph[u][v] -= path_Flow;
                  //  rGraph[v][u] += path_Flow;
               // }
           //      gleeHandler.printAugmentedPath(rGraph,numberOfVertics,parent);
          //      gleeHandler.printGraph(rGraph, numberOfVertics);
            //        gleeHandler.printResdualGraph(rGraph,basicGraph,numberOfVertics);
                
                // Add path flow to overall flow
            //    max_Flow += path_Flow;
           // }
            
            // Return the overall flow
        //    return max_Flow;
       // }


        public void printGraph()
        {
            
        }
    }
}
 
