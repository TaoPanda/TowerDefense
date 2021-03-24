using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TowerDefense.Model
{
    public class Coordinates
    {
        private int y;
        private int x;

        public Coordinates(int y, int x)
        {
            this.Y = y;
            this.X = x;
        }

        public int Y { get => y; set => y = value; }
        public int X { get => x; set => x = value; }
    }
}
