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
    
    public partial class ItemMst
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ItemMst()
        {
            this.CommentMsts = new HashSet<CommentMst>();
            this.TransactionMsts = new HashSet<TransactionMst>();
        }
    
        public string itemCode { get; set; }
        public string brandId { get; set; }
        public string catId { get; set; }
        public string certificateId { get; set; }
        public string prodId { get; set; }
        public string dimId { get; set; }
        public string goldId { get; set; }
        public string stoneId { get; set; }
        public string itemName { get; set; }
        public string itemImg { get; set; }
        public Nullable<decimal> pairs { get; set; }
        public Nullable<int> dimQty { get; set; }
        public Nullable<decimal> dimTot { get; set; }
        public Nullable<int> stoneQty { get; set; }
        public Nullable<int> stoneTot { get; set; }
        public Nullable<decimal> goldWt { get; set; }
        public Nullable<decimal> goldTot { get; set; }
        public decimal wstgPer { get; set; }
        public decimal wstg { get; set; }
        public Nullable<decimal> goldMaking { get; set; }
        public Nullable<decimal> stoneMaking { get; set; }
        public Nullable<decimal> otherMaking { get; set; }
        public decimal totMaking { get; set; }
        public decimal MRP { get; set; }
    
        public virtual BrandMst BrandMst { get; set; }
        public virtual CategoryMst CategoryMst { get; set; }
        public virtual CertificateMst CertificateMst { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommentMst> CommentMsts { get; set; }
        public virtual DimInfoMst DimInfoMst { get; set; }
        public virtual GoldInfoMst GoldInfoMst { get; set; }
        public virtual ProductMst ProductMst { get; set; }
        public virtual StoneInfoMst StoneInfoMst { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransactionMst> TransactionMsts { get; set; }
    }
}
