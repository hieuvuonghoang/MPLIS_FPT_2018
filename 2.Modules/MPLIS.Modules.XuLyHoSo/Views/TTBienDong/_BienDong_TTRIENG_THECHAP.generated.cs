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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/TTBienDong/_BienDong_TTRIENG_THECHAP.cshtml")]
    public partial class _Views_TTBienDong__BienDong_TTRIENG_THECHAP_cshtml : System.Web.Mvc.WebViewPage<MPLIS.Libraries.Data.XuLyHoSo.Models.TheChapVM>
    {
        public _Views_TTBienDong__BienDong_TTRIENG_THECHAP_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<form");

WriteLiteral(" id=\"IDformBienDong_TTRIENG_THECHAP\"");

WriteLiteral(">\r\n");

WriteLiteral("    ");

            
            #line 4 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP.cshtml"
Write(Html.HiddenFor(model => model.BIENDONGID));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 5 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP.cshtml"
Write(Html.HiddenFor(model => model.BDTHECHAPID));

            
            #line default
            #line hidden
WriteLiteral("\r\n    <div");

WriteLiteral(" class=\"box box-primary\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"box-header with-border\"");

WriteLiteral(">\r\n            <h3");

WriteLiteral(" class=\"box-title\"");

WriteLiteral(">Thông tin thế chấp</h3>\r\n            <button");

WriteLiteral(" class=\"btn-xs btn-heading pull-right\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" onclick=\"Luu_BienDong_TTRIENG_THECHAP()\"");

WriteLiteral(">Lưu thông tin</button>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"box-body\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 14 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP.cshtml"
               Write(Html.LabelFor(model => Model.NGAYNHANHS, "Ngày nhận hồ sơ", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 17 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP.cshtml"
               Write(Html.TextBoxFor(model => Model.NGAYNHANHS, "{0:yyyy-MM-dd}", new { @type = "date", @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 20 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP.cshtml"
               Write(Html.LabelFor(model => Model.NGAYTHECHAP, "Ngày thế chấp", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 23 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP.cshtml"
               Write(Html.TextBoxFor(model => Model.NGAYTHECHAP, "{0:yyyy-MM-dd}", new { @type = "date", @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 28 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP.cshtml"
               Write(Html.LabelFor(model => Model.QUYENSO, "Quyển số", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 31 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP.cshtml"
               Write(Html.TextBoxFor(model => Model.QUYENSO, "", new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 34 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP.cshtml"
               Write(Html.LabelFor(model => Model.SOTHUTU, "Số thứ tự", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 37 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP.cshtml"
               Write(Html.TextBoxFor(model => Model.SOTHUTU, "", new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 42 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP.cshtml"
               Write(Html.LabelFor(model => Model.SODANGKY, "Số đăng ký", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 45 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP.cshtml"
               Write(Html.TextBoxFor(model => Model.SODANGKY, "", new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 50 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP.cshtml"
               Write(Html.LabelFor(model => Model.NGAYBATDAU, "Ngày bắt đầu", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 53 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP.cshtml"
               Write(Html.TextBoxFor(model => Model.NGAYBATDAU, "{0:yyyy-MM-dd}", new { @type = "date", @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 56 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP.cshtml"
               Write(Html.LabelFor(model => Model.NGAYKETTHUC, "Ngày kết thúc", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 59 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP.cshtml"
               Write(Html.TextBoxFor(model => Model.NGAYKETTHUC, "{0:yyyy-MM-dd}", new { @type = "date", @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</form>" +
"\r\n\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
    var formBienDong_BD = $('#IDformBienDong_TTRIENG_THECHAP');
    function Luu_BienDong_TTRIENG_THECHAP() {
        $.ajax({
            type: ""POST"",
            url: ""/TTBienDong/Save_IDformBienDong_TTRIENG_THECHAP"",
            data: formBienDong_BD.serialize(),
            success: function () {
                alert(""Lưu biến động thông tin thế chấp thành công!"");
            },
        });
    }
</script>
");

        }
    }
}
#pragma warning restore 1591
