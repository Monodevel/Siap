using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siap.Shared.DTO
{
    public class LoginDTO
    {
        public string? usuario {  get; set; }
        public string? password { get; set; }

        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
    }
}
