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
    
    public partial class GD_GIATHUADAT
    {
        public string LOAIGIADATID { get; set; }
        public string THUADATID { get; set; }
        public string GIATHUADATID { get; set; }
        public Nullable<decimal> GIADAT { get; set; }
        public Nullable<System.DateTime> THOIDIEMXACDINH { get; set; }
        public string CANCUPHAPLY { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public string uId { get; set; }
        public string TENFILE { get; set; }
        public Nullable<decimal> GIADATTHEOHSDC { get; set; }
    
        public virtual DC_THUADAT DC_THUADAT { get; set; }
        public virtual GD_DMLOAIGIADAT GD_DMLOAIGIADAT { get; set; }
    }
}
