using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TowerDefense.ViewModel.Commands
{
    public class PlaceTowerCommand : ICommand
    {
        public MapViewModel viewModel { get; set; }

        public PlaceTowerCommand(MapViewModel mapViewModel)
        {
            this.viewModel = mapViewModel;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (this.viewModel.PlaceTowerModeEnabled)
            {
                this.viewModel.PlaceTowerModeEnabled = false;
            }
            else
            {
                this.viewModel.PlaceTowerModeEnabled = true;
            }
        }

    }
}
