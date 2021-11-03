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

        /// <summary>
        ///  Get all the floors
        /// </summary>
        /// <response code="200">Sucess</response>
        /// <response code="500">Error</response>
        /// 
        [HttpGet]
        [ProducesResponseType(typeof(List<Floor>), 200)]
        [ProducesResponseType(500)]
        public IEnumerable<Floor> Get()
        {
            return floors;
        }

        /// <summary>
        ///  Get a specific floor by ID
        /// </summary>
        /// <param name="id"> Floor ID</param>
        /// <response code="200">Sucess</response>
        /// <response code="400">Not found</response>
        /// <response code="500">Error</response>
        [HttpGet("{id}")]
        public IActionResult GetById(int id){
             Floor floor = floors.Find(p => p.Id == id);

            if(floor == null)
                return NotFound();

            return Ok(floor) ;
        }

        /// <summary>
        /// Create Floor
        /// </summary>
        /// <param name="floor"> User Model</param>
        /// <response code="200">Sucess</response>
        /// <response code="400">Invalid User Model</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Error</response>
        [HttpPost]
        public ActionResult Create(Floor floor){

            floors.Add(floor);

            return CreatedAtAction(
                nameof(Create), 
                new {
                id = floor.Id
                },
                floor
            );
            
        }
    }
}
