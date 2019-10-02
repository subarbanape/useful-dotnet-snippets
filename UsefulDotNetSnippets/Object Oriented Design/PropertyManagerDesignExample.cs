using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dvinun.UsefulDotNetSnippets.PropertyManagerDesignExample
{
    // Interface with Polymorphism
    public class Demo
    {
        public static void Run()
        {
            PropertyManagerHelper propertyManagerHelper = new PropertyManagerHelper();

            IPropertyManager[] propertyManagers =
                propertyManagerHelper.GetPropertyManagers();

            HomeRentalSearchParams homeRentalSearchParams = new HomeRentalSearchParams();
            homeRentalSearchParams.ZipCode = "94093";
            homeRentalSearchParams.RentRangeValueFrom = 2000;
            homeRentalSearchParams.RentRangeValueTo = 4000;
            homeRentalSearchParams.NumberOfBedrooms = 2;
            homeRentalSearchParams.PropertyType = PropertyType.Condo;

            List<RentalHome> rentalHomes = new List<RentalHome>();

            foreach (IPropertyManager propertyManager in propertyManagers)
            {
                // Here, the method SearchForRentals is coming from different concrete classes but they all implement the same interface.
                // Hence, we have achieved the polymorphism in interfaces since they call the same methods from their respective classes.
                rentalHomes.AddRange(propertyManager.SearchForRentals(homeRentalSearchParams));
            }

            rentalHomes.ForEach(item => Console.WriteLine(item));
        }
    }

    internal class RentalHome
    {
        public string Value { get; set; }

        public RentalHome(string value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }

    public enum PropertyType
    {
        Condo = 1,
        Apartment = 2,
        Townhome = 3,
    }

    internal class HomeRentalSearchParams
    {
        public string ZipCode { get; internal set; }
        public int RentRangeValueFrom { get; internal set; }
        public int RentRangeValueTo { get; internal set; }
        public int NumberOfBedrooms { get; internal set; }
        public object PropertyType { get; internal set; }
    }

    internal interface IPropertyManager
    {
        RentalHome[] SearchForRentals(HomeRentalSearchParams homeRentalSearchParams);
    }

    internal class PropertyManagerHelper
    {
        internal IPropertyManager[] GetPropertyManagers()
        {
            return new IPropertyManager[] { new ZillowPropertyManager(), new CraigListPropertyManager(), new AirBNBPropertyManager() };
        }
    }

    internal class AirBNBPropertyManager : IPropertyManager
    {
        public RentalHome[] SearchForRentals(HomeRentalSearchParams homeRentalSearchParams)
        {
            return new RentalHome[] { new RentalHome("AirBNB Rental Home Listing - 1"), new RentalHome("AirBNB Rental Home Listing - 2"), new RentalHome("AirBNB Rental Home Listing - 3"), };
        }
    }

    internal class CraigListPropertyManager : IPropertyManager
    {
        public RentalHome[] SearchForRentals(HomeRentalSearchParams homeRentalSearchParams)
        {
            return new RentalHome[] { new RentalHome("CraigList Rental Home Listing - 1"), new RentalHome("CraigList Rental Home Listing - 2"), new RentalHome("CraigList Rental Home Listing - 3"), };
        }
    }

    internal class ZillowPropertyManager : IPropertyManager
    {
        public RentalHome[] SearchForRentals(HomeRentalSearchParams homeRentalSearchParams)
        {
            return new RentalHome[] { new RentalHome("Zillow Rental Home Listing - 1"), new RentalHome("Zillow Rental Home Listing - 2"), new RentalHome("Zillow Rental Home Listing - 3"), };
        }
    }
}
