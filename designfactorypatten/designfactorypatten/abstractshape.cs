using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designfactorypatten
{
    abstract class abstractshape : Shapes
    {
        public abstract void draw(Graphics g);

        public abstract void set(int[] parameter);
       
       // public abstract void rectangle(int x, int y, int width, int height);

       // public abstract void circle(int x, int y, int r1, int r2);

      //  public abstract void triangle(int x1, int x2, int x3, int y1, int y2, int y3);
      
    }
}
