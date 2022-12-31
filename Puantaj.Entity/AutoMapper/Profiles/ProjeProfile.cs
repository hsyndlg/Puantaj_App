using AutoMapper;
using Puantaj.Entity.Concrete;
using Puantaj.Entity.Dtos;

namespace Puantaj.Entity.AutoMapper.Profiles
{
    public class ProjeProfile : Profile
    {
        public ProjeProfile()
        {
            CreateMap<ProjeAddDto, Proje>();
            CreateMap<ProjeUpdateDto, Proje>();
            CreateMap<Proje, ProjeUpdateDto>();
        }
    }
}