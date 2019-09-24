using DDona.Kiper.Domain;
using DDona.Kiper.Infra;
using DDona.Kiper.Service.Base;
using DDona.Kiper.Utils.HashManager;
using System.Collections.Generic;
using System.Linq;

namespace DDona.Kiper.Service
{
    public class UsuarioService : BaseService<Usuario>, IUsuarioService
    {
        public UsuarioService(KiperDesafioContext db) : base(db) { }

        public override IEnumerable<Usuario> GetAll()
        {
            var list = base.GetAll();
            foreach (var item in list)
            {
                item.Password = null;
                item.Salt = null;
            }
            return list;
        }

        public override Usuario Get(int id)
        {
            var usuario = base.Get(id);
            if (usuario != null)
            {
                usuario.Password = null;
                usuario.Salt = null;
            }
            return usuario;
        }

        public override void Save(Usuario entity)
        {
            string salt = HashManager.CreateSalt();
            string hashPassword = HashManager.CreateHash(entity.Password, salt);

            entity.Salt = salt;
            entity.Password = hashPassword;
            base.Save(entity);
        }

        public bool ValidateUsernamePassword(string username, string password)
        {
            Usuario usuario = _db.Usuario.FirstOrDefault(x => x.Username.Equals(username));
            if (usuario == null || (!usuario.Status))
            {
                // NON EXISTENT OR INACTIVE
                return false;
            }

            string dbHash = usuario.Password;
            string sentHash = HashManager.CreateHash(password, usuario.Salt);

            return dbHash.Equals(sentHash);
        }
    }
}
