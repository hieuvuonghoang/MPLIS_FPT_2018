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
    
    #line 1 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietMDSD.cshtml"
    using AppCore.Models;
    
    #line default
    #line hidden
    using MPLIS;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/XLHSDangKy/DonDangKy_DSThua_ChiTietMDSD.cshtml")]
    public partial class _Views_XLHSDangKy_DonDangKy_DSThua_ChiTietMDSD_cshtml : System.Web.Mvc.WebViewPage<DC_THUADAT>
    {
        public _Views_XLHSDangKy_DonDangKy_DSThua_ChiTietMDSD_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<body>\r\n    <style");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(@">
        .multiselect-container > li > a > label.checkbox {
            width: 299px;
        }

        .btn-group > .btn:first-child {
            width: 299px;
        }
        .dropdown-menu > li > a {
            color: #333;
        }
        .btn-group > span {
            width: 299px;
        }
    </style>
    <form");

WriteLiteral(" id=\"div_ChiTietMDSD\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 21 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietMDSD.cshtml"
   Write(Html.HiddenFor(m => m.CurMDSDDAT.MUCDICHSUDUNGDATID, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 22 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietMDSD.cshtml"
   Write(Html.HiddenFor(m => m.CurMDSDDAT.THUADATID, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 25 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietMDSD.cshtml"
           Write(Html.LabelFor(model => model.CurMDSDDAT.MUCDICHSUDUNGID, "Mục đích sử dụng", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-8\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 28 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietMDSD.cshtml"
           Write(Html.DropDownListFor(model => model.CurMDSDDAT.MUCDICHSUDUNGID, new SelectList(ViewBag.mdsddat, "MUCDICHSUDUNGID", "TENMUCDICHSUDUNG"), new { @class = "form-control input-sm", @id = "drpMDSD" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 33 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietMDSD.cshtml"
           Write(Html.LabelFor(model => model.CurMDSDDAT.MUCDICHSUDUNGQHID, "Mục đích sử dụng quy hoạch", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-8\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 36 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietMDSD.cshtml"
           Write(Html.DropDownListFor(model => model.CurMDSDDAT.MUCDICHSUDUNGQHID, new SelectList(ViewBag.mdsdquyhoach, "MUCDICHSUDUNGQHID", "TENMUCDICHSUDUNGQH"), new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 41 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietMDSD.cshtml"
           Write(Html.LabelFor(model => model.CurMDSDDAT.HINHTHUCSUDUNGID, "Hình thức sử dụng", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-8\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 44 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietMDSD.cshtml"
           Write(Html.DropDownListFor(model => model.CurMDSDDAT.HINHTHUCSUDUNGID, new SelectList(ViewBag.mdsdhinhthuc, "HINHTHUCSUDUNGID", "TENHINHTHUCSUDUNG"), new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div> \r\n        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 49 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietMDSD.cshtml"
           Write(Html.LabelFor(model => model.CurMDSDDAT.DIENTICH, "Diện tích", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-8\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 52 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietMDSD.cshtml"
           Write(Html.TextBoxFor(model => model.CurMDSDDAT.DIENTICH, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 57 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietMDSD.cshtml"
           Write(Html.LabelFor(model => model.CurMDSDDAT.DIENTICHPHAINOPTIEN, "Diện tích phải nộp tiền SD đất", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-8\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 60 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietMDSD.cshtml"
           Write(Html.TextBoxFor(model => model.CurMDSDDAT.DIENTICHPHAINOPTIEN, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 65 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietMDSD.cshtml"
           Write(Html.LabelFor(model => model.CurMDSDDAT.DIENTICHKHONGPHAINOPTIEN, "Diện tích không phải nộp tiền SD đất", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-8\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 68 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietMDSD.cshtml"
           Write(Html.TextBoxFor(model => model.CurMDSDDAT.DIENTICHKHONGPHAINOPTIEN, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 73 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietMDSD.cshtml"
           Write(Html.LabelFor(model => model.CurMDSDDAT.LOAITHOIHANSUDUNG, "Loại thời hạn sử dụng", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-8\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 76 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietMDSD.cshtml"
           Write(Html.DropDownListFor(model => model.CurMDSDDAT.LOAITHOIHANSUDUNG, new SelectList(new List<Object>{
                       new { LOAITHOIHANSUDUNG = "0" , text = "Lâu dài"  },
                       new { LOAITHOIHANSUDUNG = "1" , text = "Có thời hạn" },
                       new { LOAITHOIHANSUDUNG = "2" , text = "Gia hạn"}
                    },
                  "LOAITHOIHANSUDUNG",
                  "text"), new { @class = "form-control input-sm", @id = "drpLoaiThoiHan" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 87 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietMDSD.cshtml"
           Write(Html.LabelFor(model => model.CurMDSDDAT.TUNGAY, "Từ ngày", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-8\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 90 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietMDSD.cshtml"
           Write(Html.TextBoxFor(model => model.CurMDSDDAT.TUNGAY, "{0:yyyy-MM-dd}", new { @type = "date", @class = "form-control input-sm ", @disabled = "true", @id = "MDSDTuNgay" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 95 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietMDSD.cshtml"
           Write(Html.LabelFor(model => model.CurMDSDDAT.DENNGAY, "Đến ngày", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-8\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 98 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietMDSD.cshtml"
           Write(Html.TextBoxFor(model => model.CurMDSDDAT.DENNGAY, "{0:yyyy-MM-dd}", new { @type = "date", @class = "form-control input-sm ", @disabled = "true", @id = "MDSDDenNgay" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 103 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietMDSD.cshtml"
           Write(Html.LabelFor(model => model.CurMDSDDAT.NguonID, "Nguồn gốc sử dụng", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-8\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 106 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietMDSD.cshtml"
           Write(Html.ListBoxFor(model => model.CurMDSDDAT.NguonID, new SelectList(ViewBag.mdsdnguongoc, "LOAINGUONGOCSUDUNGID", "TENNGUONGOCSUDUNG"), new { @class = "select2 form-control input-sm" ,@id="ListBoxNGSD"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 111 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietMDSD.cshtml"
           Write(Html.LabelFor(model=>model.CurMDSDDAT.NGUONGOCSDTH,"Danh sách nguồn gốc", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-8\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 114 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietMDSD.cshtml"
           Write(Html.TextAreaFor(model=>model.CurMDSDDAT.NGUONGOCSDTH, new { @class = "form-control input-sm " ,@rows="4", @disabled ="true"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 119 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietMDSD.cshtml"
           Write(Html.LabelFor(model => model.CurMDSDDAT._LAMUCDICHCHINH, "Là mục đích chính", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(" style=\"padding-top: 7px;\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 122 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietMDSD.cshtml"
           Write(Html.CheckBoxFor(model => model.CurMDSDDAT._LAMUCDICHCHINH));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 125 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietMDSD.cshtml"
           Write(Html.LabelFor(model => model.CurMDSDDAT._SUDUNGCHUNG, "Sử dụng chung", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(" style=\"padding-top: 7px;\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 128 "..\..\Views\XLHSDangKy\DonDangKy_DSThua_ChiTietMDSD.cshtml"
           Write(Html.CheckBoxFor(model => model.CurMDSDDAT._SUDUNGCHUNG));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </form>\r\n    <div");

WriteLiteral(" class=\"box-footer\"");

WriteLiteral(">\r\n        <input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn-xs btn-heading pull-left\"");

WriteLiteral(" id=\"btncapnhatMDSD\"");

WriteLiteral(" value=\"Cập nhật\"");

WriteLiteral(" />\r\n        <input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn-xs btn-heading pull-left\"");

WriteLiteral(" id=\"btnlammoiMDSD\"");

WriteLiteral(" value=\"Xóa trắng\"");

WriteLiteral(" />\r\n    </div>\r\n</body>\r\n<script>\r\n\r\n    $(document).ready(function () {\r\n      " +
"  $(\'.select2\').multiselect({\r\n            includeSelectAllOption: true,\r\n      " +
"      search:true,\r\n            maxHeight: 400  \r\n        });\r\n        $(\'#btnla" +
"mmoiMDSD\').on(\"click\", function () {\r\n            $.ajax({\r\n                type" +
": \"GET\",\r\n                url: \"/XLHSDangKy/ChiTietMDSD\",\r\n                datat" +
"ype: \"html\",\r\n                success: function (response) {\r\n                  " +
"  $(\'#ChiTietMDSD\').html(response);\r\n                }\r\n            })\r\n        " +
"});\r\n        $(\'#btncapnhatMDSD\').on(\"click\", function () {\r\n            var for" +
"mdata = $(\"#div_ChiTietMDSD\").serializeArray();\r\n            var drpMDSD = docum" +
"ent.getElementById(\'drpMDSD\');\r\n            var r = drpMDSD.options[drpMDSD.sele" +
"ctedIndex].innerHTML;\r\n            formdata.push({\r\n                name: \"TenMD" +
"SD\",\r\n                value: r.trim()\r\n            });\r\n            $.ajax({\r\n  " +
"              type: \"POST\",\r\n                url: \"/XLHSDangKy/ThemMoiMDSD\",\r\n  " +
"              data: formdata,\r\n                success: function (data) {\r\n     " +
"               $(\'#div_MDSD_Thua\').html(data);\r\n                }\r\n            }" +
")\r\n        });\r\n        $(\'#drpLoaiThoiHan\').on(\"click\", function () {\r\n        " +
"    if ($(this).val() != 0) {\r\n                console.log($(\'#TUNGAY\').val());\r" +
"\n                $(\'#MDSDTuNgay\').prop(\"disabled\", false);\r\n                $(\'#" +
"MDSDDenNgay\').prop(\"disabled\", false);\r\n            }\r\n            else {\r\n     " +
"           $(\'#MDSDTuNgay\').prop(\"disabled\", true);\r\n                $(\'#MDSDDen" +
"Ngay\').prop(\"disabled\", true);\r\n            }\r\n        });\r\n        $(\'#ListBoxN" +
"GSD\').change( function () {\r\n            var formdata = $(\"#div_ChiTietMDSD\").se" +
"rializeArray();\r\n            console.log(formdata);\r\n            $.ajax({\r\n     " +
"           type: \"POST\",\r\n                url: \"/XLHSDangKy/ChiTietDSNguon\",\r\n\r\n" +
"                data: formdata,\r\n                success: function (data) {\r\n   " +
"                 console.log(\'CLICKBOX\');\r\n                    $(\'#CurMDSDDAT_NG" +
"UONGOCSDTH\').html(data);\r\n                }\r\n            })\r\n        });\r\n    })" +
";\r\n    </script>\r\n");

        }
    }
}
#pragma warning restore 1591
