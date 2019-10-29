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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/TTBienDong/BienDong_DSGCNVAO.cshtml")]
    public partial class _Views_TTBienDong_BienDong_DSGCNVAO_cshtml : System.Web.Mvc.WebViewPage<MPLIS.Libraries.Data.XuLyHoSo.Models.DSGCNBDVM>
    {
        public _Views_TTBienDong_BienDong_DSGCNVAO_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" class=\"box box-primary\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"box-header with-border\"");

WriteLiteral(">\r\n        <h3");

WriteLiteral(" class=\"box-title\"");

WriteLiteral(">Danh sách GCN đầu vào</h3>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"box-body\"");

WriteLiteral(">\r\n        <table");

WriteLiteral(" id=\"TableGCNVaoID\"");

WriteLiteral(" class=\"table table-bordered\"");

WriteLiteral(@">
            <thead>
                <tr>
                    <th></th>
                    <th></th>
                    <th>Là cha</th>
                    <th>#</th>
                    <th>Số phát hành</th>
                    <th>Mã vạch</th>
                    <th>Trạng thái</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
");

            
            #line 22 "..\..\Views\TTBienDong\BienDong_DSGCNVAO.cshtml"
                
            
            #line default
            #line hidden
            
            #line 22 "..\..\Views\TTBienDong\BienDong_DSGCNVAO.cshtml"
                 if (Model.DSGcn != null && Model.DSGcn.Count() > 0)
                {
                    int rowdsGCNVaoID = 0;
                    foreach (var item in Model.DSGcn)
                    {
                        if (item.LAGCNVAO == "Y")
                        {
                            rowdsGCNVaoID = rowdsGCNVaoID + 1;

            
            #line default
            #line hidden
WriteLiteral("                            <tr>\r\n                                <td>\r\n");

WriteLiteral("                                    ");

            
            #line 32 "..\..\Views\TTBienDong\BienDong_DSGCNVAO.cshtml"
                               Write(item.BDGCNID);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n");

WriteLiteral("                                    ");

            
            #line 35 "..\..\Views\TTBienDong\BienDong_DSGCNVAO.cshtml"
                               Write(item.GIAYCHUNGNHANID);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </td>\r\n                                <td></td" +
">\r\n                                <td>\r\n");

WriteLiteral("                                    ");

            
            #line 39 "..\..\Views\TTBienDong\BienDong_DSGCNVAO.cshtml"
                               Write(rowdsGCNVaoID);

            
            #line default
            #line hidden
WriteLiteral(".\r\n                                </td>\r\n                                <td>\r\n");

WriteLiteral("                                    ");

            
            #line 42 "..\..\Views\TTBienDong\BienDong_DSGCNVAO.cshtml"
                               Write(item.SoPhatHanh);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n");

WriteLiteral("                                    ");

            
            #line 45 "..\..\Views\TTBienDong\BienDong_DSGCNVAO.cshtml"
                               Write(item.MaVach);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n");

WriteLiteral("                                    ");

            
            #line 48 "..\..\Views\TTBienDong\BienDong_DSGCNVAO.cshtml"
                               Write(item.TrangThai);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </td>\r\n                                <td></td" +
">\r\n                            </tr>\r\n");

            
            #line 52 "..\..\Views\TTBienDong\BienDong_DSGCNVAO.cshtml"
                        }
                    }
                }

            
            #line default
            #line hidden
WriteLiteral("            </tbody>\r\n        </table>\r\n        <button");

WriteLiteral(" id=\"btnThemGCNVao\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-sm btn-default btn-sm m-r-5\"");

WriteLiteral("><i");

WriteLiteral(" class=\'fa fa-plus\'");

WriteLiteral("></i> Thêm mới</button>\r\n        <button");

WriteLiteral(" id=\"btnThemGCNVaoTuDangKy\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-sm btn-default\"");

WriteLiteral("><i");

WriteLiteral(" class=\'fa fa-plus\'");

