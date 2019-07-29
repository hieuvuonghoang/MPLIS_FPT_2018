using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Web.FrameWork.Mvc
{
   public class AjaxListResult
    {
        public string Content { get; set; }
        public bool More { get; set; }
        public long Count { get; set; }
        public string Thead { get; set; }
        public string HeadSum { get; set; }
    }
}
