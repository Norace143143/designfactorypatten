using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designfactorypatten
{
    class polygon: abstractshape
    {
        int po1,  po2, po3, po4, po5, po6, po7, po8, po9, po10;
        /// <summary>
        /// graphics is created
        /// pen instance is used to draw border for shape
        /// </summary>
        /// <param name="g">with the help of graphic object rectangle is drawn</param>
        public override void draw(Graphics g)
        {
            // Create pen.
            Pen p = new Pen(Color.White, 3);

            // Create points that define polygon.
            Point[] pt = new Point[8];
            pt[0] = new Point(po1, po2);
            pt[1] = new Point(po3, po4);
            pt[2] = new Point(po5, po6);
            pt[3] = new Point(po7, po8);
            pt[4] = new Point(po9, po10);

            g.DrawPolygon(p, pt);
        }
        /// <summary>
        /// setting data into parameter
        /// parameter are enlisted in array format
        /// this is used for same variable
        /// </summary>
        /// <param name="list">variable is instantiate so every value can pass thorugh it</param>
        public override void set(int[] list)
        {
            po1 = list[0];
            po2 = list[1];
            po3 = list[2];
            po4 = list[3];
            po5 = list[4];
            po6 = list[5];
            po7 = list[6];
            po8 = list[7];
            po9 = list[8];
            po10 = list[9];

        }
    }
}
