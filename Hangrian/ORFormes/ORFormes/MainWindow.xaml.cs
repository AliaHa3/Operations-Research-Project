using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ORFormes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    
    public partial class MainWindow : Window
    {
        public int person_num;
        private TextBox[][]arr;
        private StackPanel[] stackPanels;
        private Label enterLabel=new Label();
        public static int[][] costs;
        private bool ok = true;
      //  private Window solveWindow;
        private solveWindow solve;
        public MainWindow()
        {
            InitializeComponent();
            sp0.CanVerticallyScroll = true;
            sp0.CanHorizontallyScroll = true;
            sp1.CanHorizontallyScroll = true;
            sp1.CanVerticallyScroll = true;
          //  solveWindow=new Window();
        }
        


      

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(GetNumBox.Text, out person_num))
                MessageBox.Show("Enter a valid values","Error",MessageBoxButton.OK,MessageBoxImage.Error);
               
            else
            {
                costs=new int[person_num][];
                for (int i = 0; i < person_num; i++)
                {
                    costs[i]=new int[person_num];
                    
                }
                NumButton.IsEnabled = false;
                CostButton.Visibility = Visibility.Visible;
                arr = new TextBox[person_num][];
                stackPanels=new StackPanel[person_num];
                enterLabel.Content = "\nEnter the array of costs \n";
                enterLabel.FontSize = 19;
                enterLabel.Foreground = Brushes.Purple;
                sp1.Children.Add(enterLabel);
                
                for (int i = 0; i < person_num; i++)
                {
                    arr[i]=new TextBox[person_num];
                    
                }
                for (int i = 0; i < person_num; i++)
                {
                    stackPanels[i]=new StackPanel();
                  //  stackPanels[i].Name = "sp1 " + i.ToString();
                    stackPanels[i].Orientation = System.Windows.Controls.Orientation.Horizontal;
                    stackPanels[i].CanVerticallyScroll = true;

                }
                for (int i = 0; i < person_num; i++)
                {
                    for (int j = 0; j < person_num; j++)
                    {
                        arr[i][j] = new TextBox();
                        arr[i][j].Height = 20;
                        arr[i][j].Width = 60;
                        arr[i][j].Text = "";
                        arr[i][j].Background = Brushes.FloralWhite;
                        arr[i][j].Foreground = Brushes.DeepPink;
                        arr[i][j].TextAlignment=TextAlignment.Center;
                        arr[i][j].BorderBrush = Brushes.DarkViolet;
                        stackPanels[i].Children.Add(arr[i][j]);


                    }
                    stackPanels[i].HorizontalAlignment = HorizontalAlignment.Center;
                    sp1.Children.Add(stackPanels[i]);

                }
       
                
            }
        }
        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ok = true;
            for (int i = 0; i < person_num; i++)
            {
                for (int j = 0; j < person_num; j++)
                {
                    if (!int.TryParse(arr[i][j].Text, out costs[i][j]))
                        ok = false;
                    else if (costs[i][j] < 0)
                        ok = false;

                }
                
            }
            if (!ok)
                MessageBox.Show("Enter a valid values", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                CostButton.IsEnabled = false;
                solve=new solveWindow(person_num,costs);
                solve.Activate();
                solve.Visibility = Visibility.Visible;
                solve.BringIntoView();
                /*solveWindow.Activate();
                solveWindow.BringIntoView();
                solveWindow.Visibility = Visibility.Visible;*/


            }
        }

        private void GetNumBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
       

      
    }

  
}
