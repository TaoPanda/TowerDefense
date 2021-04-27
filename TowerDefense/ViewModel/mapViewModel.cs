using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TowerDefense.Model;
using System.Text;
using TowerDefense.ViewModel.Commands;
using System.Windows.Input;
using System.Threading;
using System.Windows.Media.Imaging;
using System.Windows;
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
        private ResetGame resetGame;
        private PlaceTowerCommand towerCommand;
        private Coordinates testTowerPlace = new Coordinates(0, 0);
        private bool placeTowerModeEnabled = false;
        private ObservableCollection<EnemyModel> enemiesToKill = new ObservableCollection<EnemyModel>();
        public MapViewModel()
        {
            PlayerData = new PlayerDataModel(3, 0);
            this.simpleCommand = new SimpleCommand(this);
            this.towerCommand = new PlaceTowerCommand(this);
            this.resetGame = new ResetGame(this);
            //Creates tick object
            Tick = new TickTimer(this);
            LoadRoute();
            //Adds debug enemy
            //Starts game

            Tick.startGame();
            RoutedEvent[] events = EventManager.GetRoutedEvents();


        }
        public PlayerDataModel PlayerData { get => playerData; set => playerData = value; }
        public ObservableCollection<string> Route1 { get => this.Route; set => this.Route = value; }
        public ObservableCollection<Coordinates> PositionRoute { get => positionRoute; set => positionRoute = value; }
        public ObservableCollection<EnemyModel> ActiveEnemies { get => activeEnemies; set => activeEnemies = value; }
        public int EnemiesThisWave { get => enemiesThisWave; set => enemiesThisWave = value; }
        public SimpleCommand SimpleCommand { get => simpleCommand; set => simpleCommand = value; }
        public ObservableCollection<TowerModel> ActiveTowers { get => activeTowers; set => activeTowers = value; }
        public PlaceTowerCommand TowerCommand { get => towerCommand; set => towerCommand = value; }
        public ResetGame ResetGame { get => resetGame; set => resetGame = value; }
        public Coordinates TestTowerPlace { get => testTowerPlace; set => testTowerPlace = value; }
        public bool PlaceTowerModeEnabled { get => placeTowerModeEnabled; set => placeTowerModeEnabled = value; }
        public ObservableCollection<EnemyModel> EnemiesToKill { get => enemiesToKill; set => enemiesToKill = value; }


        public void moveCursor()
        {
            if (placeTowerModeEnabled)
            {
                Point position = Mouse.GetPosition((IInputElement)Application.Current.MainWindow);
                int pX = (int)Math.Round(position.X / 25.0) * 25;
                int pY = (int)Math.Round(position.Y / 25.0) * 25;
                TestTowerPlace.X = pX;
                TestTowerPlace.Y = pY;
            }
        }

        public void newWave()
        {
            wavesCount++;
            enemiesThisWave = Convert.ToInt32(5 + Math.Floor(wavesCount * 1.5));
            RemainingEnmSpawnTick = 0;
            SpawnInterval();
        }

        public void HealthLoss()
        {
            PlayerData.Hp--;
            if (PlayerData.Hp == 0)
            {
                PlayerData.PopupIsOpen = true;
                Tick.gameOver();
            }
        }

        public void GameOver()
        {
            wavesCount = 0;
            activeEnemies.Clear();
            activeTowers.Clear();
            PlayerData.Hp = 100;
            PlayerData.Round = 0;
            PlayerData.Coins = 0;
            RemainingEnmSpawnTick = 0;
            TotalEnmSpawnTick = 0;
            PlayerData.PopupIsOpen = false;
            Tick.startGame();
        }

        public void TowerTick()
        {
            foreach (TowerModel tower in activeTowers)
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
        public void SpawnInterval()
        {
            if (RemainingEnmSpawnTick == TotalEnmSpawnTick && enemiesThisWave > 0)
            {
                string replaceMe = AppDomain.CurrentDomain.BaseDirectory;
                replaceMe = replaceMe.Replace(@"\bin\Debug\netcoreapp3.1", "");
                Random random = new Random();
                TotalEnmSpawnTick = random.Next(2, 5);
                activeEnemies.Add(new EnemyModel("test", 100, 1, 1, 1, "red", positionRoute[0], new BitmapImage(new Uri($@"file:\\\C:\Users\nico936d\Documents\S-3\TowerDefense\TowerDefense\images\notBroken.png", UriKind.Absolute))));
                RemainingEnmSpawnTick = 0;
                enemiesThisWave--;


            }
            RemainingEnmSpawnTick++;
            if (activeEnemies.Count == 0)
            {
                playerData.CanPlaceTower = true;
            }
            else
            {
                playerData.CanPlaceTower = false;
            }
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

        private int[] GetCenterOfCell(string cordinat, int cellSize)
        {
            //Gets the pixel position of the given cell
            string s = cordinat;
            string[] parts = s.Split('.');
            int x = int.Parse(parts[0]);
            int y = int.Parse(parts[1]);
            int[] cords = new[] { x * cellSize, y * cellSize };
            return cords;
        }

        public void MoveEnemyInList()
        {
            //Moves all active enenies and deletes them when they reach the end
            List<int> removeIndex = new List<int>();
            int remove = 0;

            foreach (EnemyModel enemy in ActiveEnemies)
            {
                enemy.NextPosition();
                //Checks if they are at the last cell of the route
                if (enemy.Position != PositionRoute.Count)
                {
                    enemy.Cordinate = positionRoute[enemy.Position];
                }
                else
                {
                    removeIndex.Add(remove);
                    HealthLoss();
                    if (PlayerData.Hp <= 0)
                    {
                        PlayerData.PopupIsOpen = true;
                        break;
                    }
                }
                remove++;
            }
            if (ActiveEnemies.Count > 0)
            {
                foreach (int index in removeIndex)
                {
                    ActiveEnemies.RemoveAt(index);
                }
            }
        }
        public bool isCellEmpty(Coordinates coordinates)
        {
            foreach (Coordinates routeCords in positionRoute)
            {
                if (routeCords.X == coordinates.X && routeCords.Y == coordinates.Y)
                {
                    return false;
                }
            }
            foreach (TowerModel towerCords in activeTowers)
            {
                if (towerCords.Cordinate.X == coordinates.X && towerCords.Cordinate.Y == coordinates.Y)
                {
                    return false;
                }
            }
            return true;
        }
        public void placeTower(TowerModel tower)
        {
            if (isCellEmpty(tower.Cordinate))
            {
                activeTowers.Add(tower);
            }
        }

    }
}