//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PBNL3
{
    using System;
    using System.Collections.Generic;
    
    public partial class TaiKhoan
    {
        public int MaTK { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public Nullable<int> MaNhanVien { get; set; }
    
        public virtual NhanVien NhanVien { get; set; }
    }
}