//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineEDUschoolManaementSystemMVC.Models.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Decentralization
    {
        public int accountID { get; set; }
        public int functionID { get; set; }
        public string description { get; set; }
    
        public virtual FunctionT FunctionT { get; set; }
    }
}
