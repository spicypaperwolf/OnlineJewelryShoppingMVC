﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineJewelryShoppingMVC
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OnlineJewelryShopDBEntities : DbContext
    {
        public OnlineJewelryShopDBEntities()
            : base("name=OnlineJewelryShopDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AdminLoginMst> AdminLoginMsts { get; set; }
        public virtual DbSet<BrandMst> BrandMsts { get; set; }
        public virtual DbSet<CartList> CartLists { get; set; }
        public virtual DbSet<CategoryMst> CategoryMsts { get; set; }
        public virtual DbSet<CertificateMst> CertificateMsts { get; set; }
        public virtual DbSet<CommentMst> CommentMsts { get; set; }
        public virtual DbSet<ContactMst> ContactMsts { get; set; }
        public virtual DbSet<DimInfoMst> DimInfoMsts { get; set; }
        public virtual DbSet<GoldInfoMst> GoldInfoMsts { get; set; }
        public virtual DbSet<GuestMst> GuestMsts { get; set; }
        public virtual DbSet<InquiryMst> InquiryMsts { get; set; }
        public virtual DbSet<ItemMst> ItemMsts { get; set; }
        public virtual DbSet<NewsletterMst> NewsletterMsts { get; set; }
        public virtual DbSet<ProductMst> ProductMsts { get; set; }
        public virtual DbSet<StoneInfoMst> StoneInfoMsts { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TransactionMst> TransactionMsts { get; set; }
        public virtual DbSet<UserRegMst> UserRegMsts { get; set; }
    }
}
