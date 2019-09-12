using System;

// Examples of Inheritance and Constructors in CSharp
namespace Dvinun.UsefulDotNetSnippets
{
    public abstract class BaseClass
    {
        int Param1, Param2;

        public BaseClass(int param1, int param2)
        {
            this.Param1 = param1;
            this.Param2 = param2;
        }

        public override string ToString() => $"{this.Param1} {this.Param2}";
    }

    // Inheriting the baseclass into childclass mandates child class call the base class constructor
    public class ChildClass : BaseClass
    {
        int Param3, Param4;

        public ChildClass() : this(1, 2) { }
        public ChildClass(int param3, int param4) : base(param3-1, param4-1) {
            this.Param3 = param3;
            this.Param4 = param4;
        }

        public override string ToString() => $"{this.Param3} {this.Param4}";
    }

    class Constructors
    {
        public static void Main()
        {
            // Cannot instantiate abstract classes
            // var someObj = new BaseClass();
            // var someObj = new BaseClass(1,2);

            var someObj = new ChildClass(4, 5);
            Console.WriteLine(someObj);
        }
    }
}
