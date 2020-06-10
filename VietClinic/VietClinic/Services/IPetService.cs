using System.Collections.Generic;
using System.Threading.Tasks;
using VietClinic.Models;

namespace VietClinic.Services
{
    public interface IPetService
    {
        Task<List<Pet>> GetPets();
        Task<Pet> GetPet(long id);
        Task<Pet> EditPet(Pet pet, long id);
        Task<Pet> AddPet(Pet pet);
        Task<bool> DeletePet(long id);
    }
}
