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
    
    #line 1 "..\..\Views\XLHSDangKy\_DonDangKy_DSThua_TTChiTietThua_TTChung.cshtml"
    using AppCore.Models;
    
    #line default
    #line hidden
    using MPLIS;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/XLHSDangKy/_DonDangKy_DSThua_TTChiTietThua_TTChung.cshtml")]
    public partial class _Views_XLHSDangKy__DonDangKy_DSThua_TTChiTietThua_TTChung_cshtml : System.Web.Mvc.WebViewPage<DC_THUADAT>
    {
        public _Views_XLHSDangKy__DonDangKy_DSThua_TTChiTietThua_TTChung_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<form");

WriteLiteral(" id=\"ThemMoiThuaDat\"");

WriteLiteral(">\r\n    <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id=\"THUADATID\"");

WriteLiteral(" name=\"THUADATID\"");

WriteAttribute("value", Tuple.Create(" value=\"", 128), Tuple.Create("\"", 152)
            
            #line 5 "..\..\Views\XLHSDangKy\_DonDangKy_DSThua_TTChiTietThua_TTChung.cshtml"
, Tuple.Create(Tuple.Create("", 136), Tuple.Create<System.Object, System.Int32>(Model.THUADATID
            
            #line default
            #line hidden
, 136), false)
);

WriteLiteral(" />\r\n    <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id=\"THUAGOCID\"");

WriteLiteral(" name=\"THUAGOCID\"");

WriteAttribute("value", Tuple.Create(" value=\"", 214), Tuple.Create("\"", 238)
            
            #line 6 "..\..\Views\XLHSDangKy\_DonDangKy_DSThua_TTChiTietThua_TTChung.cshtml"
, Tuple.Create(Tuple.Create("", 222), Tuple.Create<System.Object, System.Int32>(Model.THUAGOCID
            
            #line default
            #line hidden
, 222), false)
);

WriteLiteral(" />\r\n");

WriteLiteral("    ");

            
            #line 7 "..\..\Views\XLHSDangKy\_DonDangKy_DSThua_TTChiTietThua_TTChung.cshtml"
Write(Html.HiddenFor(model => model._KIEMTRA, new { @id = "KiemTra" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 8 "..\..\Views\XLHSDangKy\_DonDangKy_DSThua_TTChiTietThua_TTChung.cshtml"
Write(Html.HiddenFor(model => model._TRONGDANGKY, new { @id = "TrongDangKy" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 11 "..\..\Views\XLHSDangKy\_DonDangKy_DSThua_TTChiTietThua_TTChung.cshtml"
       Write(Html.LabelFor(model => model.XAID, "Chọn xã", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 14 "..\..\Views\XLHSDangKy\_DonDangKy_DSThua_TTChiTietThua_TTChung.cshtml"
       Write(Html.DropDownListFor(model => model.XAID, new SelectList(ViewBag.listxa, "KVHCID", "TENKVHC"), new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 17 "..\..\Views\XLHSDangKy\_DonDangKy_DSThua_TTChiTietThua_TTChung.cshtml"
       Write(Html.LabelFor(model => model.SOHIEUTOBANDO, "Số hiệu tờ bản đồ", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 20 "..\..\Views\XLHSDangKy\_DonDangKy_DSThua_TTChiTietThua_TTChung.cshtml"
       Write(Html.TextBoxFor(model => model.SOHIEUTOBANDO, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 25 "..\..\Views\XLHSDangKy\_DonDangKy_DSThua_TTChiTietThua_TTChung.cshtml"
       Write(Html.LabelFor(model => model.SOTHUTUTHUA, "Số thứ tự thửa", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-xs-10\"");

WriteLiteral(" style=\"padding: 0;\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 29 "..\..\Views\XLHSDangKy\_DonDangKy_DSThua_TTChiTietThua_TTChung.cshtml"
           Write(Html.TextBoxFor(model => model.SOTHUTUTHUA, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(" style=\"padding: 0;\"");

WriteLiteral(">\r\n                <button");

WriteLiteral(" class=\"btn-sm btn-inform pull-right\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(">...</button>\r\n            </div>\r\n        </div>\r\n");

WriteLiteral("        ");

            
            #line 35 "..\..\Views\XLHSDangKy\_DonDangKy_DSThua_TTChiTietThua_TTChung.cshtml"
   Write(Html.HiddenFor(model => model.TAILIEUDODACID));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 37 "..\..\Views\XLHSDangKy\_DonDangKy_DSThua_TTChiTietThua_TTChung.cshtml"
       Write(Html.LabelFor(model => model.TENTAILIEUDD, "Tài liệu đo đạc", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-xs-10\"");

WriteLiteral(" style=\"padding: 0;\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 41 "..\..\Views\XLHSDangKy\_DonDangKy_DSThua_TTChiTietThua_TTChung.cshtml"
           Write(Html.TextBoxFor(model => model.TENTAILIEUDD, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(" style=\"padding: 0;\"");

WriteLiteral(">\r\n                <button");

WriteLiteral(" class=\"btn-sm btn-inform pull-right\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" onclick=\"TaiLieuDoDac()\"");

WriteLiteral(">...</button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 50 "..\..\Views\XLHSDangKy\_DonDangKy_DSThua_TTChiTietThua_TTChung.cshtml"
       Write(Html.LabelFor(model => model.DIENTICH, "Diện tích", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 53 "..\..\Views\XLHSDangKy\_DonDangKy_DSThua_TTChiTietThua_TTChung.cshtml"
       Write(Html.TextBoxFor(model => model.DIENTICH, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 56 "..\..\Views\XLHSDangKy\_DonDangKy_DSThua_TTChiTietThua_TTChung.cshtml"
       Write(Html.LabelFor(model => model.DIENTICHPHAPLY, "Diện tích pháp lý", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 59 "..\..\Views\XLHSDangKy\_DonDangKy_DSThua_TTChiTietThua_TTChung.cshtml"
       Write(Html.TextBoxFor(model => model.DIENTICHPHAPLY, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 64 "..\..\Views\XLHSDangKy\_DonDangKy_DSThua_TTChiTietThua_TTChung.cshtml"
       Write(Html.LabelFor(model => model.DUONG, "Đường", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 67 "..\..\Views\XLHSDangKy\_DonDangKy_DSThua_TTChiTietThua_TTChung.cshtml"
       Write(Html.DropDownListFor(model => model.DUONG, new SelectList(ViewBag.listduong, "TENDUONGID", "TENDUONG"), new { @class = "form-control input-sm" ,@id="drptenduong"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 70 "..\..\Views\XLHSDangKy\_DonDangKy_DSThua_TTChiTietThua_TTChung.cshtml"
       Write(Html.LabelFor(model => model.DOANDUONGID, "Đoạn đường", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 73 "..\..\Views\XLHSDangKy\_DonDangKy_DSThua_TTChiTietThua_TTChung.cshtml"
       Write(Html.DropDownListFor(model => model.DOANDUONGID, new SelectList(ViewBag.listdoanduong, "DOANDUONGID", "TENDOANDUONG"), new { @class = "form-control input-sm", @disabled = "true",@id="drpdoanduong" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 78 "..\..\Views\XLHSDangKy\_DonDangKy_DSThua_TTChiTietThua_TTChung.cshtml"
       Write(Html.LabelFor(model => model.KHUVUCID, "Khu vực", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 81 "..\..\Views\XLHSDangKy\_DonDangKy_DSThua_TTChiTietThua_TTChung.cshtml"
       Write(Html.DropDownListFor(model => model.KHUVUCID, new SelectList(ViewBag.listkhuvuc, "KHUVUCID", "TENKHUVUC"), new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 87 "..\..\Views\XLHSDangKy\_DonDangKy_DSThua_TTChiTietThua_TTChung.cshtml"
       Write(Html.LabelFor(model => model.DIACHITHUADAT, "Địa chỉ thửa đất", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"col-xs-10\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 90 "..\..\Views\XLHSDangKy\_DonDangKy_DSThua_TTChiTietThua_TTChung.cshtml"
       Write(Html.TextAreaFor(model => model.DIACHITHUADAT, new { @class = "form-control", @rows = "3" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 95 "..\..\Views\XLHSDangKy\_DonDangKy_DSThua_TTChiTietThua_TTChung.cshtml"
       Write(Html.LabelFor(model => model.LOAITHUADAT, "Loại thửa đất", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 98 "..\..\Views\XLHSDangKy\_DonDangKy_DSThua_TTChiTietThua_TTChung.cshtml"
       Write(Html.DropDownListFor(model => model.LOAITHUADAT, new SelectList(ViewBag.listloaithua, "idloaithuadat", "tenloaithuadat"), new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 101 "..\..\Views\XLHSDangKy\_DonDangKy_DSThua_TTChiTietThua_TTChung.cshtml"
       Write(Html.LabelFor(model => model._DANGTRANHCHAP, "Hạn chế", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"col-xs-1 \"");

WriteLiteral(" style=\"padding-top: 7px;\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 104 "..\..\Views\XLHSDangKy\_DonDangKy_DSThua_TTChiTietThua_TTChung.cshtml"
       Write(Html.CheckBoxFor(model => model._DANGTRANHCHAP,new { @disabled="true"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 107 "..\..\Views\XLHSDangKy\_DonDangKy_DSThua_TTChiTietThua_TTChung.cshtml"
       Write(Html.LabelFor(model => model._LADOITUONGCHIEMDAT, "Là đối tượng chiếm đất", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"col-xs-1 \"");

WriteLiteral(" style=\"padding-top: 7px;\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 110 "..\..\Views\XLHSDangKy\_DonDangKy_DSThua_TTChiTietThua_TTChung.cshtml"
       Write(Html.CheckBoxFor(model => model._LADOITUONGCHIEMDAT));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n</form>\r\n\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n    function TaiLieuDoDac() {\r\n        var taiLieuDoDacID = $(\'#TAILIEUDODACID" +
"\').val();\r\n        var thuaDatID = $(\'#hi_ThuaID\').val();\r\n        $.ajax({\r\n   " +
"         type: \"POST\",\r\n            url: \"/XLHSDangKy/_Popup_TaiLieuDoDac\",\r\n   " +
"         data: { thuaDatID: thuaDatID.trim(), taiLieuDoDacID: taiLieuDoDacID.tri" +
"m() },\r\n            success: function (html) {\r\n                $(\'#dialogformTa" +
"iLieuDoDacID\').html(html);\r\n                var options = {\r\n                   " +
" \"backdrop\": \"static\",\r\n                    \"show\": true\r\n                }\r\n   " +
"             $(\"#modalformTaiLieuDoDacID\").modal(options);\r\n            }\r\n     " +
"   });\r\n    }\r\n    $(document).ready(function () {\r\n        $(\'#SOTHUTUTHUA\').fo" +
"cusout(function () {\r\n            console.log($(\'#SOTHUTUTHUA\').val());\r\n       " +
"     console.log($(\'#KiemTra\').val());\r\n            if ($(\'#KiemTra\').val() != 1" +
") {\r\n                $.ajax({\r\n                    type: \"POST\",\r\n              " +
"      url: \"/XLHSDangKy/TimKiem_THUADAT\",\r\n                    data: { SttThua: " +
"$(\'#SOTHUTUTHUA\').val(), SoToBanDo: $(\'#SOHIEUTOBANDO\').val(), KhuVucHanhChinh: " +
"$(\'#XAID\').val() },\r\n                    success: function (data) {\r\n           " +
"             $(\'#TabTTChiTietID\').html(data);\r\n                        document." +
"getElementById(\'hi_ThuaID\').value = $(\'#THUADATID\').val();\r\n                    " +
"    if ($(\'#TrongDangKy\').val() == 1) {\r\n                            alert(\"Thửa" +
" đã có trong đăng ký\");\r\n                        }\r\n                    }\r\n     " +
"           });\r\n            }\r\n        });\r\n        $(\"#drptenduong\").change(fun" +
"ction () {\r\n            var formdata = $(\'#ThemMoiThuaDat\').serializeArray();\r\n " +
"           if ($(\'#drptenduong\').val() != \"\") {\r\n                $.ajax({\r\n     " +
"               type: \"POST\",\r\n                    url: \"/XLHSDangKy/ChonDoanDuon" +
"g\",\r\n                    data: formdata,\r\n                    success: function " +
"(html) {\r\n                        $(\'#TabTTChiTietID\').html(html);\r\n            " +
"            $(\'#drpdoanduong\').prop(\"disabled\", false);\r\n                    }\r\n" +
"                });\r\n            }\r\n        });\r\n\r\n    });\r\n</script>\r\n");

        }
    }
}
#pragma warning restore 1591
