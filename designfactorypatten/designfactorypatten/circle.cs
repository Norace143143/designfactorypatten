using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designfactorypatten
{
    /// <summary>
    /// this class is for circle
    /// inheritance abstract class
    /// draw the circle using graphic 
    /// </summary>
    class circle : abstractshape
    {
        //declaring the variable 
        public int x, y, r1, r2;
        //constructor
        public circle()
        {
         
        }
        //method for drawing 
        public override void draw(Graphics g)
        {
            Pen p = new Pen(Color.White, 3);
            g.DrawEllipse(p, x, y, r1, r2);
        }
        //method for setting the parameter
        public override void set(int[] parameter)
        {
            x = parameter[0];
            y = parameter[1];
            r1 = parameter[2];
            r2 = parameter[3];
        }
    }
}
