using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Code.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OwnerController : ControllerBase
    {

        private List<Owner> owners = new List<Owner>();
        private readonly ILogger<OwnerController> _logger;

        public OwnerController(ILogger<OwnerController> logger)
        {
            _logger = logger;

            owners.Add(new Owner
            {
                Id = 1,
                FirstName = "Joao",
                LastName = "Brito",
                PhoneNumber = 9998885533

            });

            owners.Add(new Owner
            {
                Id = 1,
                FirstName = "Dayana",
                LastName = "Moreira",
                PhoneNumber = 95553344789

            });
        }

         /// <summary>
        ///  Get all the owners
        /// </summary>
        /// <response code="200">Sucess</response>
        /// <response code="500">Error</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Owner>), 200)]
        [ProducesResponseType(500)]
        public IEnumerable<Owner> Get()
        {
            return owners;
        }


        /// <summary>
        ///  Get a specific owner by ID
        /// </summary>
        /// <param name="id"> Owner ID</param>
        /// <response code="200">Sucess</response>
        /// <response code="400">Not found</response>
        /// <response code="500">Error</response>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Owner owner = owners.Find(p => p.Id == id);

            if (owner == null)
                return NotFound();

            return Ok(owner);
        }

        /// <summary>
        /// Create Owner
        /// </summary>
        /// <param name="owner"> Owner Model</param>
        /// <response code="200">Sucess</response>
        /// <response code="400">Invalid Owner Model</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Error</response>
        [HttpPost]
        public ActionResult Create(Owner owner)
        {

            owners.Add(owner);

            return CreatedAtAction(
                nameof(Create),
                new
                {
                    id = owner.Id
                },
                owner
            );

        }

        /// <summary>
        /// Edit  specific Owner by ID
        /// </summary>
        /// <param name="id"> Owner ID</param>
        /// <param name="owner"> Owner Model </param>
        /// <response code="200">Sucess</response>
        /// <response code="400">Invalid Owner Model</response>
        ///  <response code="404">Not Found</response>
        /// <response code="500">Error</response>
        [HttpPut("{id}")]
        public ActionResult Update(int id, Owner owner)
        {
            if (id != owner.Id)
            {
                return NotFound();
            }

            var existingOwnerIndex = owners.FindIndex(p => p.Id == owner.Id);

            if (existingOwnerIndex == -1)
            {
                return StatusCode(400);
            }

            owners[existingOwnerIndex] = owner;

            return StatusCode(200);


        }

         /// <summary>
        ///  Delete  a specific Owner by ID
        /// </summary>
        /// <param name="id"> Owner ID</param>
        /// <response code="200">Sucess</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Error</response>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Owner existingOwner = owners.Find(p => p.Id == id);

            if (existingOwner is null)
            {
                return NotFound();
            }

            owners.Remove(existingOwner);

            return StatusCode(200);
        }


    }
}

