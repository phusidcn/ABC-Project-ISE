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
    
    public partial class SO_NO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SO_NO()
        {
            this.Users = new HashSet<User>();
        }
    
        public int ID { get; set; }
        public int ID_VI { get; set; }
        public string LOAI { get; set; }
        public int SO_TIEN { get; set; }
        public string Ghi_Chu { get; set; }
        public string PERSON { get; set; }
        public System.DateTime NGAY { get; set; }
        public int DaTra { get; set; }
    
        public virtual Vi Vi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
    }
}
