using NUnit.Framework;
using Code.Models;
using Code.Services;
using System.Collections.Generic;

namespace Test
{
    public class OwnerServiceTest
    {
        
        OwnerService ownerService = new OwnerService();

        [Test]
        public void itShouldBeAbleToCalculateOwnerFlatsCost()
        {
            List<Flat> flats = new List<Flat>();

            flats.Add(new Flat
            {
                Id = 1,
                SquareMeters = 20,
                NumberOfRooms = 2

            });


            flats.Add(new Flat
            {
                Id = 2,
                SquareMeters = 20,
                NumberOfRooms = 3

            });

            float expectedValue = ownerService.calculateOwnerFlatsCost(new Owner {
                Flats =  flats
            }, 100);

            Assert.AreEqual(expectedValue, 4000);

        }
    }
}