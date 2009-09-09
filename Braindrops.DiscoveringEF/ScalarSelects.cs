using System;
using System.Data.Objects;
using System.Linq;
using NUnit.Framework;

namespace Braindrops.DiscoveringEF
{
    [TestFixture]
    public class ScalarSelects
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
        public void AllPeople_SelectAll_ShouldBe4()
        {
            model.AllPeople.Count().Should().Be.EqualTo(4);
        }

        [Test]
        public void AllPeople_ListNamesUsingLINQ()
        {
            var query = from p in model.AllPeople
                        where p.Age > 30
                        select p.Name;

            foreach (var name in query)
            {
                Console.WriteLine(name);
            }
        }

        [Test]
        public void AllPeople_ListNamesUsingObjectQuery()
        {
            var query = model.AllPeople
                .Where("it.Age > @age", new ObjectParameter("age", 30))
                .SelectValue<string>("it.Name");

            foreach (string name in query)
            {
                Console.WriteLine(name);
            }
        }

        [Test]
        public void AllPeople_ListNamesUsingEFSQL()
        {
            var query = model.CreateQuery<string>(
                "SELECT VALUE p.Name FROM AllPeople AS p WHERE p.Age > @age", 
                new ObjectParameter("age", 30));

            foreach (string name in query)
            {
                Console.WriteLine(name);
            }
        }
    }
}