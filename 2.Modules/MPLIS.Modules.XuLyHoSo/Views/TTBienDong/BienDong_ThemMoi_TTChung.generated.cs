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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/TTBienDong/BienDong_ThemMoi_TTChung.cshtml")]
    public partial class _Views_TTBienDong_BienDong_ThemMoi_TTChung_cshtml : System.Web.Mvc.WebViewPage<MPLIS.Libraries.Data.XuLyHoSo.Models.TTChungBienDongVM>
    {
        public _Views_TTBienDong_BienDong_ThemMoi_TTChung_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" id=\"divBienDongID\"");

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

WriteLiteral(" data-parent=\"#divBienDongID\"");

WriteLiteral(" href=\"#collapse_BienDong_BD\"");

WriteLiteral(">\r\n                Thông tin chung biến động\r\n            </a>\r\n            <butt" +
"on");

WriteLiteral(" class=\"btn-xs btn-heading pull-right\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" onclick=\"ThemMoiBienDong()\"");

WriteLiteral(">Thêm mới</button>\r\n        </div>\r\n        <div");

WriteLiteral(" id=\"collapse_BienDong_BD\"");

WriteLiteral(" class=\"panel-collapse collapse in\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" id=\"divBienDongID_BD\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 13 "..\..\Views\TTBienDong\BienDong_ThemMoi_TTChung.cshtml"
           Write(Html.Partial("_BienDong_BD"));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
    function ThemMoiBienDong() {
        $.ajax({
            type: ""POST"",
            url: ""/TTBienDong/BienDong_ThemMoi_Save"",
            data: $('#IDformBienDong_BD').serialize(),
            dateType: ""json"",
            success: function (result) {
                if (result.success) {
                    $('#bhs-tabID').load('/TTBienDong/_BienDong');
                }
                alert(result.mes);
            }
        })
    }
</script>
");

        }
    }
}
#pragma warning restore 1591
