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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/XLHSGiayChungNhan/Popup_DSTaiSan.cshtml")]
    public partial class _Views_XLHSGiayChungNhan_Popup_DSTaiSan_cshtml : System.Web.Mvc.WebViewPage<MPLIS.Libraries.Data.XuLyHoSo.Models.DSTaiSanVM>
    {
        public _Views_XLHSGiayChungNhan_Popup_DSTaiSan_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" class=\'modal fade\'");

WriteLiteral(" id=\'modalformDSTaiSan\'");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\'modal-dialog modal-lg\'");

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

WriteLiteral(">Thêm Quyền Sở Hữu Tài Sản</h4>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\'modal-body p-10\'");

WriteLiteral(">\r\n                <table");

WriteLiteral(" id=\"Table_DSTaiSanID\"");

WriteLiteral(" class=\"table table-bordered\"");

WriteLiteral(" data-toggle=\"table\"");

WriteLiteral(">\r\n                    <thead>\r\n                        <tr>\r\n                   " +
"         <th></th>\r\n                            <th><input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" id=\"checkall_QuyenSHTAISANThua\"");

WriteLiteral(@" /></th>
                            <th>#</th>
                            <th>Loại tài sản</th>
                            <th>Tên tài sản</th>
                            <th>Diện tích (m<sup>2</sup>)</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
");

            
            #line 24 "..\..\Views\XLHSGiayChungNhan\Popup_DSTaiSan.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\XLHSGiayChungNhan\Popup_DSTaiSan.cshtml"
                         if (Model.DSTaiSan != null && Model.DSTaiSan.Count > 0)
                        {
                            int stt = 0;
                            foreach (var item in Model.DSTaiSan)
                            {
                                stt++;

            
            #line default
            #line hidden
WriteLiteral("                                <tr>\r\n                                    <td>");

            
            #line 31 "..\..\Views\XLHSGiayChungNhan\Popup_DSTaiSan.cshtml"
                                   Write(item.TAISANGANLIENVOIDATID);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                                    <td></td>\r\n                           " +
"         <td>");

            
            #line 33 "..\..\Views\XLHSGiayChungNhan\Popup_DSTaiSan.cshtml"
                                   Write(stt);

            
            #line default
            #line hidden
WriteLiteral(".</td>\r\n                                    <td>");

            
            #line 34 "..\..\Views\XLHSGiayChungNhan\Popup_DSTaiSan.cshtml"
                                   Write(item.TenLoaiTaiSan);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                                    <td>");

            
            #line 35 "..\..\Views\XLHSGiayChungNhan\Popup_DSTaiSan.cshtml"
                                   Write(item.TenTaiSan);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                                    <td>");

            
            #line 36 "..\..\Views\XLHSGiayChungNhan\Popup_DSTaiSan.cshtml"
                                   Write(item.DienTich);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                                    <td></td>\r\n                           " +
"     </tr>\r\n");

            
            #line 39 "..\..\Views\XLHSGiayChungNhan\Popup_DSTaiSan.cshtml"
                            }
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </tbody>\r\n                </table>\r\n                <button");

WriteLiteral(" id=\"Table_DSTaiSanID_btnSave\"");

WriteLiteral(" type=\'button\'");

WriteLiteral(" class=\'btn btn-default btn-sm pull-left\'");

WriteLiteral("><i");

WriteLiteral(" class=\'fa fa-check\'");

WriteLiteral("></i> Xong</button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<s" +
"cript");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n    $(document).ready(function () {\r\n        var columns = [\r\n            { \"d" +
"ata\": \"TAISANGANLIENVOIDATID\" },\r\n            { \"data\": null },\r\n            { \"" +
"data\": \"STT\" },\r\n            { \"data\": \"LOAITAISAN\" },\r\n            { \"data\": \"T" +
"ENTAISAN\" },\r\n            { \"data\": \"DIENTICH\" },\r\n            { \"data\": null }\r" +
"\n        ]\r\n\r\n        var columnDefs = [\r\n            {\r\n                \"target" +
"s\": 0,\r\n                \"visible\": false\r\n            },\r\n            {\r\n       " +
"         \"targets\": 1,\r\n                \"render\": function () {\r\n               " +
"     return \"<input type=\'checkbox\'/>\";\r\n                },\r\n                \"cl" +
"assName\": \"text-center\"\r\n            },\r\n            {\r\n                \"targets" +
"\": 2,\r\n                \"className\": \"text-right\"\r\n            },\r\n            {\r" +
"\n                \"targets\": [3, 4, 5],\r\n                \"className\": \"text-cente" +
"r\"\r\n            }\r\n        ]\r\n\r\n        var options = {\r\n            \"pageLength" +
"\": 5,\r\n            \"ordering\": false,\r\n            \"autoWidth\": false,\r\n        " +
"    \"columns\": columns,\r\n            \"columnDefs\": columnDefs,\r\n            \"dom" +
"\": \"t<\'row p-0\'<\'col-xs-6 p-0\'<\'row p-0\'<\'col-xs-6 p-0\'<\'#Table_DSTaiSanID_divBT" +
"Save\'>><\'col-xs-6 p-0\' >>><\'col-xs-6 p-0\'<\'pull-right\'p>>>\",\r\n            \"initC" +
"omplete\": function () {\r\n                initComplete();\r\n            }\r\n       " +
" }\r\n\r\n        function initComplete() {\r\n            $(\'#Table_DSTaiSanID_btnSav" +
"e\').appendTo($(\'#Table_DSTaiSanID_divBTSave\'));\r\n        }\r\n\r\n        var Table_" +
"DSTaiSanID = $(\'#Table_DSTaiSanID\').DataTable(options);\r\n\r\n        ProcessCheckB" +
"ox(Table_DSTaiSanID, $(\'#checkall_QuyenSHTAISANThua\'));\r\n\r\n        $(\'#Table_DST" +
"aiSanID_btnSave\').on(\'click\', function () {\r\n            var arrSel = [];\r\n     " +
"       $.each(Table_DSTaiSanID.rows().nodes(), function () {\r\n                if" +
" ($(\'[type=checkbox]\', this).is(\':checked\')) {\r\n                    arrSel.push(" +
"Table_DSTaiSanID.row(this).data().TAISANGANLIENVOIDATID);\r\n                }\r\n  " +
"          });\r\n            if (arrSel.length == 0) {\r\n                alert(\'Vui" +
" lòng chọn ít nhất một Tài Sản?\')\r\n            } else {\r\n                $.ajax(" +
"{\r\n                    type: \"POST\",\r\n                    url: \"/XLHSGiayChungNh" +
"an/Save_Popup_ThemQuyenVaoGCN\",\r\n                    data: { data: JSON.stringif" +
"y(arrSel), isQuyen: \'");

            
            #line 116 "..\..\Views\XLHSGiayChungNhan\Popup_DSTaiSan.cshtml"
                                                               Write(Model.ISQuyen);

            
            #line default
            #line hidden
WriteLiteral(@"', thuaTheo: 2 },
                    dataType: ""json"",
                    success: function (result) {
                        if (result.success) {
                            $(""#modalformDSTaiSan"").modal('hide');
                            $('#divGCN_Main_SHTaiSanID').load('/XLHSGiayChungNhan/GiayChungNhan_Main_SHTaiSan');
                        }
                        alert(result.message);
                    }
                })
            }
        })
    })
</script>");

        }
    }
}
#pragma warning restore 1591