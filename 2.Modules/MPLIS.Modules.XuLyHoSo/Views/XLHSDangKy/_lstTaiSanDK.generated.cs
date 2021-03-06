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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/XLHSDangKy/_lstTaiSanDK.cshtml")]
    public partial class _Views_XLHSDangKy__lstTaiSanDK_cshtml : System.Web.Mvc.WebViewPage<MPLIS.Libraries.Data.XuLyHoSo.Models.VM_XuLyHoSo_DK>
    {
        public _Views_XLHSDangKy__lstTaiSanDK_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\XLHSDangKy\_lstTaiSanDK.cshtml"
Write(Html.HiddenFor(model => model.JSONTSThua));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 3 "..\..\Views\XLHSDangKy\_lstTaiSanDK.cshtml"
Write(Html.HiddenFor(model => model.JSONCanHoHM));

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"box box-primary\"");

WriteLiteral(" style=\"margin:0px;\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"box-header with-border\"");

WriteLiteral(">\r\n        <h3");

WriteLiteral(" class=\"box-title\"");

WriteLiteral(">Tài sản đăng ký</h3>\r\n    </div>\r\n    <div");

WriteLiteral(" id=\"divDSTAISAN_TABLEID\"");

WriteLiteral(" class=\"box-body\"");

WriteLiteral(">\r\n        <table");

WriteLiteral(" id=\"table_DSTAISAN\"");

WriteLiteral(" class=\"table table-bordered\"");

WriteLiteral(">\r\n            <thead>\r\n                <tr>\r\n                    <th");

WriteLiteral(" class=\"t100\"");

WriteLiteral(" hidden>TAISAN _ID</th>\r\n                    <th");

WriteLiteral(" class=\"t50\"");

WriteLiteral(">STT</th>\r\n                    <th");

WriteLiteral(" class=\"t100\"");

WriteLiteral(">Loại tài sản</th>\r\n                    <th");

WriteLiteral(" class=\"t100\"");

WriteLiteral(">Diện tích</th>\r\n                    <th");

WriteLiteral(" class=\"t100\"");

WriteLiteral(">Mô tả</th>\r\n                    <th hidden>IDGOC</th>\r\n                    <th");

WriteLiteral(" class=\"t100\"");

WriteLiteral(">Hành động</th>\r\n                    <th");

WriteLiteral(" class=\"t50\"");

WriteLiteral(" hidden>LOAITAISAN</th>\r\n                </tr>\r\n            </thead>\r\n           " +
" <tbody>\r\n");

            
            #line 23 "..\..\Views\XLHSDangKy\_lstTaiSanDK.cshtml"
                
            
            #line default
            #line hidden
            
            #line 23 "..\..\Views\XLHSDangKy\_lstTaiSanDK.cshtml"
                  int rdststable = 0;
                    if (Model != null)
                    {
                        if (Model.TAISAN_DANGKY != null)
                        {
                            foreach (var item in Model.TAISAN_DANGKY)
                            {
                                if (item.TaiSanGanLienVoiDat.LOAITAISAN != "3" && item.TaiSanGanLienVoiDat.LOAITAISAN != "5" && item.TaiSanGanLienVoiDat.LOAITAISAN != "2" && item.trangthaitaisan != 3)
                                {
                                    rdststable = rdststable + 1;

            
            #line default
            #line hidden
WriteLiteral("                                    <tr");

WriteLiteral(" data-id=\"");

            
            #line 33 "..\..\Views\XLHSDangKy\_lstTaiSanDK.cshtml"
                                            Write(item.TAISANID);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">\r\n                                        <td");

WriteLiteral(" align=\"center\"");

WriteLiteral(" hidden>\r\n");

WriteLiteral("                                            ");

            
            #line 35 "..\..\Views\XLHSDangKy\_lstTaiSanDK.cshtml"
                                       Write(item.TAISANID);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                        </td>\r\n                                " +
"        <td");

WriteLiteral(" align=\"center\"");

WriteLiteral(">\r\n");

WriteLiteral("                                            ");

            
            #line 38 "..\..\Views\XLHSDangKy\_lstTaiSanDK.cshtml"
                                       Write(rdststable);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                        </td>\r\n                                " +
"        <td");

WriteLiteral(" align=\"center\"");

WriteLiteral(">\r\n");

WriteLiteral("                                            ");

            
            #line 41 "..\..\Views\XLHSDangKy\_lstTaiSanDK.cshtml"
                                       Write(item.LoaiTaiSan);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                        </td>\r\n                                " +
"        <td");

WriteLiteral(" align=\"center\"");

WriteLiteral(">\r\n");

WriteLiteral("                                            ");

            
            #line 44 "..\..\Views\XLHSDangKy\_lstTaiSanDK.cshtml"
                                       Write(item.DienTich);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                        </td>\r\n                                " +
"        <td");

WriteLiteral(" align=\"center\"");

