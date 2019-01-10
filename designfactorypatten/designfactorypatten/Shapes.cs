using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designfactorypatten
{
    interface Shapes
    {
        void set(int[] parameter);

        void draw(Graphics g);

        //void rectangle(int x, int y, int width, int height);
        //void circle(int x, int y, int r1, int r2);
        //void triangle(int x1, int x2, int x3, int y1, int y2, int y3);

    }
}
