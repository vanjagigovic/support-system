﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SUPORT_SYSTEM.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SUPPORT_SYSTEMEntities : DbContext
    {
        public SUPPORT_SYSTEMEntities()
            : base("name=SUPPORT_SYSTEMEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<comment> comments { get; set; }
        public virtual DbSet<country> countries { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<section> sections { get; set; }
        public virtual DbSet<severity> severities { get; set; }
        public virtual DbSet<status> status { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<ticket> tickets { get; set; }
        public virtual DbSet<user> users { get; set; }
    }
}