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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/XLHSDangKy/CaNhan_GiayTo.cshtml")]
    public partial class _Views_XLHSDangKy_CaNhan_GiayTo_cshtml : System.Web.Mvc.WebViewPage<MPLIS.Libraries.Data.XuLyHoSo.Models.CaNhanLS>
    {
        public _Views_XLHSDangKy_CaNhan_GiayTo_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<table");

WriteLiteral(" id=\"TableGiayToID\"");

WriteLiteral(" class=\"table table-bordered\"");

WriteLiteral(@">
    <thead>
        <tr>
            <th></th>
            <th>#</th>
            <th>Loại giấy tờ</th>
            <th>Số giấy tờ</th>
            <th>Ngày cấp</th>
            <th>Nơi cấp</th>
            <th>Là giấy tờ in GCN</th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");

            
            #line 17 "..\..\Views\XLHSDangKy\CaNhan_GiayTo.cshtml"
        
            
            #line default
            #line hidden
            
            #line 17 "..\..\Views\XLHSDangKy\CaNhan_GiayTo.cshtml"
         if (Model.DSGiayToTuyThan != null && Model.DSGiayToTuyThan.Count > 0)
        {
            int sTT = 0;
            foreach (var item in Model.DSGiayToTuyThan)
            {
                sTT++;

            
            #line default
            #line hidden
WriteLiteral("                <tr>\r\n                    <td>\r\n");

WriteLiteral("                        ");

            
            #line 25 "..\..\Views\XLHSDangKy\CaNhan_GiayTo.cshtml"
                   Write(item.LOAIGIAYTOTUYTHANID);

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");

WriteLiteral("                        ");

            
            #line 28 "..\..\Views\XLHSDangKy\CaNhan_GiayTo.cshtml"
                   Write(sTT);

            
            #line default
            #line hidden
WriteLiteral(".\r\n                    </td>\r\n                    <td>\r\n");

WriteLiteral("                        ");

            
            #line 31 "..\..\Views\XLHSDangKy\CaNhan_GiayTo.cshtml"
                   Write(item.TenLoaiGiayTo);

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");

WriteLiteral("                        ");

            
            #line 34 "..\..\Views\XLHSDangKy\CaNhan_GiayTo.cshtml"
                   Write(item.SOGIAYTO);

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");

            
            #line 37 "..\..\Views\XLHSDangKy\CaNhan_GiayTo.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\XLHSDangKy\CaNhan_GiayTo.cshtml"
                         if (@item.NGAYCAP != null)
                        {
                            
            
            #line default
            #line hidden
            
            #line 39 "..\..\Views\XLHSDangKy\CaNhan_GiayTo.cshtml"
                       Write(item.NGAYCAP.Value.ToString("dd/MM/yyyy"));

            
            #line default
            #line hidden
            
            #line 39 "..\..\Views\XLHSDangKy\CaNhan_GiayTo.cshtml"
                                                                      
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </td>\r\n                    <td>\r\n");

WriteLiteral("                        ");

            
            #line 43 "..\..\Views\XLHSDangKy\CaNhan_GiayTo.cshtml"
                   Write(item.NOICAP);

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");

            
            #line 46 "..\..\Views\XLHSDangKy\CaNhan_GiayTo.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 46 "..\..\Views\XLHSDangKy\CaNhan_GiayTo.cshtml"
                          
                            bool laGiayToInGCN = item.LAGIAYTOINGCN ?? false;
                        
            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                        ");

            
            #line 49 "..\..\Views\XLHSDangKy\CaNhan_GiayTo.cshtml"
                   Write(laGiayToInGCN);

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </td>\r\n                    <td></td>\r\n                </tr>" +
"\r\n");

            
            #line 53 "..\..\Views\XLHSDangKy\CaNhan_GiayTo.cshtml"
                                }
                            }

            
            #line default
            #line hidden
WriteLiteral("    </tbody>\r\n</table>\r\n\r\n<button");

WriteLiteral(" id=\"btnThemGiayToID\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-sm btn-default\"");

WriteLiteral("><i");

WriteLiteral(" class=\'fa fa-plus\'");

WriteLiteral("></i> Thêm mới</button>\r\n\r\n<div");

WriteLiteral(" id=\"FormTTGTID\"");

WriteLiteral(" class=\"box box-primary m-0 d-none\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"box-header with-border\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"row p-0\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-sm-4 p-0\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"pull-left\"");

WriteLiteral(">\r\n                    <button");

WriteLiteral(" id=\"SaveFormTTGTID\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-sm btn-default\"");

WriteLiteral("></button>\r\n                    <button");

WriteLiteral(" id=\"ClearFormTTGTID\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-sm btn-default\"");

WriteLiteral("><i");

WriteLiteral(" class=\'fa fa-trash\'");

WriteLiteral("></i> Xóa trắng</i></button>\r\n                </div>\r\n            </div>\r\n       " +
"     <div");

WriteLiteral(" class=\"col-sm-4 text-center p-0\"");

WriteLiteral(">\r\n                <h3");

WriteLiteral(" class=\"box-title\"");

WriteLiteral(">Chi tiết giấy tờ</h3>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-sm-4 p-0\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"pull-right\"");

WriteLiteral(">\r\n                    <button");

WriteLiteral(" id=\"CloseFormTTGTID\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-box-tool\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-remove\"");

WriteLiteral("></i></button>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    <" +
"/div>\r\n    <div");

WriteLiteral(" class=\"box-body\"");

WriteLiteral(">\r\n        <form");

WriteLiteral(" id=\"formTTGiayToID\"");

WriteLiteral(">\r\n            <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" name=\"STT\"");

WriteLiteral(" />\r\n            <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" name=\"TRANGTHAI\"");

WriteLiteral(" />\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 85 "..\..\Views\XLHSDangKy\CaNhan_GiayTo.cshtml"
               Write(Html.Label("", "Loại giấy tờ tùy thân", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 88 "..\..\Views\XLHSDangKy\CaNhan_GiayTo.cshtml"
               Write(Html.DropDownList("LOAIGIAYTOTUYTHANID", new SelectList(ViewBag.dSGiayToTuyThan, "LOAIGIAYTOTUYTHANID", "TENLOAIGIAYTOTUYTHAN"), "---- Lựa chọn ----", new { @class = "form-control input-sm", @id = "LOAIGIAYTOTUYTHANID" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 91 "..\..\Views\XLHSDangKy\CaNhan_GiayTo.cshtml"
               Write(Html.Label("", "Số giấy tờ", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 94 "..\..\Views\XLHSDangKy\CaNhan_GiayTo.cshtml"
               Write(Html.TextBox("SOGIAYTO", "", new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 99 "..\..\Views\XLHSDangKy\CaNhan_GiayTo.cshtml"
               Write(Html.Label("", "Ngày cấp", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 102 "..\..\Views\XLHSDangKy\CaNhan_GiayTo.cshtml"
               Write(Html.TextBox("NGAYCAP", "", "{0:yyyy-MM-dd}", new { @type = "date", @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 105 "..\..\Views\XLHSDangKy\CaNhan_GiayTo.cshtml"
               Write(Html.Label("", "Nơi cấp", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 108 "..\..\Views\XLHSDangKy\CaNhan_GiayTo.cshtml"
               Write(Html.TextBox("NOICAP", "", new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 113 "..\..\Views\XLHSDangKy\CaNhan_GiayTo.cshtml"
               Write(Html.Label("", "Là giấy tờ in GCN", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 116 "..\..\Views\XLHSDangKy\CaNhan_GiayTo.cshtml"
               Write(Html.CheckBox("LAGIAYTOINGCN", new { @id = "LAGIAYTOINGCN" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </form>\r\n    </div>\r\n</div>" +
"\r\n\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n    $(document).ready(function () {\r\n        var valformTTGiayToID = $(\"#formT" +
"TGiayToID\").validate({\r\n            rules: {\r\n                SOGIAYTO: \"require" +
"d\",\r\n                NGAYCAP: \"required\",\r\n                NOICAP: \"required\",\r\n" +
"                LOAIGIAYTOTUYTHANID: \"required\"\r\n            },\r\n            err" +
"orPlacement: function (error, element) {\r\n                return true;\r\n        " +
"    }\r\n        });\r\n\r\n        var columns = [\r\n\t\t\t{ \"data\": \"LOAIGIAYTOTUYTHANID" +
"\" },\r\n            { \"data\": \"STT\" },\r\n            { \"data\": \"TenLoaiGiayTo\" },\r\n" +
"            { \"data\": \"SOGIAYTO\" },\r\n            { \"data\": \"NGAYCAP\" },\r\n       " +
"     { \"data\": \"NOICAP\" },\r\n            { \"data\": \"LAGIAYTOINGCN\" },\r\n          " +
"  { \"data\": null }\r\n        ]\r\n        var columnDefs = [\r\n\t\t\t{\r\n\t\t\t    \"targets" +
"\": 0,\r\n\t\t\t    \"visible\": false\r\n\t\t\t},\r\n            {\r\n                \"targets\":" +
" -1,\r\n                \"render\": function () {\r\n                    return \"<butt" +
"on type=\'button\' class=\'btn btn-xs btn-heading btnDel\'>Xóa</button>\";\r\n         " +
"       },\r\n                \"className\": \"text-center\"\r\n            },\r\n         " +
"   {\r\n                \"targets\": 6,\r\n                \"render\": function (data) {" +
"\r\n                    if (data == \"True\") {\r\n                        return \"<in" +
"put type=\'checkbox\' disabled checked>\";\r\n                    } else {\r\n         " +
"               return \"<input type=\'checkbox\' disabled>\";\r\n                    }" +
"\r\n                }\r\n            },\r\n            {\r\n                \"targets\": 1" +
",\r\n                \"className\": \"text-right\"\r\n            },\r\n            {\r\n   " +
"             \"targets\": [3, 4, 6],\r\n                \"className\": \"text-center\"\r\n" +
"            }\r\n        ]\r\n        var options = {\r\n            \"pageLength\": 5,\r" +
"\n            \"ordering\": false,\r\n            \"autoWidth\": false,\r\n            \"c" +
"olumns\": columns,\r\n            \"columnDefs\": columnDefs,\r\n            \"dom\": \"t<" +
"\'row p-0\'<\'col-xs-6 p-0\'<\'row p-0\'<\'col-xs-6 p-0\'<\'#divBtnThemGTID\'>>>><\'col-xs-" +
"6 p-0\'<\'pull-right\'p>>>\",\r\n            \"initComplete\": function () {\r\n          " +
"      initComplete();\r\n            }\r\n        }\r\n\r\n        function initComplete" +
"() {\r\n            $(\'#btnThemGiayToID\').appendTo($(\'#divBtnThemGTID\'));\r\n       " +
" }\r\n\r\n        var TableGiayToID = $(\'#TableGiayToID\').DataTable(options);\r\n\r\n   " +
"     TableGiayToID.rows().nodes().on(\'dblclick\', \'tbody tr\', function () {\r\n    " +
"        if (TableGiayToID.data().count() > 0) {\r\n                $(\'#TableGiayTo" +
"ID_wrapper\').addClass(\'d-none\');\r\n                XemTTGiayTo(TableGiayToID.row(" +
"this).data());\r\n                $(\'#FormTTGTID\').removeClass(\'d-none\');\r\n       " +
"     }\r\n        })\r\n\r\n        TableGiayToID.rows().nodes().on(\'click\', \'tbody tr" +
" .btnDel\', function (event) {\r\n            XoaGiayTo(TableGiayToID, TableGiayToI" +
"D.row($(this).parents(\'tr\')).data(), TableGiayToID.row($(this).parents(\'tr\')));\r" +
"\n        })\r\n\r\n        function XoaGiayTo(table, rowData, rowDel) {\r\n           " +
" if (confirm(\"Xác nhận xóa giấy tờ?\")) {\r\n                table\r\n\t\t\t\t\t.row(rowDe" +
"l)\r\n\t\t\t\t\t.remove();\r\n                var i = 1;\r\n                table.rows().ev" +
"ery(function () {\r\n                    var d = this.data();\r\n                   " +
" d.STT = i++;\r\n                    d.STT += \".\";\r\n                    table.row(" +
"this).data(d);\r\n                })\r\n                table.draw();\r\n            }" +
"\r\n        }\r\n\r\n        $(\'#CloseFormTTGTID\').on(\'click\', function () {\r\n        " +
"    $(\'#TableGiayToID_wrapper\').removeClass(\'d-none\');\r\n            $(\'#FormTTGT" +
"ID\').addClass(\'d-none\');\r\n        })\r\n\r\n        $(\'#ClearFormTTGTID\').on(\'click\'" +
", function () {\r\n            document.getElementById(\"formTTGiayToID\").reset();\r" +
"\n            $(\'#FormTTGTID [name=TRANGTHAI]\').val(\"1\");\r\n            $(\'#FormTT" +
"GTID [name=LAGIAYTOINGCN]\').val(\"false\");\r\n            $(\'#FormTTGTID [name]\').r" +
"emoveClass(\'error\');\r\n            $(\'#SaveFormTTGTID\').html(\"<i class=\'fa fa-plu" +
"s\'></i> Thêm mới\");\r\n        })\r\n\r\n        $(\'#SaveFormTTGTID\').on(\'click\', func" +
"tion () {\r\n            var checkForm = $(\'#formTTGiayToID\').valid();\r\n          " +
"  if (checkForm) {\r\n                var objGiayTo = FormToObject($(\'#formTTGiayT" +
"oID\'));\r\n                objGiayTo.TenLoaiGiayTo = $(\'#LOAIGIAYTOTUYTHANID optio" +
"n:selected\').text();\r\n                if ($(\'#LAGIAYTOINGCN\').is(\':checked\')) {\r" +
"\n                    objGiayTo.LAGIAYTOINGCN = \"True\";\r\n                } else {" +
"\r\n                    objGiayTo.LAGIAYTOINGCN = \"False\";\r\n                }\r\n   " +
"             objGiayTo.NGAYCAP = ConverDatatimeddmmYYYY(objGiayTo.NGAYCAP);\r\n   " +
"             if (objGiayTo.TRANGTHAI == \"1\") {\r\n                    objGiayTo.ST" +
"T = TableGiayToID.data().count() + 1;\r\n                    objGiayTo.STT += \".\";" +
"\r\n                    $(\'#FormTTGTID [name=STT]\').val(objGiayTo.STT);\r\n         " +
"           TableGiayToID.row.add(objGiayTo).draw();\r\n                    $(\'#For" +
"mTTGTID [name=TRANGTHAI]\').val(\'2\');\r\n                    $(\'#SaveFormTTGTID\').h" +
"tml(\"<i class=\'fa fa-check\'></i> Lưu thông tin\");\r\n                    alert(\'Th" +
"êm mới giấy tờ thành công!\');\r\n                    $(\'#ClearFormTTGTID\').click()" +
";\r\n                } else {\r\n                    $.each(TableGiayToID.rows().nod" +
"es(), function () {\r\n                        var curRow = TableGiayToID.row(this" +
").data();\r\n                        if (curRow.STT == objGiayTo.STT) {\r\n         " +
"                   TableGiayToID.row(this).data(objGiayTo).draw();\r\n            " +
"                return false;\r\n                        }\r\n                    })" +
"\r\n                    alert(\'Cập nhật thông tin giấy tờ thành công!\');\r\n        " +
"        }\r\n            }\r\n        })\r\n\r\n        $(\'#btnThemGiayToID\').on(\'click\'" +
", function () {\r\n            $(\'#FormTTGTID [name]\').removeClass(\'error\');\r\n    " +
"        $(\'#ClearFormTTGTID\').click();\r\n            $(\'#TableGiayToID_wrapper\')." +
"addClass(\'d-none\');\r\n            $(\'#FormTTGTID\').removeClass(\'d-none\');\r\n      " +
"  })\r\n\r\n        function XemTTGiayTo(rowData) {\r\n            $(\'#FormTTGTID [nam" +
"e]\').removeClass(\'error\');\r\n            $(\'#SaveFormTTGTID\').html(\"<i class=\'fa " +
"fa-check\'></i> Lưu thông tin\");\r\n            $(\'#FormTTGTID [name=STT]\').val(row" +
"Data.STT);\r\n            $(\'#FormTTGTID [name=TRANGTHAI]\').val(\"2\");\r\n           " +
" $(\'#FormTTGTID [name=SOGIAYTO]\').val(rowData.SOGIAYTO);\r\n            $(\'#FormTT" +
"GTID [name=NGAYCAP]\').val(ConverDatatime(rowData.NGAYCAP));\r\n            $(\'#For" +
"mTTGTID [name=NOICAP]\').val(rowData.NOICAP);\r\n            $(\'#FormTTGTID [name=L" +
"OAIGIAYTOTUYTHANID]\').val(rowData.LOAIGIAYTOTUYTHANID);\r\n            if (rowData" +
".LAGIAYTOINGCN == \"True\") {\r\n                $(\'#FormTTGTID [name=LAGIAYTOINGCN]" +
"\').prop(\'checked\', true);\r\n            } else {\r\n                $(\'#FormTTGTID " +
"[name=LAGIAYTOINGCN]\').prop(\'checked\', false);\r\n            }\r\n        }\r\n    })" +
"\r\n</script>\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
