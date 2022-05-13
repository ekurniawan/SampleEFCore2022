using AutoMapper;
using SampleEF.Domain;
using SampleEF.Domain.DTO;

namespace SampleEF.API.Profiles
{
    public class SamuraiProfile : Profile
    {
        public SamuraiProfile()
        {
            CreateMap<Samurai, SamuraiReadDto>();
            CreateMap<SamuraiCreateDto, Samurai>();
        }
    }
}
