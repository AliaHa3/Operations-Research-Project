using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ORproject
{
    /// <summary>
    /// Interaction logic for blankWindow.xaml
    /// </summary>
    public partial class blankWindow : Window
    {
        public int node_number;

        public blankWindow()
        {
            InitializeComponent();

            node_number = 0;
        }

        private void Add_destination_Click(object sender, RoutedEventArgs e)
        {
            node_number = Int32.Parse(Node_distination.Text);

        }

        public int get_node_destination()
        {
            return node_number;
        }
    }
}
