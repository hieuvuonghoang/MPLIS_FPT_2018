using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;
using System.Web.Mvc.Html;
using System.Web.Mvc;
using System.Collections;
using System.Web;
using System.Reflection;
using System.Xml;

namespace MPLIS.Web.FrameWork.Helpers
{
    public static class LabelForExtensions
    {
        public static MvcHtmlString LabelForIncludeValidateHelper<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression,string contentHelper, object containerAttributes, object labelAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);

            //var T = model.GetType();
            //PropertyInfo[] properties = T.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            //foreach (PropertyInfo pi in properties)
            //{
            //    if (pi.CanRead)
            //    {
            //        if (pi.GetCustomAttributes(typeof(ItemLog), true).Length > 0)
            //        {
            //            var obj = new ItemLogAttr();
            //            obj.Name = pi.Name;
            //            var _valobj = pi.GetValue(model, null);
            //            if (_valobj != null) obj.Value = _valobj.ToString();
            //            obj.Type = pi.PropertyType.ToString();
            //            results.Add(obj.Name, obj);
            //        }
            //    }
            //}


            var labelBuilder = helper.LabelFor(expression, labelAttributes);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(labelBuilder.ToHtmlString());
            XmlNode root = doc.DocumentElement;
            XmlNode idLabel = doc.SelectNodes("//label/@for")[0];

            var divTag = new TagBuilder("div");
            divTag.MergeAttributes(containerAttributes.ToDictionary());
            var aTag = new TagBuilder("a");
            aTag.Attributes.Add("href", "#");
            aTag.Attributes.Add("class", "alert-danger");
            aTag.Attributes.Add("id", "helper_" + idLabel.Value);
            aTag.Attributes.Add("rel-toggle", "popover");
            aTag.Attributes.Add("style", "background-color:transparent;");
            var spanTag = new TagBuilder("span");
            spanTag.Attributes.Add("class", "glyphicon glyphicon-exclamation-sign");

            var content = contentHelper;

            var scriptStr = "<script type='text/javascript'>";
            scriptStr += "$(document).ready(function () {";
            scriptStr += "var options = { content: '" + content + "', html: true, placement: 'auto',html:true };";
            scriptStr += "$('#helper_" + idLabel.Value + "').popover(options);";
            scriptStr += "});";
            scriptStr += "</script>";

            aTag.InnerHtml = spanTag.ToString();
            divTag.InnerHtml = aTag.ToString() + labelBuilder.ToString() + scriptStr;

            return new MvcHtmlString(divTag.ToString());
        }
    }
}
