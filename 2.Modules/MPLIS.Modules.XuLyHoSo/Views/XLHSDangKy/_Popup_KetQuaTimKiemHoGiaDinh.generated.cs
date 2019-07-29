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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/XLHSDangKy/_Popup_KetQuaTimKiemHoGiaDinh.cshtml")]
    public partial class _Views_XLHSDangKy__Popup_KetQuaTimKiemHoGiaDinh_cshtml : System.Web.Mvc.WebViewPage<MPLIS.Libraries.Data.XuLyHoSo.Models.DSHoGiaDinhVM>
    {
        public _Views_XLHSDangKy__Popup_KetQuaTimKiemHoGiaDinh_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" class=\'modal fade\'");

WriteLiteral(" id=\'modalKQTKHoGiaDinhID\'");

WriteLiteral(">\r\n");

WriteLiteral("    ");

            
            #line 4 "..\..\Views\XLHSDangKy\_Popup_KetQuaTimKiemHoGiaDinh.cshtml"
Write(Html.Hidden("Count", Model.DSHoGiaDinh.Count, new { @id = "CountHoGiaDinhID" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n    <div");

WriteLiteral(" class=\'modal-dialog\'");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\'modal-content\'");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\'modal-header\'");

WriteLiteral(">\r\n                <button");

WriteLiteral(" type=\'button\'");

WriteLiteral(" class=\'close\'");

WriteLiteral(" data-dismiss=\'modal\'");

WriteLiteral(">&times;</button>\r\n                <h4");

WriteLiteral(" class=\'modal-title\'");

WriteLiteral(">Kết quả tìm kiếm hộ gia đình</h4>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\'modal-body\'");

WriteLiteral(">\r\n                <table");

WriteLiteral(" id=\"TableDSHoGiaDinhID\"");

WriteLiteral(" class=\"table table-bordered\"");

WriteLiteral(@">
                    <thead>
                        <tr>
                            <th></th>
                            <th>#</th>
                            <th>Chủ hộ</th>
                            <th>CMT chủ hộ</th>
                            <th>Vợ / Chồng</th>
                            <th>CMT vợ / chồng</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
");

            
            #line 25 "..\..\Views\XLHSDangKy\_Popup_KetQuaTimKiemHoGiaDinh.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 25 "..\..\Views\XLHSDangKy\_Popup_KetQuaTimKiemHoGiaDinh.cshtml"
                         if (Model.DSHoGiaDinh != null && Model.DSHoGiaDinh.Count > 0)
                        {
                            int sTT = 0;
                            foreach (var item in Model.DSHoGiaDinh)
                            {
                                sTT++;

            
            #line default
            #line hidden
WriteLiteral("                                <tr>\r\n                                    <td>\r\n");

WriteLiteral("                                        ");

            
            #line 33 "..\..\Views\XLHSDangKy\_Popup_KetQuaTimKiemHoGiaDinh.cshtml"
                                   Write(item.HOGIADINHID);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    </td>\r\n                                    " +
"<td");

WriteLiteral(" class=\"text-right\"");

WriteLiteral(">\r\n");

WriteLiteral("                                        ");

            
            #line 36 "..\..\Views\XLHSDangKy\_Popup_KetQuaTimKiemHoGiaDinh.cshtml"
                                   Write(sTT);

            
            #line default
            #line hidden
WriteLiteral(".\r\n                                    </td>\r\n                                   " +
" <td>\r\n");

WriteLiteral("                                        ");

            
            #line 39 "..\..\Views\XLHSDangKy\_Popup_KetQuaTimKiemHoGiaDinh.cshtml"
                                   Write(item.ChuHoCN.HOTEN);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    </td>\r\n                                    " +
"<td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n");

WriteLiteral("                                        ");

            
            #line 42 "..\..\Views\XLHSDangKy\_Popup_KetQuaTimKiemHoGiaDinh.cshtml"
                                   Write(item.ChuHoCN.SOGIAYTO);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    </td>\r\n                                    " +
"<td>\r\n");

WriteLiteral("                                        ");

            
            #line 45 "..\..\Views\XLHSDangKy\_Popup_KetQuaTimKiemHoGiaDinh.cshtml"
                                   Write(item.VoChongCN.HOTEN);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    </td>\r\n                                    " +
"<td>\r\n");

WriteLiteral("                                        ");

            
            #line 48 "..\..\Views\XLHSDangKy\_Popup_KetQuaTimKiemHoGiaDinh.cshtml"
                                   Write(item.VoChongCN.SOGIAYTO);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    </td>\r\n                                    " +
"<td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral("></td>\r\n                                </tr>\r\n");

            
            #line 52 "..\..\Views\XLHSDangKy\_Popup_KetQuaTimKiemHoGiaDinh.cshtml"
                            }
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n     " +
"   </div>\r\n    </div>\r\n</div>\r\n\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n    $(document).ready(function () {\r\n        var columns = [\r\n            { \"d" +
"ata\": \"HOGIADINHID\" },\r\n            { \"data\": \"STT\" },\r\n            { \"data\": \"C" +
"HUHOHOTEN\" },\r\n            { \"data\": \"CHUHOSOGIAYTO\" },\r\n            { \"data\": \"" +
"VOCHONGHOTEN\" },\r\n            { \"data\": \"VOCHONGSOGIAYTO\" },\r\n            { \"dat" +
"a\": null }\r\n        ]\r\n        var columnDefs = [\r\n            {\r\n              " +
"  \"targets\": 0,\r\n                \"visible\": false\r\n            },\r\n            {" +
"\r\n                \"targets\": -1,\r\n                \"render\": function () {\r\n     " +
"               return \"<button type=\'button\' class=\'btn btn-xs btn-heading btnSe" +
"l\'>Chọn</button>\";\r\n                }\r\n            }\r\n        ]\r\n        var opt" +
"ions = {\r\n            \"pageLength\": 5,\r\n            \"lengthChange\": false,\r\n    " +
"        \"ordering\": false,\r\n            \"info\": false,\r\n            \"searching\":" +
" false,\r\n            \"autoWidth\": false,\r\n            \"language\": {\r\n           " +
"     \"url\": \"https://cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Vietnamese.jso" +
"n\"\r\n            },\r\n            \"columns\": columns,\r\n            \"columnDefs\": c" +
"olumnDefs,\r\n            \"dom\": \'t<\"bottom\"p><\"clear\">\'\r\n        }\r\n        var T" +
"ableDSHoGiaDinhID = $(\'#TableDSHoGiaDinhID\').DataTable(options);\r\n\r\n        Tabl" +
"eDSHoGiaDinhID.rows().nodes().on(\'click\', \'tbody tr\', function () {\r\n           " +
" if (TableDSHoGiaDinhID.rows().nodes().length > 0) {\r\n                ChonHoGiaD" +
"inh(TableDSHoGiaDinhID.row($(this)).data());\r\n                //if ($(TableDSCaN" +
"hanID.row(this).node()).attr(\'class\').indexOf(\'activerow\') != -1) {\r\n           " +
"     //    $(TableDSCaNhanID.row(this).node()).removeClass(\'activerow\');\r\n      " +
"          //} else {\r\n                //    $(TableDSCaNhanID.rows().nodes()).re" +
"moveClass(\'activerow\');\r\n                //    $(TableDSCaNhanID.row(this).node(" +
")).addClass(\'activerow\');\r\n                //}\r\n            }\r\n        })\r\n\r\n   " +
"     TableDSHoGiaDinhID.rows().nodes().on(\'click\', \'tbody tr button\', function (" +
"event) {\r\n            event.stopPropagation();\r\n        })\r\n\r\n        TableDSHoG" +
"iaDinhID.rows().nodes().on(\'click\', \'tbody tr .btnSel\', function (event) {\r\n    " +
"        ChonHoGiaDinh(TableDSHoGiaDinhID.row($(this).parents(\'tr\')).data());\r\n  " +
"      })\r\n\r\n        function ChonHoGiaDinh(rowData) {\r\n            console.log(r" +
"owData);\r\n            $.ajax({\r\n                type: \"POST\",\r\n                u" +
"rl: \"/XLHSDangKy/DonDangKy_ChonHoGiaDinh\",\r\n                data: { hoGiaDinhID:" +
" rowData.HOGIADINHID },\r\n                dataType: \"html\",\r\n                succ" +
"ess: function (result) {\r\n                    $(\'#divCTChuHGDID\')\r\n             " +
"           .html(result)\r\n                        .ready(function () {\r\n        " +
"                    $(\"#modalKQTKHoGiaDinhID\").modal(\'hide\');\r\n                 " +
"       })\r\n                }\r\n            })\r\n        }\r\n\r\n    })\r\n</script>\r\n\r\n" +
"");

        }
    }
}
#pragma warning restore 1591
