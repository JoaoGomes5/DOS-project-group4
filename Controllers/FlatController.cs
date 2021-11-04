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

        [HttpGet]
        [ProducesResponseType(typeof(List<Flat>), 200)]
        [ProducesResponseType(500)]
        public IEnumerable<Flat> Get()
        {
            return flats;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id){
             Flat flat = flats.Find(p => p.Id == id);

            if(flats == null)
                return NotFound();

            return Ok(flats) ;
        }

        [HttpPost]
        public ActionResult Create(Flat flat){

            flats.Add(flat);

            return CreatedAtAction(
                nameof(Create), 
                new {
                id = flat.Id
                },
                flat
            );
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Flat flat){
            if(id != flat.Id){
                return NotFound();
            }

            var existingFlatIndex = flats.FindIndex(p => p.Id == flat.Id);

            if(existingFlatIndex == -1){
                return StatusCode(400);
            }

           flats[existingFlatIndex] = flat;

           return StatusCode(200);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id){
             Flat existingFlat = flats.Find(p => p.Id == id);

            if(existingFlat is null){
                return NotFound();
            }
            
             flats.Remove(existingFlat);

             return StatusCode(200);
        }
    }
}
