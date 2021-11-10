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
        /// <summary>
        ///  Get all the flats
        /// </summary>
        /// <response code="200">Sucess</response>
        /// <response code="500">Server error</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Flat>), 200)]
        [ProducesResponseType(500)]
        public IEnumerable<Flat> Get()
        {
            return flats;
        }

        /// <summary>
        ///  Get a specific flat by ID
        /// </summary>
        /// <param name="id"> Flat ID</param>
        /// <response code="200">Sucess</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Error</response>
        [HttpGet("{id}")]
        public IActionResult GetById(int id){
             Flat flat = flats.Find(p => p.Id == id);

            if(flat == null)
                return NotFound();

            return Ok(flat) ;
        }


        /// <summary>
        /// Create Flat
        /// </summary>
        /// <param name="flat"> Flat Model</param>
        /// <response code="200">Sucess</response>
        /// <response code="400">Invalid Flat Model</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Error</response>
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
        
        /// <summary>
        /// Edit  specific Flat by Id
        /// </summary>
        /// <param name="id"> Flat Id</param>
        /// <param name="flat"> Flat Model </param>
        /// <response code="200">Sucess</response>
        /// <response code="400">Invalid Flat Model</response>
        ///  <response code="404">Not Found</response>
        /// <response code="500">Error</response>
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

         /// <summary>
        ///  Delete  a specific flat by Id
        /// </summary>
        /// <param name="id"> Flat Id</param>
        /// <response code="200">Sucess</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Error</response>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id){
             Flat existingFlat = flats.Find(p => p.Id == id);

            if(existingFlat == null){
                return NotFound();
            }
            
             flats.Remove(existingFlat);

             return StatusCode(200);
        }
    }
}
