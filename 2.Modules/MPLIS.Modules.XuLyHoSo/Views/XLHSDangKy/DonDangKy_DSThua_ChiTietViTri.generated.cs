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
    
    #line 1 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietViTri.cshtml"
    using AppCore.Models;
    
    #line default
    #line hidden
    using MPLIS;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/XLHSDangKy/DonDangKy_DSThua_ChiTietViTri.cshtml")]
    public partial class _Views_XLHSDangKy_DonDangKy_DSThua_ChiTietViTri_cshtml : System.Web.Mvc.WebViewPage<DC_THUADAT>
    {
        public _Views_XLHSDangKy_DonDangKy_DSThua_ChiTietViTri_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<form");

WriteLiteral(" id=\"Div_ChiTietViTri\"");

WriteLiteral(">\r\n");

WriteLiteral("    ");

            
            #line 4 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietViTri.cshtml"
Write(Html.HiddenFor(m => m.CurViTri.MUCDICHSUDUNGDATID, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 5 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietViTri.cshtml"
Write(Html.HiddenFor(m => m.CurViTri.VITRIID, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 8 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietViTri.cshtml"
       Write(Html.LabelFor(model => model.CurViTri.DUONG, "Đường", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"col-xs-8\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 11 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietViTri.cshtml"
       Write(Html.TextBoxFor(model => model.CurViTri.DUONG, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 16 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietViTri.cshtml"
       Write(Html.LabelFor(model => model.CurViTri.DOANDUONG, "Đoạn đường", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"col-xs-8\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 19 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietViTri.cshtml"
       Write(Html.TextBoxFor(model => model.CurViTri.DOANDUONG, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 24 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietViTri.cshtml"
       Write(Html.LabelFor(model => model.CurViTri.KHUVUC, "Khu Vực", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"col-xs-8\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 27 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietViTri.cshtml"
       Write(Html.TextBoxFor(model => model.CurViTri.KHUVUC, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 32 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietViTri.cshtml"
       Write(Html.LabelFor(model => model.CurViTri.VITRI, "Vị trí", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"col-xs-8\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 35 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietViTri.cshtml"
       Write(Html.TextBoxFor(model => model.CurViTri.VITRI, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 40 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietViTri.cshtml"
       Write(Html.LabelFor(model => model.CurViTri.CHIEUSAU, "Chiều sâu", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"col-xs-8\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 43 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietViTri.cshtml"
       Write(Html.TextBoxFor(model => model.CurViTri.CHIEUSAU, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 48 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietViTri.cshtml"
       Write(Html.LabelFor(model => model.CurViTri.CHIEURONGNGOHEM, "Chiều rộng ngõ", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"col-xs-8\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 51 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietViTri.cshtml"
       Write(Html.TextBoxFor(model => model.CurViTri.CHIEURONGNGOHEM, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n</form>\r\n<div");

WriteLiteral(" class=\"box-footer\"");

WriteLiteral(">\r\n    <input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn-xs btn-heading pull-left\"");

WriteLiteral(" id=\"btncapnhatViTri\"");

WriteLiteral(" value=\"Cập nhật\"");

WriteLiteral(" />\r\n    <input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn-xs btn-heading pull-left\"");

WriteLiteral(" id=\"btnlammoiViTri\"");

WriteLiteral(" value=\"Xóa trắng\"");

WriteLiteral(@" />
</div>
<script>
    $('#btncapnhatViTri').on(""click"", function () {
        var formdata = $(""#Div_ChiTietViTri"").serializeArray();
        $.ajax({
            type: ""POST"",
            url: ""/XLHSDangKy/ThemMoiViTri"",
            data: formdata,
            success: function (data) {
                $('#Div_DSViTri').html(data);
            }
        })
    });
    $('#btnlammoiViTri').on(""click"", function () {
        var mucdichid = $('#CurViTri_MUCDICHSUDUNGDATID').val();
        $.ajax({
            type: ""POST"",
            url: ""/XLHSDangKy/LoadViTri"",
            dataType: ""html"",
            data: { mucdichid: mucdichid.trim() },
            success: function (data) {
                console.log(""SUCCES"");
                $('#ChiTietMDSD').html(data);
            },
        });
    });

</script>
");

        }
    }
}
#pragma warning restore 1591
