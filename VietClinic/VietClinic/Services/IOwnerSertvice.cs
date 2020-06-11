using System.Collections.Generic;
using System.Threading.Tasks;
using VietClinic.Models;

namespace VietClinic.Services
{
    public interface IOwnerService
    {
        Task<List<Owner>> GetOwners();
        Task<Owner> GetOwner(long id);
        Task<Owner> EditOwner(Owner owner, long id);
        Task<Owner> AddOwner(Owner owner);
        Task<bool> DeletePet(long id);
    }
}
