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
    
    public partial class GuestMst
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GuestMst()
        {
            this.CartLists = new HashSet<CartList>();
            this.TransactionMsts = new HashSet<TransactionMst>();
        }
    
        public string guestId { get; set; }
        public string guestFname { get; set; }
        public string guestLname { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string mobNo { get; set; }
        public string emailId { get; set; }
        public string dob { get; set; }
        public System.DateTime cdate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CartList> CartLists { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransactionMst> TransactionMsts { get; set; }
    }
}
