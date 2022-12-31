using Puantaj.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puantaj.Entity.Dtos
{
    public class UserAddDto : DtoGetBase
    { 
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}