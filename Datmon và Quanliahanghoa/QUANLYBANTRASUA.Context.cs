﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Quanlybantrasua
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QUANLYBANTRASUAEntities : DbContext
    {
        public QUANLYBANTRASUAEntities()
            : base("name=QUANLYBANTRASUAEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BAN> BAN { get; set; }
        public virtual DbSet<CHI_TIET_HOA_DON> CHI_TIET_HOA_DON { get; set; }
        public virtual DbSet<HANGHOA> HANGHOA { get; set; }
        public virtual DbSet<HOA_DON> HOA_DON { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANG { get; set; }
        public virtual DbSet<Loai_HANGHOA> Loai_HANGHOA { get; set; }
        public virtual DbSet<LOAI_KHACH_HANG> LOAI_KHACH_HANG { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIEN { get; set; }
    }
}
