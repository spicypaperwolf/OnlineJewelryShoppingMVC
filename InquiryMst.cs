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
    
    public partial class InquiryMst
    {
        public string inquiryID { get; set; }
        public string transactionId { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string mobNo { get; set; }
        public string emailId { get; set; }
        public string cmt { get; set; }
        public System.DateTime cdate { get; set; }
        public string cardNo { get; set; }
        public string expdate { get; set; }
        public string CVV_No { get; set; }
    
        public virtual TransactionMst TransactionMst { get; set; }
    }
}
