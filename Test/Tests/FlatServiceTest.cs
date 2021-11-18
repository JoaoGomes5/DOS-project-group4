using NUnit.Framework;
using Code.Models;
using Code.Services;

namespace Test.Tests
{
    public class FlatServiceTest
    {
        public FlatServiceTest()
        {
            
        }
        FlatService flatService = new FlatService();
        [Test]
        public void itShouldBeAbleToCalculateFlatCost()
        {
            Flat flat = new Flat();

            float result = flatService.calculateFlatCost(flat, 100);
          
        }   
    }
}