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
    using MPLIS.Modules.LuanChuyenHoSo;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/XuLyHoSo/_XLHS_HoSoTiepNhan_TTTraHoSo.cshtml")]
    public partial class _Views_XuLyHoSo__XLHS_HoSoTiepNhan_TTTraHoSo_cshtml : System.Web.Mvc.WebViewPage<AppCore.Models.QT_HOSOTIEPNHAN>
    {
        public _Views_XuLyHoSo__XLHS_HoSoTiepNhan_TTTraHoSo_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" class=\"box box-primary\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"box-body\"");

WriteLiteral(">\r\n        <form");

WriteLiteral(" id=\"formTTTraHoSoID\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 6 "..\..\Views\XuLyHoSo\_XLHS_HoSoTiepNhan_TTTraHoSo.cshtml"
       Write(Html.HiddenFor(model => model.HOSOTIEPNHANID));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 9 "..\..\Views\XuLyHoSo\_XLHS_HoSoTiepNhan_TTTraHoSo.cshtml"
               Write(Html.LabelFor(model => model.TENNGUOINHANKETQUA, "Tên người nhận", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 12 "..\..\Views\XuLyHoSo\_XLHS_HoSoTiepNhan_TTTraHoSo.cshtml"
               Write(Html.TextBoxFor(model => model.TENNGUOINHANKETQUA, "", new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 15 "..\..\Views\XuLyHoSo\_XLHS_HoSoTiepNhan_TTTraHoSo.cshtml"
               Write(Html.LabelFor(model => model.VAITRONGUOINHANKETQUA, "Vai trò người nhận", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 18 "..\..\Views\XuLyHoSo\_XLHS_HoSoTiepNhan_TTTraHoSo.cshtml"
               Write(Html.TextBoxFor(model => model.VAITRONGUOINHANKETQUA, "", new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n                    ");

WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n                    ");

WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 29 "..\..\Views\XuLyHoSo\_XLHS_HoSoTiepNhan_TTTraHoSo.cshtml"
               Write(Html.LabelFor(model => model.NGAYTRAKETQUA, "Ngày trả", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 32 "..\..\Views\XuLyHoSo\_XLHS_HoSoTiepNhan_TTTraHoSo.cshtml"
               Write(Html.TextBoxFor(model => model.NGAYTRAKETQUA, "{0:yyyy-MM-dd}", new { @type = "date", @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 37 "..\..\Views\XuLyHoSo\_XLHS_HoSoTiepNhan_TTTraHoSo.cshtml"
               Write(Html.LabelFor(model => model.GHICHUTRAKETQUA, "Ghi chú", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 40 "..\..\Views\XuLyHoSo\_XLHS_HoSoTiepNhan_TTTraHoSo.cshtml"
               Write(Html.TextAreaFor(model => model.GHICHUTRAKETQUA, new { @class = "form-control", @rows = "3" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 45 "..\..\Views\XuLyHoSo\_XLHS_HoSoTiepNhan_TTTraHoSo.cshtml"
               Write(Html.LabelFor(model => model.DIACHINGUOINHANKETQUA, "Địa chỉ", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 48 "..\..\Views\XuLyHoSo\_XLHS_HoSoTiepNhan_TTTraHoSo.cshtml"
               Write(Html.TextAreaFor(model => model.DIACHINGUOINHANKETQUA, new { @class = "form-control", @rows = "3" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </form>\r\n    </div>\r\n</div>" +
"");

        }
    }
}
#pragma warning restore 1591