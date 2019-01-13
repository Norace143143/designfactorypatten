using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designfactorypatten
{
    public class errorhandle:Exception
    {
        public errorhandle() : base("command does not exit")

        {

        }
        
    }
}
