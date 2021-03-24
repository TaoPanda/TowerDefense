using System;
using System.Timers;
using System.Collections.ObjectModel;
using System.Threading;
using TowerDefense.Model;
using System.Windows.Threading;

public class TickTimer
{
	private DispatcherTimer timer = new DispatcherTimer();

	public void startGame()
    {
		timer.Interval = new TimeSpan(60000);
		timer.Tick += Timer_Tick;
		timer.Start();
	}
    private void gameOver()
    {
        timer.Stop();
    }
    public void Timer_Tick(object sender, EventArgs args)
    {
       
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