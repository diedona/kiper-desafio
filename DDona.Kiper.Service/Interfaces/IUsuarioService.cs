using DDona.Kiper.Domain;
using DDona.Kiper.Service.Base;

namespace DDona.Kiper.Service
{
    public interface IUsuarioService : IBaseService<Usuario>
    {
        bool ValidateUsernamePassword(string username, string password);
    }
}