WriteLiteral(">\r\n");

WriteLiteral("                                            ");

            
            #line 47 "..\..\Views\XLHSDangKy\_lstTaiSanDK.cshtml"
                                       Write(item.MOTATOMTAT);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                        </td>\r\n                                " +
"        <td");

WriteLiteral(" align=\"center\"");

WriteLiteral(" hidden>\r\n");

WriteLiteral("                                            ");

            
            #line 50 "..\..\Views\XLHSDangKy\_lstTaiSanDK.cshtml"
                                       Write(item.TaiSanGanLienVoiDat.TAISANID);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                        </td>\r\n                                " +
"        <td");

WriteLiteral(" align=\"center\"");

WriteLiteral(">\r\n                                            <input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-xs btn-heading\"");

WriteLiteral(" id=\"btnxoataisan\"");

WriteLiteral(" value=\"Xóa\"");

WriteLiteral(" onclick=\"removeRow(this)\"");

WriteLiteral(" />\r\n                                        </td>\r\n                             " +
"           <td");

WriteLiteral(" align=\"center\"");

WriteLiteral(" hidden>\r\n");

WriteLiteral("                                            ");

            
            #line 56 "..\..\Views\XLHSDangKy\_lstTaiSanDK.cshtml"
                                        Write(item.TaiSanGanLienVoiDat != null ? item.TaiSanGanLienVoiDat.LOAITAISAN : "");

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n                                        </td>\r\n                              " +
"      </tr>\r\n");

            
            #line 60 "..\..\Views\XLHSDangKy\_lstTaiSanDK.cshtml"
                                }
                            }
                        }
                    }
                
            
            #line default
            #line hidden
