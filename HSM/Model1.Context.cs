﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HSM
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HSMEntities : DbContext
    {
        public HSMEntities()
            : base("name=HSMEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<APPOINTMENT> APPOINTMENTs { get; set; }
        public virtual DbSet<BILL> BILLs { get; set; }
        public virtual DbSet<DEPARTMENT> DEPARTMENTs { get; set; }
        public virtual DbSet<DOCTOR> DOCTORs { get; set; }
        public virtual DbSet<EMPLOYEE> EMPLOYEEs { get; set; }
        public virtual DbSet<MEDICAL_EXAMINATIONS> MEDICAL_EXAMINATIONS { get; set; }
        public virtual DbSet<MEDICAL_EXAMINATIONS_TYPES> MEDICAL_EXAMINATIONS_TYPES { get; set; }
        public virtual DbSet<PATIENT> PATIENTs { get; set; }
        public virtual DbSet<PHARMACY> PHARMACies { get; set; }
        public virtual DbSet<PHARMACY_BILL> PHARMACY_BILL { get; set; }
    }
}
