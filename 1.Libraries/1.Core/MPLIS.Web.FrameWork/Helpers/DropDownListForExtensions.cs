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
    public static class DropDownListForExtensions
    {
        public static MvcHtmlString DropDownListForExtS1<TModel, TProperty>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression,
            IEnumerable<SelectListItem> selectList,
            string emptySelect,
            object htmlDivContainerAttr,
            object htmlDivTextBoxContainerAttr,
            object labelAttributes,
            object controlAttributes,
            Boolean hasValidationMessageFor,
            bool isbuildMultiselect,
            bool? isView = null)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);

            var labelBuilder = helper.LabelFor(expression, labelAttributes);
            var divTextBoxContainerBuilder = new TagBuilder("div");
            var jsBuilder = "";
            divTextBoxContainerBuilder.MergeAttributes(htmlDivTextBoxContainerAttr.ToDictionary(), false);
            if (isView == true)
            {
                var title = "";
                var content = "";
                if (selectList != null)
                {
                    var selected = selectList.Where(it => it.Selected).ToList();
                    if (selected.Count == 0)
                    {
                        title = "Không có giá trị";
                    }
                    else if (selected.Count == 1)
                    {
                        title = selected.First().Text;
                    }
                    else
                    {
                        title = string.Format("{0} {1}", selected.Count.ToString(), metadata.DisplayName ?? metadata.PropertyName);
                        for (var i = 0; i < selected.Count; i++)
                        {
                            content += selected[i].Text;
                            if (i != selected.Count - 1)
                            {
                                content += "<br/>";
                            }
                        }
                    }
                }
                else
                {
                    title = "Không có giá trị";
                }
                var tagControl = buildPopoverView("popover_" + metadata.PropertyName, title, content);
                divTextBoxContainerBuilder.InnerHtml = tagControl;
            }
            else
            {
                var ddlBuilder = helper.DropDownListFor(expression, selectList);

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(ddlBuilder.ToHtmlString());
                XmlNode root = doc.DocumentElement;
                XmlNode idDropDownList = doc.SelectNodes("//select/@id")[0];
                XmlNode nameDropDownList = doc.SelectNodes("//select/@name")[0];
                var tagDropDownListBuilder = buildControlEdit(idDropDownList.Value, nameDropDownList.Value, selectList, emptySelect, controlAttributes);
                var validationMessageBuilder = new MvcHtmlString("");
                if (hasValidationMessageFor)
                    validationMessageBuilder = helper.ValidationMessageFor(expression);

                divTextBoxContainerBuilder.InnerHtml = tagDropDownListBuilder.ToString() + validationMessageBuilder.ToHtmlString();
                if (isbuildMultiselect)
                {
                    jsBuilder = "<script type='text/javascript'>";
                    jsBuilder += "$(document).ready(function () {";
                    jsBuilder += "buildMultiselect('#" + idDropDownList.Value + "', true, 200, 1, false, 0);";
                    jsBuilder += "});";
                    jsBuilder += "</script>";
                }
            }

            var divContainerBuilder = new TagBuilder("div");
            divContainerBuilder.MergeAttributes(htmlDivContainerAttr.ToDictionary(), false);

            divContainerBuilder.InnerHtml = labelBuilder.ToHtmlString() + divTextBoxContainerBuilder.ToString() + jsBuilder;
            return MvcHtmlString.Create(divContainerBuilder.ToString());
        }
        public static MvcHtmlString DropDownListForExtS1<TModel, TProperty>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression,
            IEnumerable<SelectListItem> selectList,
            string emptySelect,
            object controlAttributes,
            Boolean hasValidationMessageFor,
            bool isbuildMultiselect,
            string onchangeFunction = null,
            bool? isView = null)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            if (isView == true)
            {
                var title = "";
                var content = "";
                if (selectList != null)
                {
                    var selected = selectList.Where(it => it.Selected).ToList();
                    if (selected.Count == 0)
                    {
                        title = "Không có giá trị";
                    }
                    else if (selected.Count == 1)
                    {
                        title = selected.First().Text;
                    }
                    else
                    {
                        title = string.Format("{0} {1}", selected.Count.ToString(), "");
                        for (var i = 0; i < selected.Count; i++)
                        {
                            content += selected[i].Text;
                            if (i != selected.Count - 1)
                            {
                                content += "<br/>";
                            }
                        }
                    }
                }
                else
                {
                    title = "Không có giá trị";
                }
                var tagControl = buildPopoverView("popover_" + metadata.PropertyName, title, content);
                return MvcHtmlString.Create(tagControl);
            }
            else
            {

                var ddlBuilderHtml = "";
                ddlBuilderHtml += "<select id='" + metadata.PropertyName + "' name='" + metadata.PropertyName + "'>";

                foreach (var sl in selectList)
                {
                    ddlBuilderHtml += "<option value='" + sl.Value + "'>" + sl.Text + "</option>";
                }
                ddlBuilderHtml += "</select>";

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(ddlBuilderHtml);
                XmlNode root = doc.DocumentElement;
                XmlNode idDropDownList = doc.SelectNodes("//select/@id")[0];
                XmlNode nameDropDownList = doc.SelectNodes("//select/@name")[0];
                var tagDropDownListBuilder = buildControlEdit(idDropDownList.Value, nameDropDownList.Value, selectList, emptySelect, controlAttributes);
                var validationMessageBuilder = new MvcHtmlString("");
                if (hasValidationMessageFor)
                    validationMessageBuilder = helper.ValidationMessageFor(expression);
                var jsBuilder = "";
                //tagDropDownListBuilder.ToString() + validationMessageBuilder.ToHtmlString();
                jsBuilder = "<script type='text/javascript'>";
                jsBuilder += "$(document).ready(function () {";
                if (isbuildMultiselect)
                {
                    jsBuilder += "buildMultiselect('#" + idDropDownList.Value + "', true, 200, 1, false, 0);";
                }
                if (!string.IsNullOrEmpty(onchangeFunction))
                {
                    var idExt = idDropDownList.Value.Replace(metadata.PropertyName, "");
                    jsBuilder += "$('#" + idDropDownList.Value + "').change(function () { " + onchangeFunction + "(this,'" + idExt + "')});";
                }
                jsBuilder += "});";
                jsBuilder += "</script>";
                return MvcHtmlString.Create(tagDropDownListBuilder.ToString() + validationMessageBuilder.ToString() + jsBuilder);
            }
        }
        private static TagBuilder buildControlEdit(string controlId, string controlName, IEnumerable<SelectListItem> selectList, string emptySelect, object controlAttributes)
        {
            //var selectValue = (selectList as System.Web.Mvc.SelectList).SelectedValue;
            var tagDropDownListBuilder = new TagBuilder("select");
            tagDropDownListBuilder.MergeAttributes(controlAttributes.ToDictionary(), true);
            tagDropDownListBuilder.MergeAttribute("id", controlId, true);
            tagDropDownListBuilder.MergeAttribute("name", controlName, true);

            if (!string.IsNullOrEmpty(emptySelect))
            {
                var optionTag = new TagBuilder("option");
                optionTag.MergeAttribute("value", string.Empty, true);
                optionTag.InnerHtml = emptySelect;
                tagDropDownListBuilder.InnerHtml += optionTag;
            }
            if (selectList != null)
            {
                foreach (var obj in selectList)
                {
                    var optionTag = new TagBuilder("option");
                    optionTag.MergeAttribute("id", obj.Value, true);
                    optionTag.MergeAttribute("value", obj.Value, true);
                    if (obj.Selected)
                    {
                        optionTag.MergeAttribute("selected", "selected", true);
                    }
                    optionTag.InnerHtml = obj.Text;
                    tagDropDownListBuilder.InnerHtml += optionTag;
                }
            }
            return tagDropDownListBuilder;
        }
        private static string buildPopoverView(string id, string title, string content)
        {
            var tagControlBuilder = new TagBuilder("a");
            tagControlBuilder.MergeAttribute("href", "#", true);
            tagControlBuilder.MergeAttribute("id", id, true);
            tagControlBuilder.MergeAttribute("class", "btn btn-default btn-sm", true);

            var jsBuilder = "";
            if (!string.IsNullOrEmpty(content))
            {
                tagControlBuilder.MergeAttribute("title", title, true);
                tagControlBuilder.MergeAttribute("rel-toggle", "popover", true);
                jsBuilder = "<script type='text/javascript'>";
                jsBuilder += "$(document).ready(function () {";
                jsBuilder += "var options = { content: '" + content + "', html: true, placement: 'auto' };";
                jsBuilder += "$('#" + id + "').popover(options);";
                jsBuilder += "});";
                jsBuilder += "</script>";
            }
            tagControlBuilder.InnerHtml = title;
            return tagControlBuilder.ToString() + jsBuilder;
        }

    }
}
