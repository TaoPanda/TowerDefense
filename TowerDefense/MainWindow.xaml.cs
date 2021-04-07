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

namespace TowerDefense
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OnMouseMoveHandler(object sender, MouseEventArgs e)
        {
            Point p = e.GetPosition(mainGrid);
            double pX = p.X;
            double pY = p.Y;
            Canvas.SetTop(customPointer, pY);
            Canvas.SetLeft(customPointer, pX);
            Cursor = Cursors.None;
        }
    }
}
