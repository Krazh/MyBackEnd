﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyBackEnd.Assets
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SalesCommEntities : DbContext
    {
        public SalesCommEntities()
            : base("name=SalesCommEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AccessRights> AccessRightsSet { get; set; }
        public virtual DbSet<Brand> BrandSet { get; set; }
        public virtual DbSet<Business> BusinessSet { get; set; }
        public virtual DbSet<BusinessType> BusinessTypeSet { get; set; }
        public virtual DbSet<Campaign> CampaignSet { get; set; }
        public virtual DbSet<Chain> ChainSet { get; set; }
        public virtual DbSet<City> CitySet { get; set; }
        public virtual DbSet<Error> ErrorSet { get; set; }
        public virtual DbSet<ItemCampaign> ItemCampaignSet { get; set; }
        public virtual DbSet<Item> ItemSet { get; set; }
        public virtual DbSet<User> UserSet { get; set; }
    }
}