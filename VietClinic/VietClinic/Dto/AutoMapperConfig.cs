using AutoMapper;
using VietClinic.Models;

namespace VietClinic.Dto
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<PetDTO, Pet>()
                .ForMember(d => d.Id, opt => opt.Ignore());
               
        }
    }
}
