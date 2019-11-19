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
    using System.ComponentModel.DataAnnotations;

    public partial class CartList
    {
        public string cartId { get; set; }
        public string transactionId { get; set; }
        public string itemCode { get; set; }
        public int qty { get; set; }
        [DataType(DataType.Currency)]
        public decimal price { get; set; }
    
        public virtual ItemMst ItemMst { get; set; }
        public virtual TransactionMst TransactionMst { get; set; }
    }
}
