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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/XLHSDangKy/_lstNhaRiengLe.cshtml")]
    public partial class _Views_XLHSDangKy__lstNhaRiengLe_cshtml : System.Web.Mvc.WebViewPage<AppCore.Models.DangKyTaiSan>
    {
        public _Views_XLHSDangKy__lstNhaRiengLe_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\XLHSDangKy\_lstNhaRiengLe.cshtml"
Write(Html.HiddenFor(m => m.CurNhaRiengLe.NHARIENGLEID, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 3 "..\..\Views\XLHSDangKy\_lstNhaRiengLe.cshtml"
Write(Html.HiddenFor(m => m.CurNhaRiengLe.uId, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n<table");

WriteLiteral(" id=\"table_nhariengle\"");

WriteLiteral(" class=\"bordered\"");

WriteLiteral(">\r\n    <thead>\r\n        <tr>\r\n            <th");

WriteLiteral(" class=\"t50\"");

WriteLiteral(" hidden=\"true\"");

WriteLiteral(">NHARIENGLEID</th>\r\n            <th");

WriteLiteral(" class=\"t50\"");

WriteLiteral(">STT</th>\r\n            <th");

WriteLiteral(" class=\"t50\"");

WriteLiteral(">Kết cấu</th>\r\n            <th");

WriteLiteral(" class=\"t50\"");

WriteLiteral(">Cấp hạng</th>\r\n            <th");

WriteLiteral(" class=\"t50\"");

WriteLiteral(">Diện tích xây dựng</th>\r\n            <th");

WriteLiteral(" class=\"t50\"");

WriteLiteral(">Diện tích sàn</th>\r\n            <th");

WriteLiteral(" class=\"t50\"");

WriteLiteral(">Số tầng</th>\r\n            <th");

WriteLiteral(" class=\"t200\"");

WriteLiteral(">Địa chỉ</th>\r\n            <th");

WriteLiteral(" class=\"50\"");

WriteLiteral(" hidden=\"true\"");

WriteLiteral(">taisanganlienvoidatid</th>\r\n            <th");

WriteLiteral(" class=\"t50\"");

WriteLiteral(">Hành động</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");

            
            #line 20 "..\..\Views\XLHSDangKy\_lstNhaRiengLe.cshtml"
        
            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\XLHSDangKy\_lstNhaRiengLe.cshtml"
          int rdsgcntable = 0;
            if (Model != null)
            {
                if (Model.lstNhaRiengLe != null)
                {
                    foreach (var item in Model.lstNhaRiengLe)
                    {

                        rdsgcntable = rdsgcntable + 1;

            
            #line default
            #line hidden
WriteLiteral("                        <tr");

WriteLiteral(" data-id=\"");

            
            #line 29 "..\..\Views\XLHSDangKy\_lstNhaRiengLe.cshtml"
                                Write(item.NHARIENGLEID);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">\r\n                            <td");

WriteLiteral(" hidden=\"true\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 31 "..\..\Views\XLHSDangKy\_lstNhaRiengLe.cshtml"
                           Write(item.NHARIENGLEID);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n");

WriteLiteral("                                ");

            
            #line 34 "..\..\Views\XLHSDangKy\_lstNhaRiengLe.cshtml"
                           Write(rdsgcntable);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n");

WriteLiteral("                                ");

            
            #line 37 "..\..\Views\XLHSDangKy\_lstNhaRiengLe.cshtml"
                           Write(item.KETCAU);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n");

WriteLiteral("                                ");

            
            #line 40 "..\..\Views\XLHSDangKy\_lstNhaRiengLe.cshtml"
                           Write(item.CAPHANG);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n");

WriteLiteral("                                ");

            
            #line 43 "..\..\Views\XLHSDangKy\_lstNhaRiengLe.cshtml"
                           Write(item.DIENTICHXAYDUNG);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n");

WriteLiteral("                                ");

            
            #line 46 "..\..\Views\XLHSDangKy\_lstNhaRiengLe.cshtml"
                           Write(item.DIENTICHSAN);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n");

WriteLiteral("                                ");

            
            #line 49 "..\..\Views\XLHSDangKy\_lstNhaRiengLe.cshtml"
                           Write(item.SOTANG);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n");

WriteLiteral("                                ");

            
            #line 52 "..\..\Views\XLHSDangKy\_lstNhaRiengLe.cshtml"
                           Write(item.DIACHI);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                            <td");

WriteLiteral(" hidden=\"true\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 55 "..\..\Views\XLHSDangKy\_lstNhaRiengLe.cshtml"
                           Write(item.uId);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n          " +
"                      <input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" value=\"Chi tiết\"");

WriteLiteral(" onclick=\"chitietnhariengle(this)\"");

WriteLiteral(" />\r\n                                <input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" value=\"Xóa\"");

WriteLiteral(" onclick=\"xoanhariengle(this)\"");

WriteLiteral(" />\r\n                            </td>\r\n\r\n                        </tr>\r\n");

            
            #line 63 "..\..\Views\XLHSDangKy\_lstNhaRiengLe.cshtml"

                    }
                }
            }
        
            
            #line default
            #line hidden
WriteLiteral("\r\n    </tbody>\r\n</table>\r\n<script>\r\n    //xóa nhà riêng lẻ\r\n    function xoanh" +
"ariengle(oButton) {\r\n\r\n        var empTab = document.getElementById(\'table_nhari" +
"engle\');\r\n        var index = oButton.parentNode.parentNode.rowIndex;\r\n        /" +
"/ alert(index);\r\n        var nhariengleid = empTab.rows[index].cells[0].innerHTM" +
"L;\r\n        var dondk = $(\'#DONDANGKYID\').val();\r\n        empTab.deleteRow(oButt" +
"on.parentNode.parentNode.rowIndex);\r\n        $.ajax({\r\n            type: \"POST\"," +
"\r\n            url: \"/XLHSDangKy/XOA_NHARIENGLE\",\r\n            dataType: \"json\",\r" +
"\n            contentType: \"application/json\",\r\n            data: JSON.stringify(" +
"{ nhaid: nhariengleid, dondangky_id: dondk }),\r\n            success: function (d" +
"ata) {\r\n                if (data === \"true\") {\r\n                    alert(\"Xóa " +
"nhà gắn đăng ký thành công!\");\r\n                }\r\n                else {\r\n " +
"                   alert(\"Có lỗi xảy ra!\");\r\n                }\r\n            }" +
",\r\n        });\r\n    }\r\n    //chi tiết nhà riêng lẻ\r\n    function chitietnhari" +
"engle(oButton) {\r\n\r\n        var empTab = document.getElementById(\'table_nharieng" +
"le\');\r\n        var index = oButton.parentNode.parentNode.rowIndex;\r\n        // a" +
"lert(index);\r\n        var nhariengleid = empTab.rows[index].cells[0].innerHTML;\r" +
"\n        var ketcau = empTab.rows[index].cells[1].innerHTML;\r\n        var caphan" +
"g = empTab.rows[index].cells[2].innerHTML;\r\n        var dientichxd = empTab.rows" +
"[index].cells[3].innerHTML;\r\n        var dientichsan = empTab.rows[index].cells[" +
"4].innerHTML;\r\n        var sotang = empTab.rows[index].cells[5].innerHTML;\r\n    " +
"    var sotangham = empTab.rows[index].cells[6].innerHTML;\r\n        var diachi =" +
" empTab.rows[index].cells[7].innerHTML;\r\n        var id = empTab.rows[index].cel" +
"ls[8].innerHTML;\r\n      //  var dondk = $(\'#DONDANGKYID\').val();\r\n        //aler" +
"t(nhariengleid);\r\n        $(\'#CurNhaRiengLe_NHARIENGLEID\').val(nhariengleid.trim" +
"());\r\n        $(\'#CurNhaRiengLe_KETCAU\').val(ketcau.trim());\r\n        $(\'#CurNha" +
"RiengLe_CAPHANG\').val(caphang.trim());\r\n        $(\'#CurNhaRiengLe_DIENTICHXAYDUN" +
"G\').val(dientichxd.trim());\r\n        $(\'#CurNhaRiengLe_DIENTICHSAN\').val(dientic" +
"hsan.trim());\r\n        $(\'#CurNhaRiengLe_SOTANG\').val(sotang.trim());\r\n        $" +
"(\'#CurNhaRiengLe_SOTANGHAM\').val(sotangham.trim());\r\n        $(\'#CurNhaRiengLe_D" +
"IACHI\').val(diachi.trim());\r\n        $(\'#CurNhaRiengLe_uId\').val(id.trim());\r\n  " +
"      \r\n    }\r\n</script>");

        }
    }
}
#pragma warning restore 1591