using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TowerDefense.Model;

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
            foreach (double element in Route)
            {
                
            }

        }

       public Array GetCenterOfCell(double cordinat,int cellSize)
        {
            int x = Convert.ToInt32(Math.Floor(cordinat));
            double s = cordinat - x;
            int y = 0;
            float half = cellSize / 2;
            int roundhalf = Convert.ToInt32(Math.Round(half));
            while (y != s)
            {
                try
                {
                    y = Convert.ToInt32(s);
                }
                catch
                {
                    s = s * 10;
                }
            }
            Array cords = new Array[x * cellSize + roundhalf, y * cellSize + roundhalf];
            return cords;
        }

        private void MoveEnemyInList(ObservableCollection<EnemyModel> enemies, ObservableCollection<double> route, int cellSize)
        {
            List<int> removeIndex = new List<int>();
            int remove = 0;
            foreach(EnemyModel enemy in enemies)
            {
                enemy.NextPosition();
                if(enemy.position != route.Count)
                {
                    enemy.cordinates = GetCenterOfCell(route[enemy.position], cellSize);
                }
                else
                {
                    removeIndex.Add(remove);
                }
                remove++;
            }
            foreach(int index in removeIndex)
            {
                enemies.RemoveAt(index);
            }
        }
    }
}
