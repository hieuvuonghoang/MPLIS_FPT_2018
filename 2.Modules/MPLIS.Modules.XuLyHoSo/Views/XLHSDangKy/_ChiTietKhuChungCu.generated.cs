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
    
    #line 1 "..\..\Views\XLHSDangKy\_ChiTietKhuChungCu.cshtml"
    using AppCore.Models;
    
    #line default
    #line hidden
    using MPLIS;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/XLHSDangKy/_ChiTietKhuChungCu.cshtml")]
    public partial class _Views_XLHSDangKy__ChiTietKhuChungCu_cshtml : System.Web.Mvc.WebViewPage<AppCore.Models.DangKyTaiSan>
    {
        public _Views_XLHSDangKy__ChiTietKhuChungCu_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\XLHSDangKy\_ChiTietKhuChungCu.cshtml"
  using (Html.BeginForm("_DonDangKy_TSNHARIENGLE", "XLHSDangKy", FormMethod.Post, new { @id = "ThemMoiKhuChungCu" }))
    {
        
            
            #line default
            #line hidden
            
            #line 5 "..\..\Views\XLHSDangKy\_ChiTietKhuChungCu.cshtml"
   Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 5 "..\..\Views\XLHSDangKy\_ChiTietKhuChungCu.cshtml"
                                
        
            
            #line default
            #line hidden
            
            #line 6 "..\..\Views\XLHSDangKy\_ChiTietKhuChungCu.cshtml"
   Write(Html.HiddenFor(m => m.CurKhuChungCu.KHUCHUNGCUID, new { @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 6 "..\..\Views\XLHSDangKy\_ChiTietKhuChungCu.cshtml"
                                                                                           
        
            
            #line default
            #line hidden
            
            #line 7 "..\..\Views\XLHSDangKy\_ChiTietKhuChungCu.cshtml"
   Write(Html.HiddenFor(m => m.CurKhuChungCu.uId, new { @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 7 "..\..\Views\XLHSDangKy\_ChiTietKhuChungCu.cshtml"
                                                                                  


            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div>\r\n                <div");

WriteLiteral(" class=\"col-xs-3\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 12 "..\..\Views\XLHSDangKy\_ChiTietKhuChungCu.cshtml"
               Write(Html.LabelFor(Model => Model.tenxats, "Phường/Xã", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-7\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 15 "..\..\Views\XLHSDangKy\_ChiTietKhuChungCu.cshtml"
               Write(Html.TextBoxFor(Model=>Model.tenxats, new { @class = "form-control input-sm", @readonly = "true" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n");

WriteLiteral("        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div>\r\n                <div");

WriteLiteral(" class=\"col-xs-3\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 22 "..\..\Views\XLHSDangKy\_ChiTietKhuChungCu.cshtml"
               Write(Html.LabelFor(Model => Model.CurKhuChungCu.TENKHU, "Tên khu chung cư", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-7\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 25 "..\..\Views\XLHSDangKy\_ChiTietKhuChungCu.cshtml"
               Write(Html.TextBoxFor(m => m.CurKhuChungCu.TENKHU, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n");

WriteLiteral("        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div>\r\n                <div");

WriteLiteral(" class=\"col-xs-3\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 32 "..\..\Views\XLHSDangKy\_ChiTietKhuChungCu.cshtml"
               Write(Html.LabelFor(Model => Model.CurKhuChungCu.DIENTICHKHU, "Diện tích", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-7\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 35 "..\..\Views\XLHSDangKy\_ChiTietKhuChungCu.cshtml"
               Write(Html.TextBoxFor(m => m.CurKhuChungCu.DIENTICHKHU, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n");

WriteLiteral("        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div>\r\n                <div");

WriteLiteral(" class=\"col-xs-3\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 42 "..\..\Views\XLHSDangKy\_ChiTietKhuChungCu.cshtml"
               Write(Html.LabelFor(Model => Model.CurKhuChungCu.DIACHI, "Địa chỉ", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-7\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 45 "..\..\Views\XLHSDangKy\_ChiTietKhuChungCu.cshtml"
               Write(Html.TextAreaFor(m => m.CurKhuChungCu.DIACHI, new { @class = "form-control input-sm", @row = "2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n");

WriteLiteral("        <div");

WriteLiteral(" class=\"clear\"");

WriteLiteral("></div>\r\n");

            
            #line 50 "..\..\Views\XLHSDangKy\_ChiTietKhuChungCu.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n    <button");

WriteLiteral(" type=\'submit\'");

WriteLiteral(" class=\'t100 btn btn-primary btn-sm pull-right\'");

WriteLiteral(" id=\"btnthemmoikcc\"");

WriteLiteral(@">Lưu</button>
</div>

<script>
    $(function () {
        $('#btnthemmoikcc').on(""click"", function () {
            var dondk = $('#DONDANGKYID').val();
            var formdata = $(""#ThemMoiKhuChungCu"").serializeArray();
            formdata.push({
                name: ""DONDANGKYID"",
                value: dondk
            });
            $.ajax({
                type: ""POST"",
                url: ""/XLHSDangKy/ThemMoiKhuChungCu"",
                data: formdata,
                dataType: ""json"",
                success: function (data) {
                    alert(""Bạn đã thêm mới thành công!"");
                }
            });
        });
    });
</script>

");

        }
    }
}
#pragma warning restore 1591
