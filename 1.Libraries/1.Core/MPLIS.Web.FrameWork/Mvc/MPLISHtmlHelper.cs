using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MPLIS.Web.FrameWork.Mvc
{
    public class MPLISHtmlHelper<T>
    {
        public MPLISHtmlHelper(HtmlHelper<T> html)
        {
            this.Html = html;
        }
        // Properties
        public HtmlHelper<T> Html { get; set; }

    }
}
