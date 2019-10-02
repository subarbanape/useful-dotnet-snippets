using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dvinun.UsefulDotNetSnippets.Object_Oriented_Design.SOLID_Principles
{
    public class LiskovSubstitutionPrinciple
    {   
        public static void DemoRun()
        {
            // With this principle, we have a clean separation of concerns by splitting the behavior
            // of the classes as separate behavior based interfaces

            Automobile car = new Car();
            IsRentable rentableCar = car as IsRentable;
            IRentalRepository rentalRepository = new ABCCompanyRentalRepository();
            if(rentableCar != null) rentalRepository.ListForRental(rentableCar);

            Automobile plane = new Plane();
            IsRentable rentablePlane = plane as IsRentable;
            if (rentablePlane != null) rentalRepository.ListForRental(rentablePlane);
        }

        private interface IsRentable
        {
        }

        private interface IRentalRepository
        {
            void ListForRental(IsRentable auto);
        }

        private class Automobile
        {
        }

        private class Car : Automobile, IsRentable
        {
        }

        private class ABCCompanyRentalRepository : IRentalRepository
        {
            public void ListForRental(IsRentable auto)
            {
            }
        }

        private class Plane : Automobile
        {
        }
    }
}
