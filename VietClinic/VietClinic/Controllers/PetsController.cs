using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VietClinic.Dto;
using VietClinic.Models;
using VietClinic.Services;

namespace VietClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        // GET: api/Pets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pet>>> GetPetS()
        {
            return await _petService.GetPets();
        }

        // GET: api/Pets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pet>> GetPet(long id)
        {
            var pet = await _petService.GetPet(id);

            if (pet == null)
            {
                return NotFound();
            }

            return pet;
        }

        // PUT: api/Pets/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPet(long id, PetDTO pet)
        { 
            await _petService.EditPet(pet, id);

            return Ok(pet);
        }

        // POST: api/Pets
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Pet>> PostPet(PetDTO pet)
        {
            var result = await _petService.AddPet(pet);

            return Ok(pet);
        }

        // DELETE: api/Pets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pet>> DeletePet(long id)
        {
            await _petService.DeletePet(id);
            return Ok();
        }
    }
}
