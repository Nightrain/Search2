﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataHelper
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SearchDataEntities : DbContext
    {
        public SearchDataEntities()
            : base("name=SearchDataEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<base_food> base_food { get; set; }
        public DbSet<base_move> base_move { get; set; }
        public DbSet<base_release> base_release { get; set; }
        public DbSet<base_risk> base_risk { get; set; }
        public DbSet<base_social> base_social { get; set; }
    }
}
