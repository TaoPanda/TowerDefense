using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using TowerDefense.Model;
using System.Text;

namespace TowerDefense.ViewModel
{
    public class MapViewModel
    {
        private ObservableCollection<EnemyModel> activeEnemies = new ObservableCollection<EnemyModel>();
        private ObservableCollection<string> Route = new ObservableCollection<string>();
        private ObservableCollection<Coordinates> positionRoute = new ObservableCollection<Coordinates>();
        private TickTimer Tick;
        public MapViewModel(){
            Tick = new TickTimer(this);
            LoadRoute();
            ActiveEnemies.Add(new EnemyModel("test", 100, 1, 1, 1, "red", positionRoute[0]));
            Tick.startGame();
        }
        public void LoadRoute()
        {
            Route.Add("2.0");
            Route.Add("2.1");
            Route.Add("2.2");
            Route.Add("3.2");
            Route.Add("4.2");
            Route.Add("5.2");
            Route.Add("6.2");
            Route.Add("6.3");
            Route.Add("6.4");
            Route.Add("6.5");
            Route.Add("5.5");
            Route.Add("4.5");
            Route.Add("3.5");
            Route.Add("3.6");
            Route.Add("3.7");
            Route.Add("3.8");
            Route.Add("3.9");


            GenerateRoute();
        }

        public ObservableCollection<string> Route1 { get => this.Route; set => this.Route = value; }
        public ObservableCollection<Coordinates> PositionRoute { get => positionRoute; set => positionRoute = value; }
        public ObservableCollection<EnemyModel> ActiveEnemies { get => activeEnemies; set => activeEnemies = value; }

        private void GenerateRoute()
        {
            foreach (string element in Route)
            {
               int[] cords = GetCenterOfCell(element, 50);

                PositionRoute.Add(new Coordinates(cords[1], cords[0]));
            }
        }

       private int[] GetCenterOfCell(string cordinat,int cellSize)
        {
            string s = cordinat;
            string[] parts = s.Split('.');
            int x = int.Parse(parts[0]);
            int y = int.Parse(parts[1]);
            int[] cords = new[] { x * cellSize, y * cellSize};
            return cords;
        }

        public void MoveEnemyInList()
        {
            List<int> removeIndex = new List<int>();
            int remove = 0;
            foreach(EnemyModel enemy in ActiveEnemies)
            {
                enemy.NextPosition();
                if(enemy.Position != PositionRoute.Count)
                {
                    enemy.Cordinate = positionRoute[enemy.Position];
                }
                else
                {
                    removeIndex.Add(remove);
                }
                remove++;
            }
            foreach(int index in removeIndex)
            {
                ActiveEnemies.RemoveAt(index);
            }
        }
    }
}
