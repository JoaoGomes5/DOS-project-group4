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
                FirstName = "João",
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

        [HttpGet]
        [ProducesResponseType(typeof(List<Owner>), 200)]
        [ProducesResponseType(500)]
        public IEnumerable<Owner> Get()
        {
            return owners;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Owner owner = owners.Find(p => p.Id == id);

            if (owner == null)
                return NotFound();

            return Ok(owner);
        }

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

