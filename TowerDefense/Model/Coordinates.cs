using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TowerDefense.Model
{
    public class Coordinates : INotifyPropertyChanged
    {
        private int id;
        private int y;
        private int x;

        public Coordinates(int x, int y)
        {
            this.Y = y;
            this.X = x;
        }
       
        public int Y { get => y; set { 
                if(y != value)
                {
                    y = value;
                    RaisePropertyChanged("Y");
                }
            } 
        }
        public int X { get => x; set {
                if(x != value)
                {
                    x = value;
                    RaisePropertyChanged("X");
                }
            }
        }
        [Key]
        public int Id { get => id; set => id = value; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));

            }
        }
    }
}
