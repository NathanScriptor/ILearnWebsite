﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineEDUschoolManaementSystemMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBEntities : DbContext
    {
        public DBEntities()
            : base("name=DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<CartTbl> CartTbls { get; set; }
        public DbSet<CourseTbl> CourseTbls { get; set; }
        public DbSet<LecturerTbl> LecturerTbls { get; set; }
        public DbSet<OrderDetailTbl> OrderDetailTbls { get; set; }
        public DbSet<UserTbl> UserTbls { get; set; }
    }
}