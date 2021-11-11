using System.Collections.Generic;
using Code.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Code.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuildingController : ControllerBase
    {

        private List<Building> buildings =  new List<Building>();
        private readonly ILogger<BuildingController> _logger;

        public BuildingController(ILogger<BuildingController> logger)
        {
            _logger = logger;

              buildings.Add(new Building
            {
                Id = 1,
                Name = "The Shard",
                Street = "London Bridge St",
                Town = "London",
                Postcode = "SE1 9SG",
                FloorsNumber = 87,
                Country = "United Kingdom"

            });

            buildings.Add(new Building
            {
                Id = 2,
                Name = "One Canada Square",
                Street = "Canary Wharf",
                Town = "London",
                Postcode = "E14 5AB",
                FloorsNumber = 50,
                Country = "United Kingdom"

            });
        }


        /// <summary>
        ///  Get all the buildings
        /// </summary>
        /// <response code="200">Sucess</response>
        /// <response code="500">Error</response>
        /// 
        [HttpGet]
        [ProducesResponseType(typeof(List<Building>), 200)]
        [ProducesResponseType(500)]
        public IEnumerable<Building> Get()
        {
            return buildings;
        }

          /// <summary>
        ///  Get a specific building by ID
        /// </summary>
        /// <param name="id"> Building ID</param>
        /// <response code="200">Sucess</response>
        /// <response code="400">Not found</response>
        /// <response code="500">Error</response>
        [HttpGet("{id}")]
        public IActionResult GetById(int id){
             Building building = buildings.Find(p => p.Id == id);

            if(building == null)
                return NotFound();

            return Ok(building) ;
        }



        /// <summary>
        /// Create Building
        /// </summary>
        /// <param name="building"> Building Model</param>
        /// <response code="200">Sucess</response>
        /// <response code="400">Invalid Building Model</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Error</response>
        [HttpPost]
        public ActionResult Create(Building building){

            buildings.Add(building);

            return CreatedAtAction(
                nameof(Create), 
                new {
                id = building.Id
                },
                building
            );
            
        }



        /// <summary>
        /// Edit  specific building by ID
        /// </summary>
        /// <param name="id"> Building ID</param>
        /// <param name="building"> Building Model </param>
        /// <response code="200">Sucess</response>
        /// <response code="400">Invalid Building Model</response>
        ///  <response code="404">Not Found</response>
        /// <response code="500">Error</response>
        [HttpPut("{id}")]
        public ActionResult Update(int id, Building building){
            if(id != building.Id){
                return NotFound();
            }

            var existingBuildingIndex = buildings.FindIndex(p => p.Id == building.Id);

            if(existingBuildingIndex == -1){
                return StatusCode(400);
            }

           buildings[existingBuildingIndex] = building;

           return StatusCode(200);

          
        }



          /// <summary>
        ///  Delete  a specific building by ID
        /// </summary>
        /// <param name="id"> Building ID</param>
        /// <response code="200">Sucess</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Error</response>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id){
             Building existingBuilding = buildings.Find(p => p.Id == id);

            if(existingBuilding is null){
                return NotFound();
            }
            
             buildings.Remove(existingBuilding);

             return StatusCode(200);
        }
    
   
    }
}
