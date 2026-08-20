using AprendizadoCSharp.Domain.Authentication.Models;

namespace AprendizadoCSharp.Domain.Authentication.Interfaces
{
    public interface ITokenService
    {
        public string CreateToken(AppUser user);
    }
}
