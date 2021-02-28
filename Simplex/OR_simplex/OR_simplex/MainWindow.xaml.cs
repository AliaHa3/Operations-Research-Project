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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OR_simplex
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Simplex simplex;
        public Window1 window1;
        public String s = "\n";
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Readvalues(int numDecisionVar, int numSubjectTo)
        {
            for (int i = 0; i < simplex.numRow; i++)
            {
                if (i == 0)
                {
                    StackPanel s = new StackPanel();
                    sp1.Children.Add(s);
                    Label l = new Label();
                    l.Content = "enter the parameters of Decision variables : ";
                    s.Children.Add(l);
                }

                else
                {
                    StackPanel s = new StackPanel();
                    sp1.Children.Add(s);
                    Label l = new Label();
                    l.Content = "enter the parameters of subject to" + i + " :  ";
                    s.Children.Add(l);
                }
                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Horizontal;
                sp1.Children.Add(stackPanel);

                for (int j = 0; j <= numDecisionVar; j++)
                {
                    if (i == 0 && (j != numDecisionVar))
                    {
                        TextBox t = new TextBox();
                        t.Margin = new Thickness(5);
                        stackPanel.Children.Add(t);
                        t.Height = 30;
                        t.Width = 30;

                    }
                    else if (i == 0 && j == (numDecisionVar))
                        //  simplex.Total[0, numDecisionVar] = 0;
                        continue;
                    else
                    {
                        TextBox t = new TextBox();
                        t.Margin = new Thickness(5);
                        t.Height = 30;
                        t.Width = 30;
                        stackPanel.Children.Add(t);
                    }

                    Label label = new Label();
                    stackPanel.Children.Add(label);
                    label.Width = 40;
                    label.Height = 30;
                    if (j == (numDecisionVar - 1) && (i != 0))
                        label.Content = " x " + j + " ≤";
                    else if ((j == numDecisionVar - 1) && i == 0)
                    {
                        label.Content = " x " + j;
                    }

                    else if (j != numDecisionVar)
                    {
                        label.Content = " x " + j + " +";
                    }
                }
            }
            button2.Visibility = Visibility.Visible;
        }

        void solving()
        {
            //قراءة القيم من الواجهة
            int count = 0, row = 0, col = 0;
            foreach (StackPanel v in sp1.Children)
            {
                if (count %2==0 )
                {
                    count++; continue;
                }
                else  
                {
                    col = 0;
                    foreach (var VARIABLE in v.Children)
                    {
                        if (row == 0)
                        {
                            if (col < simplex.numDecisionVar)
                            {
                                if (typeof(TextBox) == VARIABLE.GetType())
                                {
                                    TextBox tb = (TextBox)VARIABLE;
                                    simplex.Total[row, col] = -Convert.ToDouble(tb.Text);
                                    col++;
                                }
                            }
                            else if (col == simplex.numDecisionVar)
                                simplex.Total[row, col] = 0;
                        }
                        else
                        {
                            if (typeof(TextBox) == VARIABLE.GetType())
                            {
                                TextBox tb = (TextBox)VARIABLE;
                                simplex.Total[row, col] = Convert.ToDouble(tb.Text);
                                col++;    
                            }
                        }
                    }
                    row++;
                    count++;
                }
            }

            //تعبئة الحلول الاساسية
            for (int i = simplex.numDecisionVar + 1; i < simplex.numCol; i++)
                simplex.Total[0, i] = 0;

            for (int i = 1; i < simplex.numRow; i++)
            {
                for (int j = simplex.numDecisionVar + 1; j < simplex.numCol; j++)
                {
                    simplex.Total[i, j] = 0;
                }
                simplex.Total[i, simplex.numDecisionVar + i] = 1;
            }
            if(Min.IsChecked==true)
                for (int i = 0; i < simplex.numDecisionVar; i++)
                    simplex.Total[0, i] = -simplex.Total[0, i];

            window1 = new Window1();
            s += printBorder();

            simplex.numOfBasicVar = 0;
            while ((simplex.numOfBasicVar != simplex.numDecisionVar)&&(!simplex.end))
            {
                //إيجاد أصغر عنصر لادخاله في الحلول الأساسية
                double aux = simplex.Total[0, 0];
                for (int i = 0; i < simplex.numDecisionVar; i++)
                {
                    if (simplex.Total[0, i] < aux)
                    {
                        aux = simplex.Total[0, i];
                        simplex.pivotCol = i;
                    }
                }

                //ايجاد النسبة الدنيا التي تجعل احد الحلول الأساسية تخرج من الحل
                for (int i = 1; i < simplex.numRow; i++)
                {
                    if (!(Double.IsInfinity(simplex.Total[i, simplex.numDecisionVar] / simplex.Total[i, simplex.pivotCol])) &&
                        (simplex.Total[i, simplex.numDecisionVar]) / simplex.Total[i, simplex.pivotCol] > 0)
                    {
                        aux = ((simplex.Total[i, simplex.numDecisionVar]) / (simplex.Total[i, simplex.pivotCol]));
                        simplex.pivotRow = i;
                        break;
                    }
                    if (i == simplex.numRow - 1 && ((Double.IsInfinity(simplex.Total[i, simplex.numDecisionVar] / simplex.Total[i, simplex.pivotCol])) ||
                                         (simplex.Total[i, simplex.numDecisionVar] / simplex.Total[i, simplex.pivotCol]) <= 0))
                    {
                        simplex.unLimited = true;
                    }
                }

                if (simplex.unLimited == false)
                {
                    for (int i = 1; i < simplex.numRow; i++)
                    {
                        if (!(Double.IsInfinity(simplex.Total[i, simplex.numDecisionVar] / simplex.Total[i, simplex.pivotCol])) &&
                            (simplex.Total[i, simplex.numDecisionVar] / simplex.Total[i, simplex.pivotCol]) > 0)

                            if (aux > (simplex.Total[i, simplex.numDecisionVar] / simplex.Total[i, simplex.pivotCol]))
                            {
                                aux = simplex.Total[i, simplex.numDecisionVar] / simplex.Total[i, simplex.pivotCol];
                                simplex.pivotRow = i;
                            }
                    }

                    s += ("\n\nThe minimum ratio is " + String.Format("{0,-4:0.00}",aux) + "  which is in Row " + simplex.pivotRow +
                                     " and column " + simplex.pivotCol);

                    //ادخال العنصر ذي القيمة الدنيا في دالة الهدف بالحلول الاساسية 
                    simplex.BasicSolution[simplex.pivotRow] = "x" + simplex.pivotCol;
                    simplex.numOfBasicVar++;
                    s += ("\n\nThe divide element is " + simplex.Total[simplex.pivotRow, simplex.pivotCol]);

                    double quotient = simplex.Total[simplex.pivotRow, simplex.pivotCol]; //عنصر القسمة 
                    for (int i = 0; i < simplex.numCol; ++i)
                    {
                        simplex.Total[simplex.pivotRow, i] = simplex.Total[simplex.pivotRow, i] / quotient;
                    }
                    //ضبط باقي الجدول
                    for (int i = 0; i < simplex.numRow; ++i)
                    {
                        if (simplex.Total[i, simplex.pivotCol] != 0 && i != simplex.pivotRow)
                        {
                            quotient = simplex.Total[i, simplex.pivotCol];
                            for (int j = 0; j < simplex.numCol; ++j)
                            {
                                simplex.Total[i, j] = simplex.Total[i, j] - quotient * simplex.Total[simplex.pivotRow, j];
                            }
                        }
                    }


                    //طباعة القيم الجديدة
                    
                    s += ("\n\nThe new table is\n\n");
                    s += printBorder();

                    simplex.end = true;
                    for (int j = 0; j < simplex.numDecisionVar; j++)
                        if (simplex.Total[0, j] != 0)
                            simplex.end = false;
                }
                else
                {
                    
                    s += ("\nThe area of solutions is Un Limited ");
                    break;
                }
            }


            //فحص هل الحل مستحيل
            for (int i = 1; i < simplex.numRow; i++)
            {
                if (simplex.Total[i, simplex.numOfBasicVar] > 0)//الثابت
                {
                    bool allnegatine = true;
                    for (int j = 0; j < simplex.numCol; j++)
                    {
                        if (simplex.Total[i, j] > 0)
                        {
                            allnegatine = false;
                        }
                    }
                    if (allnegatine == true)
                    {
                        simplex.impossible = true;
                        break;
                    }
                }
                if (simplex.Total[i, simplex.numOfBasicVar] < 0)//الثابت
                {
                    bool allpositive = true;
                    for (int j = 0; j < simplex.numCol; j++)
                    {
                        if (simplex.Total[i, j] < 0)
                        {
                            allpositive = false;
                        }
                    }
                    if (allpositive == true)
                    {
                        simplex.impossible = true;
                        break;
                    }
                }
            }

            if (simplex.impossible)
            {
                s += ("\n\nImpossible to solve");
            }
            else
            {
                if (simplex.unLimited == false)
                {
                    if ((simplex.end == true) && (simplex.numOfBasicVar != simplex.numDecisionVar))
                        s += ("\n\nMany solutions , represented as a line");
                    s += ("\nz = " +String.Format("{0,-4:0.00}", simplex.Total[0, simplex.numDecisionVar]));
                    for (int i = 1; i < simplex.numSubjectTo + 1; i++)
                        s += ("\n" + simplex.BasicSolution[i] + " : " + String.Format("{0,-4:0.00}",simplex.Total[i, simplex.numDecisionVar]));
                }
            }
            window1.lb.Items.Add(s);
            window1.Show();
        }

        String printBorder()
        {
            string temp = null;
            temp += "           ";
            for (int i = 0; i < simplex.numDecisionVar; i++)
            {
                temp += (" x" + i + "     ");
            }
            for (int i = simplex.numDecisionVar; i < simplex.numCol; i++)
            {
                if (i == simplex.numDecisionVar)
                    temp += ("   b        ");
                else
                    temp += ("s" + (i - simplex.numDecisionVar) + "      ");
            }
            temp += "\n";

            for (int i = 0; i < simplex.numRow; i++)
            {

                for (int j = 0; j < simplex.numCol; j++)
                {
                    if (j == 0)
                    {
                        if (i == 0)
                            temp += (" z      ");
                        else
                            temp += (String.Format("{0,-4:0.00}",simplex.BasicSolution[i] )+ "     ");
                    }
                    if (simplex.Total[i, j] < 0)
                        temp += (String.Format("{0,-4:0.00}", simplex.Total[i, j]) + "   ");
                    else
                        temp += (String.Format("{0,-5:0.00}", simplex.Total[i, j]) + "   ");


                }
                temp += "\n";
            }
            return temp;
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            simplex = new Simplex(Convert.ToInt16(numDecisionVarTB.Text), Convert.ToInt16(numST.Text));
            Readvalues(Convert.ToInt16(numDecisionVarTB.Text), Convert.ToInt16(numST.Text));
            button1.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            solving();
            button2.IsEnabled = false;
        }

        private void Max_Checked(object sender, RoutedEventArgs e)
        {
            Min.IsEnabled = false;
        }

        private void Min_Checked(object sender, RoutedEventArgs e)
        {
            Max.IsEnabled = false;
        }






    }
}
