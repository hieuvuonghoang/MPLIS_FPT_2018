using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Web.FrameWork.Mvc
{
    public class ButtonCancel<T> : MPLISHelperBase
    {
        private readonly MPLISInfo a;
        private ButtonCanelInfo btInfo;
        public ButtonCancel(MPLISInfo o)
        {
            this.a = o;
            btInfo = new ButtonCanelInfo();
        }
        public ButtonCancel<T> Property(ButtonCanelInfo info)
        {
            btInfo = info;
            return (ButtonCancel<T>)this;
        }
        internal override string Render()
        {
            string st = "";
            string name = a.Prop;
            string data = string.IsNullOrEmpty(btInfo.data) ? "{keys:[],vals:[]}" : btInfo.data;
            st += string.Format("<button class=\"btn btn-danger btn-sm\" id=\"{0}\"><i class=\"glyphicon glyphicon-minus-sign\"></i> Cancel</button>", a.Prop);
            st += "<script>jQuery($(\"#" + a.Prop + "\").click(function (){loadContent({";
            st += "url:'" + btInfo.urlLoadBack + "'," +
            "tagid:'" + btInfo.tagid + "'," +
            "data:" + data +
             "});}))</script>";
            return st;
        }
    }
    public class ButtonCanelInfo
    {
        public string urlLoadBack { get; set; }
        public string tagid { get; set; }
        public string data { get; set; }
    }
}
