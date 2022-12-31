using Puantaj.Entity.Concrete;
using Puantaj.Shared.Entities.Abstract;

namespace Puantaj.Entity.Dtos
{
    public class PuantajCizelgeListDto
    {
        public IList<PuantajCizelge> PuantajCizelges { get; set; }
    }
}