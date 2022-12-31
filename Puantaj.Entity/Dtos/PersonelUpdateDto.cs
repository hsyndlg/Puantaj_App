using System.ComponentModel.DataAnnotations;

namespace Puantaj.Entity.Dtos
{
    public class PersonelUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string Adi { get; set; }
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]

        public string Soyadi { get; set; }
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]

        public string Tckn { get; set; }
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]

        public string SicilNo { get; set; }

        public string DogumTarihi { get; set; }

        public string BaslangicTarihi { get; set; }

        public string BaslangicTarihiGun { get; set; }

        public string BaslangicTarihiAy { get; set; }

        public string BaslangicTarihiYil { get; set; }

        public string DogumTarihiGun { get; set; }

        public string DogumTarihiAy { get; set; }

        public string DogumTarihiYil { get; set; }

        public string DogumYeri { get; set; }
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]

        public string Sskno { get; set; }
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]

        public string BabaAdi { get; set; }
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]

        public string CariHesapKodu { get; set; }
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]

        public string CepNo { get; set; }
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]

        public string Email { get; set; }
    }
}