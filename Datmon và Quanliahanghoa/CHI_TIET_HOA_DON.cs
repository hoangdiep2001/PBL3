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
    
    public partial class CHI_TIET_HOA_DON
    {
        public int ID_CTHD { get; set; }
        public Nullable<int> ID_HD { get; set; }
        public Nullable<int> ID_HH { get; set; }
        public Nullable<int> soluong { get; set; }
    
        public virtual HANGHOA HANGHOA { get; set; }
        public virtual HOA_DON HOA_DON { get; set; }
    }
}
