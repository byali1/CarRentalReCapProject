using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            //WebAPI'nin hangi security key ve algoritmanın kullanıldığını bilmesi lazım.
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        }
    }
}
