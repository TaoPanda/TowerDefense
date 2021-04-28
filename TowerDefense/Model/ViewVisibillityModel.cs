using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TowerDefense.Model
{
    public class ViewVisibillityModel : INotifyPropertyChanged
    {
        private double towerHoverVisibillity;
        private TowerModel selectedUiModel;

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

        public TowerModel SelectedUiModel { get => selectedUiModel; set { 
                if(selectedUiModel != value)
                {
                    selectedUiModel = value;
                    RaisePropertyChanged("SelectedUiModel");
                }
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
