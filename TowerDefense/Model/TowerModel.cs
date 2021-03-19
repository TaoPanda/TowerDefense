using System;
using System.Collections.Generic;
using System.Text;

namespace TowerDefense.Model
{
    class TowerModel
    {
        public string name;
        public int range;
        public int dmg;
        public int fr;
        public int cost;
        public int lvl;
        public int xp;
        public int size;
        public string color;

        public TowerModel(string name, int range, int dmg, int fr, int cost, int lvl, int xp, int size, string color)
        {
            this.name = name;
            this.range = range;
            this.dmg = dmg;
            this.fr = fr;
            this.cost = cost;
            this.lvl = lvl;
            this.xp = xp;
            this.size = size;
            this.color = color;
        }
    }
}
