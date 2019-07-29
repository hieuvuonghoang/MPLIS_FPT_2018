using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Web.FrameWork.Mvc
{
    public class ButtonEdit<T> : MPLISHelperBase
    {
        private readonly MPLISInfo a;
        private ButtonEditInfo btInfo;
        public ButtonEdit(MPLISInfo o)
        {
            this.a = o;
            btInfo = new ButtonEditInfo();
        }
        public ButtonEdit<T> Property(ButtonEditInfo info)
        {
            btInfo = info;
            return (ButtonEdit<T>)this;
        }
        internal override string Render()
        {
            string st = "";
            string name = a.Prop;
            st += "<button class=\"btn btn-success btn-sm\" onclick=\"loadContent({url:'" + btInfo.url + "',data:" + btInfo.data + ",tagid:'" + btInfo.tagid + "'});\"><i class=\"glyphicon glyphicon-edit\"></i></button>";
            //st += "<script>jQuery($(\"#" + a.Prop + "\").click(function (){loadContent({";
            //st += "url:'" + btInfo.url + "'," +
            //"tagid:'" + btInfo.tagid + "'," +
            //"data:" + btInfo.data +
            // "});}))</script>";
            return st;
        }
    }
    public class ButtonEditInfo
    {
        public string url { get; set; }
        public string tagid { get; set; }
        public string data { get; set; }
    }
}
