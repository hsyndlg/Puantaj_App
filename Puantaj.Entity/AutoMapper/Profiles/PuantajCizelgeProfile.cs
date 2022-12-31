using AutoMapper;
using Puantaj.Entity.Concrete;
using Puantaj.Entity.Dtos;

namespace Puantaj.Entity.AutoMapper.Profiles
{
    public class PuantajCizelgeProfile : Profile
    {
        public PuantajCizelgeProfile()
        {
            CreateMap<PuantajCizelgeAddDto, PuantajCizelge>();
            CreateMap<PuantajCizelgeUpdateDto, PuantajCizelge>();
            CreateMap<PuantajCizelge, PuantajCizelgeUpdateDto>();
        }
    }
}