﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Language.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LanguageEntities : DbContext
    {
        public LanguageEntities()
            : base("name=LanguageEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<About> About { get; set; }
        public virtual DbSet<Conversation> Conversation { get; set; }
        public virtual DbSet<Food> Food { get; set; }
        public virtual DbSet<Food_Category> Food_Category { get; set; }
        public virtual DbSet<Header> Header { get; set; }
        public virtual DbSet<Setting> Setting { get; set; }
        public virtual DbSet<Social_Network> Social_Network { get; set; }
    }
}
