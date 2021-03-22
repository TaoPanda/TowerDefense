using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TowerDefense.ViewModel
{
    public class MapViewModel
    {
        public void LoadRoute()
        {
            Route.Add(5.1);
            Route.Add(5.2);
            Route.Add(5.3);
            Route.Add(5.4);
            Route.Add(5.5);
        }
        public ObservableCollection<double> Route
        {
            get { return Route; }
            set
            {
                Route = value;
            }
        }
        private void GenerateRoute()
        {


        }

       
    }
}
