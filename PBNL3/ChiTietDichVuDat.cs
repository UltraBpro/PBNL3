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
    
    public partial class ChiTietDichVuDat
    {
        public int MaDichVu { get; set; }
        public double GiaDichVuDat { get; set; }
        public int SoLuong { get; set; }
        public int MaDonDatPhong { get; set; }
    
        public virtual LoaiDichVu LoaiDichVu { get; set; }
        public virtual DonDatPhong DonDatPhong { get; set; }
    }
}
