﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MPLIS.Web.FrameWork.Mvc
{
    public static class MPLISHtmlHelperExtensions
    {
        public static AjaxList<T> AjaxList<T>(this MPLISHtmlHelper<T> a, string name)
        {
            return new AjaxList<T>(MPLISInfo<T>(a, name));
        }
        public static ButtonSave<T> ButtonSave<T>(this MPLISHtmlHelper<T> a, string name)
        {
            return new ButtonSave<T>(MPLISInfo<T>(a, name));
        }
        public static ButtonCancel<T> ButtonCancel<T>(this MPLISHtmlHelper<T> a, string name)
        {
            return new ButtonCancel<T>(MPLISInfo<T>(a, name));
        }
        public static ButtonLoad<T> ButtonLoad<T>(this MPLISHtmlHelper<T> a, string name)
        {
            return new ButtonLoad<T>(MPLISInfo<T>(a, name));
        }
        public static ButtonEdit<T> ButtonEdit<T>(this MPLISHtmlHelper<T> a, string name)
        {
            return new ButtonEdit<T>(MPLISInfo<T>(a, name));
        }
        private static MPLISInfo MPLISInfo<T>(MPLISHtmlHelper<T> a, string prop)
        {
            return new MPLISInfo { Html = a.Html, Prop = prop };
        }
        private static MPLISInfo MPLISInfo<T, TReturn>(MPLISHtmlHelper<T> a, Expression<Func<T, TReturn>> expression)
        {
            return new MPLISInfo { Html = a.Html, Metadata = ModelMetadata.FromLambdaExpression<T, TReturn>(expression, a.Html.ViewData), Prop = ExpressionHelper.GetExpressionText(expression) };
        }
    }
    public static class HtmlPrefixScopeExtensions
    {
        private const string idsToReuseKey = "__htmlPrefixScopeExtensions_IdsToReuse_";

        public static IDisposable BeginCollectionItem(this HtmlHelper html, string collectionName)
        {
            if (html.ViewData["ContainerPrefix"] != null)
            {
                collectionName = string.Concat(html.ViewData["ContainerPrefix"], ".", collectionName);
            }

            var idsToReuse = GetIdsToReuse(html.ViewContext.HttpContext, collectionName);
            string itemIndex = idsToReuse.Count > 0 ? idsToReuse.Dequeue() : Guid.NewGuid().ToString();

            var htmlFieldPrefix = string.Format("{0}[{1}]", collectionName, itemIndex);

            html.ViewData["ContainerPrefix"] = htmlFieldPrefix;

            // autocomplete="off" is needed to work around a very annoying Chrome behaviour whereby it reuses old values after the user clicks "Back", which causes the xyz.index and xyz[...] values to get out of sync.
            html.ViewContext.Writer.WriteLine(string.Format("<input type=\"hidden\" name=\"{0}.index\" autocomplete=\"off\" value=\"{1}\" />", collectionName, html.Encode(itemIndex)));

            return BeginHtmlFieldPrefixScope(html, htmlFieldPrefix);
        }

        public static IDisposable BeginHtmlFieldPrefixScope(this HtmlHelper html, string htmlFieldPrefix)
        {
            return new HtmlFieldPrefixScope(html.ViewData.TemplateInfo, htmlFieldPrefix);
        }

        private static Queue<string> GetIdsToReuse(HttpContextBase httpContext, string collectionName)
        {
            // We need to use the same sequence of IDs following a server-side validation failure,  
            // otherwise the framework won't render the validation error messages next to each item.
            string key = idsToReuseKey + collectionName;
            var queue = (Queue<string>)httpContext.Items[key];
            if (queue == null)
            {
                httpContext.Items[key] = queue = new Queue<string>();
                var previouslyUsedIds = httpContext.Request[collectionName + ".index"];
                if (!string.IsNullOrEmpty(previouslyUsedIds))
                    foreach (string previouslyUsedId in previouslyUsedIds.Split(','))
                        queue.Enqueue(previouslyUsedId);
            }
            return queue;
        }

        private class HtmlFieldPrefixScope : IDisposable
        {
            private readonly TemplateInfo templateInfo;
            private readonly string previousHtmlFieldPrefix;

            public HtmlFieldPrefixScope(TemplateInfo templateInfo, string htmlFieldPrefix)
            {
                this.templateInfo = templateInfo;

                previousHtmlFieldPrefix = templateInfo.HtmlFieldPrefix;
                templateInfo.HtmlFieldPrefix = htmlFieldPrefix;
            }

            public void Dispose()
            {
                templateInfo.HtmlFieldPrefix = previousHtmlFieldPrefix;
            }
        }
    }
}
