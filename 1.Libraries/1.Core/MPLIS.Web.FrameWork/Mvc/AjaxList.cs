using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MPLIS.Web.FrameWork.Mvc
{
    public sealed class AjaxList<T> : MPLISHelperBase
    {
        private readonly MPLISInfo a;
        private string action;
        private string cssClass;
        private object htmlAttributes;
        private string moreText;
        private string tagidCount;
        private string tagidHeadSum;
        private readonly IDictionary<string, object> parameters;
        private readonly IList<KeyValuePair<string, string>> parents;
        private string prefix;
        private bool tableLayout;
        private string url;
        private readonly UrlHelper urlh;

        public AjaxList(MPLISInfo o)
        {
            this.a = o;
            this.parents = new List<KeyValuePair<string, string>>();
            this.parameters = new Dictionary<string, object>();
            this.urlh = new UrlHelper(this.a.Html.ViewContext.RequestContext);
        }

        public AjaxList<T> Action(string o)
        {
            this.action = o;
            return (AjaxList<T>)this;
        }
        public AjaxList<T> CssClass(string s)
        {
            this.cssClass = s;
            return (AjaxList<T>)this;
        }
        public AjaxList<T> HtmlAttributes(object o)
        {
            this.htmlAttributes = o;
            return (AjaxList<T>)this;
        }
        public AjaxList<T> MoreText(string o)
        {
            this.moreText = o;
            return (AjaxList<T>)this;
        }
        public AjaxList<T> TagIdCount(string o)
        {
            this.tagidCount = o;
            return (AjaxList<T>)this;
        }
        public AjaxList<T> TagIdHeadSum(string o)
        {
            this.tagidHeadSum = o;
            return (AjaxList<T>)this;
        }
        public AjaxList<T> Parameter(string name, object value)
        {
            this.parameters.Add(name, value);
            return (AjaxList<T>)this;
        }
        public AjaxList<T> Parent(string o, string alias = "parent")
        {
            this.parents.Add(new KeyValuePair<string, string>(alias, o));
            return (AjaxList<T>)this;
        }
        public AjaxList<T> Parent<TReturn>(Expression<Func<T, TReturn>> o, string alias = "parent")
        {
            this.parents.Add(new KeyValuePair<string, string>(alias, ExpressionHelper.GetExpressionText(o)));
            return (AjaxList<T>)this;
        }
        public AjaxList<T> TableLayout(bool o)
        {
            this.tableLayout = o;
            return (AjaxList<T>)this;
        }
        public AjaxList<T> Url(string o)
        {
            this.url = o;
            return (AjaxList<T>)this;
        }
        internal override string Render()
        {
            string str = "";
            //str += string.Format("<div id=\"{0}_totalrecord\"></div>", a.Prop);
            if (tableLayout == true)
            {
                str += string.Format("<table class=\"table table-bordered table-striped table-hover\"><tbody id=\"{0}\"></tbody></table>", a.Prop);
            }
            else
            {
                str += string.Format("<div id=\"{0}\"></div>", a.Prop);
            }
            str += string.Format("<div id=\"{0}_loadMore\" class=\"divMore\">", a.Prop);
            str += string.Format("<span id=\"span_{0}\"> {1} </span>", a.Prop, moreText);
            str += string.Format("<div id=\"{0}_loading\" style=\"display: none;text-align:center;\">", a.Prop);
            str += "<img src=\"/Images/loading-icon.gif\" />";
            str += "</div>";
            str += "</div>";
            str += "<script type='text/javascript'>";
            str += "jQuery(function(){ajaxlist({lname:'" + a.Prop + "',url:'" + this.url + "',tagidCount:'" + this.tagidCount + "',tagidHead:'" + this.tagidHeadSum + "',data:" + this.parents.ToData() + "})});";
            //str += String.Format("jQuery(function(){ajaxlist({lname:'{0},url:\"{1}\",data:{2}})});",a.Prop,this.url.ToString(),this.parents.ToData().ToString());
            str += "</script>";
            return str;
        }
    }
}
