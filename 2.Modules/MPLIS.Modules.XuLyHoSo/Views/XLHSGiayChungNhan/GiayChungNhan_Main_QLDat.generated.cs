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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/XLHSGiayChungNhan/GiayChungNhan_Main_QLDat.cshtml")]
    public partial class _Views_XLHSGiayChungNhan_GiayChungNhan_Main_QLDat_cshtml : System.Web.Mvc.WebViewPage<MPLIS.Libraries.Data.XuLyHoSo.Models.GiayChungNhanLS>
    {
        public _Views_XLHSGiayChungNhan_GiayChungNhan_Main_QLDat_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" class=\"box\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"box-body\"");

WriteLiteral(">\r\n        <table");

WriteLiteral(" id=\"TableQuyenQLDatID\"");

WriteLiteral(" class=\"table table-bordered\"");

WriteLiteral(@">
            <thead>
                <tr>
                    <th></th>
                    <th></th>
                    <th>#</th>
                    <th>Xã phường</th>
                    <th>SH tờ bản đồ</th>
                    <th>STT thửa</th>
                    <th>Mục đích sử dụng</th>
                    <th>Diện tích (m<sup>2</sup>)</th>
                    <th>Trạng thái</th>
                    <th>TLSH</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
");

            
            #line 22 "..\..\Views\XLHSGiayChungNhan\GiayChungNhan_Main_QLDat.cshtml"
                
            
            #line default
            #line hidden
            
            #line 22 "..\..\Views\XLHSGiayChungNhan\GiayChungNhan_Main_QLDat.cshtml"
                 if (Model != null && Model.DSQuyenQLDat != null && Model.DSQuyenQLDat.Count > 0)
                {
                    int stt = 0;
                    foreach (var item in Model.DSQuyenQLDat)
                    {
                        stt++;

            
            #line default
            #line hidden
WriteLiteral("                        <tr>\r\n                            <td>\r\n");

WriteLiteral("                                ");

            
            #line 30 "..\..\Views\XLHSGiayChungNhan\GiayChungNhan_Main_QLDat.cshtml"
                           Write(item.QUYENQUANLYDATID);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n");

WriteLiteral("                                ");

            
            #line 33 "..\..\Views\XLHSGiayChungNhan\GiayChungNhan_Main_QLDat.cshtml"
                           Write(item.MUCDICHSUDUNGID);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n");

WriteLiteral("                                ");

            
            #line 36 "..\..\Views\XLHSGiayChungNhan\GiayChungNhan_Main_QLDat.cshtml"
                           Write(stt);

            
            #line default
            #line hidden
WriteLiteral(".\r\n                            </td>\r\n                            <td>\r\n");

WriteLiteral("                                ");

            
            #line 39 "..\..\Views\XLHSGiayChungNhan\GiayChungNhan_Main_QLDat.cshtml"
                           Write(item.XaPhuong);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n");

WriteLiteral("                                ");

            
            #line 42 "..\..\Views\XLHSGiayChungNhan\GiayChungNhan_Main_QLDat.cshtml"
                           Write(item.SHToBanDo);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n");

WriteLiteral("                                ");

            
            #line 45 "..\..\Views\XLHSGiayChungNhan\GiayChungNhan_Main_QLDat.cshtml"
                           Write(item.STTThua);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n");

WriteLiteral("                                ");

            
            #line 48 "..\..\Views\XLHSGiayChungNhan\GiayChungNhan_Main_QLDat.cshtml"
                           Write(item.Str_MucDichSDDat);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n");

WriteLiteral("                                ");

            
            #line 51 "..\..\Views\XLHSGiayChungNhan\GiayChungNhan_Main_QLDat.cshtml"
                           Write(item.DienTich);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n");

WriteLiteral("                                ");

            
            #line 54 "..\..\Views\XLHSGiayChungNhan\GiayChungNhan_Main_QLDat.cshtml"
                            Write(item.TRANGTHAIPL == "T" ? "Đang thế chấp" : "Bình thường");

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                            <td>");

            
            #line 56 "..\..\Views\XLHSGiayChungNhan\GiayChungNhan_Main_QLDat.cshtml"
                           Write(item.TILESOHUU);

            
            #line default
            #line hidden
WriteLiteral("%</td>\r\n                            <td></td>\r\n                        </tr>\r\n");

            
            #line 59 "..\..\Views\XLHSGiayChungNhan\GiayChungNhan_Main_QLDat.cshtml"
                    }
                }

            
            #line default
            #line hidden
WriteLiteral("            </tbody>\r\n        </table>\r\n        <button");

WriteLiteral(" id=\"btnThemQuyenQLDatID\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default btn-sm\"");

WriteLiteral(" disabled><i");

WriteLiteral(" class=\'fa fa-plus\'");

WriteLiteral("></i> Thêm quyền</button>\r\n    </div>\r\n</div>\r\n\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n    $(document).ready(function () {\r\n\r\n        if (\'");

            
            #line 70 "..\..\Views\XLHSGiayChungNhan\GiayChungNhan_Main_QLDat.cshtml"
        Write(Model.ChinhSua);

            
            #line default
            #line hidden
WriteLiteral(@"' == 'True') {
            $('#btnThemQuyenQLDatID').prop('disabled', false)
        }

        var columns = [
            { ""data"": ""QUYENQUANLYDATID"" },
            { ""data"": ""MUCDICHSUDUNGID"" },
            { ""data"": ""STT"" },
            { ""data"": ""XaPhuong"" },
            { ""data"": ""SHToBanDo"" },
            { ""data"": ""STTThua"" },
            { ""data"": ""MDSD"" },
            { ""data"": ""DienTich"" },
            { ""data"": ""TRANGTHAIPL"" },
            { ""data"": ""TILESOHUU"" },
            { ""data"": null }
        ]

        var columnDefs = [
            {
                ""targets"": [0, 1],
                ""visible"": false
            },
            {
                ""targets"": -1,
                ""render"": function () {
                    if ('");

            
            #line 96 "..\..\Views\XLHSGiayChungNhan\GiayChungNhan_Main_QLDat.cshtml"
                    Write(Model.TRANGTHAIXULY);

            
            #line default
            #line hidden
WriteLiteral("\' == \'S\') {\r\n                        return \"<button type=\'button\' class=\'btn btn" +
"-xs btn-heading btnDel\'>Xóa</button>\";\r\n                    }\r\n                 " +
"   return \"<button type=\'button\' class=\'btn btn-xs btn-heading btnDel\' disabled>" +
"Xóa</button>\";\r\n                }\r\n            },\r\n            {\r\n              " +
"  \"targets\": 1,\r\n                \"className\": \"text-right\"\r\n            },\r\n    " +
"        {\r\n                \"targets\": [-1, -2, 3, 4, 5, 6, 7],\r\n                " +
"\"className\": \"text-center\"\r\n            }\r\n        ]\r\n\r\n        var options = {\r" +
"\n            \"pageLength\": 5,\r\n            \"ordering\": false,\r\n            \"auto" +
"Width\": false,\r\n            \"columns\": columns,\r\n            \"columnDefs\": colum" +
"nDefs,\r\n            \"dom\": \"t<\'row p-0\'<\'col-xs-6 p-0\'<\'row p-0\'<\'col-xs-6 p-0\'<" +
"\'#divBTAddQuyenQLDat\'>>>><\'col-xs-6 p-0\'<\'pull-right\'p>>>\",\r\n            \"initCo" +
"mplete\": function () {\r\n                initComplete();\r\n            }\r\n        " +
"}\r\n\r\n        function initComplete() {\r\n            $(\'#btnThemQuyenQLDatID\').ap" +
"pendTo($(\'#divBTAddQuyenQLDat\'));\r\n        }\r\n\r\n        var TableQuyenQLDatID = " +
"$(\'#TableQuyenQLDatID\').DataTable(options);\r\n\r\n        $(\'#btnThemQuyenQLDatID\')" +
".on(\'click\', function () {\r\n            $.ajax({\r\n                type: \"POST\",\r" +
"\n                url: \"/XLHSGiayChungNhan/Popup_ThemQuyenVaoGCN\",\r\n             " +
"   data: { isQuyen: \"2\" },\r\n                success: function (result) {\r\n      " +
"              if (result.message == undefined) {\r\n                        $(\'#di" +
"vPopup\')\r\n                        .html(result)\r\n                        .ready(" +
"function () {\r\n                            var options = {\r\n                    " +
"            \"backdrop\": \"static\",\r\n                                \"show\": true\r" +
"\n                            }\r\n                            $(\"#modalformDSThua\"" +
").modal(options);\r\n                        });\r\n                    } else {\r\n  " +
"                      alert(result.message);\r\n                    }\r\n           " +
"     }\r\n            });\r\n        })\r\n\r\n        TableQuyenQLDatID.rows().nodes()." +
"on(\'click\', \'tbody tr .btnDel\', function (event) {\r\n            if (confirm(\"Xác" +
" nhận xóa quyền quản lý đất?\")) {\r\n                var curRow = TableQuyenQLDatI" +
"D.row($(this).parents(\'tr\'));\r\n                $.ajax({\r\n                    typ" +
"e: \"POST\",\r\n                    url: \"/XLHSGiayChungNhan/QuyenQuanLyDat_XoaQuyen" +
"\",\r\n                    data: { quyenQuanLyDatID: curRow.data().QUYENQUANLYDATID" +
" },\r\n                    dataType: \"json\",\r\n                    success: functio" +
"n (result) {\r\n                        if (result.success) {\r\n                   " +
"         TableQuyenQLDatID\r\n                            .row(curRow)\r\n          " +
"                  .remove();\r\n                            //Cập nhật lại STT cho" +
" dataTable\r\n                            var i = 1;\r\n                            " +
"TableQuyenQLDatID.rows().every(function () {\r\n                                va" +
"r d = this.data();\r\n                                d.STT = i++;\r\n              " +
"                  d.STT += \".\";\r\n                                TableQuyenQLDat" +
"ID.row(this).data(d);\r\n                            })\r\n                         " +
"   //Vẽ lại dataTable sau khi cập nhật\r\n                            TableQuyenQL" +
"DatID.draw();\r\n                        }\r\n                        alert(result.m" +
"essage);\r\n                    }\r\n                })\r\n            }\r\n        })\r\n" +
"\r\n        TableQuyenQLDatID.rows().nodes().on(\'dblclick\', \'tbody tr\', function (" +
"event) {\r\n            var curRow = TableQuyenQLDatID.row($(this));\r\n            " +
"$.ajax({\r\n                type: \"POST\",\r\n                url: \"/XLHSGiayChungNha" +
"n/Popup_SetTLSH_TrenQuyen\",\r\n                data: { isQuyen: \"2\", ID: curRow.da" +
"ta().MUCDICHSUDUNGID },\r\n                dataType: \"html\",\r\n                succ" +
"ess: function (html) {\r\n                    $(\'#divPopup\')\r\n                    " +
"    .html(html)\r\n                        .ready(function () {\r\n                 " +
"           var options = {\r\n                                \"backdrop\": \"static\"" +
",\r\n                                \"show\": true\r\n                            }\r\n" +
"                            $(\"#modal_GCN_QUYEN_TLSH_ID\").modal(options);\r\n     " +
"                   });\r\n                }\r\n            })\r\n        })\r\n\r\n    })\r" +
"\n</script>");

        }
    }
}
#pragma warning restore 1591