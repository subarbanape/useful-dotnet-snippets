using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Assignment Question
//Create 2 interfaces(ICar and IBike), define 2 methods(Car_M1 and Car_M2 ) in IOne and 3 methods(IBike_M1, IBike_M2 and IBike_M3) in IBike.
//Inherit both interfaces(ICar and IBike) into class (C_Vehicle).
//In another class create 2 C_Vehicle class objects one for Car other for Bike.
//In such a way that 
//if required to use Car object methods(Car_MI and Car_M2) only should be available/accessible.
//if required to use Bike methods(IBike_M1, IBike_M2 and IBike_M3) only should be available/accessible.

namespace Dvinun.UsefulDotNetSnippets.Object_Oriented_Design.BikeAndCar
{
    public interface ICar
    {
        void CarM1();
        void CarM2();
    }

    public interface IBike
    {
        void BikeM1();
        void BikeM2();
    }

    class CVehicle : ICar, IBike
    {
        public void BikeM1()
        {
            Console.WriteLine("I am Bike M1");
        }

        public void BikeM2()
        {
            Console.WriteLine("I am Bike M2");
        }

        public void CarM1()
        {
            Console.WriteLine("I am Car M1");
        }

        public void CarM2()
        {
            Console.WriteLine("I am Car M2");
        }
    }

    public class Demo
    {
        public static void Run()
        {
            CVehicle Car = new CVehicle();
            CVehicle Bike = new CVehicle();

            ICar ICar = Car as ICar;
            IBike IBike = Bike as IBike;

            ICar.CarM1();
            ICar.CarM2();
            IBike.BikeM1();
            IBike.BikeM2();
        }
    }
}
