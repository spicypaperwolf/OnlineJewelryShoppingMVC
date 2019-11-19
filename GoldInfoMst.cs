//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineJewelryShoppingMVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class GoldInfoMst
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GoldInfoMst()
        {
            this.ItemMsts = new HashSet<ItemMst>();
        }

        [DisplayName("Gold ID")]
        public string goldId { get; set; }

        [DisplayName("Gold Criteria")]
        [Range(1, 20, ErrorMessage = "Criteria must be from 1 to 20 ")]
        public decimal goldCrt { get; set; }

        [DisplayName("Gold Type")]
        public string goldType { get; set; }

        [DisplayName("Gold Rate")]
        [Range(1, 100000000, ErrorMessage = "Rate must be from 1 to 100,000,000 ")]
        public decimal goldRate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemMst> ItemMsts { get; set; }
    }
}
