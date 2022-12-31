using Puantaj.Entity.Concrete;
using Puantaj.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puantaj.Entity.Dtos
{
    public class PuantajCizelgeAddDto : DtoGetBase
    {
        public PuantajCizelge PuantajCizelge { get; set; }
    }
}