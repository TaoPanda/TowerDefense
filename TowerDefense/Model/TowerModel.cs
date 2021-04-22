using Nest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Windows.Media.Imaging;
using TowerDefense.ViewModel;

namespace TowerDefense.Model
{
    public class TowerModel : INotifyPropertyChanged
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
        private int attackCount = 0;

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
            distance(1, 1, 4, 2);
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
        public int AttackCount
        {
            get => attackCount; set
            {
                if (attackCount != value)
                {
                    attackCount = value;
                    RaisePropertyChanged("AttackCount");
                }
            }
        }

        static double distance(int x1, int y1, int x2, int y2)
        {
            double test = Math.Sqrt(Math.Pow(x2 - x1, 2) +
                          Math.Pow(y2 - y1, 2) * 1.0);
            double final = Math.Round((test * 100000.0) / 100000);
            return final;
        }

        public void checkRange()
        {
            MapViewModel MapView = (MapViewModel)App.Current.Resources["sharedMapViewModel"];
            foreach (EnemyModel enemy in MapView.ActiveEnemies)
            {
                if (distance(cordinate.X / 25, cordinate.Y / 25, enemy.Cordinate.X / 25, enemy.Cordinate.Y / 25) <= range)
                {
                    attack(enemy, Dmg);

                }
            }
        }

        public void attack(EnemyModel enemy, int damage)
        {
            // Kinda Fields i think

            // Get The directory that your in
            string replaceMe = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));

            // BitmapImages for enemies
            BitmapImage break1 = new BitmapImage(new Uri($@"file:\\\" + $"{replaceMe}" + @"\images\break1.png", UriKind.Absolute));
            BitmapImage break2 = new BitmapImage(new Uri($@"file:\\\" + $"{replaceMe}" + @"\images\break2.png", UriKind.Absolute));
            BitmapImage break3 = new BitmapImage(new Uri($@"file:\\\" + $"{replaceMe}" + @"\images\break3.png", UriKind.Absolute));

            AttackCount++;
            enemy.Hp -= damage;

            // This is where the image gets changed, the image depends on the health of the enemy
            if (enemy.Hp <= 75 && enemy.Hp > 50)
            {
                enemy.Image = break1;
            }
            if (enemy.Hp <= 50 && enemy.Hp > 25)
            {
                enemy.Image = break2;
            }
            if (enemy.Hp <= 25)
            {
                enemy.Image = break3;
            }
        }
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