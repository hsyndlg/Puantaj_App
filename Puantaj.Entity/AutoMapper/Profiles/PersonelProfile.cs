using AutoMapper;
using Puantaj.Entity.Concrete;
using Puantaj.Entity.Dtos;

namespace Puantaj.Entity.AutoMapper.Profiles
{
    public class PersonelProfile : Profile
    {
        public PersonelProfile()
        {
            CreateMap<PersonelAddDto , Personel>();
            CreateMap<PersonelUpdateDto , Personel>();
            CreateMap<Personel , PersonelUpdateDto>();
        }
    }
}