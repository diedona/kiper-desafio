using System;
using System.Collections.Generic;
using System.Text;

namespace DDona.Kiper.Domain.BaseDomain
{
    public interface IEntity
    {
        int Id { get; set; }
        bool Status { get; set; }
    }
}
