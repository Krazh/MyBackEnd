//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyBackEnd.Assets
{
    using System;
    using System.Collections.Generic;
    
    public partial class Chain
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Chain()
        {
            this.BusinessSet = new HashSet<Business>();
            this.CampaignSet = new HashSet<Campaign>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public bool ProMode { get; set; }
        public string Address { get; set; }
        public int CityPostalCode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Business> BusinessSet { get; set; }
        public virtual City CitySet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Campaign> CampaignSet { get; set; }
    }
}