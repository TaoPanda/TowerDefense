using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TowerDefense.Model
{
    public class Coordinates
    {
        private int id;
        private int y;
        private int x;

        public Coordinates(int x, int y)
        {
            this.Y = y;
            this.X = x;
            
        }
        public int Y { get => y; set => y = value; }
        public int X { get => x; set => x = value; }
        [Key]
        public int Id { get => id; set => id = value; }
    }
}
