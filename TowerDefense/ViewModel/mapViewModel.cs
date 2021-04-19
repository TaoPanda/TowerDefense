using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using TowerDefense.Model;
using System.Text;
using TowerDefense.ViewModel.Commands;
using System.Windows.Input;
using System.Windows.Controls;

namespace TowerDefense.ViewModel
{
    public class MapViewModel
    {
        private ObservableCollection<string> test = new ObservableCollection<string>();
        private int wavesCount = 0;
        private int enemiesThisWave = 5;
        private int TotalEnmSpawnTick = 0;
        private int RemainingEnmSpawnTick = 0;
        private ObservableCollection<TowerModel> activeTowers = new ObservableCollection<TowerModel>();
        private ObservableCollection<EnemyModel> activeEnemies = new ObservableCollection<EnemyModel>();
        private ObservableCollection<string> Route = new ObservableCollection<string>();
        private ObservableCollection<Coordinates> positionRoute = new ObservableCollection<Coordinates>();
        private TickTimer Tick;
        private PlayerDataModel playerData;
        private SimpleCommand simpleCommand;
        public MapViewModel(){
            PlayerData = new PlayerDataModel(3, 0);
            this.simpleCommand = new SimpleCommand(this);
            //Creates tick object
            Tick = new TickTimer();
            LoadRoute();
            test.Add("2");
            //Adds debug enemy
            //Starts game
            Tick.startGame();
            placeTower();
        }

        
        public PlayerDataModel PlayerData { get => playerData; set => playerData = value; }

        public void newWave()
        {
            wavesCount++;
            enemiesThisWave = Convert.ToInt32(5 + Math.Floor(wavesCount * 1.5));
            RemainingEnmSpawnTick = 0;
        }
        public void HealthLoss()
        {
            PlayerData.Hp--;
        }

        public void TowerTick()
        {
            foreach(TowerModel tower in activeTowers)
            {
                tower.checkRange();
            }
        }

        public void LoadRoute()
        {
            using (var context = new TowerDefenseContext())
            {
                
                foreach (var row in context.Route)
                    Route.Add(row.Y.ToString() + "." + row.X.ToString());
                GenerateRoute();
            }
           
        }

        public ObservableCollection<string> Route1 { get => this.Route; set => this.Route = value; }
        public ObservableCollection<Coordinates> PositionRoute { get => positionRoute; set => positionRoute = value; }
        public ObservableCollection<EnemyModel> ActiveEnemies { get => activeEnemies; set => activeEnemies = value; }
        public int EnemiesThisWave { get => enemiesThisWave; set => enemiesThisWave = value; }
        public SimpleCommand SimpleCommand { get => simpleCommand; set => simpleCommand = value; }
        public ObservableCollection<TowerModel> ActiveTowers { get => activeTowers; set => activeTowers = value; }

        public void SpawnInterval()
        {
            if(RemainingEnmSpawnTick == TotalEnmSpawnTick && enemiesThisWave > 0)
            {
                Random random = new Random();
                TotalEnmSpawnTick = random.Next(2, 5);
                activeEnemies.Add(new EnemyModel("test", 100, 1, 1, 1, "red", positionRoute[0]));
                RemainingEnmSpawnTick = 0;
                enemiesThisWave--;
            }
            RemainingEnmSpawnTick++;
        }

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
                    HealthLoss();
                }
                remove++;
            }
            foreach(int index in removeIndex)
            {
                ActiveEnemies.RemoveAt(index);
            }
        }

        public void placeTower()
        {
            TowerModel debugTower = new TowerModel(1, "test", 1, 1, 10, 10, 1, 0, 1, "blue");
            debugTower.Cordinate = new Coordinates(9, 12);
            string formatCords = debugTower.Cordinate.X.ToString() + "." + debugTower.Cordinate.Y.ToString();
            int[] towerCords = GetCenterOfCell(formatCords, 25);
            debugTower.Cordinate = new Coordinates(towerCords[1], towerCords[0]);
            activeTowers.Add(debugTower);
            
        }

        public void GetMousePos(double x, double y)
        {
            
        }

    }
}
