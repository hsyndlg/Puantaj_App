using Puantaj.Entity.Concrete;
using Puantaj.Shared.Entities.Abstract;

namespace Puantaj.Entity.Dtos
{
    public class PersonelListDto : DtoGetBase
    {
        public IList<Personel> Personels { get; set; }
    }
}