using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public class People : IEquatable<People>
    {
        public People(string nguoiID)
        {
            this.NGUOIID = nguoiID;
        }
        public string NGUOIID { get; set; }
        public List<string> DSKVHCID { get; set; }
        public bool Equals(People other)
        {
            if (Object.ReferenceEquals(other, null))
                return false;
            if (Object.ReferenceEquals(this, other))
                return true;
            return NGUOIID.Equals(other.NGUOIID);
        }
        public override int GetHashCode()
        {
            return NGUOIID.GetHashCode();
        }
    }
}
