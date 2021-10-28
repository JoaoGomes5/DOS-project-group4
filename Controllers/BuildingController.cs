using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Code.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuildingController : ControllerBase
    {


        private readonly ILogger<BuildingController> _logger;

        public BuildingController(ILogger<BuildingController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Building> Get()
        {

            var buildings = new List<Building>();

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

            return buildings;
        }
    
    
        [HttpPost]
        public IActionResult Create(Building building){

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Building building){

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            
        }
    }
}
