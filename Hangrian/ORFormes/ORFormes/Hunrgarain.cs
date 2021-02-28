using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ORFormes
{
    internal class MyClass : IComparable<MyClass>
    {
        public int rowIndex;
        public int zeroNumber;

        public int CompareTo(MyClass other)
        {
            if (zeroNumber < other.zeroNumber)
                return -1;
            if (zeroNumber > other.zeroNumber)
                return 1;
            if (rowIndex > other.rowIndex)
                return -1;
            if (rowIndex < other.rowIndex)
                return +1;
            return 0;
        }

        public override string ToString()
        {
            string s = "";
            s = "row index is  " + rowIndex + "  number of zero" + zeroNumber;
            return s;
        }
    }

    internal class Hunrgarain
    {
        private enum LineType
        {
            none,
            horz,
            vert

        };

        private class minLine : IComparable<minLine>
        {
            public int zeroNum;
            public bool rowOrcol; //true if row ,zero if col
            public int index;

            public int CompareTo(minLine other)
            {
                if (zeroNum < other.zeroNum)
                    return -1;
                else if (zeroNum > other.zeroNum)
                    return 1;
                else if (!rowOrcol)
                    return 1;

                return 0;
            }

            public override string ToString()
            {
                string s = "";
                s = zeroNum + "  ";
                if (rowOrcol)
                {
                    s = s + "row " + index;
                }
                else
                {
                    s = s + "col " + index;
                }
                return s;
            }
        }

        private static void min_row(int[][] costs, int row, int personNum)
        {
            int min = int.MaxValue;
            for (int i = 0; i < personNum; i++)
            {
                if (costs[row][i] < min)
                    min = costs[row][i];
            }
            for (int i = 0; i < personNum; i++)
            {
                costs[row][i] = costs[row][i] - min;
            }

        }

        private static bool allZeroCoverd(LineType[][] line, int[][] costs, int personNum)
        {
            for (int i = 0; i < personNum; i++)
            {
                for (int j = 0; j < personNum; j++)
                {
                    if (costs[i][j] == 0 && line[i][j] == LineType.none)
                        return false;

                }

            }
            return true;

        }

        private static bool AllcoveredInrow(LineType[][] line, int[][] costs, int row, int personNum)
        {
            for (int i = 0; i < personNum; i++)
                if (costs[row][i] == 0 && line[row][i] == LineType.none)
                    return false;
            return true;
        }

        private static bool AllcoveredIncol(LineType[][] line, int[][] costs, int col, int personNum)
        {
            for (int i = 0; i < personNum; i++)
                if (costs[i][col] == 0 && line[i][col] == LineType.none)
                    return false;
            return true;
        }

        private static void min_col(int[][] costs, int col, int personNum)
        {
            int min = int.MaxValue;
            for (int i = 0; i < personNum; i++)
            {
                if (costs[i][col] < min)
                    min = costs[i][col];
            }
            for (int i = 0; i < personNum; i++)
            {
                costs[i][col] = costs[i][col] - min;
            }

        }

        public static void Solve(int personNum, int[][] costs,solveWindow solveWindow)
        {   //مشان الواجهات
            StackPanel[] SolvPanels;
            SolvPanels = new StackPanel[personNum];
            TextBlock explainLabel=new TextBlock();
            explainLabel.Text = "\nSubtract the smallest entry in each row from all the entries of its row\n" +
                                "Subtract the smallest entry in each column from all the entries of its column\n";
            explainLabel.TextWrapping = TextWrapping.WrapWithOverflow;
            explainLabel.FontSize = 15;
            explainLabel.Foreground = Brushes.DarkMagenta;
            solveWindow.SolvePanel.Children.Add(explainLabel);
            for (int i = 0; i < personNum; i++)
            {
                SolvPanels[i] = new StackPanel();
                SolvPanels[i].Orientation = Orientation.Horizontal;
                SolvPanels[i].HorizontalAlignment = HorizontalAlignment.Center;

            }
            //خلصو الواجهات
            //حل
            for (int i = 0; i < personNum; i++)
            {
                min_row(costs, i, personNum);
            }
            for (int i = 0; i < personNum; i++)
            {
                min_col(costs, i, personNum);

            }
            //حل
            //واجهات
            TextBox[][] solveBoxs=new TextBox[personNum][];
            for (int i = 0; i < personNum; i++)
            {
                solveBoxs[i]=new TextBox[personNum];
                
            }
            for (int i = 0; i < personNum; i++)
            {
                for (int j = 0; j < personNum; j++)
                    solveBoxs[i][j]=new TextBox();
            }
            for (int i = 0; i < personNum; i++)
            {
                for (int j = 0; j < personNum; j++)
                {
                    solveBoxs[i][j].Text = costs[i][j].ToString();
                }
                
            }
            for (int i = 0; i < personNum; i++)
            {
                for (int j = 0; j < personNum; j++)
                {
                    
                    solveBoxs[i][j].Background = Brushes.FloralWhite;
                    solveBoxs[i][j].Foreground = Brushes.DeepPink;
                    solveBoxs[i][j].TextAlignment = TextAlignment.Center;
                    solveBoxs[i][j].BorderBrush = Brushes.DarkViolet;
                    solveBoxs[i][j].Height = 20;
                    solveBoxs[i][j].Width = 60;
                    SolvPanels[i].Children.Add(solveBoxs[i][j]);
                }
                solveWindow.SolvePanel.Children.Add(SolvPanels[i]);

            }

        //واجهات.
            //طباعة
            //نهاية الطباعة 

            List<minLine> minLines = new List<minLine>();
            for (int i = 0; i < personNum; i++)
            {
                int zeroSum = 0;
                for (int j = 0; j < personNum; j++)
                {
                    if (costs[i][j] == 0)
                    {
                        zeroSum = zeroSum + 1;

                    }

                }
                minLine tempmMinLine = new minLine();
                tempmMinLine.zeroNum = zeroSum;
                tempmMinLine.rowOrcol = true;
                tempmMinLine.index = i;
                minLines.Add(tempmMinLine);


            }

            for (int i = 0; i < personNum; i++)
            {
                int zeroSum = 0;
                for (int j = 0; j < personNum; j++)
                {
                    if (costs[j][i] == 0)
                    {
                        zeroSum = zeroSum + 1;

                    }
                }
                minLine tempmMinLine = new minLine();
                tempmMinLine.zeroNum = zeroSum;
                tempmMinLine.rowOrcol = false;
                tempmMinLine.index = i;
                minLines.Add(tempmMinLine);


            }
            //true if covred
            bool[] flagRow = new bool[personNum];
            bool[] flagCol = new bool[personNum];
            for (int i = 0; i < personNum; i++)
            {
                flagRow[i] = flagCol[i] = false;
            }
            //ترتيب الائحة بحسب العواميد أو الأسطر التي تحوي أكبر عدد من الأصفار
            minLines.Sort();
            minLines.Reverse();
            //طباعة
          /*  foreach (minLine minLine in minLines)
            {
                Console.WriteLine(minLine);
            }*/
            //نهاية الطباعة

            //مصفوفة لمعرفة هل حذف السطر عامودياأو افقيا 

            LineType[][] line = new LineType[personNum][];
            for (int i = 0; i < personNum; i++)
            {
                line[i] = new LineType[personNum];

            }
            for (int i = 0; i < personNum; i++)
            {
                for (int j = 0; j < personNum; j++)
                {
                    line[i][j] = LineType.none;

                }

            }

            int minimunline = 0;
            foreach (minLine minLine in minLines)
            {
                if (!allZeroCoverd(line, costs, personNum))
                {
                    if (minLine.rowOrcol)
                    {
                        if (!AllcoveredInrow(line, costs, minLine.index, personNum))
                        {
                            for (int j = 0; j < personNum; j++)
                            {
                                line[minLine.index][j] = LineType.horz;
                            }
                            minimunline++;
                            flagRow[minLine.index] = true;
                        }
                    }
                    if (!minLine.rowOrcol)
                    {
                        if (!AllcoveredIncol(line, costs, minLine.index, personNum))
                        {
                            for (int j = 0; j < personNum; j++)
                            {
                                line[j][minLine.index] = LineType.vert;
                            }
                            minimunline++;
                            flagCol[minLine.index] = true;
                        }
                    }



                }
            }
            //colCheck
            for (int i = 0; i < personNum; i++)
            {
                int flagrow = 0;
                int flagcol = 0;
                for (int j = 0; j < personNum; j++)
                {
                    if (costs[j][i] == 0)
                    {
                        if (flagRow[j])
                            flagrow++;
                        if (flagCol[i])
                            flagcol++;
                    }

                }
                if (flagcol == flagrow)
                {
                    for (int j = 0; j < personNum; j++)
                    {
                        if (costs[j][i] != 0 && line[j][i] == LineType.vert)
                            line[j][i] = LineType.none;
                        if (costs[j][i] == 0)
                            line[j][i] = LineType.horz;

                    }
                    minimunline = minimunline - 1;
                    flagCol[i] = false;
                }
            }
            //check row
            for (int i = 0; i < personNum; i++)
            {
                int flagrow = 0;
                int flagcol = 0;
                for (int j = 0; j < personNum; j++)
                {
                    if (costs[i][j] == 0)
                    {
                        if (flagRow[i])
                            flagrow++;
                        if (flagCol[j])
                            flagcol++;
                    }

                }
                if (flagcol == flagrow)
                {
                    for (int j = 0; j < personNum; j++)
                    {
                        if (costs[i][j] != 0 && line[i][j] == LineType.horz)
                            line[i][j] = LineType.none;
                        if (costs[i][j] == 0)
                            line[i][j] = LineType.vert;

                    }
                    minimunline = minimunline - 1;
                    flagRow[i] = false;
                }
            }
        //    Console.WriteLine(minimunline);
            StackPanel[] solvePanels2=new StackPanel[personNum];
            for (int i = 0; i < personNum; i++)
            {
                solvePanels2[i] = new StackPanel();
                solvePanels2[i].Orientation = Orientation.Horizontal;
                solvePanels2[i].HorizontalAlignment = HorizontalAlignment.Center;

            }
            TextBox[][] solvBox2 = solveBoxs;
           /* for (int i = 0; i < personNum; i++)
            {
                solvBox2[i] = new TextBox[personNum];

            }*/
            for (int i = 0; i < personNum; i++)
            {
                SolvPanels[i].Children.Clear();
                
            }
            for (int i = 0; i < personNum; i++)
            {
                for (int j = 0; j < personNum; j++)
                {
                   // solvBox2[i][j]=new TextBox();
                    solvBox2[i][j].Background = Brushes.FloralWhite;
                    solvBox2[i][j].Foreground = Brushes.DeepPink;
                    solvBox2[i][j].TextAlignment = TextAlignment.Center;
                    solvBox2[i][j].BorderBrush = Brushes.DarkViolet;
                    solvBox2[i][j].Height = 20;
                    solvBox2[i][j].Width = 60;
                    solvBox2[i][j].FontSize = 14;

                }
                
            }
            TextDecoration textDecoration=new TextDecoration();
            textDecoration.Location=TextDecorationLocation.Strikethrough;
            textDecoration.Pen=new Pen(Brushes.Black,4);
            textDecoration.PenThicknessUnit=TextDecorationUnit.FontRecommended;
            TextDecorationCollection myCollection = new TextDecorationCollection();
            myCollection.Add(textDecoration);
            for (int i = 0; i < personNum; i++)
            {
                for (int j = 0; j < personNum; j++)
                {
                    if (line[i][j] == LineType.none)
                        solvBox2[i][j].Text = costs[i][j].ToString();
                    else if (line[i][j] == LineType.horz)
                    {
                       
                        solvBox2[i][j].Text = costs[i][j].ToString();
                        solvBox2[i][j].TextDecorations = myCollection;

                    }
                    else
                    {
                        solvBox2[i][j].Text = costs[i][j].ToString();
                        solvBox2[i][j].TextDecorations = myCollection;
                        
                    }
                    solvePanels2[i].Children.Add(solvBox2[i][j]);
                }
                solveWindow.SolvePanel.Children.Add(solvePanels2[i]);
            }
            
            bool optimal = false;
            if (minimunline == personNum)
            {
                TextBlock explainBlock=new TextBlock();
                explainBlock.Text = "\nThe solution is optimal\n";
                explainBlock.TextWrapping = TextWrapping.WrapWithOverflow;
                explainBlock.FontSize = 15;
                explainBlock.Foreground = Brushes.DarkMagenta;
                solveWindow.SolvePanel.Children.Add(explainBlock);
            
            }


            else
            {

                TextBlock expalinBlock2=new TextBlock();
                expalinBlock2.Text =
                    "the solution is not optimal \n" + "Determine the smallest entry not covered by any line.\n" +
                    "Subtractthis entry from each uncovered row" +
                    "\nthen add it to each covered column\n";
                expalinBlock2.TextWrapping = TextWrapping.Wrap;
                expalinBlock2.FontSize = 15;
                expalinBlock2.Foreground = Brushes.DarkMagenta;
                int min = int.MaxValue;
                
                for (int i = 0; i < personNum; i++)
                {
                    if (!flagRow[i])
                    {
                        for (int j = 0; j < personNum; j++)
                        {
                            if (costs[i][j] < min && costs[i][j] != 0)
                                min = costs[i][j];
                        }
                    }

                }
                TextBlock explainBlock3=new TextBlock();
                explainBlock3.Text = "\nthe minimum vaule is: " + min.ToString();
                explainBlock3.TextWrapping=TextWrapping.Wrap;
                explainBlock3.FontSize = 15;
                explainBlock3.Foreground = Brushes.DarkMagenta;
                solveWindow.SolvePanel.Children.Add(explainBlock3);
               // Console.WriteLine("min is  " + min);

                for (int i = 0; i < personNum; i++)
                {
                    if (!flagRow[i])
                    {
                        for (int j = 0; j < personNum; j++)
                        {
                            costs[i][j] = costs[i][j] - min;
                        }
                    }

                }
                for (int i = 0; i < personNum; i++)
                {
                    if (flagCol[i])
                    {
                        for (int j = 0; j < personNum; j++)
                        {
                            costs[j][i] = costs[j][i] + min;
                        }
                    }


                }
                Solve(personNum, costs,solveWindow);



            }
        }

        public static void OptimalSol(int[][] costsClone, int[][] costs, int personNum,solveWindow solveWindow)
        {
            List<MyClass> ordering = new List<MyClass>();
            for (int i = 0; i < personNum; i++)
            {
                int sum = 0;
                for (int j = 0; j < personNum; j++)
                {
                    if (costsClone[i][j] == 0)
                        sum = sum + 1;
                }
                MyClass temp = new MyClass();
                temp.zeroNumber = sum;
                temp.rowIndex = i;
                ordering.Add(temp);


            }
            ordering.Sort();
            foreach (var myClass in ordering)
            {
                Console.WriteLine(myClass);
            }
            bool[] taken = new bool[personNum];
            int[] sol = new int[personNum];
            for (int i = 0; i < personNum; i++)
            {
                sol[i] = -1;

            }

            bool once = true;
            for (int i = 0; i < personNum; i++)
            {
                for (int j = 0; j < personNum; j++)
                {
                    if (ordering.Count > 0)
                        if (costsClone[ordering[0].rowIndex][j] == 0 && !taken[j])
                        {
                            if (once)
                            {
                                sol[ordering[0].rowIndex] = j;
                                costsClone[ordering[0].rowIndex][j] = -1;
                                for (int l = 0; l < personNum; l++)
                                {
                                    costsClone[l][j] = -1;
                                }
                                for (int l = 0; l < personNum; l++)
                                {
                                    costsClone[ordering[0].rowIndex][l] = -1;

                                }
                                once = false;
                            }
                            ordering.Clear();

                        }

                }


                for (int k = 0; k < personNum; k++)
                {
                    int sum = 0;
                    for (int j = 0; j < personNum; j++)
                    {
                        if (costsClone[k][j] == 0)
                            sum = sum + 1;
                    }
                    if (sum > 0)
                    {
                        MyClass temp = new MyClass();
                        temp.zeroNumber = sum;
                        temp.rowIndex = k;
                        ordering.Add(temp);
                    }


                }
                ordering.Sort();
                foreach (var myClass in ordering)
                {
                    Console.WriteLine(myClass);
                }
                once = true;
            }




            for (int i = 0; i < personNum; i++)
            {
                TextBlock solbBlock=new TextBlock();
                solbBlock.Text = "\nPerson Number: " + (i+1).ToString() + " take job number " + (sol[i]+1).ToString();
                solbBlock.TextWrapping = TextWrapping.Wrap;
                solbBlock.FontSize = 15;
                solbBlock.Foreground = Brushes.DarkMagenta;
                solveWindow.SolvePanel.Children.Add(solbBlock);


            }
            int optimalSol = 0;
            for (int i = 0; i < personNum; i++)
            {
                optimalSol = optimalSol + costs[i][sol[i]];
            }
            TextBlock solBlock2=new TextBlock();
            solBlock2.Text = "\nthe minimum cost is: " + optimalSol.ToString() + "\n";
            solBlock2.TextWrapping = TextWrapping.Wrap;
            solBlock2.FontSize = 15;
            solBlock2.Foreground = Brushes.DarkMagenta;
            solveWindow.SolvePanel.Children.Add(solBlock2);

        }


    }
}
