using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Web.FrameWork.Models
{
    public class Message
    {
        public string Text { get; set; }
        public TypeMessage Type { get; set; }
    }
    public enum TypeMessage
    {
        success = 0,
        info = 1,
        warning = 2,
        error = 3
    }
}
