using Microsoft.EntityFrameworkCore;
using Puantaj.Data.Abstract;
using Puantaj.Entity.Concrete;

namespace Puantaj.Data.Concrete.EntityFramework.Repositories
{
    public class EfPuantajCizelgeRepository : EfEntityRepositoryBase<PuantajCizelge>, IPuantajCizelgeRepository
    {
        public EfPuantajCizelgeRepository(DbContext context) : base(context)
        {
        }
    }
}