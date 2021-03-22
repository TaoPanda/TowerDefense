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
            int numberOfColumn = 10;
            for (int i = 0; i < numberOfColumn; i++)
            {
                ColumnDefinition c1 = new ColumnDefinition();
                c1.Width = new GridLength(1, GridUnitType.Star);
                TheGrid.ColumnDefinitions.Add(c1);
            }
            for (int j = 0; j < (numberOfColumn / 5) + 1; j++)
            {
                RowDefinition r1 = new RowDefinition();
                TheGrid.RowDefinitions.Add(r1);
                for (int i = 0; i < numberOfColumn; i++)
                {
                    TextBlock tb = new TextBlock();
                    tb.FontSize = 20;
                    tb.VerticalAlignment = VerticalAlignment.Top;
                    tb.HorizontalAlignment = HorizontalAlignment.Stretch;
                    tb.Text = string.Format("Text row {0}, column {1}", j, i);
                    TheGrid.Children.Add(tb);
                    Grid.SetColumn(tb, i);
                    Grid.SetRow(tb, j);
                }
            }
        }

    }
}
