using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designfactorypatten
{
    class circle : abstractshape
    {
        public int x, y, r1, r2;

        public circle()
        {
           /* this.x = x;
            this.y = y;
            this.r1 = r1;
            this.r1 = r2;*/
        }
        public override void draw(Graphics g)
        {
            Pen p = new Pen(Color.White, 3);
            g.DrawEllipse(p, x, y, r1, r2);
        }

        public override void set(int[] parameter)
        {
            x = parameter[0];
            y = parameter[1];
            r1 = parameter[2];
            r2 = parameter[3];
        }
    }
}
