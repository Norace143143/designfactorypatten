using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designfactorypatten
{
    /// <summary>
    /// this class is a factory calss 
    /// parameter is passed 
    /// if command check and return shape 
    /// </summary>
    class shapefactory
    {
        public abstractshape GetName(string shapetype)
        {
            //variable to collect passed parameter
            string shapetypename = shapetype;
            //checking the passed parameter 
            if (shapetypename.Equals("Rectangle", StringComparison.OrdinalIgnoreCase))
            {
                //returning the class
                return new rectangle();
            }
            //checking the passed parameter 
            else if (shapetypename.Equals("Triangle", StringComparison.OrdinalIgnoreCase))
            {
                //returning the class
                return new triangle();
            }
            //checking the passed parameter 
            else if (shapetypename.Equals("Circle", StringComparison.OrdinalIgnoreCase))
            {
                //returning the class
                return new circle();
            }
            else if (shapetypename.Equals("POLYGON", StringComparison.OrdinalIgnoreCase))
            {
                //returning the class
                return new polygon(); //creating instance of polygon
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
