﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace DDona.Kiper.Domain
{
    public partial class Apartamento
    {
        public Apartamento()
        {
            Morador = new HashSet<Morador>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int Numero { get; set; }
        public string Bloco { get; set; }
        public bool Status { get; set; }
        public int CondominioId { get; set; }

        public virtual Condominio Condominio { get; set; }
        public virtual ICollection<Morador> Morador { get; set; }
    }
}