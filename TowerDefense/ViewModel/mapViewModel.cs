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
        private UIViewModel UI = new UIViewModel();
        public MapViewModel(){
            //Creates tick object
            Tick = new TickTimer(this);
            LoadRoute();
            //Adds debug enemy
            ActiveEnemies.Add(new EnemyModel("test", 100, 1, 1, 1, "red", positionRoute[0]));
            //Starts game
            Tick.startGame();
        }
        public void LoadRoute()
        {
            using (var context = new TowerDefenseContext())
            {
                
                foreach (var row in context.Route)
                    Route.Add(row.X.ToString() + "." + row.Y.ToString());
                GenerateRoute();
            }
           
        }

        public ObservableCollection<string> Route1 { get => this.Route; set => this.Route = value; }
        public ObservableCollection<Coordinates> PositionRoute { get => positionRoute; set => positionRoute = value; }
        public ObservableCollection<EnemyModel> ActiveEnemies { get => activeEnemies; set => activeEnemies = value; }
        public UIViewModel UI1 { get => UI; set => UI = value; }

        private void GenerateRoute()
        {
            //Generates the enemy route from given coordinates 
            foreach (string element in Route)
            {
               int[] cords = GetCenterOfCell(element, 25);

                PositionRoute.Add(new Coordinates(cords[1], cords[0]));
            }
        }

       private int[] GetCenterOfCell(string cordinat,int cellSize)
        {
            //Gets the pixel position of the given cell
            string s = cordinat;
            string[] parts = s.Split('.');
            int x = int.Parse(parts[0]);
            int y = int.Parse(parts[1]);
            int[] cords = new[] { x * cellSize, y * cellSize};
            return cords;
        }

        public void MoveEnemyInList()
        {
            //Moves all active enenies and deletes them when they reach the end
            List<int> removeIndex = new List<int>();
            int remove = 0;
            foreach(EnemyModel enemy in ActiveEnemies)
            {
                enemy.NextPosition();
                //Checks if they are at the last cell of the route
                if(enemy.Position != PositionRoute.Count)
                {
                    enemy.Cordinate = positionRoute[enemy.Position];
                }
                else
                {
                    removeIndex.Add(remove);
                    UI1.HealthLoss();
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
