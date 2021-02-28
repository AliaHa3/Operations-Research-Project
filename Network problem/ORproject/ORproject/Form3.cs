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
    public partial class MstViewer : Form
    {
        private MST mst;
        private bool findNextNode = true, calculateDistance = false, finish = false;
        private int node;

        public MstViewer(MST mst)
        {
            InitializeComponent();
            this.mst = new MST(mst.graphMatrix,mst.numberOfVertics);
            findNextNode = true;
            calculateDistance = false;
            finish = false;
            node = 0;
        }

        private void MstViewer_Load(object sender, EventArgs e)
        {

        }

        private void next_button_Click(object sender, EventArgs e)
        {
            if (findNextNode)
            {
                node = mst.minKey();
                Step.Text = "Min node is " + (node + 1);
                MainWindow.tempGraph = MainWindow.printMstMinNode(mst.graphMatrix,mst.numberOfVertics,node,
                                                             mst.parent,MainWindow.tempGraph);
                findNextNode = false;
                calculateDistance = true;
            }
            else if ((calculateDistance) && (!finish))
            {
                if (mst.count < mst.numberOfVertics)
                {
                    mst.primMST();
                    Step.Text = "calculate distance ";
                    
                    MainWindow.tempGraph = MainWindow.clacuMst(mst.graphMatrix, node, MainWindow.tempGraph);
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
                
                Step.Text = "finish\n";
                MessageBox.Show("finish\n" );
            }
        }
    }
}
