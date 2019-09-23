using System;
using System.Collections.Generic;
using System.Text;

namespace DDona.Kiper.Domain.BaseDomain
{
    public interface IEntity
    {
        int Id { get; set; }
        public bool Status { get; set; }
    }
}
