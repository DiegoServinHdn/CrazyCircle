using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyCircle
{
    public class Circle
    {
        public int id;
        public int radius;
        public double area;
        public int centerX;
        public int centerY;

        public Circle(int ID, int centerX, int centerY, int radius_)
        {
            id = ID;
            this.centerX = centerX;
            this.centerY = centerY;
            radius = radius_;
            area = Math.PI * (radius * radius);
        }
        public override string ToString()
        {
            return String.Format("{0}. Centro=({1},{2}), Area={3}, Radio={4}", id, centerX, centerY, Math.Round(area, 2), radius);
        }
    }
}
