using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Code.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlatController : ControllerBase
    {

        private List<Flat> flats =  new List<Flat>();
        private readonly ILogger<FlatController> _logger;

        public FlatController(ILogger<FlatController> logger)
        {
            _logger = logger;

              flats.Add(new Flat
            {
                OwnerId = 1,
                SquareMeters = 20,
                NumberOfRooms = 2

            });

            flats.Add(new Flat
            {
                OwnerId = 1,
                SquareMeters = 25,
                NumberOfRooms = 3

            });
        }
    }
}
