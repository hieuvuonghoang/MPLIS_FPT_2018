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
    using MPLIS;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/XLHSDangKyV2/_DangKy.cshtml")]
    public partial class _Views_XLHSDangKyV2__DangKy_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_XLHSDangKyV2__DangKy_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" id=\"divDonDangKyID\"");

WriteLiteral(" class=\"m-15\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"row panel\"");

WriteLiteral(" style=\"margin-bottom: 5px;\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"btn btn-default btn-block tab-doc\"");

WriteLiteral(" style=\"text-align:left;\"");

WriteLiteral(">\r\n            <a");

WriteLiteral(" style=\"color: blue;font-weight: bold;\"");

WriteLiteral(" data-toggle=\"collapse\"");

WriteLiteral(" data-parent=\"#divDonDangKyID\"");

WriteLiteral(" href=\"#collapse_DonDangKy_DSGCN\"");

WriteLiteral(">\r\n                Danh sách GCN trong đăng ký\r\n            </a>\r\n        </div>\r" +
"\n        <div");

WriteLiteral(" id=\"collapse_DonDangKy_DSGCN\"");

WriteLiteral(" class=\"panel-collapse collapse in\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" id=\"divDSDangKyGCNID\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\'overlay\'");

WriteLiteral("> <i");

WriteLiteral(" class=\'fa fa-refresh fa-spin\'");

WriteLiteral("></i> </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"row panel\"");

WriteLiteral(" style=\"margin-bottom: 5px;\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"btn btn-default btn-block tab-doc\"");

WriteLiteral(" style=\"text-align:left;\"");

WriteLiteral(">\r\n            <a");

WriteLiteral(" style=\"color: blue;font-weight: bold;\"");

WriteLiteral(" data-toggle=\"collapse\"");

WriteLiteral(" data-parent=\"#divDonDangKyID\"");

WriteLiteral(" href=\"#collapse_DonDangKy_DSCHU\"");

WriteLiteral(">\r\n                Danh sách Chủ trong đăng ký\r\n            </a>\r\n        </div>\r" +
"\n        <div");

WriteLiteral(" id=\"collapse_DonDangKy_DSCHU\"");

WriteLiteral(" class=\"panel-collapse collapse\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" id=\"divDSDangKyChuID\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\'overlay\'");

WriteLiteral("> <i");

WriteLiteral(" class=\'fa fa-refresh fa-spin\'");

WriteLiteral("></i> </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    ");

WriteLiteral("\r\n</div>\r\n\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
    $(document).ready(function () {

        trigger_tab_doc();

        $.ajax({
            type: ""POST"",
            url: ""/XLHSDangKyV2/_DonDangKy_DSGiayChungNhan"",
            dataType: ""html"",
            success: function (html) {
                $('#divDSDangKyGCNID').html(html);
            },
            complete: function () {
                $('.overlay', $('#divDSDangKyGCNID')).remove();
            }
        })

        $.ajax({
            type: ""POST"",
            url: ""/XLHSDangKyV2/_DonDangKy_DSChu"",
            dataType: ""html"",
            success: function (html) {
                $('#divDSDangKyChuID').html(html);
            },
            complete: function () {
                $('.overlay', $('#divDSDangKyChuID')).remove();
            }
        })
    });
</script>

");

        }
    }
}
#pragma warning restore 1591