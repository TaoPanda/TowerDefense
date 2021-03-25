using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TowerDefense.Model
{
    public class PlayerDataModel : INotifyPropertyChanged
    {
        private int hp;
        private int coins;
        private int round;

        public PlayerDataModel(int hp, int coins)
        {
            Hp = hp;
            Coins = coins;
            Round = 0;
        }

        public int Hp { get => hp; set { 
                if(hp != value)
                {
                    hp = value;
                    RaisePropertyChanged("Hp");
                }
            } 
        }
        public int Coins { get => coins; set => coins = value; }
        public int Round { get => round; set => round = value; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));

            }
        }
    }
}
