using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDotNet
{
    public class TestCompareTwoCollections
    {
        public void SequenceEqualEx1()
        {
            Pet pet1 = new Pet { Name = "Turbo", Age = 2 };
            Pet pet2 = new Pet { Name = "Peanut", Age = 8 };

            Pet pet3 = new Pet { Name = "Turbo", Age = 2 };

            // Create two lists of pets.
            List<Pet> pets1 = new List<Pet> { pet1, pet2 };
            List<Pet> pets2 = new List<Pet> { pet3, pet2 };

            // SequenceEqual use the Equals method, if there is no override Equals(), it will compare values.
            // 1. To compare two primitive collections, use SequenceEqual() directly. 
            // 2. To compare two object collections, implement Equals() on object and then use SequenceEqual().
            bool equal = pets1.SequenceEqual(pets2);

            Console.WriteLine(
                "The lists {0} equal.",
                equal ? "are" : "are not");
        }

        public void test()
        {
            var obj = new TestCompareTwoCollections();
            obj.SequenceEqualEx1();
        }
    }

    class Pet
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override bool Equals(object o)
        {
            Pet obj = (Pet) o;

            return obj.Name.Equals(Name) && obj.Age == Age;
        }
    }

}
