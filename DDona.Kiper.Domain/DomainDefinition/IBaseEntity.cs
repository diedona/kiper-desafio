using System;
using System.Collections.Generic;
using System.Text;

namespace DDona.Kiper.Domain.DomainDefinition
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        bool Status { get; set; }
    }
}
