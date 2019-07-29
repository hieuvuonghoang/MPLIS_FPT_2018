using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Web.FrameWork.Mvc
{
    public class ButtonLoad<T> : MPLISHelperBase
    {
        private readonly MPLISInfo a;
        private ButtonLoadInfo btInfo;
        public ButtonLoad(MPLISInfo o)
        {
            this.a = o;
            btInfo = new ButtonLoadInfo();
        }
        public ButtonLoad<T> Property(ButtonLoadInfo info)
        {
            btInfo = info;
            return (ButtonLoad<T>)this;
        }
        internal override string Render()
        {
            string st = "";
            string name = a.Prop;
            st += string.Format("<button class=\"btn btn-danger btn-sm\" id=\"{0}\"><i class=\"icon-minus-sign icon-white\"></i>Cancel</button>", a.Prop);
            st += "<script>jQuery($(\"#" + a.Prop + "\").click(function (){loadContent({";
            st += "url:'" + btInfo.url + "'," +
            "tagid:'" + btInfo.tagid + "'," +
            "data:" + btInfo.data +
             "});}))</script>";
            return st;
        }
    }
    public class ButtonLoadInfo
    {
        public string url { get; set; }
        public string tagid { get; set; }
        public string data { get; set; }
    }
}
