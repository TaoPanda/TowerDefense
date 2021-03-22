using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TowerDefense.ViewModel
{
    class mapViewModel
    {
        private void GenerateRoute()
        {


        }

       private Array GetCenterOfCell(float cordinat,int cellSize)
        {
            int x = Convert.ToInt32(Math.Floor(cordinat));
            float s = cordinat - x;
            int y = 0;
            while(y != s)
            {
                try
                {
                    y = Convert.ToInt32(s);
                }
                catch
                {
                    s = s * 10;
                }
            }
            Array cords = new Array[x*cellSize,y*cellSize];
            return cords;
        }
    }
}
