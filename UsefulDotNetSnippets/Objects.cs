using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dvinun.UsefulDotNetSnippets
{
    public static class AnonymousTypes
    {
        public static void CreateAnonymousTypeObjects()
        {
            var anonymousType = new
            {
                prop1 = "prop1",
                prop2 = 2,
                prop3 = true
            };

            Console.WriteLine(anonymousType);
        }
    }
}
