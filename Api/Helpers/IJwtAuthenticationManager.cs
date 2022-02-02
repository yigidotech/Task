
using Api.Entities;

namespace Api.Helpers
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(User user);
    }
}