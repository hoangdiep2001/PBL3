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
    
    public partial class HANGHOA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HANGHOA()
        {
            this.CHI_TIET_HOA_DON = new HashSet<CHI_TIET_HOA_DON>();
        }
    
        public int ID_HH { get; set; }
        public Nullable<int> ID_LHH { get; set; }
        public string Ten_HH { get; set; }
        public Nullable<decimal> Gia { get; set; }
        public Nullable<bool> tinhTrang { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHI_TIET_HOA_DON> CHI_TIET_HOA_DON { get; set; }
        public virtual Loai_HANGHOA Loai_HANGHOA { get; set; }
    }
}
