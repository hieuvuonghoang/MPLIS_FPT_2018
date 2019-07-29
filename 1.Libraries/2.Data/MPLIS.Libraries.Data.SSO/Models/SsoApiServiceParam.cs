using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.SSO.Models
{
    public class SsoApiServiceData
    {
        public string Value { get; set; }
        public DateTime TimeValid { get; set; }

        public SsoApiServiceData()
        {
            Value = "";
            TimeValid = DateTime.Now;
        }
    }
}
