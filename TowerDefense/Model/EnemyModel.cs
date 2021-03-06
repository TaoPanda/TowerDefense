using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Media.Imaging;

namespace TowerDefense.Model
{
    public class EnemyModel : INotifyPropertyChanged
    {
        private string name;
        private int hp;
        private int ms;
        private int xp;
        private int position;
        private int cost;
        private string color;
        private Coordinates cordinate;
        private BitmapImage image;

        public string Name { get => name; set => name = value; }
        public int Hp { get => hp; set => hp = value; }
        public int Ms { get => ms; set => ms = value; }
        public int Xp { get => xp; set => xp = value; }
        public int Position { get => position; set { 
            if(position != value)
                {
                    position = value;
                    RaisePropertyChanged("Position");
                }
            } 
        }
        
        public int Cost { get => cost; set => cost = value; }
        public string Color { get => color; set => color = value; }
        public Coordinates Cordinate { get => cordinate; set { 
                if(Cordinate != value)
                {
                    cordinate = value;
                    RaisePropertyChanged("Cordinate");
                }
            } 
        }

        public BitmapImage Image 
        {
            get { return image; }
            set
            {
                if(Image != value)
                {

                    image = value;
                    RaisePropertyChanged("Image");
                }


            }
        }

        public EnemyModel(string name, int hp, int ms, int xp, int cost, string color, Coordinates coordinates, BitmapImage image)
        {
            this.Name = name;
            this.Hp = hp;
            this.Ms = ms;
            this.Xp = xp;
            Position = 0;
            this.Cost = cost;
            this.Color = color;
            this.Cordinate = coordinates;
            this.image = image;
        }

        public EnemyModel(string name, int hp, int ms, int xp, int cost, string color, Coordinates coordinates)
        {
            this.Name = name;
            this.Hp = hp;
            this.Ms = ms;
            this.Xp = xp;
            Position = 0;
            this.Cost = cost;
            this.Color = color;
            this.Cordinate = coordinates;
        }

        public void NextPosition()
        {
            Position++;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
