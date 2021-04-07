using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CrazyCircle
{
    public class Circle
    {
        public int id;
        public int radius;
        public double area;
        public Point center;

        public Circle(int id, int centerX, int centerY, int radius)
        {
            this.id = id;
            this.center = new Point(centerX, centerY);
            this.radius = radius;
            this.area = Math.PI * (radius * radius);
        }
        public override string ToString()
        {   
            return String.Format("{0}. Centro=({1},{2}), Area={3}, Radio={4}", id, center.X, center.Y, Math.Round(area, 2), radius);
        }
    }
}
