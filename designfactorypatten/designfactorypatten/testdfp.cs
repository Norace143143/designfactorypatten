using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designfactorypatten
{
    [TestFixture]
    class rectangletest
    {
        rectangle r = new rectangle();
        circle c = new circle();
        triangle t = new triangle();
        [TestCase]
        public void checkrectangleClass()

        {
            int[] a = { 9, 10, 30, 60 };
            Assert.AreEqual(4, r.check(a));
           
        }
        [TestCase]
        public void checkcircleclass()
        {
            int[] a = { 100, 20, 300, 500 };
            Assert.AreEqual(4, c.check(a));
        }
        [TestCase]
        public void checktriangleclass()
        {
            int[] a = { 100, 20, 300, 500, 10, 30 };
            Assert.AreEqual(6, t.check(a));
        }

    }
}
