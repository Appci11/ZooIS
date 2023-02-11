using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooIS.Shared.Dto
{
    public class LoginDto
    {
        public LoginDto(string authToken, bool passResetRequest)
        {
            AuthToken = authToken;
            PassResetRequest = passResetRequest;
        }

        public string AuthToken { get; set; }
        public bool PassResetRequest { get; set; }
    }
}
