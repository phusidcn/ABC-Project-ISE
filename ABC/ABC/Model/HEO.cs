//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ABC.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class HEO
    {
        public int ID { get; set; }
        public string TEN { get; set; }
        public string MUC_DICH { get; set; }
        public int MUC_TIEU { get; set; }
        public int HIEN_TAI { get; set; }
        public System.DateTime NGAY_KT { get; set; }
        public int ID_USER { get; set; }
    
        public virtual User User { get; set; }
    }
}
