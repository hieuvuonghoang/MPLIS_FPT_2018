//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppCore.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class HS_TC_CHU
    {
        public string TENCHU { get; set; }
        public string DIACHI { get; set; }
        public string CHUID { get; set; }
        public string SOGIAYTOXM { get; set; }
        public string TCCHUID { get; set; }
        public string HOSOID { get; set; }
    
        public virtual HS_HOSO HS_HOSO { get; set; }
    }
}
