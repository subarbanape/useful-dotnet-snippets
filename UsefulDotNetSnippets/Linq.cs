using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dvinun.UsefulDotNetSnippets
{
    //public static class ExtensionMethods
    //{
    //    public static bool ContainsFood<Food>(this IEnumerable<Food> foods, string value)
    //    {
    //        foreach (Food food in foods)
    //        {
    //            food
    //                return true;
    //        }
    //        return false;
    //    }
    //}

    // Custom comparer for the Product class
    class DistinctFoodComparer : IEqualityComparer<Food>
    {
        // Products are equal if their names and product numbers are equal.
        public bool Equals(Food x, Food y)
        {
            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            //Check whether the products' properties are equal.
            return x.Type == y.Type;
        }

        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.
        public int GetHashCode(Food food)
        {
            //Check whether the object is null
            if (Object.ReferenceEquals(food, null)) return 0;

            //Calculate the hash code with some random properties.
            return food.Type.GetHashCode();
        }
    }

    // Custom comparer for the Product class
    class FoodComparer : IEqualityComparer<Food>
    {
        // Products are equal if their names and product numbers are equal.
        public bool Equals(Food x, Food y)
        {
            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            //Check whether the products' properties are equal.
            return x.Name.Equals(y.Name, StringComparison.OrdinalIgnoreCase);
        }

        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.
        public int GetHashCode(Food food)
        {
            //Check whether the object is null
            if (Object.ReferenceEquals(food, null)) return 0;

            //Get hash code for the Name field if it is not null.
            int hashFoodName = food.Name == null ? 0 : food.Name.GetHashCode();
            
            //Calculate the hash code with some random properties.
            return hashFoodName;
        }

    }

    public class Book
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public float Cost { get; set; }
    }

    public class Nutrition
    {
        public int VitaminB;
        public int VitaminC;
        public int VitaminD;
        public int Iron;
        public int Carbohydrates;
        public int Magnesium;
        public int Calcium;
        public Nutrition() { }
        public Nutrition(int VitaminB, int VitaminC, int VitaminD, int Iron, int Carbohydrates, int Magnesium, int Calcium)
        {
            this.VitaminB = VitaminB;
            this.VitaminC = VitaminC;
            this.VitaminD = VitaminD;
            this.Iron = Iron;
            this.Carbohydrates = Carbohydrates;
            this.Magnesium = Magnesium;
            this.Calcium = Calcium;
        }

        public void Print()
        {
            Console.WriteLine("VitaminB: {0}, VitaminC: {1}, VitaminD: {2}, Iron: {3}, Carbohydrates: {4}, Magnesium: {5}, Calcium: {6}", 
                            new object[] { VitaminB, VitaminC, VitaminD, Iron, Carbohydrates, Magnesium, Calcium });
        }
    }

    public class Food 
    {
        public string Name;
        public string Type;
        public int SpiceLevel;
        public Nutrition Nutrition;
        public int CaloriesPerServing;

        // Products are equal if their names and product numbers are equal.
        public bool Equals(Food x)
        {
            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(this, x)) return true;

            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null))
                return false;

            //Check whether the products' properties are equal.
            return Type.Equals(x.Type, StringComparison.OrdinalIgnoreCase);
        }

        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.
        public int GetHashCode(Food food)
        {
            //Check whether the object is null
            if (Object.ReferenceEquals(food, null)) return 0;

            //Get hash code for the Name field if it is not null.
            int hashFoodName = food.Name == null ? 0 : food.Name.GetHashCode();

            //Calculate the hash code with some random properties.
            return hashFoodName;
        }
    }

    public class RegionAndFoods
    {
        public string RegionName;
        public List<Food> Foods = new List<Food>();
    }

    public class Linq
    {
        static List<RegionAndFoods> getFoods()
        {
            List<RegionAndFoods> regionAndFoods = new List<RegionAndFoods>() {

                new RegionAndFoods(){ RegionName= "South Indian",
                                          Foods = new List<Food>(){
                                              new Food(){Name = "Chapathi", Type = "Bread", CaloriesPerServing = 50, Nutrition = new Nutrition(10,5,2,9,40,8,12), SpiceLevel=1},
                                              new Food(){Name = "Parota", Type = "Bread", CaloriesPerServing = 100, Nutrition = new Nutrition(8,2,4,40,55,2,2), SpiceLevel=1},
                                              new Food(){Name = "Egg Omelete", Type = "Snack", CaloriesPerServing = 80, Nutrition = new Nutrition(10,20,4,50,55,15,30), SpiceLevel=2},
                                              new Food(){Name = "Rice Sambar", Type = "Meal", CaloriesPerServing = 200, Nutrition = new Nutrition(3,10,7,15,60,7,10), SpiceLevel=3},
                                              new Food(){Name = "Biryani", Type = "Entries", CaloriesPerServing = 300, Nutrition = new Nutrition(3,3,9,13,75,9,18), SpiceLevel=4},
                                          }  },
                new RegionAndFoods(){ RegionName= "North Indian",
                                          Foods = new List<Food>(){
                                              new Food(){Name = "Pani Puri", Type = "Snack", CaloriesPerServing = 36, Nutrition = new Nutrition(10,8,4,30,50,7,10), SpiceLevel=5},
                                              new Food(){Name = "Butter Naan", Type = "Bread", CaloriesPerServing = 150, Nutrition = new Nutrition(1,6,9,15,60,17,12), SpiceLevel=1},
                                              new Food(){Name = "Malai Kofta", Type = "Curry", CaloriesPerServing = 250, Nutrition = new Nutrition(8,20,15,20,60,7,5), SpiceLevel=3},
                                          }  },
                new RegionAndFoods(){ RegionName= "Mexican",
                                        Foods = new List<Food>(){
                                            new Food(){Name = "Tortilla", Type = "Starters", CaloriesPerServing = 80, Nutrition = new Nutrition(4,6,2,15,60,2,15), SpiceLevel=2},
                                            new Food(){Name = "Tacos al pastor", Type = "Entries", CaloriesPerServing = 170, Nutrition = new Nutrition(7,3,10,20,70,19,10), SpiceLevel=1},
                                            new Food(){Name = "Enchiladas", Type = "Entries", CaloriesPerServing = 319, Nutrition = new Nutrition(1,21,14,20,65,12,15), SpiceLevel=2},
                                        }  },
                new RegionAndFoods(){ RegionName= "Japanese",
                                        Foods = new List<Food>(){
                                            new Food(){Name = "Ramen Noodles", Type = "Starters", CaloriesPerServing = 188, Nutrition = new Nutrition(2,8,5,25,70,12,3), SpiceLevel=3},
                                            new Food(){Name = "Sushi", Type = "Lunch", CaloriesPerServing = 280, Nutrition = new Nutrition(12,23,10,30,30,12,7), SpiceLevel=3},
                                            new Food(){Name = "Tempura", Type = "Breakfast", CaloriesPerServing = 50, Nutrition = new Nutrition(15,7,20,20,30,30,20), SpiceLevel=4},
                                        }  },
                 new RegionAndFoods(){ RegionName= "American",
                                        Foods = new List<Food>(){
                                            new Food(){Name = "Cheeseburger", Type = "Lunch", CaloriesPerServing = 300, Nutrition = new Nutrition(2,3,4,18,60,6,10), SpiceLevel=1},
                                            new Food(){Name = "Sandwich", Type = "Breakfast", CaloriesPerServing = 400, Nutrition = new Nutrition(8,12,8,20,50,2,9), SpiceLevel=2},
                                            new Food(){Name = "Apple Pie", Type = "Desserts", CaloriesPerServing = 500, Nutrition = new Nutrition(1,3,4,8,12,70,13), SpiceLevel=0},
                                            new Food(){Name = "Salad", Type = "Starters", CaloriesPerServing = 120, Nutrition = new Nutrition(6,9,24,35,20,14,40), SpiceLevel=1},
                                        }  }
            };

            return regionAndFoods;
        }

        public static void EnumerableMethods()
        {
            Book[] books = {
                new Book() { Author = "Bob", Cost = 20.3F, Name = "Learn Java"},
                new Book() { Author = "John", Cost = 10.5F, Name = "Learn C++"},
                new Book() { Author = "Nick", Cost = 5.5F, Name = "Learn C#"},
                new Book() { Author = "Bob", Cost = 13.5F, Name = "Learn Angular"},
            };

            // check if all books are less than $11
            // All - Determines whether all elements of a sequence satisfy a condition.
            bool discountedBooksExist = books.All(book => book.Cost < 11);

            // get discounted books that are less than $11
            var discountedBooks = from book in books
                                  where book.Cost < 11
                                  select book;
            foreach (Book book in discountedBooks)
                Console.WriteLine("{0} {1} {2}", book.Name, book.Author, book.Cost);

            // check if all books are less than $11
            // Any - Determines whether any element in the sequence satisfy a condition.
            discountedBooksExist = books.Any(book => book.Cost < 11);

            // get the average cost of all books
            var averageCostOfAllBooks = (from book in books
                                         select book.Cost).Average();

            // order by
            var sortedBooksByCost = books.OrderBy(book => book.Cost);
            // using query expression (this will be eventually converted to Lambda at runtime)
            sortedBooksByCost = (from book in books
                                 orderby book.Cost
                                 select book);

            // cast
            ArrayList dogsTypeList = new ArrayList();
            dogsTypeList.Add("Lab");
            dogsTypeList.Add("Pung");
            dogsTypeList.Add("Dalmat");
            dogsTypeList.Add("Dachsh");
            dogsTypeList.Add("Pitbull");
            var sortedDogsTypeList = dogsTypeList.Cast<string>().OrderBy(dog => dog);

            // concat
            // combine book names and dogs, and sort them
            IEnumerable<string> dogsAndBooks = dogsTypeList.Cast<string>().Select(dog => dog).Concat(books.Select(book => book.Name)).OrderBy(item => item);

            List<RegionAndFoods> regionsAndFoods = getFoods();

            // select many 
            // get all foods and the region
            var regionAndFoodCollection =
                   regionsAndFoods
                   .SelectMany(regionAndFoods => regionAndFoods.Foods, (regionAndFoods, food) => new { regionAndFoods.RegionName, food })
                   .Select(regionAndFoodItem =>
                           new
                           {
                               RegionName = regionAndFoodItem.RegionName,
                               FoodName = regionAndFoodItem.food.Name
                           }
                   );

            // print enumerable - approach 1
            Console.WriteLine(String.Join(Environment.NewLine, regionAndFoodCollection));

            // print enumerable - approach 2
            var printable = (from item in regionAndFoodCollection
                             select "Region: " + item.RegionName + "Food: " + item.FoodName);
            Console.WriteLine(String.Join(Environment.NewLine, printable));

            // print enumerable - approach 3
            foreach (var item in regionAndFoodCollection) Console.WriteLine("Region: {0}, Food: {1}", item.RegionName, item.FoodName);

            // just select all the foods
            var anonymousAllFoods = regionsAndFoods.SelectMany(regionAndFoods => regionAndFoods.Foods, (regionAndFoods, food) => new { food });

            // contains - check if there is a food called paddu
            // SORRY. You cant use contains on Anonymous types or its way too hard to achieve. Use query instead.
            // var isThereAFoodPaddu = allFoods.Contains(new Food(), new FoodComparer());

            // approach - 1
            // this returns true as the count is one as Paddu is not found but Pani Puri is found
            var isThereAFoodPadduOrPaniPuri = (from item in anonymousAllFoods
                                               where item.food.Name.Equals("paddu", StringComparison.OrdinalIgnoreCase) ||
                                               item.food.Name.Equals("pani puri", StringComparison.OrdinalIgnoreCase)
                                               select item
                                     ).Count() > 0;

            // approach - 2
            // this is not an efficient way to search for an object because we have to work with anonymous collection
            // which means it needs to be converted first to actual food class collection and then call contains on the collection.
            // If you have anonymous types, it would be best to use query like shown in approach 1.
            var allFoods = (from item in anonymousAllFoods
                            select
                            (new Food() { Name = item.food.Name,
                                CaloriesPerServing = item.food.CaloriesPerServing,
                                Nutrition = item.food.Nutrition,
                                SpiceLevel = item.food.SpiceLevel,
                                Type = item.food.Type
                            })
                                               );
            var isThereAFoodPaddu = allFoods.Contains(new Food() { Name = "paddu" }, new FoodComparer());
            var isThereAFoodPaniPuri = allFoods.Contains(new Food() { Name = "pani puri" }, new FoodComparer());

            // get top 3 healthy foods which are rich in calcium.
            var top3HealthyFoods =
                   regionsAndFoods
                   .SelectMany(regionAndFoods => regionAndFoods.Foods, (regionAndFoods, food) => new { regionAndFoods.RegionName, food })
                   .Select(regionAndFoodItem =>
                           new
                           {
                               RegionName = regionAndFoodItem.RegionName,
                               Food = regionAndFoodItem.food
                           }
                   )
                   .OrderByDescending(item => item.Food.Nutrition.Calcium)
                   .Take(3)
                   .Select(healthyFood => new { RegionName = healthyFood.RegionName, FoodName = healthyFood.Food.Name, Calcium = healthyFood.Food.Nutrition.Calcium });
            Console.WriteLine(String.Join(Environment.NewLine, top3HealthyFoods));

            // get top 3 spicy foods
            var top3SpicyFoods =
                   regionsAndFoods
                   .SelectMany(regionAndFoods => regionAndFoods.Foods, (regionAndFoods, food) => new { regionAndFoods.RegionName, food })
                   .Select(regionAndFoodItem =>
                           new
                           {
                               RegionName = regionAndFoodItem.RegionName,
                               Food = regionAndFoodItem.food
                           }
                   )
                   .OrderByDescending(item => item.Food.SpiceLevel)
                   .Take(3)
                   .Select(healthyFood => new { RegionName = healthyFood.RegionName, FoodName = healthyFood.Food.Name, SpiceLevel = healthyFood.Food.SpiceLevel });
            Console.WriteLine(String.Join(Environment.NewLine, top3SpicyFoods));

            // default or empty
            RegionAndFoods defaultRegionAndFoods = new RegionAndFoods() { RegionName = "Default Region" };
            foreach (var regionAndFoods in regionsAndFoods.DefaultIfEmpty(defaultRegionAndFoods))
            {
                Console.WriteLine("Region: {0}", regionAndFoods.RegionName);
            }

            // distinct - get distinct food based on type
            var distinctIndianFoods =
                (from indianFood in (
                regionsAndFoods
                   .SelectMany(regionAndFoods => regionAndFoods.Foods, (regionAndFoods, food) => new { regionAndFoods.RegionName, food })
                   .Where(regionAndFoodItem => (regionAndFoodItem.RegionName == "South Indian" || regionAndFoodItem.RegionName == "North Indian"))
                )
                 select
                 (new Food()
                 {
                     Name = indianFood.food.Name,
                     CaloriesPerServing = indianFood.food.CaloriesPerServing,
                     Nutrition = indianFood.food.Nutrition,
                     SpiceLevel = indianFood.food.SpiceLevel,
                     Type = indianFood.food.Type
                 })).Distinct(new DistinctFoodComparer());

            // group by - group all foods by type
            var groupByTypeFoods =
                regionsAndFoods
                   .SelectMany(regionAndFoods => regionAndFoods.Foods, (regionAndFoods, food) => new { food })
                   .GroupBy(foods => foods.food.Type);

            // aggregate - get the comma separated regions
            var commaSeparatedRegions = regionsAndFoods.Aggregate("", (currentVal, nextVal) => currentVal + ", " + nextVal.RegionName);

            // aggregate and select many - get the total of all nutrition values
                 regionsAndFoods
                   .SelectMany(regionAndFoods => regionAndFoods.Foods, (regionAndFoods, food) => new { food.Nutrition })
                    .Select(nutrition =>
                           new
                           {
                               nutrition.Nutrition.Calcium,
                               nutrition.Nutrition.Carbohydrates,
                               nutrition.Nutrition.Iron,
                               nutrition.Nutrition.Magnesium,
                               nutrition.Nutrition.VitaminB,
                               nutrition.Nutrition.VitaminD,
                               nutrition.Nutrition.VitaminC,
                           }
                   )
                   .Aggregate(new Nutrition(),(currentVal, nextVal) => {
                                                                            currentVal.Calcium += nextVal.Calcium;
                                                                            currentVal.Carbohydrates += nextVal.Carbohydrates;
                                                                            currentVal.Iron += nextVal.Iron;
                                                                            currentVal.Magnesium += nextVal.Magnesium;
                                                                            currentVal.VitaminB += nextVal.VitaminB;
                                                                            currentVal.VitaminD += nextVal.VitaminD;
                                                                            currentVal.VitaminC += nextVal.VitaminC;
                                                                            return currentVal;  }).Print();

            // select - once again :-) in case if you have gotten confused coming this far!
            // to extract the regions and return the list
            var listOfRegions = regionsAndFoods.Select(item1 => item1.RegionName);
        }
    }
}
