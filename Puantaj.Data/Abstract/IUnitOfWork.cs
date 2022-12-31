namespace Puantaj.Data.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IPersonelRepository Personel { get; }
        IProjeRepository Proje { get; }
        IPuantajCizelgeRepository PuantajCizelge { get; }
        Task<int> SaveAsync();
    }
}