using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TowerDefense.Model
{
    public class TowerModel
    {
        private int id;
        public string name;
        public int range;
        public int dmg;
        public int fr;
        public int cost;
        public int lvl;
        public int xp;
        public int size;
        public string color;

        [Key]
        public int Id { get => id; set => id = value; }

        public TowerModel()
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
