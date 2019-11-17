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
    
    public partial class UserRegMst
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserRegMst()
        {
            this.CartLists = new HashSet<CartList>();
            this.CommentMsts = new HashSet<CommentMst>();
            this.TransactionMsts = new HashSet<TransactionMst>();
        }
    
        public string userId { get; set; }
        public string userFname { get; set; }
        public string userLname { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string mobNo { get; set; }
        public string emailId { get; set; }
        public string dob { get; set; }
        public byte[] cdate { get; set; }
        public string password { get; set; }
        public Nullable<bool> status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CartList> CartLists { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommentMst> CommentMsts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransactionMst> TransactionMsts { get; set; }
    }
}
