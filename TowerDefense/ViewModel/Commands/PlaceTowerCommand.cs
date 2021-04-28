using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TowerDefense.ViewModel.Commands
{
    public class PlaceTowerCommand : ICommand
    {
        public MapViewModel ViewModel { get; set; }

        public PlaceTowerCommand(MapViewModel mapViewModel)
        {
            this.ViewModel = mapViewModel;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (this.ViewModel.PlaceTowerModeEnabled)
            {
                this.ViewModel.PlaceTowerModeEnabled = false;
            }
            else
            {
                this.ViewModel.PlaceTowerModeEnabled = true;
                this.ViewModel.TowerHover.TowerHoverVisibillity = 0.35;
            }
        }

    }
}
