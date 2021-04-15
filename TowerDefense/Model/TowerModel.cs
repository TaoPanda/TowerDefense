using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TowerDefense.Model
{
    public class TowerModel
    {
        private int id;
        private string name;
        private int range;
        private int dmg;
        private int fr;
        private int cost;
        private int lvl;
        private int xp;
        private int size;
        private string color;
        private Coordinates cordinate;

        public TowerModel(int id, string name, int range, int dmg, int fr, int cost, int lvl, int xp, int size, string color)
        {
            this.id = id;
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

        [Key]
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Range { get => range; set => range = value; }
        public int Dmg { get => dmg; set => dmg = value; }
        public int Fr { get => fr; set => fr = value; }
        public int Cost { get => cost; set => cost = value; }
        public int Lvl { get => lvl; set => lvl = value; }
        public int Xp { get => xp; set => xp = value; }
        public int Size { get => size; set => size = value; }
        public string Color { get => color; set => color = value; }
        public Coordinates Cordinate { get => cordinate; set => cordinate = value; }

        public void checkMobsInRange()
        {

        }

        public void attack()
        {

        }







































































    }
}
