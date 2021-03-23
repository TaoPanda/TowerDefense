using System;
using System.Collections.Generic;
using System.Text;

namespace TowerDefense.Model
{
    class EnemyModel
    {
        public string name;
        public int hp;
        public int ms;
        public int xp;
        public int position;
        public int cost;
        public string color;

        public EnemyModel(string name, int hp, int ms, int xp, int position, int cost, string color)
        {
            this.name = name;
            this.hp = hp;
            this.ms = ms;
            this.xp = xp;
            this.position = position;
            this.cost = cost;
            this.color = color;
        }

        public void NextPosition()
        {
            position++;
        }
    }
}
