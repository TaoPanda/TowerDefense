using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TowerDefense.ViewModel.Commands
{
    public class ResetGame : ICommand
    {
        public MapViewModel ViewModel { get; set; }

        public ResetGame(MapViewModel viewModel)
        {
            this.ViewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.ViewModel.GameOver();
        }
    }
}