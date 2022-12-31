using Microsoft.EntityFrameworkCore;
using Puantaj.Data.Abstract;
using Puantaj.Entity.Concrete;

namespace Puantaj.Data.Concrete.EntityFramework.Repositories
{
    public class EfPersonelRepository : EfEntityRepositoryBase<Personel>, IPersonelRepository
    {
        public EfPersonelRepository(DbContext context) : base(context)
        {
        }
    }
}