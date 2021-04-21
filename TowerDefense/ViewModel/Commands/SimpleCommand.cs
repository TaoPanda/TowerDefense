using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TowerDefense.ViewModel.Commands
{
    public class SimpleCommand : ICommand
    {
        public MapViewModel viewModel { get; set; } 
        public  SimpleCommand(MapViewModel mapViewModel)
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
            this.viewModel.newWave();
            this.viewModel.PlaceTowerModeEnabled = false;

        }

    }
}
