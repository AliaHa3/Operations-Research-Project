using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORproject
{
    public class MST
    {
        public int[][] graphMatrix;
        public int[] parent; // Array to store constructed MST
        public int[] key;  // Key values used to pick minimum weight edge in cut
        private bool[] mstSet;  // To represent set of vertices not yet included in MST
        public int numberOfVertics;
        private int minNodeIndex;
        public int count;

        public MST(int[][] graph, int numberOfVertics)
        {
            parent = new int[numberOfVertics];
            key = new int[numberOfVertics];
            mstSet = new bool[numberOfVertics];
            this.numberOfVertics = numberOfVertics;
            count = 0;
            minNodeIndex = 0;
            copyGraph(graph);
            initilize();
        }

        private void copyGraph(int[][] graph)
        {
            graphMatrix = new int[numberOfVertics][];
            for (int i = 0; i < numberOfVertics; i++)
            {
                graphMatrix[i] = new int[numberOfVertics];
                for (int j = 0; j < numberOfVertics; j++)
                {
                    graphMatrix[i][j] = graph[i][j];
                }
            }
        }

        private void initilize()
        {
              // Initialize all keys as INFINITE
            for (int i = 0; i < numberOfVertics; i++)
            {
                key[i] = Int32.MaxValue;
                mstSet[i] = false;
            }
            // Always include first 1st vertex in MST.

            key[0] = 0;     // Make key 0 so that this vertex is picked as first vertex
            parent[0] = -1; // First node is always root of MST
        }

        // A utility function to find the vertex with minimum key value, from
        // the set of vertices not yet included in MST
        public int minKey()
        {
            // Initialize min value
            int min = Int32.MaxValue;
 
            for (int v = 0; v < numberOfVertics; v++)
                 if (mstSet[v] == false && key[v] < min)
                 {
                     min = key[v];
                     minNodeIndex = v; 
                 }
 
             return minNodeIndex;
        }

        // Function to construct and print MST for a graph represented using adjacency
        // matrix representation
        public void primMST()
        {
     
         // The MST will have V vertices
        if (count < numberOfVertics)
        {    
            // Pick thd minimum key vertex from the set of vertices
            // not yet included in MST
       
 
            // Add the picked vertex to the MST Set
            mstSet[minNodeIndex] = true;
 
            // Update key value and parent index of the adjacent vertices of
            // the picked vertex. Consider only those vertices which are not yet
            // included in MST
            for (int v = 0; v < numberOfVertics; v++)
            {
                 // graph[u][v] is non zero only for adjacent vertices of m
                // mstSet[v] is false for vertices not yet included in MST
                // Update the key only if graph[u][v] is smaller than key[v]
                if ((graphMatrix[minNodeIndex][v] > 0) && (mstSet[v] == false))
                {
                    if (graphMatrix[minNodeIndex][v] < key[v])
                    {
                        parent[v] = minNodeIndex;
                        key[v] = graphMatrix[minNodeIndex][v];
                    }
                }
            }
            count++;
       }
    }




    }
}
