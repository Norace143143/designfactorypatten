using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designfactorypatten
{
    class rectangle : abstractshape
    {
        public int x, y, width, height;

        public rectangle()
        {
            /*this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;*/
            
        }
        public override void draw(Graphics g)
        {
            Pen p = new Pen(Color.White, 3);
            g.DrawRectangle(p, x, y, width, height);
        }

        public override void set(int[] parameter)
        {
           this.x = parameter[0];
           this.y = parameter[1];
           this.width = parameter[2];
           this.height = parameter[3];
        }
    }
}
