using Puantaj.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puantaj.Entity.Dtos
{
    public class PuantajCizelgeUpdateDto : DtoGetBase
    {
        [Required]
        public int Id { get; set; }

        public int? ProjeId { get; set; }

        public int? PersonelId { get; set; }

        public int Ay { get; set; }

        public int Yil { get; set; }

        public bool Gun1 { get; set; }

        public bool Gun2 { get; set; }

        public bool Gun3 { get; set; }

        public bool Gun4 { get; set; }

        public bool Gun5 { get; set; }

        public bool Gun6 { get; set; }

        public bool Gun7 { get; set; }

        public bool Gun8 { get; set; }

        public bool Gun9 { get; set; }

        public bool Gun10 { get; set; }

        public bool Gun11 { get; set; }

        public bool Gun12 { get; set; }

        public bool Gun13 { get; set; }

        public bool Gun14 { get; set; }

        public bool Gun15 { get; set; }

        public bool Gun16 { get; set; }

        public bool Gun17 { get; set; }

        public bool Gun18 { get; set; }

        public bool Gun19 { get; set; }

        public bool Gun20 { get; set; }

        public bool Gun21 { get; set; }

        public bool Gun22 { get; set; }

        public bool Gun23 { get; set; }

        public bool Gun24 { get; set; }

        public bool Gun25 { get; set; }

        public bool Gun26 { get; set; }

        public bool Gun27 { get; set; }

        public bool Gun28 { get; set; }

        public bool Gun29 { get; set; }

        public bool Gun30 { get; set; }

        public bool Gun31 { get; set; }

        public int BirimMaliyet { get; set; }

        public string Aciklama { get; set; } = null!;
    }
}