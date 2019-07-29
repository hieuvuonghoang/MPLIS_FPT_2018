using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MPLIS.Web.FrameWork.Mvc
{
    public static class MPLISExtensions
    {
        public static MPLISHtmlHelper<T> MPLISMvc<T>(this HtmlHelper<T> html)
        {
            return new MPLISHtmlHelper<T>(html);
        }
    }
}
