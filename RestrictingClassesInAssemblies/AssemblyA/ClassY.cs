using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyA
{
    internal class ClassY : IBaseInterface
    {
        public void SomeMethod1()
        {
            Console.WriteLine("I am method of from Class Y - Some Method1");
        }

        public void SomeMethod2()
        {
            Console.WriteLine("I am method of from Class Y - Some Method2");
        }

        public void SomeMethod3()
        {
            Console.WriteLine("I am method of from Class Y - Some Method3");
        }
    }
}
