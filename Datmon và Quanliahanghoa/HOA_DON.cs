//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class HOA_DON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOA_DON()
        {
            this.CHI_TIET_HOA_DON = new HashSet<CHI_TIET_HOA_DON>();
        }
    
        public int ID_HD { get; set; }
        public Nullable<int> ID_BAN { get; set; }
        public Nullable<int> ID_NV { get; set; }
        public Nullable<int> PhoneNumber { get; set; }
        public Nullable<System.DateTime> Gio_den { get; set; }
        public Nullable<System.DateTime> Gio_di { get; set; }
        public Nullable<decimal> Tongtien { get; set; }
        public Nullable<int> discount { get; set; }
        public Nullable<int> Diem_TL { get; set; }
        public Nullable<bool> Thanhtoan { get; set; }
    
        public virtual BAN BAN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHI_TIET_HOA_DON> CHI_TIET_HOA_DON { get; set; }
        public virtual KHACHHANG KHACHHANG { get; set; }
        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
