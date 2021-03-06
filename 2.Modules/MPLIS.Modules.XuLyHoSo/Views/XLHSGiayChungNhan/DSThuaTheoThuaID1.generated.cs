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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/XLHSGiayChungNhan/DSThuaTheoThuaID.cshtml")]
    public partial class _Views_XLHSGiayChungNhan_DSThuaTheoThuaID_cshtml : System.Web.Mvc.WebViewPage<MPLIS.Libraries.Data.XuLyHoSo.Models.DSThuaDatVM>
    {
        public _Views_XLHSGiayChungNhan_DSThuaTheoThuaID_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<table");

WriteLiteral(" id=\"Table_SDDatThuaID\"");

WriteLiteral(" class=\"table table-bordered\"");

WriteLiteral(" data-toggle=\"table\"");

WriteLiteral(">\r\n    <thead>\r\n        <tr>\r\n            <th></th>\r\n            <th>\r\n          " +
"      <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" id=\"checkall_QuyenSDDATThua\"");

WriteLiteral(@" />
            </th>
            <th>#</th>
            <th>Xã phường</th>
            <th>SH tờ bản đồ</th>
            <th>STT thửa</th>
            <th>Mục đích sử dụng</th>
            <th>Diện tích (m<sup>2</sup>)</th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");

            
            #line 20 "..\..\Views\XLHSGiayChungNhan\DSThuaTheoThuaID.cshtml"
        
            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\XLHSGiayChungNhan\DSThuaTheoThuaID.cshtml"
         if (Model.DSThuaTheoThuaID != null && Model.DSThuaTheoThuaID.Count() > 0)
        {
            int stt = 0;
            foreach (var item in Model.DSThuaTheoThuaID)
            {
                stt++;

            
            #line default
            #line hidden
WriteLiteral("                <tr>\r\n                    <td>");

            
            #line 27 "..\..\Views\XLHSGiayChungNhan\DSThuaTheoThuaID.cshtml"
                   Write(item.THUADATID);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    <td></td>\r\n                    <td>");

            
            #line 29 "..\..\Views\XLHSGiayChungNhan\DSThuaTheoThuaID.cshtml"
                   Write(stt);

            
            #line default
            #line hidden
WriteLiteral(".</td>\r\n                    <td>");

            
            #line 30 "..\..\Views\XLHSGiayChungNhan\DSThuaTheoThuaID.cshtml"
                   Write(item.TenXaPhuong);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    <td>");

            
            #line 31 "..\..\Views\XLHSGiayChungNhan\DSThuaTheoThuaID.cshtml"
                   Write(item.SOHIEUTOBANDO);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    <td>");

            
            #line 32 "..\..\Views\XLHSGiayChungNhan\DSThuaTheoThuaID.cshtml"
                   Write(item.SOTHUTUTHUA);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    <td>");

            
            #line 33 "..\..\Views\XLHSGiayChungNhan\DSThuaTheoThuaID.cshtml"
                   Write(item.DSMucDichSuDungDatToString);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    <td>");

            
            #line 34 "..\..\Views\XLHSGiayChungNhan\DSThuaTheoThuaID.cshtml"
                   Write(item.DIENTICH);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    <td></td>\r\n                </tr>\r\n");

            
            #line 37 "..\..\Views\XLHSGiayChungNhan\DSThuaTheoThuaID.cshtml"
            }
        }

            
            #line default
            #line hidden
WriteLiteral("    </tbody>\r\n</table>\r\n<button");

WriteLiteral(" id=\"Table_SDDatThuaID_btnSave\"");

WriteLiteral(" type=\'button\'");

WriteLiteral(" class=\'btn btn-default btn-sm pull-left\'");

WriteLiteral("><i");

WriteLiteral(" class=\'fa fa-check\'");

WriteLiteral("></i> Xong</button>\r\n\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n    $(document).ready(function () {\r\n        var columns = [\r\n            { \"d" +
"ata\": \"THUADATID\" },\r\n            { \"data\": null },\r\n            { \"data\": \"STT\"" +
" },\r\n            { \"data\": \"TenXaPhuong\" },\r\n            { \"data\": \"SOHIEUTOBAND" +
"O\" },\r\n            { \"data\": \"SOTHUTUTHUA\" },\r\n            { \"data\": \"DSMucDichS" +
"uDungDatToString\" },\r\n            { \"data\": \"DIENTICH\" },\r\n            { \"data\":" +
" null }\r\n        ]\r\n\r\n        var columnDefs = [\r\n            {\r\n               " +
" \"targets\": 0,\r\n                \"visible\": false\r\n            },\r\n            {\r" +
"\n                \"targets\": 1,\r\n                \"render\": function () {\r\n       " +
"             return \"<input type=\'checkbox\'/>\";\r\n                }\r\n            " +
"},\r\n            {\r\n                \"targets\": 2,\r\n                \"className\": \"" +
"text-right\"\r\n            },\r\n            {\r\n                \"targets\": [1, 4, 5," +
" 6, 7],\r\n                \"className\": \"text-center\"\r\n            }\r\n        ]\r\n\r" +
"\n        var options = {\r\n            \"pageLength\": 5,\r\n            \"ordering\": " +
"false,\r\n            \"autoWidth\": false,\r\n            \"columns\": columns,\r\n      " +
"      \"columnDefs\": columnDefs,\r\n            \"dom\": \"t<\'row p-0\'<\'col-xs-6 p-0\'<" +
"\'row p-0\'<\'col-xs-6 p-0\'<\'#Table_SDDatThuaID_divBTSave\'>><\'col-xs-6 p-0\' >>><\'co" +
"l-xs-6 p-0\'<\'pull-right\'p>>>\",\r\n            \"initComplete\": function () {\r\n     " +
"           initComplete();\r\n            }\r\n        }\r\n\r\n        function initCom" +
"plete() {\r\n            $(\'#Table_SDDatThuaID_btnSave\').appendTo($(\'#Table_SDDatT" +
"huaID_divBTSave\'));\r\n        }\r\n\r\n        var Table_SDDatThuaID = $(\'#Table_SDDa" +
"tThuaID\').DataTable(options);\r\n\r\n        ProcessCheckBox(Table_SDDatThuaID, $(\'#" +
"checkall_QuyenSDDATThua\'));\r\n\r\n        $(\'#Table_SDDatThuaID_btnSave\').on(\'click" +
"\', function () {\r\n            var arrSel = [];\r\n            $.each(Table_SDDatTh" +
"uaID.rows().nodes(), function () {\r\n                if ($(\'[type=checkbox]\', thi" +
"s).is(\':checked\')) {\r\n                    arrSel.push(Table_SDDatThuaID.row(this" +
").data().THUADATID);\r\n                }\r\n            });\r\n            if (arrSel" +
".length == 0) {\r\n                alert(\'Vui lòng chọn ít nhất một Thửa Đất?\')\r\n " +
"           } else {\r\n                $.ajax({\r\n                    type: \"POST\"," +
"\r\n                    url: \"/XLHSGiayChungNhan/Save_Popup_ThemQuyenVaoGCN\",\r\n   " +
"                 data: { data: JSON.stringify(arrSel), isQuyen: \'");

            
            #line 111 "..\..\Views\XLHSGiayChungNhan\DSThuaTheoThuaID.cshtml"
                                                               Write(Model.ISQuyen);

            
            #line default
            #line hidden
WriteLiteral("\', thuaTheo: 1 },\r\n                    dataType: \"json\",\r\n                    suc" +
"cess: function (result) {\r\n                        if (result.success) {\r\n      " +
"                      $(\"#modalformDSThua\").modal(\'hide\');\r\n                    " +
"        if(\'");

            
            #line 116 "..\..\Views\XLHSGiayChungNhan\DSThuaTheoThuaID.cshtml"
                           Write(Model.ISQuyen);

            
            #line default
            #line hidden
WriteLiteral("\' == \'QSDDAT\') {\r\n                                $(\'#divGCN_Main_SDDATID\').load(" +
"\'/XLHSGiayChungNhan/GiayChungNhan_Main_SDDat\');\r\n                            } e" +
"lse if(\'");

            
            #line 118 "..\..\Views\XLHSGiayChungNhan\DSThuaTheoThuaID.cshtml"
                                  Write(Model.ISQuyen);

            
            #line default
            #line hidden
WriteLiteral(@"' == 'QQLDAT') {
                                $('#divGCN_Main_QLDATID').load('/XLHSGiayChungNhan/GiayChungNhan_Main_QLDat');
                            }
                        }
                        alert(result.message);
                    }
                })
            }
        })
    })
</script>
");

        }
    }
}
#pragma warning restore 1591
