using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Glee.Drawing;

using Microsoft.Glee;
using Edge = Microsoft.Glee.Drawing.Edge;

namespace ORproject
{
    public partial class MaxFlowViewer : Form
    {
       
        private MaxFlow maxFlow;
       
        
        private bool augmentedPath = true, residualGraph = false, final = false;

        public MaxFlowViewer(MaxFlow max)
        {
            InitializeComponent();

            augmentedPath = true;
            residualGraph = false;
            final = false;

            this.maxFlow = new MaxFlow(max.numberOfVertics, max.basicGraph);
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void previous_button_Click(object sender, EventArgs e)
        {
            
        }

        private void next_button_Click(object sender, EventArgs e)
        {
            
            if (augmentedPath)
            {
                //حساب الطريق
                if (maxFlow.foundPath())
                {
                    //طباعة الطريق
                    Step.Text = "Augmented Path";;
                    MainWindow.printAugmentedPath(maxFlow.rGraph,maxFlow.numberOfVertics,maxFlow.parent);
                    augmentedPath = false;
                    residualGraph = true;
                }
                else
                {
                    final = true;
                }
                
                
            }
            else if ((residualGraph)&&(!final))
            {
                //حساب الغراف
                maxFlow.residualGraph();
                //طباعة الغراف
                Step.Text = "Residual Graph\nMin Value Path =" + maxFlow.getPathMinValue();
                MainWindow.printResdualGraph(maxFlow.rGraph,maxFlow.basicGraph,maxFlow.numberOfVertics);
                residualGraph = false;
                augmentedPath = true;
            }
             if(final)
            {
                //لم يعد هناك طريق 
                MainWindow.printDirectGraph(maxFlow.rGraph,maxFlow.basicGraph,maxFlow.numberOfVertics);
                 MessageBox.Show( "Max Flow  =" +maxFlow.getMaxFlow().ToString());
                Step.Text = "Max = " +maxFlow.getMaxFlow().ToString();
             
            }
        }

        
    }
}
