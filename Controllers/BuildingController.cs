using System.Collections.Generic;
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
                Name = "The Shard",
                Street = "London Bridge St",
                Town = "London",
                Postcode = "SE1 9SG",
                FloorsNumber = 87,
                Country = "United Kingdom"

            });

            buildings.Add(new Building
            {
                Name = "One Canada Square",
                Street = "Canary Wharf",
                Town = "London",
                Postcode = "E14 5AB",
                FloorsNumber = 50,
                Country = "United Kingdom"

            });
        }

        [HttpGet]
        public IEnumerable<Building> Get()
        {
            return buildings;
        }

        [HttpGet("{id}")]
        public ActionResult<Building> GetID(int id){
             Building building = buildings.Find(p => p.Id == id);

            if(building is null)
                return NotFound();

            return building;
        }

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
