using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TowerDefense.Model
{
    public class ViewVisibillityModel : INotifyPropertyChanged
    {
        private double towerHoverVisibillity;

        public ViewVisibillityModel()
        {

        }

        public double TowerHoverVisibillity { get => towerHoverVisibillity; set { 
                if(towerHoverVisibillity != value)
                {
                    towerHoverVisibillity = value;
                    RaisePropertyChanged("TowerHoverVisibillity");
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
