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
    
    #line 1 "..\..\Views\XLHSDangKy\_DonDangKy_NhaChungCu.cshtml"
    using AppCore.Models;
    
    #line default
    #line hidden
    using MPLIS;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/XLHSDangKy/_DonDangKy_NhaChungCu.cshtml")]
    public partial class _Views_XLHSDangKy__DonDangKy_NhaChungCu_cshtml : System.Web.Mvc.WebViewPage<AppCore.Models.DangKyTaiSan>
    {
        public _Views_XLHSDangKy__DonDangKy_NhaChungCu_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\XLHSDangKy\_DonDangKy_NhaChungCu.cshtml"
  using (Html.BeginForm("_DonDangKy_TSNHARIENGLE", "XLHSDangKy", FormMethod.Post, new { @id = "ThemMoiNhaChungCu" }))
    {
        
            
            #line default
            #line hidden
            
            #line 5 "..\..\Views\XLHSDangKy\_DonDangKy_NhaChungCu.cshtml"
   Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 5 "..\..\Views\XLHSDangKy\_DonDangKy_NhaChungCu.cshtml"
                                
        
            
            #line default
            #line hidden
            
            #line 6 "..\..\Views\XLHSDangKy\_DonDangKy_NhaChungCu.cshtml"
   Write(Html.HiddenFor(m => m.CurNhaChungCu.NHACHUNGCUID, new { @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 6 "..\..\Views\XLHSDangKy\_DonDangKy_NhaChungCu.cshtml"
                                                                                           
        
            
            #line default
            #line hidden
            
            #line 7 "..\..\Views\XLHSDangKy\_DonDangKy_NhaChungCu.cshtml"
   Write(Html.HiddenFor(m => m.CurNhaChungCu.uId, new { @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 7 "..\..\Views\XLHSDangKy\_DonDangKy_NhaChungCu.cshtml"
                                                                                  


            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(" id=\"khuchungcuncc\"");

WriteLiteral(" hidden>\r\n            <div>\r\n                <div");

WriteLiteral(" class=\"col-xs-3\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 12 "..\..\Views\XLHSDangKy\_DonDangKy_NhaChungCu.cshtml"
               Write(Html.LabelFor(Model => Model.CurNhaChungCu.KHUCHUNGCUID, "Khu chung cư", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-7\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 15 "..\..\Views\XLHSDangKy\_DonDangKy_NhaChungCu.cshtml"
               Write(Html.DropDownListFor(m => m.CurNhaChungCu.KHUCHUNGCUID, new SelectList(ViewBag.listkhuchungcu, "KHUCHUNGCUID", "TENKHU"), "---- Lựa chọn ----", new { @class = "form-control input-sm", @id = "drpkhuchungcuncc" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" id=\"btnthemkhuchungcuncc\"");

WriteLiteral(" value=\"Thêm mới\"");

WriteLiteral(" />\r\n                </div>\r\n            </div>\r\n        </div>\r\n");

WriteLiteral("        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div>\r\n                <div");

WriteLiteral(" class=\"col-xs-3\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 25 "..\..\Views\XLHSDangKy\_DonDangKy_NhaChungCu.cshtml"
               Write(Html.LabelFor(Model=>Model.CurNhaChungCu.TENCHUNGCU,"Tên chung cư", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-9\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 28 "..\..\Views\XLHSDangKy\_DonDangKy_NhaChungCu.cshtml"
               Write(Html.TextBoxFor(m => m.CurNhaChungCu.TENCHUNGCU, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n");

WriteLiteral("        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div>\r\n                <div");

WriteLiteral(" class=\"col-xs-3\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 35 "..\..\Views\XLHSDangKy\_DonDangKy_NhaChungCu.cshtml"
               Write(Html.LabelFor(Model=>Model.CurNhaChungCu.NAMHOANTHANH,"Năm hoàn thành", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-3\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 38 "..\..\Views\XLHSDangKy\_DonDangKy_NhaChungCu.cshtml"
               Write(Html.TextBoxFor(m => m.CurNhaChungCu.NAMHOANTHANH, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div>\r\n                " +
"<div");

WriteLiteral(" class=\"col-xs-3\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 43 "..\..\Views\XLHSDangKy\_DonDangKy_NhaChungCu.cshtml"
               Write(Html.LabelFor(Model=>Model.CurNhaChungCu.NAMXAYDUNG,"Năm xây dựng", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-3\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 46 "..\..\Views\XLHSDangKy\_DonDangKy_NhaChungCu.cshtml"
               Write(Html.TextBoxFor(m => m.CurNhaChungCu.NAMXAYDUNG, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n");

WriteLiteral("        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div>\r\n                <div");

WriteLiteral(" class=\"col-xs-3\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 53 "..\..\Views\XLHSDangKy\_DonDangKy_NhaChungCu.cshtml"
               Write(Html.LabelFor(Model=>Model.CurNhaChungCu.SOTANG,"Số tầng", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-3\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 56 "..\..\Views\XLHSDangKy\_DonDangKy_NhaChungCu.cshtml"
               Write(Html.TextBoxFor(m => m.CurNhaChungCu.SOTANG, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div>\r\n                " +
"<div");

WriteLiteral(" class=\"col-xs-3\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 61 "..\..\Views\XLHSDangKy\_DonDangKy_NhaChungCu.cshtml"
               Write(Html.LabelFor(Model=>Model.CurNhaChungCu.DIENTICHSAN,"Diện tích sàn", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-3\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 64 "..\..\Views\XLHSDangKy\_DonDangKy_NhaChungCu.cshtml"
               Write(Html.TextBoxFor(m => m.CurNhaChungCu.DIENTICHSAN, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n");

            
            #line 68 "..\..\Views\XLHSDangKy\_DonDangKy_NhaChungCu.cshtml"


            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div>\r\n                <div");

WriteLiteral(" class=\"col-xs-3\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 72 "..\..\Views\XLHSDangKy\_DonDangKy_NhaChungCu.cshtml"
               Write(Html.LabelFor(Model=>Model.CurNhaChungCu.SOTANGHAM,"Số tầng hầm", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-3\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 75 "..\..\Views\XLHSDangKy\_DonDangKy_NhaChungCu.cshtml"
               Write(Html.TextBoxFor(m => m.CurNhaChungCu.SOTANGHAM, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div>\r\n                " +
"<div");

WriteLiteral(" class=\"col-xs-3\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 80 "..\..\Views\XLHSDangKy\_DonDangKy_NhaChungCu.cshtml"
               Write(Html.LabelFor(Model=>Model.CurNhaChungCu.THOIHANSOHUU,"Thời hạn sử dụng", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-3\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 83 "..\..\Views\XLHSDangKy\_DonDangKy_NhaChungCu.cshtml"
               Write(Html.TextBoxFor(m => m.CurNhaChungCu.THOIHANSOHUU, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n\r\n        </div>\r\n");

WriteLiteral("        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div>\r\n                <div");

WriteLiteral(" class=\"col-xs-3\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 91 "..\..\Views\XLHSDangKy\_DonDangKy_NhaChungCu.cshtml"
               Write(Html.LabelFor(Model=>Model.CurNhaChungCu.TONGSOCAN,"Tổng số căn hộ", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-3\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 94 "..\..\Views\XLHSDangKy\_DonDangKy_NhaChungCu.cshtml"
               Write(Html.TextBoxFor(m => m.CurNhaChungCu.TONGSOCAN, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div>\r\n                " +
"<div");

WriteLiteral(" class=\"col-xs-3\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 99 "..\..\Views\XLHSDangKy\_DonDangKy_NhaChungCu.cshtml"
               Write(Html.LabelFor(Model=>Model.CurNhaChungCu.DIENTICHXAYDUNG,"Diện tích xây dựng", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-3\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 102 "..\..\Views\XLHSDangKy\_DonDangKy_NhaChungCu.cshtml"
               Write(Html.TextBoxFor(m => m.CurNhaChungCu.DIENTICHXAYDUNG, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n");

WriteLiteral("        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div>\r\n                <div");

WriteLiteral(" class=\"col-xs-3\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 109 "..\..\Views\XLHSDangKy\_DonDangKy_NhaChungCu.cshtml"
               Write(Html.LabelFor(Model=>Model.CurNhaChungCu.CAPHANG, "Cấp hạng", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-3\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 112 "..\..\Views\XLHSDangKy\_DonDangKy_NhaChungCu.cshtml"
               Write(Html.TextBoxFor(m => m.CurNhaChungCu.CAPHANG, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div>\r\n                " +
"<div");

WriteLiteral(" class=\"col-xs-3\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 117 "..\..\Views\XLHSDangKy\_DonDangKy_NhaChungCu.cshtml"
               Write(Html.LabelFor(Model => Model.tenxats, "Tên xã", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-3\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 120 "..\..\Views\XLHSDangKy\_DonDangKy_NhaChungCu.cshtml"
               Write(Html.TextBoxFor(m => m.tenxats, new { @class = "form-control input-sm", @readonly = "true" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n");

WriteLiteral("        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div>\r\n                <div");

WriteLiteral(" class=\"col-xs-3\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 127 "..\..\Views\XLHSDangKy\_DonDangKy_NhaChungCu.cshtml"
               Write(Html.LabelFor(Model => Model.CurNhaChungCu.DIACHI, "Địa chỉ", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-9\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 130 "..\..\Views\XLHSDangKy\_DonDangKy_NhaChungCu.cshtml"
               Write(Html.TextAreaFor(m => m.CurNhaChungCu.DIACHI, new { @class = "form-control input-sm", @row = "2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n");

WriteLiteral("        <div");

WriteLiteral(" class=\"clear\"");

WriteLiteral("></div>\r\n");

            
            #line 135 "..\..\Views\XLHSDangKy\_DonDangKy_NhaChungCu.cshtml"

            }
            
            
            #line default
            #line hidden
WriteLiteral(@"
            <script>
                $(""#btnthemkhuchungcuncc"").on(""click"", function () {
                    console.log(""click button"");
                    $.ajax({
                        type: ""GET"",
                        url: ""/XLHSDangKy/_DonDangKy_KhuChungCu"",
                        success: function (html) {
                            $('#dialogformKHUCHUNGCU').html(html);
                            var options = {
                                ""backdrop"": ""static"",
                                ""show"": true
                            }
                            $(""#modalformKhuChungCu"").modal(options);
                        }
                    });
                });

            </script>
");

        }
    }
}
#pragma warning restore 1591
