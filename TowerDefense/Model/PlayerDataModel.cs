using System;
using System.Collections.Generic;
using System.Text;

namespace TowerDefense.Model
{
    class PlayerDataModel
    {
        int hp;
        int coins;
        int round;

        public PlayerDataModel(int hp, int coins)
        {
            Hp = hp;
            Coins = coins;
            Round = 0;
        }

        public int Hp { get => hp; set => hp = value; }
        public int Coins { get => coins; set => coins = value; }
        public int Round { get => round; set => round = value; }
    }
}
