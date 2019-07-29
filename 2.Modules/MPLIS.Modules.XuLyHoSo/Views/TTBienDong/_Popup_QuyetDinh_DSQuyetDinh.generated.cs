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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/TTBienDong/_Popup_QuyetDinh_DSQuyetDinh.cshtml")]
    public partial class _Views_TTBienDong__Popup_QuyetDinh_DSQuyetDinh_cshtml : System.Web.Mvc.WebViewPage<MPLIS.Libraries.Data.XuLyHoSo.Models.DSQuyetDinhVM>
    {
        public _Views_TTBienDong__Popup_QuyetDinh_DSQuyetDinh_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" class=\'modal fade\'");

WriteLiteral(" id=\'modalDanhSachQuyetDinhID\'");

WriteLiteral(" role=\"dialog\"");

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

WriteLiteral(">Danh sách quyết định</h4>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\'modal-body\'");

WriteLiteral(">\r\n                <table");

WriteLiteral(" class=\"table table-bordered\"");

WriteLiteral(" id=\"dSQDTableID\"");

WriteLiteral(" data-toggle=\"table\"");

WriteLiteral(@">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Số hợp đồng</th>
                            <th>Số công chứng</th>
                            <th>Quyển công chứng</th>
                            <th>Nơi công chứng</th>
                            <th>Ngày công chứng</th>
                        </tr>
                    </thead>
                    <tbody>
");

            
            #line 22 "..\..\Views\TTBienDong\_Popup_QuyetDinh_DSQuyetDinh.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 22 "..\..\Views\TTBienDong\_Popup_QuyetDinh_DSQuyetDinh.cshtml"
                          
                            int stt = 0;
                            foreach (var item in Model.DSQuyetDinh)
                            {
                                stt++;

            
            #line default
            #line hidden
WriteLiteral("                                <tr");

WriteLiteral(" data-id=\"");

            
            #line 27 "..\..\Views\TTBienDong\_Popup_QuyetDinh_DSQuyetDinh.cshtml"
                                        Write(item.QUYETDINHID);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">\r\n                                    <td");

WriteLiteral(" class=\"text-right\"");

WriteLiteral(">\r\n");

WriteLiteral("                                        ");

            
            #line 29 "..\..\Views\TTBienDong\_Popup_QuyetDinh_DSQuyetDinh.cshtml"
                                   Write(stt);

            
            #line default
            #line hidden
WriteLiteral(".\r\n                                    </td>\r\n                                   " +
" <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n");

WriteLiteral("                                        ");

            
            #line 32 "..\..\Views\TTBienDong\_Popup_QuyetDinh_DSQuyetDinh.cshtml"
                                   Write(item.SOHOPDONG);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    </td>\r\n                                    " +
"<td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n");

WriteLiteral("                                        ");

            
            #line 35 "..\..\Views\TTBienDong\_Popup_QuyetDinh_DSQuyetDinh.cshtml"
                                   Write(item.SOCONGCHUNG);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    </td>\r\n                                    " +
"<td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n");

WriteLiteral("                                        ");

            
            #line 38 "..\..\Views\TTBienDong\_Popup_QuyetDinh_DSQuyetDinh.cshtml"
                                   Write(item.QUYENCONGCHUNG);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    </td>\r\n                                    " +
"<td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n");

WriteLiteral("                                        ");

            
            #line 41 "..\..\Views\TTBienDong\_Popup_QuyetDinh_DSQuyetDinh.cshtml"
                                   Write(item.NOICONGCHUNG);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    </td>\r\n                                    " +
"<td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n");

WriteLiteral("                                        ");

            
            #line 44 "..\..\Views\TTBienDong\_Popup_QuyetDinh_DSQuyetDinh.cshtml"
                                   Write(item.NGAYCONGCHUNG);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    </td>\r\n                                </tr" +
">\r\n");

            
            #line 47 "..\..\Views\TTBienDong\_Popup_QuyetDinh_DSQuyetDinh.cshtml"
                            }
                        
            
            #line default
            #line hidden
WriteLiteral("\r\n                    </tbody>\r\n                </table>\r\n            </div>\r\n   " +
"         <div");

WriteLiteral(" class=\'modal-footer\'");

WriteLiteral(" style=\'text-align:center;\'");

WriteLiteral(">\r\n                <button");

WriteLiteral(" type=\'button\'");

WriteLiteral(" class=\'t100 btn btn-primary btn-sm pull-right\'");

WriteLiteral(" onclick=\"Chon_QuyetDinh()\"");

WriteLiteral(">Chọn</button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<script" +
"");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n    var dSQDTableID = InitDataTableXLHS($(\'#dSQDTableID\'));\r\n    ActiveRowData" +
"Table(dSQDTableID, \'activerow\');\r\n    function Chon_QuyetDinh() {\r\n        conso" +
"le.log(\'Chờ xử lý\');\r\n    }\r\n</script>\r\n");

        }
    }
}
#pragma warning restore 1591
