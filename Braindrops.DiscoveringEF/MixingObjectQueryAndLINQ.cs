// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MixingObjectQueryAndLINQ.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the MixingObjectQueryAndLINQ type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using System;
using System.Linq;
using NUnit.Framework;

namespace Braindrops.DiscoveringEF
{
    [TestFixture]
    public class MixingObjectQueryAndLINQ
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
        public void AllPeopleAndCars_SelectPeopleWhereCarContainsVW()
        {
            var query = from p in model.AllPeople
                        from c in p.Cars
                        where c.Model.Contains("VW")
                        select new { p.Name, c.Model };

            foreach (var name in query)
            {
                Console.WriteLine(name);
            }
        }
    }
}