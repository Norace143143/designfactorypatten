using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designfactorypatten
{
    /// <summary>
    /// this class is a interface 
    /// all method are described 
    /// </summary>
    interface Shapes
    {
        //method for setting the parameter 
        void set(int[] parameter);
        //method for drawing 
        void draw(Graphics g);

       

    }
}
