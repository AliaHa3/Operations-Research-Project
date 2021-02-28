using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORproject
{
    public partial class dijkstraViewer : Form
    {
        private ShortestPath dijkstra;
        private bool findNextNode = true, calculateDistance = false, finish = false;
        private int node;

        public dijkstraViewer(ShortestPath shortest)
        {
            
            InitializeComponent();
            this.dijkstra = new ShortestPath(shortest.graphMatrix,shortest.numberOfVertics,shortest.secondNode);
            findNextNode = true;
            calculateDistance = false;
            finish = false;
            node = 0;
        }

        private void dijkstraViewer_Load(object sender, EventArgs e)
        {

        }

        private void next_button_Click(object sender, EventArgs e)
        {
         
            
            if (findNextNode)
            {
                node = dijkstra.getClosestUnmarkedNode();
                Step.Text = "Min node is " + (node+1);
                MainWindow.tempGraph = MainWindow.printMinNode(dijkstra.graphMatrix,dijkstra.numberOfVertics,dijkstra.distance,
                                        node);
                findNextNode = false;
                calculateDistance = true;
            }
            else if ( (calculateDistance)&& (!finish) )
            {
                if (dijkstra.count < dijkstra.numberOfVertics)
                {
                    
                    dijkstra.calculateDistance();
                    Step.Text = "calculate distance " ; 
                    MainWindow.printCalcDistance(dijkstra.graphMatrix,dijkstra.numberOfVertics,
                                                dijkstra.distance,node,MainWindow.tempGraph);
                    calculateDistance = false;
                    findNextNode = true;
                }
                else
                {
                    
                    calculateDistance = false;
                    finish = true;
                }
                
                
            }
            if (finish)
            {
                MainWindow.printDijkstraPath(dijkstra.graphMatrix,dijkstra.numberOfVertics,dijkstra.distance,
                                               dijkstra.predecessor,dijkstra.secondNode);
                Step.Text = "finish\n" + dijkstra.get_path();
                MessageBox.Show("finish\n" + dijkstra.get_path());
            }
        }
    }
}
