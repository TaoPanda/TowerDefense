using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TowerDefense.View
{
    /// <summary>
    /// Interaction logic for Map.xaml
    /// </summary>
    public partial class Map : Page
    {
        public Map()
        {
            InitializeComponent();
            initiateGrid();
        }
        private void initiateGrid()
        {
            Grid myGrid = new Grid();
            myGrid.Width = 250;
            myGrid.Height = 100;
            myGrid.HorizontalAlignment = HorizontalAlignment.Left;
            myGrid.VerticalAlignment = VerticalAlignment.Top;
            myGrid.ShowGridLines = true;
            for (int i = 0; i < 5; i++)
            {
                ColumnDefinition colDef = new ColumnDefinition();
                RowDefinition rowDef = new RowDefinition();
                myGrid.RowDefinitions.Add(rowDef);
                myGrid.ColumnDefinitions.Add(colDef);
                TextBlock txt = new TextBlock();
                txt.Text = i.ToString();
                txt.FontSize = 20;
                txt.FontWeight = FontWeights.Bold;
                Grid.SetRow(txt, i);
            }
        }

    }
}
