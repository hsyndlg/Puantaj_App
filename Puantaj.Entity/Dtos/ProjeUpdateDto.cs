using Puantaj.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puantaj.Entity.Dtos
{
    public class ProjeUpdateDto : DtoGetBase
    {
        [Required]
        public int Id { get; set; }
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
    }
}