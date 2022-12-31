using Microsoft.EntityFrameworkCore;
using Puantaj.Data.Abstract;
using Puantaj.Entity.Concrete;

namespace Puantaj.Data.Concrete.EntityFramework.Repositories
{
    public class EfProjeRepository : EfEntityRepositoryBase<Proje>, IProjeRepository
    {
        public EfProjeRepository(DbContext context) : base(context)
        {
        }
    }
}