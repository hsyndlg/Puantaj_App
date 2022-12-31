using Puantaj.Entity.Abstract;
using Puantaj.Shared.Entities.Abstract;

namespace Puantaj.Entity.Concrete;

public partial class Personel : EntityBase, IEntity
{
    public string? Adi { get; set; }

    public string? Soyadi { get; set; }

    public string? Tckn { get; set; }

    public string? SicilNo { get; set; }

    public string? BaslangicTarihiGun { get; set; }

    public string? BaslangicTarihiAy { get; set; }

    public string? BaslangicTarihiYil { get; set; }

    public string? DogumTarihiGun { get; set; }

    public string? DogumTarihiAy { get; set; }

    public string? DogumTarihiYil { get; set; }

    public string? DogumYeri { get; set; }

    public string? Sskno { get; set; }

    public string? YillikIzinBaslangicTarihiGun { get; set; }

    public string? YillikIzinBaslangicTarihiAy { get; set; }

    public string? YillikIzinBaslangicTarihiYil { get; set; }

    public string? BabaAdi { get; set; }

    public string? CariHesapKodu { get; set; }

    public string? CepNo { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<PuantajCizelge> PuantajCizelges { get; } = new List<PuantajCizelge>();
}
