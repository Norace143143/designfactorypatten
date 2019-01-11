using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designfactorypatten
{
    /// <summary>
    /// this class is for rectangle 
    /// inheritance abstract class
    /// draw the rectangle using graphic 
    /// </summary>
    class rectangle : abstractshape
    {
        //declaring the variable 
        public int x, y, width, height;
        //constructor
        public rectangle()
        {
                      
        }
        //method for drawing 
        public override void draw(Graphics g)
        {
            Pen p = new Pen(Color.White, 3);
            g.DrawRectangle(p, x, y, width, height);
        }
        //method for setting the parameter
        public override void set(int[] parameter)
        {
           this.x = parameter[0];
           this.y = parameter[1];
           this.width = parameter[2];
           this.height = parameter[3];
        }
    }
}
