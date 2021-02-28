using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Forms;
using Microsoft.Glee.Drawing;
using Brushes = System.Windows.Media.Brushes;
using Edge = Microsoft.Glee.Drawing.Edge;
using Label = System.Windows.Controls.Label;
using MessageBox = System.Windows.MessageBox;
using Node = Microsoft.Glee.Drawing.Node;
using TextBox = System.Windows.Controls.TextBox;


namespace ORproject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MaxFlowViewer maxFlowform;
        public static dijkstraViewer dijkstraForm;
        public static MstViewer mstForm;

        public int distination_number = 0;
        public blankWindow blank;
        private static Microsoft.Glee.GraphViewerGdi.GViewer viewer = new Microsoft.Glee.GraphViewerGdi.GViewer();
        public static Microsoft.Glee.Drawing.Graph tempGraph = new Microsoft.Glee.Drawing.Graph("tempGraph");

        public  MaxFlow max;
        public ShortestPath dijkstra;
        public MST mst;


        public int VerticsNum;
        private TextBox[][] textBoxs_array;
        private StackPanel[] stackPanels;
        private Label enterLabel = new Label();
        public static int[][] graph_matrix;
        private bool ok = true;
        
        public MainWindow()
        {
          
 
            InitializeComponent();
           
            this.Show();

            sp0.CanVerticallyScroll = true;
            sp0.CanHorizontallyScroll = true;
            sp1.CanHorizontallyScroll = true;
            sp1.CanVerticallyScroll = true;
            
            int[][] graph = new int[6][]{
                      new int[]  {0, 16, 13, 0, 0, 0},
                     new int[]  {0, 0, 10, 12, 0, 0},
                     new int[]  {0, 4, 0, 0, 14, 0},
                     new int[]  {0, 0, 9, 0, 0, 20},
                     new int[]  {0, 0, 0, 7, 0, 4},
                     new int[]  {0, 0, 0, 0, 0, 0}
                      };

            int[][] graph2 = new int[8][]{ new int[] 
                                {0, 8, 7, 4, 0, 0,0,0},
                      new int[]  {0, 0, 2, 0, 3, 9,0,0},
                   new int[ ]     {0, 0, 0, 5, 0, 6,0,0},
                      new int[ ]  {0, 0, 0, 0, 0, 7,2,0},
                     new int[ ]   {0, 0, 0, 0, 0, 0,0,9},
                     new int[ ]   {0, 0, 0, 0, 3, 0,4,5},
                     new int[]    {0,0,0,0,0,0,0,8},
                     new int[]    {0,0,0,0,0,0,0,0}
                      };
            int[][] graph3 = new int[9][]{
                       new int[]  {0, 4, 0, 0, 0, 0, 0, 8, 0},
                     new int[] {4, 0, 8, 0, 0, 0, 0, 11, 0},
                    new int[]  {0, 8, 0, 7, 0, 4, 0, 0, 2},
                    new int[]  {0, 0, 7, 0, 9, 14, 0,+ 0, 0},
                     new int[] {0, 0, 0, 9, 0, 10, 0, 0, 0},
                      new int[]{0, 0, 4, 0, 10, 0, 2, 0, 0},
                      new int[]{0, 0, 0, 14, 0, 2, 0, 1, 6},
                      new int[]{8, 11, 0, 0, 0, 0, 1, 0, 7},
                      new int[]{0, 0, 2, 0, 0, 0, 6, 7, 0}
                     };

            int [][] graph4 = new int[5][]
                {
                    new int[]{0,9,6,5,3},
                    new int[]{0,0,0,0,0},
                    new int[]{0,2,0,4,0},
                    new int[]{0,0,0,0,0},
                    new int[]{0,0,0,0,0}
                };


            int[][] graph5 = new int[5][]{
                        new int[] {0, 2, 0, 6, 0},
                      new int[]{2, 0, 3, 8, 5},
                      new int[]{0, 3, 0, 0, 7},
                      new int[]{6, 8, 0, 0, 9},
                      new int[]{0, 5, 7, 9, 0},
                     }; ;
        
            /*
             * mst = new MST(graph5,5);
             mstForm = new MstViewer(mst);
            tempGraph =  mstPrintGraph(graph5,mst.numberOfVertics);
            */

     
          /*   
            //enter the destination node -1 
            dijkstra = new ShortestPath(graph4,5,4-1);
            dijkstraForm =new dijkstraViewer(dijkstra);
          //  printGraph(graph4,5,dijkstraForm);
            printDijkstraGraph(graph4,5,dijkstra.distance);
        */
           /*
            dijkstra = new ShortestPath(graph3,9,9);
            dijkstraForm = new dijkstraViewer(dijkstra);
            printGraph(graph3,9,dijkstraForm);
            */            

            /*
            max = new MaxFlow(6, graph);
            maxFlowform = new MaxFlowViewer(max);
            printGraph(max.basicGraph,max.numberOfVertics,maxFlowform);
            */
        
       /*     max = new MaxFlow(8,graph2);
            maxFlowform = new GraphViewer(max);
            printGraph(graph2,8);
        */  
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(GetNumBox.Text, out VerticsNum))
                MessageBox.Show("Enter a valid values", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            else
            {
                graph_matrix = new int[VerticsNum][];
                for (int i = 0; i < VerticsNum; i++)
                {
                    graph_matrix[i] = new int[VerticsNum];

                }
                NumButton.IsEnabled = false;
                CostButton.Visibility = Visibility.Visible;
                MaxFlowButton.Visibility = Visibility.Visible;
                dijkstraButton.Visibility = Visibility.Visible;
                primsButton.Visibility = Visibility.Visible;

                
                MaxFlowButton.IsEnabled = false;
                dijkstraButton.IsEnabled = false;
                primsButton.IsEnabled = false;
                    

                textBoxs_array = new TextBox[VerticsNum][];
                stackPanels = new StackPanel[VerticsNum];
                enterLabel.Content = "\nEnter the array of graph_matrix \n";
                enterLabel.FontSize = 19;
                enterLabel.Foreground = Brushes.Purple;
                sp1.Children.Add(enterLabel);

                for (int i = 0; i < VerticsNum; i++)
                {
                    textBoxs_array[i] = new TextBox[VerticsNum];

                }
                for (int i = 0; i < VerticsNum; i++)
                {
                    stackPanels[i] = new StackPanel();
                    //  stackPanels[i].Name = "sp1 " + i.ToString();
                    stackPanels[i].Orientation = System.Windows.Controls.Orientation.Horizontal;
                    stackPanels[i].CanVerticallyScroll = true;

                }
                for (int i = 0; i < VerticsNum; i++)
                {
                    for (int j = 0; j < VerticsNum; j++)
                    {
                        textBoxs_array[i][j] = new TextBox();
                        textBoxs_array[i][j].Height = 20;
                        textBoxs_array[i][j].Width = 60;
                        textBoxs_array[i][j].Text = "";
                        textBoxs_array[i][j].Background = Brushes.FloralWhite;
                        textBoxs_array[i][j].Foreground = Brushes.DeepPink;
                        textBoxs_array[i][j].TextAlignment = TextAlignment.Center;
                        textBoxs_array[i][j].BorderBrush = Brushes.DarkViolet;
                        stackPanels[i].Children.Add(textBoxs_array[i][j]);


                    }
                    stackPanels[i].HorizontalAlignment = HorizontalAlignment;
                    sp1.Children.Add(stackPanels[i]);

                }


            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ok = true;
            for (int i = 0; i < VerticsNum; i++)
            {
                for (int j = 0; j < VerticsNum; j++)
                {
                    if (!int.TryParse(textBoxs_array[i][j].Text, out graph_matrix[i][j]))
                        ok = false;
                    else if (graph_matrix[i][j] < 0)
                        ok = false;

                }

            }
            if (!ok)
                MessageBox.Show("Enter a valid values", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            MaxFlowButton.IsEnabled = true;
            dijkstraButton.IsEnabled = true;
            primsButton.IsEnabled = true;
        }

       public static void printGraph(int[][] graphMatrix,int numberOfVertex,Form form )       
        {

           
            //create a graph object
            Microsoft.Glee.Drawing.Graph graph = new Microsoft.Glee.Drawing.Graph("graph");

            for (int i = 0; i < numberOfVertex ; i++)
            {
                for (int j = 0; j < numberOfVertex; j++)
                {
                    if (graphMatrix[i][j] > 0)
                    {
                        Edge e = graph.AddEdge("Node" + (i+1), "Node" + (j+1));

                   
                        e.EdgeAttr.Label = graphMatrix[i][j].ToString();
                    }


                }
                
            }
         
            
            

            //bind the graph to the viewer
            viewer.Graph = graph;

            //associate the viewer with the form
            form.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            form.Controls.Add(viewer);
            form.ResumeLayout();

            //show the form
            form.Show();
           
        }
        
        public static void printAugmentedPath(int[][] graphMatrix, int numberOfVertex, int[] parent)
        {
            Microsoft.Glee.Drawing.Graph graph = new Microsoft.Glee.Drawing.Graph("graph");

            for (int i = 0; i < numberOfVertex; i++)
            {
                for (int j = 0; j < numberOfVertex; j++)
                {
                    if (graphMatrix[i][j] > 0)
                    {
                        Edge e = graph.AddEdge("Node" + (i+1), "Node" + (j+1));
                        e.EdgeAttr.Label = graphMatrix[i][j].ToString();
                    }


                }

            }

            int u;
            try
            {



                for (int v = numberOfVertex - 1; v != 0; v = parent[v])
                {
                    u = parent[v];
                    Node n1 = graph.FindNode("Node" + (u + 1));
                    Node n2 = graph.FindNode("Node" + (v + 1));

                    n1.Attr.Fillcolor = Microsoft.Glee.Drawing.Color.Red;
                    n2.Attr.Fillcolor = Microsoft.Glee.Drawing.Color.Red;

                    //    Edge e = graph.AddEdge("Node" + u, "Node" + v);
                    //   e.EdgeAttr.Color = Microsoft.Glee.Drawing.Color.Red;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Your graph is incorrect \nGraph should be directed with source and sink");
            }



            //bind the graph to the viewer
            viewer.Graph = graph;

            //associate the viewer with the form
            //  form.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            maxFlowform.Controls.Add(viewer);
            maxFlowform.ResumeLayout();

            //show the form
            maxFlowform.Show();

            
        }



        public static  void printDirectGraph(int[][] graphMatrix, int[][] basicGraph, int numberOfVertics)
        {
            Microsoft.Glee.Drawing.Graph graph = new Microsoft.Glee.Drawing.Graph("graph");

            for (int i = 0; i < numberOfVertics; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if ((basicGraph[j][i] > 0)&&graphMatrix[i][j] >0)
                    {
                        Edge e = graph.AddEdge("Node" + (j+1), "Node" + (i+1));
                        e.EdgeAttr.Label = graphMatrix[i][j].ToString() + "/" + basicGraph[j][i];
                        e.EdgeAttr.Color = Microsoft.Glee.Drawing.Color.Green;
                    }
                }
            }

            //bind the graph to the viewer
            viewer.Graph = graph;

            //associate the viewer with the form
            maxFlowform.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            maxFlowform.Controls.Add(viewer);
            maxFlowform.ResumeLayout();

            //show the form
            maxFlowform.Show();
        }

        public static void printResdualGraph(int[][] graphMatrix, int[][] basicGraph, int numberOfVertics)
        {
            Microsoft.Glee.Drawing.Graph graph = new Microsoft.Glee.Drawing.Graph("graph");

            for (int i = 0; i < numberOfVertics; i++)
            {
                for (int j = 0; j < numberOfVertics; j++)
                {
                    if ((basicGraph[i][j] > 0)&&(graphMatrix[i][j] > 0))
                    {
                        Edge e = graph.AddEdge("Node" + (i+1), "Node" + (j+1));
                        e.EdgeAttr.Label = graphMatrix[i][j].ToString() + "/" + basicGraph[i][j];
                        e.EdgeAttr.Color = Microsoft.Glee.Drawing.Color.Red;
                        e.EdgeAttr.Fontcolor = Microsoft.Glee.Drawing.Color.Red;

                    }
                    else if (graphMatrix[i][j] > 0)
                    {
                        Edge e = graph.AddEdge("Node" + (i+1), "Node" + (j+1));
                        e.EdgeAttr.Color = Microsoft.Glee.Drawing.Color.Blue;
                        e.EdgeAttr.Fontcolor = Microsoft.Glee.Drawing.Color.Blue;
                        e.EdgeAttr.Label = graphMatrix[i][j].ToString() ;

                    }
                }
            }

            
            //bind the graph to the viewer
            viewer.Graph = graph;

            //associate the viewer with the form
            maxFlowform.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            maxFlowform.Controls.Add(viewer);
            maxFlowform.ResumeLayout();

            //show the form
            maxFlowform.Show();
        }


        public static void printDijkstraGraph(int[][] graphMatrix, int numberOfVertex, int[] distance)
        {


            //create a graph object
            Microsoft.Glee.Drawing.Graph graph = new Microsoft.Glee.Drawing.Graph("graph");

            for (int i = 0; i < numberOfVertex; i++)
            {
                for (int j = 0; j < numberOfVertex; j++)
                {
                    if (graphMatrix[i][j] > 0)
                    {
                        Edge e = graph.AddEdge("Node" + (i + 1), "Node" + (j + 1));

                        e.EdgeAttr.Label = graphMatrix[i][j].ToString();
                    }


                }

            }


            for (int i = 0; i < numberOfVertex; i++)
            {
                Node n = graph.FindNode("Node" + (i + 1));
                if (distance[i] == Int32.MaxValue)
                    n.Attr.Label += "\n(" + "infinity"+")";
                else
                    n.Attr.Label += "\n(" + distance[i].ToString() + ")";

            }

            //bind the graph to the viewer
            viewer.Graph = graph;

            //associate the viewer with the form
            dijkstraForm.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            dijkstraForm.Controls.Add(viewer);
            dijkstraForm.ResumeLayout();

            //show the form
            dijkstraForm.Show();

        }

        public static Microsoft.Glee.Drawing.Graph printMinNode(int[][] graphMatrix, int numberOfVertex,int[]distance,int minNode)
        {


            //create a graph object
            Microsoft.Glee.Drawing.Graph graph = new Microsoft.Glee.Drawing.Graph("graph");

            for (int i = 0; i < numberOfVertex; i++)
            {
                for (int j = 0; j < numberOfVertex; j++)
                {
                    if (graphMatrix[i][j] > 0)
                    {
                        Edge e = graph.AddEdge("Node" + (i + 1), "Node" + (j + 1));

                        e.EdgeAttr.Label = graphMatrix[i][j].ToString();
                    }


                }

            }


            for (int i = 0; i < numberOfVertex; i++)
            {
                Node n = graph.FindNode("Node" + (i + 1));
                if (distance[i] == Int32.MaxValue)
                    n.Attr.Label += "\n(" + "infinity"+")";
                else
                    n.Attr.Label += "\n(" + distance[i].ToString()+")";
            }

            Node n1 = graph.FindNode("Node" + (minNode + 1));
            n1.Attr.Fillcolor = Microsoft.Glee.Drawing.Color.Red;

            //bind the graph to the viewer
            viewer.Graph = graph;

            //associate the viewer with the form
            dijkstraForm.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            dijkstraForm.Controls.Add(viewer);
            dijkstraForm.ResumeLayout();

            //show the form
            dijkstraForm.Show();
            return graph;
        }

        public static void printCalcDistance(int[][] graphMatrix, int numberOfVertex, int[] distance, int minNode,
                                            Microsoft.Glee.Drawing.Graph graph1)
        {


            //create a graph object
            Microsoft.Glee.Drawing.Graph graph = graph1;



            Node n1 = graph.FindNode("Node" + (minNode + 1));
           
            foreach (var i in n1.OutEdges)
            {
                i.EdgeAttr.Color = Microsoft.Glee.Drawing.Color.Green;
                i.EdgeAttr.Fontcolor = Microsoft.Glee.Drawing.Color.Green;
            }


            for (int i = 0; i < numberOfVertex; i++)
            {
                Node n = graph.FindNode("Node" + (i + 1));
                if (distance[i] != Int32.MaxValue)
                    n.Attr.Label += "->\n(" + distance[i].ToString() + ")";
            }

            //bind the graph to the viewer
            viewer.Graph = graph;

            //associate the viewer with the form
            dijkstraForm.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            dijkstraForm.Controls.Add(viewer);
            dijkstraForm.ResumeLayout();

            //show the form
            dijkstraForm.Show();

        }

        public static void printDijkstraPath(int[][] graphMatrix, int numberOfVertex,int[]distance,
                                                int[] path , int distination)
        {


            //create a graph object
            Microsoft.Glee.Drawing.Graph graph = new Microsoft.Glee.Drawing.Graph("graph");

            for (int i = 0; i < numberOfVertex; i++)
            {
                for (int j = 0; j < numberOfVertex; j++)
                {
                    if (graphMatrix[i][j] > 0)
                    {
                        Edge e = graph.AddEdge("Node" + (i + 1), "Node" + (j + 1));

                        e.EdgeAttr.Label = graphMatrix[i][j].ToString();
                    }


                }

            }


            for (int i = 0; i < numberOfVertex; i++)
            {
                Node n = graph.FindNode("Node" + (i + 1));
                if (distance[i] == Int32.MaxValue)
                    n.Attr.Label += "\n(" + "infinity" + ")";
                else
                    n.Attr.Label += "\n(" + distance[i].ToString() + ")";

            }

            int iTemp = distination;
            int jTemp=0;

            while (iTemp != (-1))
            {
                jTemp = path[iTemp];

                if (iTemp != 0)
                {
                    Node nsource = graph.FindNode("Node" + (jTemp + 1));
                    Node ntarget = graph.FindNode("Node" + (iTemp + 1));
                    foreach (var edge in nsource.OutEdges)
                    {
                        if (edge.TargetNode == ntarget)
                            edge.EdgeAttr.Color = Microsoft.Glee.Drawing.Color.Red;
                    }
                    
                }


                iTemp = jTemp;
            }

            //bind the graph to the viewer
            viewer.Graph = graph;

            //associate the viewer with the form
            dijkstraForm.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            dijkstraForm.Controls.Add(viewer);
            dijkstraForm.ResumeLayout();

            //show the form
            dijkstraForm.Show();

        }

        public static Microsoft.Glee.Drawing.Graph mstPrintGraph(int[][] graphMatrix, int numberOfVertex)
                                                     
        {
            //create a graph object
         //   Microsoft.Glee.Drawing.Graph graph = new Microsoft.Glee.Drawing.Graph("graph");

            for (int i = 0; i < numberOfVertex; i++)
            {
                for (int j = i; j < numberOfVertex; j++)
                {
                    if (graphMatrix[i][j] > 0)
                    {
                        Edge e = tempGraph.AddEdge("Node" + (i + 1), "Node" + (j + 1));
                        e.EdgeAttr.ArrowHeadAtTarget = ArrowStyle.None;
                        
                        e.EdgeAttr.Label = graphMatrix[i][j].ToString();
                    }


                }

            }


            //bind the graph to the viewer
            viewer.Graph = tempGraph;

            //associate the viewer with the form
            mstForm.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            mstForm.Controls.Add(viewer);
            mstForm.ResumeLayout();

            //show the form
            mstForm.Show();

            return tempGraph;
        }


        public static Microsoft.Glee.Drawing.Graph printMstMinNode(int[][] graphMatrix, int numberOfVertex, int minNode,
                                                                      int[] parent, Microsoft.Glee.Drawing.Graph graph1)
        {


            //create a graph object
           // Microsoft.Glee.Drawing.Graph graph = graph1;

            Node n1 = tempGraph.FindNode("Node" + (minNode + 1));
            //n1.Attr.Fillcolor = Microsoft.Glee.Drawing.Color.Red;
            n1.Attr.Color = Microsoft.Glee.Drawing.Color.Red;

            if (minNode != 0)
            {
                Node n0 = tempGraph.FindNode("Node" + (parent[minNode] + 1));

                foreach (Edge e in n0.OutEdges)
                {
                    if (e.TargetNode == n1)
                        e.EdgeAttr.Color = Microsoft.Glee.Drawing.Color.Red;

                }
            }

            //bind the graph to the viewer
            viewer.Graph = tempGraph;

            //associate the viewer with the form
            mstForm.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            mstForm.Controls.Add(viewer);
            mstForm.ResumeLayout();

            //show the form
            mstForm.Show();
            return tempGraph;
        }
       
        public static Microsoft.Glee.Drawing.Graph clacuMst(int[][] graphMatrix,int minNode,
                                                                      Microsoft.Glee.Drawing.Graph graph1)
        {


            //create a graph object
          //  Microsoft.Glee.Drawing.Graph graph = graph1;

            Node n1 = tempGraph.FindNode("Node" + (minNode + 1));

            foreach (Edge e in n1.OutEdges)
            {
                e.EdgeAttr.Color = Microsoft.Glee.Drawing.Color.Green;
            }

            //bind the graph to the viewer
            viewer.Graph = tempGraph;

            //associate the viewer with the form
            mstForm.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            mstForm.Controls.Add(viewer);
            mstForm.ResumeLayout();

            //show the form
            mstForm.Show();
            return tempGraph;
        }

        private void primsButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Do Not Close The Window Of Solution to solve Many Graph");
            mst = new MST(graph_matrix, VerticsNum);
            mstForm = new MstViewer(mst);
            MainWindow.tempGraph = new Graph("graph");
            MainWindow.tempGraph = mstPrintGraph(graph_matrix, mst.numberOfVertics);
            int i = 1;

        }

        private void dijkstraButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Do Not Close The Window Of Solution to solve Many Graph");
            Node_distination.Visibility = Visibility.Visible;
            add_distination.Visibility = Visibility.Visible;
            
          
        }
        
        private void MaxFlowButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Do Not Close The Window Of Solution to solve Many Graph");
            max = new MaxFlow(VerticsNum,graph_matrix);
            
            maxFlowform = new MaxFlowViewer(max);
            printGraph(max.basicGraph, max.numberOfVertics, maxFlowform);
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void add_distination_Click(object sender, RoutedEventArgs e)
        {
            distination_number = Int32.Parse(Node_distination.Text);
            dijkstra = new ShortestPath(graph_matrix, VerticsNum, distination_number-1);
            dijkstraForm = new dijkstraViewer(dijkstra);

            printDijkstraGraph(graph_matrix, VerticsNum, dijkstra.distance);
        }

       

    }

    
        
}
