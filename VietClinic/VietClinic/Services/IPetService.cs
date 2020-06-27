using System.Collections.Generic;
using System.Threading.Tasks;
using VietClinic.Dto;
using VietClinic.Models;

namespace VietClinic.Services
{
    public interface IPetService
    {
        Task<List<Pet>> GetPets();
        Task<Pet> GetPet(long id);
        Task<Pet> EditPet(PetDTO pet, long id);
        Task<Pet> AddPet(PetDTO pet);
        Task<bool> DeletePet(long id);
    }
}
