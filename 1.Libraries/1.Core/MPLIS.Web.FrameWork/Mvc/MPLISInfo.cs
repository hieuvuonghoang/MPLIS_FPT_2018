using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MPLIS.Web.FrameWork.Mvc
{
    public class MPLISInfo
    {
        // Properties
        public HtmlHelper Html { get; set; }
        public ModelMetadata Metadata { get; set; }
        public string Prop { get; set; }
    }
}
