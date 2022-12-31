using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Puantaj.Entity.Concrete;

namespace Puantaj.Data.Concrete.EntityFramework.Contexts;

public partial class PuantajAppContext : IdentityDbContext<User,Role,int,UserClaim,UserRole,UserLogin,RoleClaim,UserToken>
{
    public PuantajAppContext()
    {
    }

    public PuantajAppContext(DbContextOptions<PuantajAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Personel> Personels { get; set; }

    public virtual DbSet<Proje> Projes { get; set; }

    public virtual DbSet<PuantajCizelge> PuantajCizelges { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Personel>(entity =>
        {
            entity.ToTable("Personel");

            entity.Property(e => e.Adi).HasMaxLength(30);
            entity.Property(e => e.BabaAdi).HasMaxLength(30);
            entity.Property(e => e.BaslangicTarihiAy)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.BaslangicTarihiGun)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.BaslangicTarihiYil)
                .HasMaxLength(4)
                .IsFixedLength();
            entity.Property(e => e.CariHesapKodu).HasMaxLength(50);
            entity.Property(e => e.CepNo).HasMaxLength(50);
            entity.Property(e => e.DogumTarihiAy)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.DogumTarihiGun)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.DogumTarihiYil)
                .HasMaxLength(4)
                .IsFixedLength();
            entity.Property(e => e.DogumYeri).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.SicilNo).HasMaxLength(50);
            entity.Property(e => e.Soyadi).HasMaxLength(30);
            entity.Property(e => e.Sskno)
                .HasMaxLength(50)
                .HasColumnName("SSKNo");
            entity.Property(e => e.Tckn)
                .HasMaxLength(11)
                .HasColumnName("TCKN");
            entity.Property(e => e.YillikIzinBaslangicTarihiAy)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.YillikIzinBaslangicTarihiGun)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.YillikIzinBaslangicTarihiYil)
                .HasMaxLength(4)
                .IsFixedLength();
        });

        modelBuilder.Entity<Proje>(entity =>
        {
            entity.ToTable("Proje");

            entity.Property(e => e.Durumu).HasMaxLength(20);
            entity.Property(e => e.EklemeTarihiAy)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.EklemeTarihiGun)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.EklemeTarihiYil)
                .HasMaxLength(4)
                .IsFixedLength();
            entity.Property(e => e.Gmy)
                .HasMaxLength(50)
                .HasColumnName("GMY");
            entity.Property(e => e.HizmetTuru).HasMaxLength(50);
            entity.Property(e => e.Kurum).HasMaxLength(50);
            entity.Property(e => e.ProjeKodu).HasMaxLength(50);
            entity.Property(e => e.Segment).HasMaxLength(50);
            entity.Property(e => e.SegmentYoneticisi).HasMaxLength(50);
            entity.Property(e => e.Sfmsorumlusu)
                .HasMaxLength(50)
                .HasColumnName("SFMSorumlusu");
            entity.Property(e => e.TamamlanmaYuzdesi).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<PuantajCizelge>(entity =>
        {
            entity.ToTable("PuantajCizelge");

            entity.HasOne(d => d.Personel).WithMany(p => p.PuantajCizelges)
                .HasForeignKey(d => d.PersonelId)
                .HasConstraintName("FK_PuantajCizelge_Personel");

            entity.HasOne(d => d.Proje).WithMany(p => p.PuantajCizelges)
                .HasForeignKey(d => d.ProjeId)
                .HasConstraintName("FK_PuantajCizelge_Proje");
        });

        modelBuilder.Ignore<IdentityUserLogin<int>>();

        base.OnModelCreating(modelBuilder);
    }

}