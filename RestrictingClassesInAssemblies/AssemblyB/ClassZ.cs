using AssemblyA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyB
{
    public class ClassZ
    {
        // Assignment Question
        // Create 2 Assemblies(A and B)
        // Declare 2 Classes(X and Y) in Assembly A both classes should be accessible in Assembly B.
        // But restrict the instantiation of class Y in Assembly B.
        // But methods from the Class Y should be accessible in Assembly B via Class X.
        public static void Main()
        {
            ClassX classXObj = new ClassX();
            classXObj.MethodOfClassX();
            IBaseInterface baseInterface = classXObj.classYObject;
            baseInterface.SomeMethod1();
            baseInterface.SomeMethod2();
            baseInterface.SomeMethod3();
        }
    }
}
