using System;
using System.Timers;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows.Threading;
using TowerDefense.ViewModel;
using TowerDefense;

public class TickTimer
{
	private DispatcherTimer timer = new DispatcherTimer();
    private MapViewModel MapView;
    public TickTimer(MapViewModel mapViewModel)
    {
        MapView = mapViewModel;
    }


    public void startGame()
    {
		timer.Interval = TimeSpan.FromMilliseconds(250);
		timer.Tick += Timer_Tick;
		timer.Start();
	}
    public void gameOver()
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