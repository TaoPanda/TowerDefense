using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using TowerDefense.Model;
using System.Text;

namespace TowerDefense.ViewModel
{
    public class UIViewModel
    {
        private PlayerDataModel playerData;

        public UIViewModel()
        {
            PlayerData = new PlayerDataModel(100, 0);
        }

        public PlayerDataModel PlayerData { get => playerData; set => playerData = value; }

        public void HealthLoss()
        {
            PlayerData.Hp--;
        }
    }
}
