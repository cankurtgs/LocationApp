//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LocationApp.Data.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class subunit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public subunit()
        {
            this.departments = new HashSet<department>();
        }
    
        public int SubUnitID { get; set; }
        public string Name { get; set; }
        public Nullable<int> MainUnitID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<department> departments { get; set; }
        public virtual mainunit mainunit { get; set; }
    }
}