WriteLiteral("></i> Thêm từ đăng ký</button>\r\n    </div>\r\n</div>\r\n\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n    $(document).ready(function () {\r\n        var columns = [\r\n            { \"d" +
"ata\": \"BDGCNID\" },\r\n            { \"data\": \"GIAYCHUNGNHANID\" },\r\n            { \"d" +
"ata\": null },\r\n            { \"data\": \"STT\" },\r\n            { \"data\": \"SoPhatHanh" +
"\" },\r\n            { \"data\": \"MaVach\" },\r\n            { \"data\": \"TrangThai\" },\r\n " +
"           { \"data\": null }\r\n        ]\r\n\r\n        var columnDefs = [\r\n          " +
"  {\r\n                \"targets\": [0, 1],\r\n                \"visible\": false\r\n     " +
"       },\r\n            {\r\n                \"targets\": -1,\r\n                \"rende" +
"r\": function (data) {\r\n                    if (data.TrangThai == \"Y\") {\r\n       " +
"                 return \"<button type=\'button\' class=\'btn btn-xs btn-heading btn" +
"Del\' data-toggle=\'tooltip\' data-placement=\'bottom\' title=\'Xóa GCN khỏi danh sách" +
"\'>Xóa</button> <button type=\'button\' class=\'btn btn-xs btn-heading btnCoppy\' dat" +
"a-toggle=\'tooltip\' data-placement=\'bottom\' title=\'Sao chép GCN đầu vào tới GCN đ" +
"ầu ra\'>Sao chép</button> <button type=\'button\' class=\'btn btn-xs btn-heading btn" +
"Detail\' data-toggle=\'tooltip\' data-placement=\'bottom\' title=\'Xem thông tin chi t" +
"iết GCN\'>Chi tiết</button>\";\r\n                    }\r\n                    return " +
"\"<button type=\'button\' class=\'btn btn-xs btn-heading btnDel\' data-toggle=\'toolti" +
"p\' data-placement=\'bottom\' title=\'Xóa GCN khỏi danh sách\'>Xóa</button> <button t" +
"ype=\'button\' class=\'btn btn-xs btn-heading btnCoppy\' disabled>Sao chép</button> " +
"<button type=\'button\' class=\'btn btn-xs btn-heading btnDetail\' data-toggle=\'tool" +
"tip\' data-placement=\'bottom\' title=\'Xem thông tin chi tiết GCN\'>Chi tiết</button" +
">\";\r\n                }\r\n            },\r\n            {\r\n                \"targets\"" +
": 2,\r\n                \"render\": function () {\r\n                    return \"<inpu" +
"t type=\'checkbox\' disabled/>\";\r\n                },\r\n                \"className\":" +
" \"text-center\"\r\n            },\r\n            {\r\n                \"targets\": 3,\r\n  " +
"              \"className\": \"text-right\"\r\n            },\r\n            {\r\n        " +
"        \"targets\": [-1, 4, 5, 6],\r\n                \"className\": \"text-center\"\r\n " +
"           }\r\n        ]\r\n\r\n        var options = {\r\n            \"pageLength\": 5," +
"\r\n            \"ordering\": false,\r\n            \"autoWidth\": false,\r\n            \"" +
"columns\": columns,\r\n            \"columnDefs\": columnDefs,\r\n            \"dom\": \"t" +
"<\'row p-0\'<\'col-xs-6 p-0\'<\'row p-0\'<\'col-xs-12 p-0\'<\'#divBTAdd\'>>>><\'col-xs-6 p-" +
"0\'<\'pull-right\'p>>>\",\r\n            \"stateSave\": true,\r\n            \"initComplete" +
"\": function () {\r\n                initComplete();\r\n            }\r\n        }\r\n\r\n " +
"       function initComplete() {\r\n            $(\'#btnThemGCNVao\').appendTo($(\'#d" +
"ivBTAdd\'));\r\n            $(\'#btnThemGCNVaoTuDangKy\').appendTo($(\'#divBTAdd\'));\r\n" +
"        }\r\n\r\n        var TableGCNVaoID = $(\'#TableGCNVaoID\').DataTable(options);" +
"\r\n\r\n        $(\'#btnThemGCNVao\').on(\'click\', function () {\r\n            $.ajax({\r" +
"\n                type: \"POST\",\r\n                url: \"/TTBienDong/ThemMoi_GCN\",\r" +
"\n                data: { LAGCNVAO: \"Y\" },\r\n                dataType: \"json\",\r\n  " +
"              success: function (result) {\r\n                    if (result.succe" +
"ss) {\r\n                        $(\'#divBienDongID_DSGCN\').load(\'/TTBienDong/BienD" +
"ong_DSGCN\');\r\n                    }\r\n                    alert(result.message);\r" +
"\n                }\r\n            })\r\n        })\r\n\r\n        $(\'#btnThemGCNVaoTuDan" +
"gKy\').on(\'click\', function () {\r\n            $.ajax({\r\n                type: \"PO" +
"ST\",\r\n                url: \"/TTBienDong/ThemMoi_GCNVao_TuDangKy\",\r\n             " +
"   dataType: \"html\",\r\n                success: function (html) {\r\n              " +
"      $(\'#divPopupID\')\r\n                        .html(html)\r\n                   " +
"     .ready(function () {\r\n                            var options = {\r\n        " +
"                        \"backdrop\": \"static\",\r\n                                \"" +
"show\": true\r\n                            }\r\n                            $(\"#moda" +
"lDSDangKyGCNID\").modal(options);\r\n                        })\r\n                }\r" +
"\n            })\r\n        })\r\n\r\n        TableGCNVaoID.rows().nodes().on(\'click\', " +
"\'tbody tr .btnDetail\', function (event) {\r\n            var rowData = TableGCNVao" +
"ID.row($(this).parents(\'tr\')).data();\r\n            $.ajax({\r\n                typ" +
"e: \"POST\",\r\n                url: \"/XLHSGiayChungNhan/InitCurGiayChungNhan\",\r\n   " +
"             data: { gCNID: rowData.GIAYCHUNGNHANID, taiGCN: \"1\" },\r\n           " +
"     success: function (result) {\r\n                    if (result.message == und" +
"efined) {\r\n                        $(\'#bhs-tabID\').html(result);\r\n              " +
"      } else {\r\n                        alert(result.message);\r\n                " +
"    }\r\n                }\r\n            })\r\n        })\r\n\r\n        TableGCNVaoID.ro" +
"ws().nodes().on(\'click\', \'tbody tr .btnDel\', function (event) {\r\n            var" +
" rowData = TableGCNVaoID.row($(this).parents(\'tr\')).data();\r\n            if (con" +
"firm(\"Xác nhận xóa GCN đầu vào khỏi danh sách?\")) {\r\n                $.ajax({\r\n " +
"                   type: \"POST\",\r\n                    url: \"/TTBienDong/BienDong" +
"_DSGCN_XoaGCN\",\r\n                    data: { bienDongGCNID: rowData.BDGCNID },\r\n" +
"                    dataType: \"json\",\r\n                    success: function (re" +
"sult) {\r\n                        if (result.success) {\r\n                        " +
"    $(\'#divBienDongID_DSGCN\').load(\'/TTBienDong/BienDong_DSGCN\');\r\n             " +
"           }\r\n                        alert(result.message);\r\n                  " +
"  }\r\n                })\r\n            }\r\n        })\r\n\r\n        TableGCNVaoID.rows" +
"().nodes().on(\'click\', \'tbody tr .btnCoppy\', function (event) {\r\n            var" +
" rowData = TableGCNVaoID.row($(this).parents(\'tr\')).data();\r\n            $.ajax(" +
"{\r\n                type: \"POST\",\r\n                url: \"/TTBienDong/BienDong_DSG" +
"CNVAO_SaoChepGCN\",\r\n                data: { bienDongGCNID: rowData.BDGCNID },\r\n " +
"               dataType: \"json\",\r\n                success: function (result) {\r\n" +
"                    if (result.success) {\r\n                        $(\'#divBienDo" +
"ngID_DSGCN\').load(\'/TTBienDong/BienDong_DSGCN\');\r\n                    }\r\n       " +
"             alert(result.message);\r\n                }\r\n            })\r\n        " +
"})\r\n\r\n    })\r\n</script>");

        }
    }
}
#pragma warning restore 1591