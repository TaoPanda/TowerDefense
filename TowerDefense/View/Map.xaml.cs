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
using TowerDefense.ViewModel;

namespace TowerDefense.View
{
    /// <summary>
    /// Interaction logic for Map.xaml
    /// </summary>
    public partial class Map : UserControl
    {
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

        private void myCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            // Get the x and y coordinates of the mouse pointer.
            Point position = e.GetPosition(myCanvas);
            double pX = position.X;
            double pY = position.Y;

            MapViewModel MapView = (MapViewModel)App.Current.Resources["sharedMapViewModel"];
            MapView.moveCursor(Convert.ToInt32(pX), Convert.ToInt32(pY));
        }
    }
}
