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
using System.Diagnostics;

namespace TowerDefense.ViewModel
{
    public class MapViewModel
    {
        private int wavesCount = 0;
        private int enemiesThisWave = 5;
        private int TotalEnmSpawnTick = 0;
        private int RemainingEnmSpawnTick = 0;
        private ObservableCollection<TowerModel> activeTowers = new ObservableCollection<TowerModel>();
        private ObservableCollection<EnemyModel> activeEnemies = new ObservableCollection<EnemyModel>();
        private ObservableCollection<Coordinates> activeRocks = new ObservableCollection<Coordinates>();
        private ObservableCollection<string> Route = new ObservableCollection<string>();
        private ObservableCollection<Coordinates> positionRoute = new ObservableCollection<Coordinates>();
        private ViewVisibillityModel towerHover = new ViewVisibillityModel();
        private readonly TickTimer Tick;
        private PlayerDataModel playerData;
        private SimpleCommand simpleCommand;
        private ResetGame resetGame;
        private PlaceTowerCommand towerCommand;
        private Coordinates testTowerPlace = new Coordinates(0, 0);
        private Coordinates rangeTowerPlace = new Coordinates(0, 0);
        private Coordinates rangeTowerDimensions = new Coordinates(75, 75);
        private bool placeTowerModeEnabled = false;
        private ObservableCollection<EnemyModel> enemiesToKill = new ObservableCollection<EnemyModel>();
        private TowerModel selectedTower = new TowerModel(1, "debugRangeSystem", 1, 1, 1, 1, 1, 1, 1, "blue");
        private TowerModel selectedUITower;
        public MapViewModel(){
            PlayerData = new PlayerDataModel(100, 50);
            this.simpleCommand = new SimpleCommand(this);
            this.towerCommand = new PlaceTowerCommand(this);
            this.resetGame = new ResetGame(this);
            //Creates tick object
            Tick = new TickTimer(this);
            LoadRoute();
            //Adds debug enemy
            //Starts game
            Tick.StartGame();
            TowerHover.TowerHoverVisibillity = 0.0;
            for (int i = 0; i < 5; i++)
            {
                GenerateRockFormations();
            }

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
        public Coordinates RangeTowerPlace { get => rangeTowerPlace; set => rangeTowerPlace = value; }
        public Coordinates RangeTowerDimensions { get => rangeTowerDimensions; set => rangeTowerDimensions = value; }
        public ObservableCollection<Coordinates> ActiveRocks { get => activeRocks; set => activeRocks = value; }
        public ViewVisibillityModel TowerHover { get => towerHover; set => towerHover = value; }
        public TowerModel SelectedTower { get => selectedTower; set => selectedTower = value; }
        public int WavesCount { get => wavesCount; set => wavesCount = value; }
        public TowerModel SelectedUITower { get => selectedUITower; set => selectedUITower = value; }

        public void MoveCursor()
        {
            if (placeTowerModeEnabled)
            {
                Point position = Mouse.GetPosition((IInputElement)Application.Current.MainWindow);
                int pX = (int)Math.Round(position.X / 25.0) * 25;
                int pY = (int)Math.Round(position.Y / 25.0) * 25;
                TestTowerPlace.X = pX;
                TestTowerPlace.Y = pY;
                MoveRangeCursor();
            }
        }
        public void MoveRangeCursor()
        {
            RangeTowerPlace.X = TestTowerPlace.X - (SelectedTower.Range * 25);
            RangeTowerPlace.Y = TestTowerPlace.Y - (SelectedTower.Range * 25);
            RangeTowerDimensions.X = ((SelectedTower.Range * 25) * 2) + 25;
            RangeTowerDimensions.Y = ((SelectedTower.Range * 25) * 2) + 25;
        }

        public void NewWave()
        {
            wavesCount++;
            enemiesThisWave = Convert.ToInt32(5 + Math.Floor(wavesCount * 1.5));
            RemainingEnmSpawnTick = 0;

            activeRocks.Clear();
            for (int i = 0; i < 5; i++)
            {
                GenerateRockFormations();
            }
            SpawnInterval();
        }

        public void HealthLoss()
        {
            PlayerData.Hp--;
            if (PlayerData.Hp == 0)
            {
                PlayerData.PopupIsOpen = true;
                Tick.GameOver();
            }
        }

        public void GameOver()
        {
            wavesCount = 0;
            activeEnemies.Clear();
            activeTowers.Clear();
            PlayerData.Hp = 100;
            PlayerData.Round = 0;
            PlayerData.Coins = 10;
            RemainingEnmSpawnTick = 0;
            TotalEnmSpawnTick = 0;
            PlayerData.PopupIsOpen = false;
            Tick.StartGame();
        }

        public void TowerTick()
        {
            foreach (TowerModel tower in activeTowers)
            {
                tower.CheckRange(tower);
            }
        }

        public void LoadRoute()
        {
            using var context = new TowerDefenseContext();

            foreach (var row in context.Route)
                Route.Add(row.Y.ToString() + "." + row.X.ToString());
            GenerateRoute();

        }
        public void SpawnInterval()
        {
            if (RemainingEnmSpawnTick == TotalEnmSpawnTick && enemiesThisWave > 0)
            {
                Random random = new Random();
                TotalEnmSpawnTick = random.Next(2, 5);

                activeEnemies.Add(new EnemyModel("test", 100, 1, 1, 1, "red", positionRoute[0], new BitmapImage(new Uri("/images/notBroken.png", UriKind.Relative))));
                RemainingEnmSpawnTick = 0;
                enemiesThisWave--;


            }
            RemainingEnmSpawnTick++;
            
            


            // hele tower placement systemet crasher før vi fjerner UI elementerne fra MapView
            if (activeEnemies.Count == 0 && PlayerData.Coins >= 5 * (ActiveTowers.Count + 1))
            {
                playerData.CanPlaceTower = true;
                //Husk at implementere visibilitty
                TowerHover.TowerHoverVisibillity = 0.35;
            }
            else
            {
                playerData.CanPlaceTower = false;
                TowerHover.TowerHoverVisibillity = 0.0;
            }
        }
        private void GenerateRockFormations()
        {
            
            int x;
            int y;
            Random rnd = new Random();
            while (true)
            {
                x = rnd.Next(0, 20);
                y = rnd.Next(0, 20);
                if (IsCellEmpty(new Coordinates(x, y)))
                {
                    break;
                }
            }
            List<Point> posibleRockLocations = GetSurroundingCells(new Point(x, y), 3);
            foreach (Point element in  posibleRockLocations)
            {
                if(rnd.Next(0, 2) == 1)
                {
                    activeRocks.Add(new Coordinates(Convert.ToInt32(element.X * 25), Convert.ToInt32(element.Y * 25)));
                }
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

        public List<Point> GetSurroundingCells(Point fromLocation, int Distance)
        {

            var nearbySpots = new List<Point>();

            for (int i = -Distance; i <= Distance; ++i)
                for (int j = -Distance; j <= Distance; ++j)
                    nearbySpots.Add(new Point(fromLocation.X + j, fromLocation.Y + i));

            return nearbySpots;

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
        public bool IsCellEmpty(Coordinates coordinates)
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
            foreach(Coordinates rocks in activeRocks)
            {
                if(rocks.X == coordinates.X && rocks.Y == coordinates.Y)
                {
                    return false;
                }
            }
            return true;
        }
        public void PlaceTower(TowerModel tower)
        {
            if(PlayerData.Coins >= 5 * (ActiveTowers.Count + 1))
            {
                if (IsCellEmpty(tower.Cordinate))
                {
                    activeTowers.Add(tower);

                    // When you buy a tower you lose coins
                    PlayerData.Coins -= 5 * (ActiveTowers.Count+1);

                    // So when you place/buy a tower it check if you have enought coins to buy/place one more, if not then placeTowerModeEnabled is equal to false
                    if (PlayerData.Coins < 5 * (ActiveTowers.Count + 1))
                    {
                        placeTowerModeEnabled = false;
                    }
                }
            }
        }

    }
}