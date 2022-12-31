using Puantaj.Entity.Abstract;
using Puantaj.Shared.Entities.Abstract;

namespace Puantaj.Entity.Concrete;

public partial class Proje : EntityBase, IEntity
{
    public string? HizmetTuru { get; set; }

    public string? ProjeKodu { get; set; }

    public string? Kurum { get; set; }

    public string? ProjeAdi { get; set; }

    public string? EklemeTarihiGun { get; set; }

    public string? EklemeTarihiAy { get; set; }

    public string? EklemeTarihiYil { get; set; }

    public string? Durumu { get; set; }

    public decimal? TamamlanmaYuzdesi { get; set; }

    public int? KisiSayisi { get; set; }

    public string? Segment { get; set; }

    public string? SegmentYoneticisi { get; set; }

    public string? Gmy { get; set; }

    public string? Sfmsorumlusu { get; set; }

    public virtual ICollection<PuantajCizelge> PuantajCizelges { get; } = new List<PuantajCizelge>();
}
