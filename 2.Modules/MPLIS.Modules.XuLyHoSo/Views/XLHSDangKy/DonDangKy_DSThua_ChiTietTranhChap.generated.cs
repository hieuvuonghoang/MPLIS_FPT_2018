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
    
    #line 1 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietTranhChap.cshtml"
    using AppCore.Models;
    
    #line default
    #line hidden
    using MPLIS;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/XLHSDangKy/DonDangKy_DSThua_ChiTietTranhChap.cshtml")]
    public partial class _Views_XLHSDangKy_DonDangKy_DSThua_ChiTietTranhChap_cshtml : System.Web.Mvc.WebViewPage<DC_THUADAT>
    {
        public _Views_XLHSDangKy_DonDangKy_DSThua_ChiTietTranhChap_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("    <form");

WriteLiteral(" id=\"divHanCheThua\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 4 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietTranhChap.cshtml"
   Write(Html.HiddenFor(m => m.CurHanChe.THUADATID, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 5 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietTranhChap.cshtml"
   Write(Html.HiddenFor(m => m.CurHanChe.HANCHEID, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n   ");

WriteLiteral("   \r\n        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 9 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietTranhChap.cshtml"
           Write(Html.LabelFor(Model=>Model.CurHanChe.LOAIHANCHEID,"Loại hạn chế", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-8\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 12 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietTranhChap.cshtml"
           Write(Html.DropDownListFor(Model=>Model.CurHanChe.LOAIHANCHEID, new SelectList(ViewBag.mdsdhanche, "LOAIHANCHEID", "TENLOAIHANCHE"), new { @class = "form-control input-sm"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 17 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietTranhChap.cshtml"
           Write(Html.LabelFor(Model => Model.CurHanChe.NOIDUNGHANCHE, "Nội dung hạn chế", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-8\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 20 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietTranhChap.cshtml"
           Write(Html.TextBoxFor(Model => Model.CurHanChe.NOIDUNGHANCHE, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 25 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietTranhChap.cshtml"
           Write(Html.LabelFor(Model => Model.CurHanChe.COQUANBANHANH, "Cơ quan ban hành", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-8\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 28 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietTranhChap.cshtml"
           Write(Html.TextBoxFor(Model => Model.CurHanChe.COQUANBANHANH, new {  @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 33 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietTranhChap.cshtml"
           Write(Html.LabelFor(Model => Model.CurHanChe.NGAYBANHANH, "Ngày ban hành", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-8\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 36 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietTranhChap.cshtml"
           Write(Html.TextBoxFor(Model => Model.CurHanChe.NGAYBANHANH, "{0:yyyy-MM-dd}", new { @type = "date", @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 41 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietTranhChap.cshtml"
           Write(Html.LabelFor(Model => Model.CurHanChe.SOVANBAN, "Số văn bản", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-8\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 44 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietTranhChap.cshtml"
           Write(Html.TextBoxFor(Model => Model.CurHanChe.SOVANBAN, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 49 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietTranhChap.cshtml"
           Write(Html.LabelFor(Model=>Model.CurHanChe.DIENTICH,"Diện tích", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div> \r\n            <div");

WriteLiteral(" class=\"col-xs-8\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 52 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietTranhChap.cshtml"
           Write(Html.TextBoxFor(Model=>Model.CurHanChe.DIENTICH, new { @class = "form-control input-sm"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 57 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietTranhChap.cshtml"
           Write(Html.LabelFor(Model => Model.CurHanChe.SODORANHGIOIHANCHE, "Ranh giới hạn chế", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-8\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 60 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietTranhChap.cshtml"
           Write(Html.TextBoxFor(Model => Model.CurHanChe.SODORANHGIOIHANCHE, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 65 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietTranhChap.cshtml"
           Write(Html.LabelFor(Model => Model.CurHanChe.NGAYHETHIEULUC, "Ngày hết hiệu lực", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-8\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 68 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietTranhChap.cshtml"
           Write(Html.TextBoxFor(Model => Model.CurHanChe.NGAYHETHIEULUC, "{0:yyyy-MM-dd}", new { @type = "date", @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 73 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietTranhChap.cshtml"
           Write(Html.LabelFor(Model => Model.CurHanChe._HanCheMotPhan, "Hạn chế một phần", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(" style=\"padding-top: 7px;\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 76 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietTranhChap.cshtml"
           Write(Html.CheckBoxFor(Model => Model.CurHanChe._HanCheMotPhan));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 79 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietTranhChap.cshtml"
           Write(Html.LabelFor(Model => Model.CurHanChe._ConHieuLuc, "Còn hiệu lực", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(" style=\"padding-top: 7px;\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 82 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietTranhChap.cshtml"
           Write(Html.CheckBoxFor(Model => Model.CurHanChe._ConHieuLuc));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n    </form>\r\n<script>\r\n\r\n</script>");

        }
    }
}
#pragma warning restore 1591
