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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/TTBienDong/_BienDong_DSCHUVAO.cshtml")]
    public partial class _Views_TTBienDong__BienDong_DSCHUVAO_cshtml : System.Web.Mvc.WebViewPage<MPLIS.Libraries.Data.XuLyHoSo.Models.DSChuBDVM>
    {
        public _Views_TTBienDong__BienDong_DSCHUVAO_cshtml()
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

WriteLiteral(">Danh sách chủ đầu vào</h3>\r\n        <button");

WriteLiteral(" class=\"btn-xs btn-heading pull-right\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" onclick=\"\"");

WriteLiteral(">Lưu thông tin</button>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"box-body\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(" style=\"margin-bottom: 10px\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(" style=\"padding-left: 0\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 11 "..\..\Views\TTBienDong\_BienDong_DSCHUVAO.cshtml"
           Write(Html.Label("lablelistchovaitro_ttrieng", "Vai trò", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-3\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 14 "..\..\Views\TTBienDong\_BienDong_DSCHUVAO.cshtml"
           Write(Html.DropDownList("listchovaitro_ttrieng", ViewBag.DS_dsVaiTro_list as SelectList, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n                <button");

WriteLiteral(" class=\"btn-sm btn-inform pull-left\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" onclick=\"ThemChuVao()\"");

WriteLiteral(">Thêm mới</button>\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" id=\"divBienDongID_DSCHUVAO_Table\"");

WriteLiteral(">\r\n");

            
            #line 21 "..\..\Views\TTBienDong\_BienDong_DSCHUVAO.cshtml"
            
            
            #line default
            #line hidden
            
            #line 21 "..\..\Views\TTBienDong\_BienDong_DSCHUVAO.cshtml"
              Html.RenderPartial("_BienDong_DSCHUVAO_Table", Model);
            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
    function ThemChuVao() {
        $.ajax({
            type: ""GET"",
            url: ""/TTBienDong/_Popup_DSCHU"",
            success: function (html) {
                $('#dialogformDSCHUVAOID').html(html);
                var options = {
                    ""backdrop"": ""static"",
                    ""show"": true
                }
                $(""#modalformDSCHU"").modal(options);
            },
        });
    }
</script>
");

        }
    }
}
#pragma warning restore 1591