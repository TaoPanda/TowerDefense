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
        private bool canPlaceTower = false;
        private bool popupIsOpen = false;



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
        public bool CanPlaceTower { get => canPlaceTower; set { 
                if(canPlaceTower != value)
                {
                    canPlaceTower = value;
                    RaisePropertyChanged("CanPlaceTower");
                }
            } 
        }

        public bool PopupIsOpen
        {
            get => popupIsOpen; set
            {
                if(popupIsOpen != value)
                {
                    popupIsOpen = value;
                    RaisePropertyChanged("PopupIsOpen");
                }
            }
        }

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