WriteLiteral("\r\n            </tbody>           \r\n        </table>\r\n    </div>\r\n</div>\r\n<script>" +
"\r\n    $(document).ready(function () {\r\n     table_TS=  InitDataTableXLHS($(\'#tab" +
"le_DSTAISAN\'));\r\n     $(\"#table_DSTAISAN tbody\").on(\"click\",\"tr\", function (e) {" +
"\r\n            $(\'#thuataisan\').show();\r\n            $(\'#thuataisancanho\').hide()" +
";\r\n            document.getElementById(\'headerthuataisan\').innerHTML = \"Nằm trên" +
" thửa\";\r\n            $(this).addClass(\'activerow\').siblings().removeClass(\'activ" +
"erow\');\r\n            var taisanid = $(this)[0].cells[0].innerHTML;\r\n            " +
"var LoaitaisanID = $(this)[0].cells[7].innerHTML;\r\n            var taisanchitiet" +
"id = $(this)[0].cells[5].innerHTML;\r\n            document.getElementById(\"CurTSI" +
"D\").value = taisanid;\r\n            document.getElementById(\"CurCHID\").value = ta" +
"isanchitietid;\r\n            var dondk = $(\'#DONDANGKYID\').val();\r\n            if" +
" (LoaitaisanID.trim() == \"1\") {\r\n                $(\'#iddstaisan\').val(\"0\");\r\n   " +
"             $(\'#drpchontaisan\').val(1);\r\n                $.ajax({\r\n            " +
"        type: \"POST\",\r\n                    url: \"/XLHSDangKy/ChiTietNhaRiengLe\"," +
"\r\n                    data: { idtaisan: taisanid.trim(), Loaitaisan: LoaitaisanI" +
"D.trim() },\r\n                    datatype: \"html\",\r\n                    success:" +
" function (data) {\r\n                        $(\'#tabTaiSan\').html(data);\r\n       " +
"                 CheckRow(taisanid.trim());\r\n                    }\r\n            " +
"    });\r\n            }\r\n            else if (LoaitaisanID.trim() == \"4\") {\r\n    " +
"            $(\'#iddstaisan\').val(\"3\");\r\n                $(\'#drpchontaisan\').val(" +
"4);\r\n                $(\'#thuataisan\').hide();\r\n                $(\'#thuataisancan" +
"ho\').show();\r\n                $.ajax({\r\n                    type: \"POST\",\r\n     " +
"               url: \"/XLHSDangKy/ChiTietCanHo\",\r\n                    data: { idt" +
"aisan: taisanid.trim(), Loaitaisan: LoaitaisanID.trim() },\r\n                    " +
"datatype: \"html\",\r\n                    success: function (data) {\r\n             " +
"           $(\'#tabTaiSan\').html(data);\r\n                        $(\'#openTabThuaC" +
"anHo\').click();\r\n                        document.getElementById(\"CurCHID\").valu" +
"e = taisanchitietid.trim();\r\n                        CheckRowThuaTSCH(taisanid.t" +
"rim());\r\n                        if ($(\'#drpnhachungcu\').val() != null) {\r\n     " +
"                       document.getElementById(\"btnthemnhachungcuch\").value = \"\"" +
" + \"  Sửa  \" + \"\";\r\n                        }\r\n                        else {\r\n " +
"                           document.getElementById(\"btnthemnhachungcuch\").value " +
"= \"Thêm mới\";\r\n                        }\r\n                        if ($(\'#drpkhu" +
"chungcu\').val() != null) {\r\n                            document.getElementById(" +
"\"btnthemkhuchungcu\").value = \"\" + \"  Sửa  \" + \"\";\r\n                        }\r\n  " +
"                      else {\r\n                            document.getElementByI" +
"d(\"btnthemkhuchungcu\").value = \"Thêm mới\";\r\n                        }\r\n         " +
"               CheckRowHM(taisanchitietid.trim());\r\n                    }\r\n     " +
"           });\r\n            }\r\n            else if (LoaitaisanID.trim() == \"6\") " +
"{\r\n                $(\'#iddstaisan\').val(\"5\");\r\n                $(\'#drpchontaisan" +
"\').val(6);\r\n                $.ajax({\r\n                    type: \"POST\",\r\n       " +
"             url: \"/XLHSDangKy/ChiTietCongTrinhXayDung\",\r\n                    da" +
"ta: { idtaisan: taisanid.trim(), Loaitaisan: LoaitaisanID.trim() },\r\n           " +
"         datatype: \"html\",\r\n                    success: function (data) {\r\n    " +
"                    $(\'#tabTaiSan\').html(data);\r\n                        CheckRo" +
"w(taisanid.trim());\r\n                    }\r\n                });\r\n            }\r\n" +
"            else if (LoaitaisanID.trim() == \"7\") {\r\n                $(\'#iddstais" +
"an\').val(\"6\");\r\n                $(\'#drpchontaisan\').val(7);\r\n                $.a" +
"jax({\r\n                    type: \"POST\",\r\n                    url: \"/XLHSDangKy/" +
"ChiTietCongTrinhNgam\",\r\n                    data: { idtaisan: taisanid.trim(), L" +
"oaitaisan: LoaitaisanID.trim() },\r\n                    datatype: \"html\",\r\n      " +
"              success: function (data) {\r\n                        $(\'#tabTaiSan\'" +
").html(data);\r\n                        CheckRow(taisanid.trim());\r\n             " +
"       }\r\n                });\r\n            }\r\n            else if (LoaitaisanID." +
"trim() == \"8\") {\r\n                $(\'#iddstaisan\').val(\"7\");\r\n                $(" +
"\'#drpchontaisan\').val(8);\r\n                $.ajax({\r\n                    type: \"" +
"POST\",\r\n                    url: \"/XLHSDangKy/ChiTietHangMucCongTrinh\",\r\n       " +
"             data: { idtaisan: taisanid.trim(), Loaitaisan: LoaitaisanID.trim() " +
"},\r\n                    datatype: \"html\",\r\n                    success: function" +
" (data) {\r\n                        $(\'#tabTaiSan\').html(data);\r\n                " +
"        CheckRow(taisanid.trim());\r\n                    }\r\n                });\r\n" +
"            }\r\n            else if (LoaitaisanID.trim() == \"9\") {\r\n             " +
"   $(\'#iddstaisan\').val(\"8\");\r\n                $(\'#drpchontaisan\').val(9);\r\n    " +
"            $.ajax({\r\n                    type: \"POST\",\r\n                    url" +
": (\"/XLHSDangKy/ChiTietRungTrong\"),\r\n                    data: { idtaisan: taisa" +
"nid.trim(), Loaitaisan: LoaitaisanID.trim() },\r\n                    datatype: \"h" +
"tml\",\r\n                    success: function (data) {\r\n                        $" +
"(\'#tabTaiSan\').html(data);\r\n                        CheckRow(taisanid.trim());\r\n" +
"                    }\r\n                });\r\n            }\r\n            else if (" +
"LoaitaisanID.trim() == \"10\") {\r\n                $(\'#iddstaisan\').val(\"9\");\r\n    " +
"            $(\'#drpchontaisan\').val(10);\r\n                $.ajax({\r\n            " +
"        type: \"POST\",\r\n                    url: (\"/XLHSDangKy/ChiTietCayLauNam\")" +
",\r\n                    data: { idtaisan: taisanid.trim(), Loaitaisan: Loaitaisan" +
"ID.trim() },\r\n                    datatype: \"html\",\r\n                    success" +
": function (data) {\r\n                        $(\'#tabTaiSan\').html(data);\r\n      " +
"                  CheckRow(taisanid.trim());\r\n                    },\r\n          " +
"          error: function (xhr) {\r\n                        console.log(\'Request " +
"Status: \' + xhr.status + \' Status Text: \' + xhr.statusText + \' \' + xhr.responseT" +
"ext);\r\n                    }\r\n                });\r\n            }           \r\n   " +
"     });\r\n    });\r\n\r\n</script>");

        }
    }
}
#pragma warning restore 1591
