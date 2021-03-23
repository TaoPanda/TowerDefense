using System;
using System.Timers;
using System.Collections.ObjectModel;

public class TickTimer
{
	public TickTimer()
	{
		Timer timer = new Timer();
		timer.Interval = 100; //ticks every 1/10th of a second.
		timer.Tick += new EventHandler(GameMethods());	
			
		public void CheckTimerActive(ObservableCollection<enemy> listOfEnemies)
        {
            if (listOfEnemies.Count == 0)
            {
				timer.Stop;
            }
		}

		public void GameMethods(ObservableCollection<enemy> listOfEnemies)
        {
			CheckTimerActive(listOfEnemies);
        }
	}
}