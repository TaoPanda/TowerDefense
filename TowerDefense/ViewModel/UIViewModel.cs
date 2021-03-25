using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using TowerDefense.Model;
using System.Text;

namespace TowerDefense.ViewModel
{
    class UIViewModel
    {
        PlayerDataModel playerData = new PlayerDataModel(100, 0);

        public UIViewModel()
        {
        }

        public void HealthLoss()
        {
            playerData.Hp--;
        }
    }
}
