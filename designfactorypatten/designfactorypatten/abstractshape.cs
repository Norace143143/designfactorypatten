using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designfactorypatten
{
    /// <summary>
    /// this is abstract class
    /// all method are made abstract 
    /// </summary>
    abstract class abstractshape : Shapes
    {
        //method for drawing shape
        public abstract void draw(Graphics g);
        //method for setting the parameter 
        public abstract void set(int[] parameter);
                 
    }
}
