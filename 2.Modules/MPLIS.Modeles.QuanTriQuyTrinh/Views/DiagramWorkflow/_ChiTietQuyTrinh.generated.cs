﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using MPLIS.Modeles.QuanTriQuyTrinh;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/DiagramWorkflow/_ChiTietQuyTrinh.cshtml")]
    public partial class _Views_DiagramWorkflow__ChiTietQuyTrinh_cshtml : System.Web.Mvc.WebViewPage<AppCore.Models.QT_TTHC_QUYTRINH>
    {
        public _Views_DiagramWorkflow__ChiTietQuyTrinh_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" class=\"box box-primary\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"box-header with-border\"");

WriteLiteral(">\r\n        <h3");

WriteLiteral(" class=\"box-title\"");

WriteLiteral(">Thông tin chi tiết</h3>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"box-body\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 8 "..\..\Views\DiagramWorkflow\_ChiTietQuyTrinh.cshtml"
   Write(Html.HiddenFor(model => model.TTHCQUYTRINHID));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <div");

WriteLiteral(" id=\"QTnavtabID\"");

WriteLiteral(">\r\n            <ul");

WriteLiteral(" class=\"nav nav-tabs nav-justified\"");

WriteLiteral(">\r\n                <li");

WriteLiteral(" id=\"quyTrinh-li1\"");

WriteLiteral(" class=\"active\"");

WriteLiteral(">\r\n                    <a");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(" href=\"#quyTrinh-tabID\"");

WriteLiteral(">Thông tin quy trình</a>\r\n                </li>\r\n                <li");

WriteLiteral(" id=\"quyTrinh-li2\"");

WriteLiteral(">\r\n                    <a");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(" href=\"#quyTrinh-tabID\"");

WriteLiteral(">Sơ đồ quy trình</a>\r\n                </li>\r\n                <li");

WriteLiteral(" id=\"quyTrinh-li3\"");

WriteLiteral(">\r\n                    <a");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(" href=\"#quyTrinh-tabID\"");

WriteLiteral(">Cấu hình xử lý</a>\r\n                </li>\r\n            </ul>\r\n            <div");

WriteLiteral(" id=\"quyTrinh-tabs-cont\"");

WriteLiteral(" class=\"tab-content\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" id=\"quyTrinh-tabID\"");

WriteLiteral(" class=\"tab-pane fade in active\"");

WriteLiteral(">\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>" +
"\r\n\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
    $(document).ready(function () {
        $('#quyTrinh-li1').on('click', function () {
            $.ajax({
                type: ""POST"",
                url: ""/DiagramWorkflow/_QuyTrinh_TTQuyTrinh"",
                data: { tTHCQuyTrinhID: $('#TTHCQUYTRINHID').val() },
                dataType: ""html"",
                success: function (html) {
                    $('#quyTrinh-tabID').html(html);
                }
            })
        })
        $('#quyTrinh-li2').on('click', function () {

        })
        $('#quyTrinh-li3').on('click', function () {

        })
    })
</script>
");

        }
    }
}
#pragma warning restore 1591