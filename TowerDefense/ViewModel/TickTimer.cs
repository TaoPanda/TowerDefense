using System;
using System.Timers;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows.Threading;
using TowerDefense.ViewModel;
using TowerDefense;
using System.Threading.Tasks;

public class TickTimer
{
	private readonly DispatcherTimer timer = new DispatcherTimer();
    private readonly MapViewModel MapView;
    public TickTimer(MapViewModel mapViewModel)
    {
        MapView = mapViewModel;
    }


    public void StartGame()
    {
		timer.Interval = TimeSpan.FromMilliseconds(200);
		timer.Tick += Timer_Tick;
		timer.Start();
	}
    public void GameOver()
    {
        timer.Stop();
    }
    public void Timer_Tick(object sender, EventArgs args)
    {
        MapView.MoveEnemyInList();
        MapView.SpawnInterval();
        MapView.TowerTick();
        MapView.moveCursor();
    }

        /*
        public TickTimer()
        {
            Timer timer = new Timer();
            timer.Interval = 100; //ticks every 1/10th of a second.
            timer.Tick += new EventHandler(GameMethods());	


        }
        public void CheckTimerActive(ObservableCollection<EnemyModel> listOfEnemies)
        {
            if (listOfEnemies.Count == 0)
            {
                timer.Stop;
            }
        }

        public void GameMethods(ObservableCollection<EnemyModel> listOfEnemies)
        {
            CheckTimerActive(listOfEnemies);
        }*/
    }