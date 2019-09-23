﻿

// ------------------------------------------------------------------------------------------------
// This code was generated by EntityFramework Reverse POCO Generator (http://www.reversepoco.com/).
// Created by Simon Hughes (https://about.me/simon.hughes).
//
// Do not make changes directly to this file - edit the template instead.
//
// The following connection settings were used to generate this file:
//     Configuration file:     "D:\Desenvolvimento\Dona\DDona.Kiper.Domain\Generator\app.config"
//     Connection String Name: "Default"
//     Connection String:      "Data Source=.\SQLExpress;Initial Catalog=kiper-desafio;Integrated Security=false;User Id=sa;password=**zapped**;;"
// ------------------------------------------------------------------------------------------------
// Database Edition        : Express Edition (64-bit)
// Database Engine Edition : Express
// Database Version        : 14.0.2027.2

// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable EmptyNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 2.2
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace DDona.Kiper.Domain
{

    #region POCO classes

    // Apartamento
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public partial class Apartamento
    {
        public int Id { get; set; } // Id (Primary key)
        public string Nome { get; set; } // Nome (length: 100)
        public int Numero { get; set; } // Numero
        public string Bloco { get; set; } // Bloco (length: 50)
        public bool Status { get; set; } // Status
        public int CondominioId { get; set; } // CondominioId

        // Reverse navigation

        /// <summary>
        /// Child Morador where [Morador].[ApartamentoId] point to this entity (FK_Morador_Apartamento)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<Morador> Morador { get; set; } // Morador.FK_Morador_Apartamento

        // Foreign keys

        /// <summary>
        /// Parent Condominio pointed by [Apartamento].([CondominioId]) (FK_Apartamento_Condominio)
        /// </summary>
        public virtual Condominio Condominio { get; set; } // FK_Apartamento_Condominio

        public Apartamento()
        {
            Morador = new System.Collections.Generic.List<Morador>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // Condominio
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public partial class Condominio
    {
        public int Id { get; set; } // Id (Primary key)
        public string Nome { get; set; } // Nome (length: 150)
        public bool Status { get; set; } // Status

        // Reverse navigation

        /// <summary>
        /// Child Apartamento where [Apartamento].[CondominioId] point to this entity (FK_Apartamento_Condominio)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<Apartamento> Apartamento { get; set; } // Apartamento.FK_Apartamento_Condominio

        public Condominio()
        {
            Apartamento = new System.Collections.Generic.List<Apartamento>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // Morador
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public partial class Morador
    {
        public int Id { get; set; } // Id (Primary key)
        public string Nome { get; set; } // Nome (length: 200)
        public System.DateTime DataNascimento { get; set; } // DataNascimento
        public string Telefone { get; set; } // Telefone (length: 50)
        public string Celular { get; set; } // Celular (length: 50)
        public string Cpf { get; set; } // CPF (length: 20)
        public string Email { get; set; } // Email (length: 200)
        public bool Status { get; set; } // Status
        public int? ApartamentoId { get; set; } // ApartamentoId

        // Foreign keys

        /// <summary>
        /// Parent Apartamento pointed by [Morador].([ApartamentoId]) (FK_Morador_Apartamento)
        /// </summary>
        public virtual Apartamento Apartamento { get; set; } // FK_Morador_Apartamento

        public Morador()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // Usuario
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public partial class Usuario
    {
        public int Id { get; set; } // Id (Primary key)
        public string Username { get; set; } // Username (length: 50)
        public string Password { get; set; } // Password (length: 300)
        public bool Status { get; set; } // Status

        public Usuario()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    #endregion

}
// </auto-generated>
