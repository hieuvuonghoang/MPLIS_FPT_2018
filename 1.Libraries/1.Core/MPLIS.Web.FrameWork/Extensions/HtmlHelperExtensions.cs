using System.Web.Mvc;
using MPLIS.Web.FrameWork.Helpers;

namespace MPLIS.Web.FrameWork.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static UserHtmlHelper User(this HtmlHelper html)
        {
            return new UserHtmlHelper(html, new UrlHelper(html.ViewContext.RequestContext));
        }
    }
}