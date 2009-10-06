using System;
using System.Data.Objects;
using System.Linq;
using NUnit.Framework;

namespace Braindrops.DiscoveringEF
{
    [TestFixture]
    public class QueryVariations
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
        public void AllPeople_ListNamesUsingLINQ()
        {
            var query = from p in model.AllPeople
                        where p.Age > 30
                        select p.Name;

            Console.WriteLine("/* Results");
            foreach (var name in query)
            {
                Console.WriteLine("*  " + name);
            }
            Console.WriteLine("*/");
        }

        [Test]
        public void AllPeople_ListNamesUsingLINQ_Parameters()
        {
            var age = 30;
            var query = from p in model.AllPeople
                        where p.Age > age
                        select p.Name;

            Console.WriteLine("/* Results");
            foreach (var name in query)
            {
                Console.WriteLine("*  " + name);
            }
            Console.WriteLine("*/");
        }

        [Test]
        public void AllPeople_ListNamesUsingObjectQuery()
        {
            var query = model.AllPeople
                .Where("it.Age > @age", new ObjectParameter("age", 30))
                .SelectValue<string>("it.Name");

            Console.WriteLine("/* Results");
            foreach (var name in query)
            {
                Console.WriteLine("*  " + name);
            }
            Console.WriteLine("*/");
        }

        [Test]
        public void AllPeople_ListNamesUsingEFSQL()
        {
            var query = model.CreateQuery<string>(
                "SELECT VALUE p.Name FROM AllPeople AS p WHERE p.Age > @age", 
                new ObjectParameter("age", 30));

            Console.WriteLine("/* Results");
            foreach (var name in query)
            {
                Console.WriteLine("*  " + name);
            }
            Console.WriteLine("*/");
        }

        [Test, ExpectedException(typeof(NotSupportedException))]
        public void AllPeople_ListNamesUsingLINQPlusObjectQuery()
        {
            var query = (ObjectQuery <Person>) 
                        from p in model.AllPeople
                        select p;

            query = query.Where("it.Age > 30");

            Console.WriteLine("/* Results");
            foreach (var name in query.Select(p => p.Name))
            {
                Console.WriteLine("*  " + name);
            }
            Console.WriteLine("*/");
        }
    }
}