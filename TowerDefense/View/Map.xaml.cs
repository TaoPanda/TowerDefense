using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using TowerDefense.ViewModel;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TowerDefense.View
{
    /// <summary>
    /// Interaction logic for Map.xaml
    /// </summary>
    public partial class Map : UserControl
    {
        MapViewModel MapViewModel = new MapViewModel();

        public Map()
        {
            InitializeComponent();
            InitiateGrid();
                    
        }
        private void InitiateGrid()
        {
        
            myGrid.Width = 500;
            myGrid.Height = 500;
            myGrid.HorizontalAlignment = HorizontalAlignment.Left;
            myGrid.VerticalAlignment = VerticalAlignment.Top;
            myGrid.ShowGridLines = true;
            //Creates rows and collumns based of the given number
            for (int i = 0; i < 20; i++)
            {
                ColumnDefinition colDef = new ColumnDefinition();
                RowDefinition rowDef = new RowDefinition();
                myGrid.RowDefinitions.Add(rowDef);
                myGrid.ColumnDefinitions.Add(colDef);
                
            }
        }

        private void callViewmodelFunction(object sender, MouseEventArgs e)
        {
            Point position = Mouse.GetPosition(myCanvas);
            MapViewModel.GetMousePos(position.X, position.Y);
        }
    }
}
