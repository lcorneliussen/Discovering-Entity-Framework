using System;
using System.Data;
using System.Data.Common;
using System.Data.Objects;
using System.Linq;
using NUnit.Framework;

namespace Braindrops.DiscoveringEF
{
    [TestFixture]
    public class SampleQueries
    {
        private PeopleModelConnection model;

        [SetUp]
        public void SetUp()
        {
            model = new PeopleModelConnection();
        }

        [TearDown]
        public void TearDown()
        {
            model.Dispose();
        }

        [Test]
        public void SelectPeopleWithCars()
        {
            var query = 
                from p in model.AllPeople
                        from c in p.Cars
                        orderby c.Model
                        select new { p.Name, c.Model };

            Console.WriteLine("/* Results");
            foreach (var name in query)
            {
                Console.WriteLine("*  " + name);
            }
            Console.WriteLine("*/");
        }

        [Test, ExpectedException(typeof(NotSupportedException))]
        public void SelectPeopleWithOrWithoutCars_LINQ()
        {
            var query =
                from p in model.AllPeople
                from c in p.Cars.DefaultIfEmpty()
                orderby c.Model
                select new { p.Name, Model = c != null ? c.Model : null };

            Console.WriteLine("/* Results");
            foreach (var name in query)
            {
                Console.WriteLine("*  " + name);
            }
            Console.WriteLine("*/");
        }

        [Test]
        public void SelectPeopleWithOrWithoutCars_EntitySQL()
        {
            var query = model.CreateQuery<IDataRecord>(
                      "SELECT p.Name, c.Model FROM AllPeople as " 
                    + "p OUTER APPLY p.Cars as c ORDER BY c.Model");
            
            var casted = from item in query.ToArray() /* executes here */
                         select new {
                             Name = item.GetString(0), 
                             Model = (item.IsDBNull(1) ? null : item.GetString(1))
                         };
            
            Console.WriteLine("/* Results");
            foreach (var item in casted)
            {
                Console.WriteLine("*  " + item);
            }
            Console.WriteLine("*/");
        }

        [Test]
        public void SelectPeopleByModelVolkswagen_LINQ()
        {
            var query =
                from p in model.AllPeople
                where p.Cars.Any(c => c.Model.Contains("VW"))
                select p;

            Console.WriteLine("/* Results");
            foreach (var person in query)
            {
                Console.WriteLine("*  " + new {person.Name, person.Age});
            }
            Console.WriteLine("*/");
        }

        [Test]
        public void SelectPeopleByModelVolkswagen_ObjectQuery()
        {
            var query = model.AllPeople.Where("EXISTS(SELECT c FROM it.Cars as c WHERE c.Model LIKE '%vw%')")
              .Where("it.Name LIKE @pattern", new ObjectParameter("pattern", "m%"));

            Console.WriteLine("/* Results");
            foreach (var person in query)
            {
                Console.WriteLine("*  " + new { person.Name, person.Age });
            }
            Console.WriteLine("*/");
        }
    }
}