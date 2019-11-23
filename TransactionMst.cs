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
    
    public partial class TransactionMst
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TransactionMst()
        {
            this.CartLists = new HashSet<CartList>();
            this.InquiryMsts = new HashSet<InquiryMst>();
        }
    
        public string transactionId { get; set; }
        public string userId { get; set; }
        public decimal totPrice { get; set; }
        public int totQty { get; set; }
        public string approvalStt { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CartList> CartLists { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InquiryMst> InquiryMsts { get; set; }
        public virtual UserRegMst UserRegMst { get; set; }
    }
}
