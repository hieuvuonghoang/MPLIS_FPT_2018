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
    
    public partial class DC_BD_CHU
    {
        public string BDCHUID { get; set; }
        public string NGUOIID { get; set; }
        public string BIENDONGID { get; set; }
        public string VAITROCHU { get; set; }
    
        public virtual DC_BIENDONG DC_BIENDONG { get; set; }
        public virtual DC_NGUOI DC_NGUOI { get; set; }
    }
}
