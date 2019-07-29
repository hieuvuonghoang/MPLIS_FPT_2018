using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace MPLIS.Web.FrameWork.Mvc
{
    public static class ComboTreeHelpers
    {
        public static MvcHtmlString ComboTree(this HtmlHelper htmlHelper, string name)
        {
            return ComboTree(htmlHelper, name, null /* selectList */, null /* optionLabel */, null /* htmlAttributes */);
        }
        public static MvcHtmlString ComboTree(this HtmlHelper htmlHelper, string name, string UrlData)
        {
            return ComboTree(htmlHelper, name, UrlData, null /* optionLabel */, null /* htmlAttributes */);
        }

        public static MvcHtmlString ComboTree(this HtmlHelper htmlHelper, string name, string UrlData, object htmlAttributes)
        {
            return ComboTree(htmlHelper, name, UrlData, null /* optionLabel */, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString ComboTree(this HtmlHelper htmlHelper, string name, string UrlData, IDictionary<string, object> htmlAttributes)
        {
            return ComboTree(htmlHelper, name, UrlData, null /* optionLabel */, htmlAttributes);
        }

        public static MvcHtmlString ComboTree(this HtmlHelper htmlHelper, string name, string UrlData, string optionLabel)
        {
            return ComboTree(htmlHelper, name, UrlData, optionLabel, null /* htmlAttributes */);
        }

        public static MvcHtmlString ComboTree(this HtmlHelper htmlHelper, string name, string UrlData, string optionLabel, object htmlAttributes)
        {
            return ComboTree(htmlHelper, name, UrlData, optionLabel, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString ComboTree(this HtmlHelper htmlHelper, string name, string UrlData, string optionLabel, IDictionary<string, object> htmlAttributes)
        {
            return ComboTreeHelper(htmlHelper, metadata: null, expression: name, UrlData: UrlData, optionLabel: optionLabel, htmlAttributes: htmlAttributes);
        }

        public static MvcHtmlString ComboTreeFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string UrlData)
        {
            return ComboTreeFor(htmlHelper, expression, UrlData, null /* optionLabel */, null /* htmlAttributes */);
        }

        public static MvcHtmlString ComboTreeFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string UrlData, object htmlAttributes)
        {
            return ComboTreeFor(htmlHelper, expression, UrlData, null /* optionLabel */, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString ComboTreeFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string UrlData, IDictionary<string, object> htmlAttributes)
        {
            return ComboTreeFor(htmlHelper, expression, UrlData, null /* optionLabel */, htmlAttributes);
        }

        public static MvcHtmlString ComboTreeFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string UrlData, string optionLabel)
        {
            return ComboTreeFor(htmlHelper, expression, UrlData, optionLabel, null /* htmlAttributes */);
        }

        public static MvcHtmlString ComboTreeFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string UrlData, string optionLabel, object htmlAttributes)
        {
            return ComboTreeFor(htmlHelper, expression, UrlData, optionLabel, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString ComboTreeFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string UrlData, string optionLabel, IDictionary<string, object> htmlAttributes)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            return ComboTreeHelper(htmlHelper, metadata, ExpressionHelper.GetExpressionText(expression), UrlData, optionLabel, htmlAttributes);
        }

        private static MvcHtmlString ComboTreeHelper(HtmlHelper htmlHelper, ModelMetadata metadata, string expression, string UrlData, string optionLabel, IDictionary<string, object> htmlAttributes)
        {
            return SelectInternal(htmlHelper, metadata, optionLabel, expression, UrlData, allowMultiple: false, htmlAttributes: htmlAttributes);
        }
        private static MvcHtmlString SelectInternal(this HtmlHelper htmlHelper, ModelMetadata metadata, string optionLabel, string name, string UrlData, bool allowMultiple, IDictionary<string, object> htmlAttributes)
        {
            string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            string id = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(name);
            if (String.IsNullOrEmpty(fullName))
            {
                throw new ArgumentException("string parameter is null or empty", "name");
            }
            TagBuilder inputBuilder = new TagBuilder("input");
            inputBuilder.GenerateId(fullName);
            inputBuilder.MergeAttributes(htmlAttributes, true);
            inputBuilder.MergeAttribute("name", fullName, true);
            inputBuilder.MergeAttribute("class", "easyui-combotree");
            inputBuilder.MergeAttribute("style", "display:none");
            ModelState modelState;
            if (htmlHelper.ViewData.ModelState.TryGetValue(fullName, out modelState) && modelState.Errors.Count > 0)
            {
                inputBuilder.AddCssClass(HtmlHelper.ValidationInputCssClassName);
            }

            inputBuilder.MergeAttributes(htmlHelper.GetUnobtrusiveValidationAttributes(name));

            string value;
            if (modelState != null && modelState.Value != null)
            {
                value = modelState.Value.AttemptedValue;
            }
            else if (metadata.Model != null)
            {
                value = metadata.Model.ToString();
                if (value == Guid.Empty.ToString()) value = string.Empty;
            }
            else
            {
                value = String.Empty;
            }
            TagBuilder scriptBuilder = new TagBuilder("script");
            scriptBuilder.MergeAttribute("type", "text/javascript");
            string scritp = "";
            scritp += "$(function () {";
            scritp += "$('#" + id + "').combotree({";
            scritp += "url: '" + UrlData + "',";
            scritp += "required: false});";
            scritp += "});";
            if (!string.IsNullOrEmpty(value))
            {
                scritp += "$('#" + id + "').combotree('setValue', '" + value + "');  ";
            }
            scriptBuilder.InnerHtml = scritp;
            return MvcHtmlString.Create(inputBuilder.ToString() + "\n" + scriptBuilder.ToString());
        }
    }
}
