using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyA
{
   public class ClassX 
   {
        public IBaseInterface classYObject;

        public ClassX()
        {
            classYObject = new ClassY();
        }

        public void MethodOfClassX()
        {
            Console.WriteLine("I am method of from Class Xs");
        }
    }
}
