using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designfactorypatten
{
    /// <summary>
    /// this class is for triangle 
    /// inheritance abstract class
    /// draw the triangle using graphic 
    /// </summary>
    class triangle : abstractshape
    {
        //declaring the variable 
        public int x1, x2, x3, y1, y2, y3;
        //constructor
        public triangle()
        {
        }
        //method for drawing 
        public override void draw(Graphics g)
        {
            Pen p = new Pen(Color.White, 3);
            Point[] point = new Point[3];
            point[0] = new Point(x1, y1);
            point[1] = new Point(x2, y2);
            point[2] = new Point(x3, y3);
            g.DrawPolygon(p, point);

        }
        //method for setting the parameter
        public override void set(int[] parameter)
        {
            if (check(parameter) == 6)
            {
                x1 = parameter[0];
                y1 = parameter[1];
                x2 = parameter[2];
                y2 = parameter[3];
                x3 = parameter[4];
                y3 = parameter[5];
            }
        }

        public int check(int[] a)
        {
            return a.Length;
        }
    }
}
