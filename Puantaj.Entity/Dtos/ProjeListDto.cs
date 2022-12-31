using Puantaj.Entity.Concrete;
using Puantaj.Shared.Entities.Abstract;

namespace Puantaj.Entity.Dtos
{
    public class ProjeListDto : DtoGetBase
    {
        public IList<Proje> Projes { get; set; }
    }
}