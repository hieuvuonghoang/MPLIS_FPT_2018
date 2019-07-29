using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Web.FrameWork.Mvc
{
    public sealed class ButtonSave<T> : MPLISHelperBase
    {
        private readonly MPLISInfo a;
        private ButtonSaveInfo btInfo;
        public ButtonSave(MPLISInfo o)
        {
            this.a = o;
            btInfo = new ButtonSaveInfo();
        }
        public ButtonSave<T> Property(ButtonSaveInfo info)
        {
            btInfo = info;
            return (ButtonSave<T>)this;
        }
        internal override string Render()
        {
            string st = "";
            string val = " Save";
            string datasuccess = string.IsNullOrEmpty(btInfo.dataUrlsuccess) ? "{keys:[],vals:[]}" : btInfo.dataUrlsuccess;
            if (btInfo.text != null && !string.IsNullOrEmpty(btInfo.text))
            { val = btInfo.text; }
            string name = a.Prop;
            st += string.Format("<button class=\"btn btn-sm btn-primary\" id=\"{0}\"><i class=\"glyphicon glyphicon-ok-circle\"></i>{1}</button>", a.Prop, val);
            st += "<script>jQuery($(\"#" + a.Prop + "\").click(function (){ ";
            //st += "if(ValidateFields()){";
            st += "ajaxCallBack({";
            st += "url:'" + btInfo.url + "'," +
            "formid:'" + btInfo.formid + "'," +
            "method:'" + btInfo.method + "'," +
            "data:" + btInfo.data + "," +
            "urlsuccess:'" + btInfo.urlsuccess + "'," +
            "tagidsuccess:'" + btInfo.tagidsuccess + "'," +
            "dataUrlsuccess:" + datasuccess +
             "});}))</script>";
            return st;
        }
    }
    public class ButtonSaveInfo
    {
        public string formid { get; set; }
        public string text { get; set; }
        public string url { get; set; }
        public string method { get; set; }
        public string data { get; set; }
        public string urlsuccess { get; set; }
        public string tagidsuccess { get; set; }
        public string dataUrlsuccess { get; set; }

        public string validate { get; set; }

        public ButtonSaveInfo()
        {
            formid = "";
            text = "";
            url = "";
            method = "";
            data = "";
            urlsuccess = "";
            tagidsuccess = "";
            dataUrlsuccess = "";
        }

    }
}
