using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designfactorypatten
{
    class shapefactory
    {
        public abstractshape GetName(string shapetype)
        {
            
            string shapetypename = shapetype;

            if (shapetypename.Equals("Rectangle", StringComparison.OrdinalIgnoreCase))
            {
                return new rectangle();
            }
            else if (shapetypename.Equals("Triangle", StringComparison.OrdinalIgnoreCase))
            {
                return new triangle();
            }
            else if (shapetypename.Equals("Circle", StringComparison.OrdinalIgnoreCase))
            {
                return new circle();
            }
            else
            {

                //if we get here then what has been passed in is unknown so throw an appropriate exception
                System.ArgumentException argEx = new System.ArgumentException("Factory error: " + shapetypename + " does not exist");
                throw argEx;
            }

       
            }
        }
}
