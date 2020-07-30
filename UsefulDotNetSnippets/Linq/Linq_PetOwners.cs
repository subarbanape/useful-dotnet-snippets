using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLambdaDemo.Linq
{
    //Just a code dump to try the Join method.
    public class Linq_PetOwners
    {
        class Person
        {
            public Person(string name, int id) { Name = name; Id = id; }
            public string Name;
            public int Id;
        }

        class Pet
        {
            public Pet(string pet, int ownerId) { PetName = pet; OwnerId = ownerId; }

            public string PetName;
            public int OwnerId;
        }

        class PetOwner
        {
            public PetOwner(string ownerName, string[] petName) { OwnerName = ownerName; PetName = petName; }

            public string OwnerName;
            public string[] PetName;
        }
        public void Run()
        {
            var petOwners = new List<Person>() {
                    new Person("joe", 1),
                    new Person("bob", 2),
                    new Person("kim", 3),
                };

            var pets = new List<Pet>()
                {
                    new Pet("ramu", 3),
                    new Pet("daisy", 2),
                    new Pet("sonu", 3),
                    new Pet("bolt", 2),
                    new Pet("ana", 1),
                    new Pet("yogi", 2),
                };

            var result = petOwners.Join(
                pets,
                po => po.Id,
                p => p.OwnerId,
                (po, p) => new { OwnerName = po.Name, PetName = p.PetName }
                )
                .GroupBy(joined => joined.OwnerName)
                .Select(item => {
                    return new PetOwner(item.Key, item.Select(valueItem => valueItem.PetName).ToArray());
                });
        }
    }
}
