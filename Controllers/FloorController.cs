using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Code.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FloorController : ControllerBase
    {

        private List<Floor> floors =  new List<Floor>();
        private readonly ILogger<FloorController> _logger;

        public FloorController(ILogger<FloorController> logger)
        {
            _logger = logger;

              floors.Add(new Floor
            {
                Type = "Marketing",
                Number = 0,
                NumberOfRooms = 15

            });

            floors.Add(new Floor
            {
                Type = "Accounting and Finance",
                Number = 1,
                NumberOfRooms = 10

            });
        }
    }
}