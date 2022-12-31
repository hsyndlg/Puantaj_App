using Puantaj.Data.Abstract;
using Puantaj.Data.Concrete.EntityFramework.Contexts;
using Puantaj.Data.Concrete.EntityFramework.Repositories;

namespace Puantaj.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PuantajAppContext _context;
        private EfPersonelRepository _personelRepository;
        private EfProjeRepository _projeRepository;
        private EfPuantajCizelgeRepository _puantajCizelgeRepository;

        public UnitOfWork(PuantajAppContext context)
        {
            _context = context;
        }

        public IPersonelRepository Personel => _personelRepository ?? new EfPersonelRepository(_context);
        public IProjeRepository Proje => _projeRepository ?? new EfProjeRepository(_context);
        public IPuantajCizelgeRepository PuantajCizelge => _puantajCizelgeRepository ?? new EfPuantajCizelgeRepository(_context);
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}