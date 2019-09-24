using DDona.Kiper.Domain;
using DDona.Kiper.Infra;
using DDona.Kiper.Service.Base;
using DDona.Kiper.Utils.HashManager;

namespace DDona.Kiper.Service
{
    public class UsuarioService : BaseService<Usuario>, IUsuarioService
    {
        public UsuarioService(KiperDesafioContext db) : base(db) { }

        public override void Save(Usuario entity)
        {
            string salt = HashManager.CreateSalt();
            string hashPassword = HashManager.CreateHash(entity.Password, salt);

            entity.Salt = salt;
            entity.Password = hashPassword;
            base.Save(entity);
        }
    }
}
