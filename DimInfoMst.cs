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

    public partial class DimInfoMst
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DimInfoMst()
        {
            this.ItemMsts = new HashSet<ItemMst>();
        }

        [DisplayName("Diamond ID")]
        public string dimId { get; set; }
        [DisplayName("Diamond Shape")]
        public string dimShape { get; set; }

        [DisplayName("Diamond Criteria")]
        [Range(1, 10, ErrorMessage = "Criteria must be from 0.1 to 10 ")]
        public decimal dimCrt { get; set; }

        [DisplayName("Diamond Size")]
        [Range(3, 11, ErrorMessage = "Size must be from 3 to 11 mm ")]
        public decimal dimSize { get; set; }

        [DisplayName("Diamond Color")]
        public string dimColor { get; set; }
        [DisplayName("Diamond Clarity")]
        public string dimClarity { get; set; }
        [DisplayName("Diamond Cut")]
        public string dimCut { get; set; }
        [DisplayName("Diamond Polish")]
        public string dimPolish { get; set; }
        [DisplayName("Diamond Symetry")]
        public string dimSymmetry { get; set; }
        [DisplayName("Diamond Report")]
        public string dimReport { get; set; }

        [DisplayName("Diamond Rate")]
        [Range(1, 100000000, ErrorMessage = "Rate must be from 1 to 100,000,000 ")]
        public decimal dimRate { get; set; }
        [DisplayName("Upload Image")]
        public string dimImg { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemMst> ItemMsts { get; set; }
    }
}
