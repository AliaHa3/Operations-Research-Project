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
    public partial class NetworkEntry : Form
    {
        public MaxFlow max;
        private DataGridView matrix;
        public NetworkEntry()
        {
            InitializeComponent();

            
       /*    int[][] graph = new int[6][]{ new int[] 
                                {0, 16, 13, 0, 0, 0},
                      new int[]  {0, 0, 10, 12, 0, 0},
                   new int[ ]     {0, 4, 0, 0, 14, 0},
                      new int[ ]  {0, 0, 9, 0, 0, 20},
                     new int[ ]   {0, 0, 0, 7, 0, 4},
                     new int[ ]   {0, 0, 0, 0, 0, 0}
                      };


            max = new MaxFlow(6, graph);*/
        }

        private void NetworkEntry_Load(object sender, EventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {
            int number = Int32.Parse(numberVerticsText.Text);

            for (int i = 0; i < number; i++)
            {
                for (int j = 0; j < number; j++)
                {
                    TextBox t = new TextBox();
                    t.Width = 20;
                    t.Height = 20;
                    t.Margin = new Padding(2);
                    matrix_Panel.Controls.Add(t);
                }
            }
        }

        
    }
}
