using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VietClinic.Models;

namespace VietClinic.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly DataContext _context;

        public OwnerService(DataContext context)
        {
            _context = context;
        }
        public async Task<Owner> AddOwner(Owner owner)
        {
            _context.Owners.Add(owner);
            await _context.SaveChangesAsync();
            return owner;
        }

        public async Task<bool> DeletePet(long id)
        {
            var owner = await _context.Owners.FindAsync(id);
            if (owner == null)
            {
                return false;
            }
            _context.Owners.Remove(owner);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Owner> EditOwner(Owner owner, long id)
        {
            var petFromDb = await _context.Owners.FindAsync(id);

            if (petFromDb == null)
            {
                return owner;
            }

            petFromDb.Adress = owner.Adress;
            petFromDb.TelNumber = owner.TelNumber;


            await _context.SaveChangesAsync();

            return petFromDb;
        }

        public async Task<Owner> GetOwner(long id)
        {
            return await _context.Owners.Include(p => p.Pets).FirstOrDefaultAsync(o => o.Id==id);
        }

        public async Task<List<Owner>> GetOwners()
        {
            return await _context.Owners.ToListAsync();
        }
    }
}
