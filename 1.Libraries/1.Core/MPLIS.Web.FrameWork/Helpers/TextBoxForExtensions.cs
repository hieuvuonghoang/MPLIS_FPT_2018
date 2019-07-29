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
    public static class TextBoxForExtensions
    {
        public static MvcHtmlString TextBoxPlaceHolderFor(this HtmlHelper html, Expression<Func<string>> expression, object htmlAttributes)
        {
            var dict = new RouteValueDictionary(htmlAttributes);
            return html.TextBoxPlaceHolderFor(expression, dict);
        }
        public static MvcHtmlString TextBoxPlaceHolderFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression, IDictionary htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            if (!String.IsNullOrEmpty(labelText))
            {
                htmlAttributes.Add("placeholder", labelText);
            }
            return html.TextBoxFor(expression, htmlAttributes);
        }
        public static MvcHtmlString TextBoxForExt<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, List<string> ListItemKeyLogs, Dictionary<string, string> listItemLogs, object htmlAttributes, object btnAttributes)
        {

            //input tag
            var textBoxBuilder = helper.TextBoxFor(expression, htmlAttributes);
            var clsaBuilder = "btn-default";
            var metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);

            if (ListItemKeyLogs != null && ListItemKeyLogs.Contains(metadata.PropertyName))
            {
                if (listItemLogs[metadata.PropertyName] == "DEF")
                {
                    clsaBuilder = "btn-default";
                }
                else
                {
                    if (metadata.ModelType == typeof(decimal) || metadata.ModelType == typeof(decimal?))
                    {
                        if (Convert.ToDecimal(metadata.Model) == Convert.ToDecimal(listItemLogs[metadata.PropertyName]))
                        {
                            clsaBuilder = "btn-primary";
                        }
                        else if (Convert.ToDecimal(metadata.Model) > Convert.ToDecimal(listItemLogs[metadata.PropertyName]))
                        {
                            clsaBuilder = "btn-danger";
                        }
                        else
                        {
                            clsaBuilder = "btn-warning";
                        }
                    }
                    if (metadata.ModelType == typeof(int) || metadata.ModelType == typeof(int?))
                    {
                        if (Convert.ToInt16(metadata.Model.ToString()) == Convert.ToInt16(listItemLogs[metadata.PropertyName]))
                        {
                            clsaBuilder = "btn-primary";
                        }
                        else if (Convert.ToInt16(metadata.Model.ToString()) > Convert.ToInt16(listItemLogs[metadata.PropertyName]))
                        {
                            clsaBuilder = "btn-danger";
                        }
                        else
                        {
                            clsaBuilder = "btn-warning";
                        }
                    }
                }
            }
            else
            {
                ListItemKeyLogs.Add(metadata.PropertyName);
                //var hiddenBuilder = helper.Hidden(listItemLogs.Where(it => it == metadata.PropertyName).First(), listItemLogs.Where(it => it == metadata.PropertyName).First());
                //var htmlBuilder = textBoxBuilder.ToHtmlString() + hiddenBuilder.ToHtmlString();
                //MvcHtmlString.Create(htmlBuilder.ToString());
                return textBoxBuilder;
            }
            //div tag
            var divBuilder = new TagBuilder("div");
            divBuilder.Attributes.Add("class", "input-group");

            //span tag
            var spanBuilder = new TagBuilder("span");
            spanBuilder.Attributes.Add("class", "input-group-btn");

            var dictionaryAttr = btnAttributes.ToDictionary();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(textBoxBuilder.ToHtmlString());
            XmlNode root = doc.DocumentElement;
            XmlNode idTextBox = doc.SelectNodes("//input/@id")[0];
            dictionaryAttr.Add("data-uid", idTextBox.Value);
            // a tag
            var aBuider = new TagBuilder("a");
            aBuider.Attributes.Add("href", "#");
            aBuider.Attributes.Add("tabindex", "0");
            aBuider.Attributes.Add("class", "btn btn-sm clsPopoverItemLog imgPopover " + clsaBuilder);

            //rel="popover"
            aBuider.Attributes.Add("rel-toggle", "popover");
            //aBuider.Attributes.Add("data-trigger", "focus");
            aBuider.MergeAttributes(dictionaryAttr, true);
            aBuider.Attributes.Add("data-name", metadata.PropertyName);

            spanBuilder.InnerHtml = aBuider.ToString();

            divBuilder.InnerHtml = textBoxBuilder.ToHtmlString() + spanBuilder.ToString();

            return MvcHtmlString.Create(divBuilder.ToString());

            //return helper.TextBoxFor(expression, htmlAttributes);
        }
        public static MvcHtmlString TextBoxForExt<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, IDictionary htmlAttributes)
        {
            var textBoxBuilder = helper.TextBoxFor(expression, htmlAttributes);
            return helper.TextBoxFor(expression, htmlAttributes);
        }

        public static MvcHtmlString TextBoxForExtS1<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, object htmlDivContainerAttr, object htmlDivTextBoxContainerAttr, object labelAttributes, object textBoxAttributes, Boolean hasValidationMessageFor)
        {
            var labelBuilder = helper.LabelFor(expression, labelAttributes);
            var textBoxBuilder = helper.TextBoxFor(expression, textBoxAttributes);
            var validationMessageBuilder = new MvcHtmlString("");
            if (hasValidationMessageFor)
                validationMessageBuilder = helper.ValidationMessageFor(expression);
            var divContainerBuilder = new TagBuilder("div");
            divContainerBuilder.MergeAttributes(htmlDivContainerAttr.ToDictionary(), false);
            var divTextBoxContainerBuilder = new TagBuilder("div");
            divTextBoxContainerBuilder.MergeAttributes(htmlDivTextBoxContainerAttr.ToDictionary(), false);
            divTextBoxContainerBuilder.InnerHtml = textBoxBuilder.ToHtmlString() + validationMessageBuilder.ToHtmlString();
            divContainerBuilder.InnerHtml = labelBuilder.ToHtmlString() + divTextBoxContainerBuilder.ToString();
            return MvcHtmlString.Create(divContainerBuilder.ToString());
        }

        public static MvcHtmlString TextAreaForExtS1<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, object htmlDivContainerAttr, object htmlDivTextBoxContainerAttr, object labelAttributes, object textBoxAttributes, Boolean hasValidationMessageFor)
        {
            var labelBuilder = helper.LabelFor(expression, labelAttributes);
            var textBoxBuilder = helper.TextAreaFor(expression, textBoxAttributes);
            var validationMessageBuilder = new MvcHtmlString("");
            if (hasValidationMessageFor)
                validationMessageBuilder = helper.ValidationMessageFor(expression);
            var divContainerBuilder = new TagBuilder("div");
            divContainerBuilder.MergeAttributes(htmlDivContainerAttr.ToDictionary(), false);
            var divTextBoxContainerBuilder = new TagBuilder("div");
            divTextBoxContainerBuilder.MergeAttributes(htmlDivTextBoxContainerAttr.ToDictionary(), false);
            divTextBoxContainerBuilder.InnerHtml = textBoxBuilder.ToHtmlString() + validationMessageBuilder.ToHtmlString();
            divContainerBuilder.InnerHtml = labelBuilder.ToHtmlString() + divTextBoxContainerBuilder.ToString();
            return MvcHtmlString.Create(divContainerBuilder.ToString());
        }

        public static IHtmlString GridFor<TModel>(this HtmlHelper<TModel> htmlHelper, String modelView, Type type)
        {
            TagBuilder controlBuilder = new TagBuilder("table");
            controlBuilder.Attributes.Add("style", "border:1px;");

            var properties = type.GetProperties();

            #region Header
            TagBuilder thead = new TagBuilder("thead");
            TagBuilder rowHeader = new TagBuilder("tr");
            foreach (var property in properties)
            {

                var attrHeader = property.CustomAttributes.Where(i => i.AttributeType == typeof(GridColumnAttribute)).ToList();
                if (attrHeader.Count != 0)
                {
                    var attributeHeader = attrHeader[0];
                    if (Convert.ToBoolean(attributeHeader.ConstructorArguments[1].Value) == false)
                    {
                        TagBuilder col = new TagBuilder("td");
                        col.InnerHtml = attributeHeader.ConstructorArguments[0].Value.ToString();
                        rowHeader.InnerHtml += col.ToString();
                    }

                }
            }
            thead.InnerHtml += rowHeader.ToString();
            controlBuilder.InnerHtml = thead.ToString();

            #endregion

            #region Rows and Columns
            TagBuilder tbody = new TagBuilder("tbody");
            tbody.Attributes.Add("data-bind", "foreach: " + modelView);
            tbody.Attributes.Add("style", "width:100");
            TagBuilder row = new TagBuilder("tr");
            foreach (var property in properties)
            {
                var attr = property.CustomAttributes.Where(i => i.AttributeType == typeof(GridColumnAttribute)).ToList();
                if (attr.Count != 0)
                {
                    var attribute = attr[0];
                    if (Convert.ToBoolean(attribute.ConstructorArguments[1].Value) == false)
                    {
                        TagBuilder col = new
                        TagBuilder("td");
                        col.Attributes.Add("data-bind", "text: " + property.Name);
                        row.InnerHtml += col.ToString();
                    }
                }
            }

            TagBuilder editTd = new TagBuilder("td");
            TagBuilder editLink = new TagBuilder("a");
            editLink.Attributes.Add("data-bind", "attr: {href: EditLink}");
            editLink.InnerHtml = "Edit";
            editTd.InnerHtml += editLink.ToString();
            row.InnerHtml += editTd.ToString();
            TagBuilder deleteTd = new TagBuilder("td");
            TagBuilder deleteLink = new TagBuilder("a");
            deleteLink.Attributes.Add("data-bind", "attr: {href: DeleteLink}");
            deleteLink.InnerHtml = "Delete";
            deleteTd.InnerHtml += deleteLink.ToString();
            row.InnerHtml += deleteTd.ToString();
            tbody.InnerHtml += row.ToString();
            controlBuilder.InnerHtml += tbody.ToString();
            #endregion
            return MvcHtmlString.Create(controlBuilder.ToString());
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class GridColumnAttribute : Attribute
    {
        public string GridColName { set; get; }
        public bool IsHidden { set; get; }
        public GridColumnAttribute(String Name, bool isHidden)
        {
            this.GridColName = Name;
            this.IsHidden = isHidden;
        }
    }

    public static class ext
    {
        public static IDictionary<string, object> ToDictionary(this object data)
        {
            if (data == null) return null; // Or throw an ArgumentNullException if you want

            BindingFlags publicAttributes = BindingFlags.Public | BindingFlags.Instance;
            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            foreach (PropertyInfo property in
                     data.GetType().GetProperties(publicAttributes))
            {
                if (property.CanRead)
                {
                    dictionary.Add(property.Name.Replace("_", "-"), property.GetValue(data, null));
                }
            }
            return dictionary;
        }
    }
}
