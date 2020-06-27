using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VietClinic.Dto;
using VietClinic.Models;

namespace VietClinic.Services
{
    public class PetService : IPetService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PetService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Pet> AddPet(PetDTO petDto)
        {
            var pet = _mapper.Map<Pet>(petDto);
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

        public async Task<Pet> EditPet(PetDTO petDto, long id)
        {

            var petFromDb = await _context.Pets.FindAsync(id);

            _mapper.Map(petDto, petFromDb);

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
