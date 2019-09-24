using DDona.Kiper.Domain;
using DDona.Kiper.Infra;
using DDona.Kiper.Service.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDona.Kiper.Service
{
    public class CondominioService : BaseService<Condominio>, ICondominioService
    {
        public CondominioService(KiperDesafioContext db) : base(db) { }
    }
}
