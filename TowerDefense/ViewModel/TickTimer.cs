using System;
using System.Timers;
using System.Collections.ObjectModel;
using TowerDefense.Model;

public class TickTimer
{
	public TickTimer()
	{
		Timer timer = new Timer();
		timer.Interval = 100; //ticks every 1/10th of a second.
		timer.Tick += new EventHandler(GameMethods());	
			
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
        }
	}
}