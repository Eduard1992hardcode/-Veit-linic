using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VietClinic.Models;
using VietClinic.Services;

namespace VietClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnersController(IOwnerService ownerService) 
        {
            _ownerService = ownerService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Owner>>> GetPetS()
        {
            return await _ownerService.GetOwners();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Owner>> GetOwner(long id)
        {
            var owner = await _ownerService.GetOwner(id);

            if (owner == null)
            {
                return NotFound();
            }

            return owner;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOwner(long id, Owner owner)
        {
            if (id != owner.Id)
            {
                return BadRequest();
            }

           // await _ownerService.Addowner(owner);

            return Ok(owner);
        }

        [HttpPost]
        public async Task<ActionResult<Owner>> PostOwner(Owner owner)
        {
            var result = await _ownerService.AddOwner(owner);

            return Ok(owner);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Pet>> DeleteOwner(long id)
        {
            await _ownerService.DeletePet(id);
            return Ok();
        }
    }
}
