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
using TowerDefense.Model;

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
        
        private void callViewmodelFunction(object sender, MouseButtonEventArgs e)
        {
            MapViewModel MapView = (MapViewModel)App.Current.Resources["sharedMapViewModel"];
            if (MapView.PlaceTowerModeEnabled)
            {
                Point position = Mouse.GetPosition(myCanvas);
                TowerModel testTower = new TowerModel(1, "test", 3, 5, 1, 1, 1, 1, 1, "blue");
                int pX = (int)Math.Round(position.X / 25.0) * 25;
                int pY = (int)Math.Round(position.Y / 25.0) * 25;
                testTower.Cordinate = new Coordinates(pX, pY);
                MapView.placeTower(testTower);
            }
            else
            {
                hoverRectangle.Opacity = 0;
            }
        }

    }

}
