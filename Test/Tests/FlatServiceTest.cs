using NUnit.Framework;
using Code.Models;
using Code.Services;

namespace Test.Tests
{
    public class FlatServiceTest
    {
        FlatService flatService = new FlatService();

        [Test]
        public void itShouldBeAbleToCalculateFlatCost()
        {
            Flat flat = new Flat
            {
                Id = 1,
                SquareMeters = 20,
                NumberOfRooms = 2

            };

            float expectedValue = flatService.calculateFlatCost(flat, 100);

            Assert.AreEqual(expectedValue,2000);


          
        }   
    }
}