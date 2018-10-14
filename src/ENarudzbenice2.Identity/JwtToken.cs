using System.IdentityModel.Tokens.Jwt;

namespace ENarudzbenice2.Identity
{
    public sealed class JwtToken
    {
        private readonly JwtSecurityToken _token;

        internal JwtToken(JwtSecurityToken token)
        {
            _token = token;
        }

        public string Value => new JwtSecurityTokenHandler().WriteToken(_token);
    }
}
