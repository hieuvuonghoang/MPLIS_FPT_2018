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
    
    #line 1 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietGiaDat.cshtml"
    using AppCore.Models;
    
    #line default
    #line hidden
    using MPLIS;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/XLHSDangKy/DonDangKy_DSThua_ChiTietGiaDat.cshtml")]
    public partial class _Views_XLHSDangKy_DonDangKy_DSThua_ChiTietGiaDat_cshtml : System.Web.Mvc.WebViewPage<DC_THUADAT>
    {
        public _Views_XLHSDangKy_DonDangKy_DSThua_ChiTietGiaDat_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("    <form");

WriteLiteral(" id=\"ChiTietGiaDat\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 4 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietGiaDat.cshtml"
   Write(Html.HiddenFor(m => m.CurGiaDat.THUADATID, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 5 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietGiaDat.cshtml"
   Write(Html.HiddenFor(m => m.CurGiaDat.GIATHUADATID, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 8 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietGiaDat.cshtml"
           Write(Html.LabelFor(model => model.CurGiaDat.LOAIGIADATID, "Loại giá đất", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-8\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 11 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietGiaDat.cshtml"
           Write(Html.DropDownListFor(model => model.CurGiaDat.LOAIGIADATID, new SelectList(ViewBag.loaigiadat, "LOAIGIADATID", "LOAIGIADAT"), new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 16 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietGiaDat.cshtml"
           Write(Html.LabelFor(model => model.CurGiaDat.CANCUPHAPLY, "Căn cứ pháp lý", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-8\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 19 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietGiaDat.cshtml"
           Write(Html.TextBoxFor(model => model.CurGiaDat.CANCUPHAPLY, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 24 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietGiaDat.cshtml"
           Write(Html.LabelFor(model => model.CurGiaDat.THOIDIEMXACDINH, "Thời điểm", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-8\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 27 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietGiaDat.cshtml"
           Write(Html.TextBoxFor(model => model.CurGiaDat.THOIDIEMXACDINH, "{0:yyyy-MM-dd}", new { @type = "date", @class = "form-control input-sm date" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 32 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietGiaDat.cshtml"
           Write(Html.LabelFor(model => model.CurGiaDat.GIADAT, "Giá đất", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-8\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 35 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietGiaDat.cshtml"
           Write(Html.TextBoxFor(model => model.CurGiaDat.GIADAT, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 40 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietGiaDat.cshtml"
           Write(Html.LabelFor(model => model.CurGiaDat.TENFILE, "Tên tệp tin", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-8\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 43 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietGiaDat.cshtml"
           Write(Html.TextBoxFor(model => model.CurGiaDat.TENFILE, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </form>\r\n\r\n<script>\r\n\r\n</script>");

        }
    }
}
#pragma warning restore 1591
