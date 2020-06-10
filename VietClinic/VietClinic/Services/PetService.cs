using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VietClinic.Models;

namespace VietClinic.Services
{
    public class PetService : IPetService
    {
        private readonly DataContext _context;

        public PetService(DataContext context)
        {
            _context = context;
        }

        public async Task<Pet> AddPet(Pet pet)
        {
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();
            return pet;
        }

        public async Task<bool> DeletePet(long id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet == null)
            {
                return false;
            }

            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Pet> EditPet(Pet pet, long id)
        {

            var petFromDb = await _context.Pets.FindAsync(id);

            if (petFromDb == null)
            {
                return pet;
            }

            petFromDb.Name = pet.Name;
            petFromDb.Age = pet.Age;
            petFromDb.Weight = pet.Weight;
            petFromDb.Color = pet.Color;
            
            await _context.SaveChangesAsync();
           
            return petFromDb;
        }

        public async Task<List<Pet>> GetPets()
        {
            return await _context.Pets.ToListAsync();
          
        }

        public async Task<Pet> GetPet(long id)
        {
            return await _context.Pets.FindAsync(id);
        }
    }
}
