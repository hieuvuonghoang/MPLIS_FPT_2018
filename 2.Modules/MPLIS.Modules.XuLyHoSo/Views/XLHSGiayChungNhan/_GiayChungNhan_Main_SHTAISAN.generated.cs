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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/XLHSGiayChungNhan/_GiayChungNhan_Main_SHTAISAN.cshtml")]
    public partial class _Views_XLHSGiayChungNhan__GiayChungNhan_Main_SHTAISAN_cshtml : System.Web.Mvc.WebViewPage<MPLIS.Libraries.Data.XuLyHoSo.Models.BoHoSoModel>
    {
        public _Views_XLHSGiayChungNhan__GiayChungNhan_Main_SHTAISAN_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" class=\"box\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"box-body\"");

WriteLiteral(">\r\n        <table");

WriteLiteral(" id=\"_GCN_Main_SHTAISAN_TableID\"");

WriteLiteral(" class=\"table table-bordered\"");

WriteLiteral(@">
            <thead>
                <tr>
                    <th>STT</th>
                    <th>Loại tài sản</th>
                    <th>Tên tài sản</th>
                    <th>Diện tích (m<sup>2</sup>)</th>
                    <th>Trạng thái</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
");

            
            #line 17 "..\..\Views\XLHSGiayChungNhan\_GiayChungNhan_Main_SHTAISAN.cshtml"
                
            
            #line default
            #line hidden
            
            #line 17 "..\..\Views\XLHSGiayChungNhan\_GiayChungNhan_Main_SHTAISAN.cshtml"
                 if (Model.CurDC_GIAYCHUNGNHAN != null && Model.CurDC_GIAYCHUNGNHAN.DSQuyenSHTS != null && Model.CurDC_GIAYCHUNGNHAN.DSQuyenSHTS.Count > 0)
                {
                    int sttdsQUYENSHTAISAN = 0;
                    foreach (var item in Model.CurDC_GIAYCHUNGNHAN.DSQuyenSHTS)
                    {
                        sttdsQUYENSHTAISAN = sttdsQUYENSHTAISAN + 1;

            
            #line default
            #line hidden
WriteLiteral("                        <tr");

WriteLiteral(" data-id=\"");

            
            #line 23 "..\..\Views\XLHSGiayChungNhan\_GiayChungNhan_Main_SHTAISAN.cshtml"
                                Write(item.QUYENSOHUUTAISANID);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">\r\n                            <td");

WriteLiteral(" class=\"text-right\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 25 "..\..\Views\XLHSGiayChungNhan\_GiayChungNhan_Main_SHTAISAN.cshtml"
                           Write(sttdsQUYENSHTAISAN);

            
            #line default
            #line hidden
WriteLiteral(".\r\n                            </td>\r\n                            <td>\r\n");

WriteLiteral("                                ");

            
            #line 28 "..\..\Views\XLHSGiayChungNhan\_GiayChungNhan_Main_SHTAISAN.cshtml"
                           Write(item.LoaiTaiSan);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n");

WriteLiteral("                                ");

            
            #line 31 "..\..\Views\XLHSGiayChungNhan\_GiayChungNhan_Main_SHTAISAN.cshtml"
                           Write(item.TenTaiSan);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                            <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 34 "..\..\Views\XLHSGiayChungNhan\_GiayChungNhan_Main_SHTAISAN.cshtml"
                           Write(item.DienTich);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                            <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 37 "..\..\Views\XLHSGiayChungNhan\_GiayChungNhan_Main_SHTAISAN.cshtml"
                            Write(item.TRANGTHAIPL == "T" ? "Đang thế chấp" : "Bình thường");

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                            <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 40 "..\..\Views\XLHSGiayChungNhan\_GiayChungNhan_Main_SHTAISAN.cshtml"
                           Write(Ajax.ActionLink("Xóa", "Remove_DSSHTAISAN_Row", "XLHSGiayChungNhan", new { quyenSHTSID = item.QUYENSOHUUTAISANID, gcnID = Model.CurDC_GIAYCHUNGNHAN.GIAYCHUNGNHANID },
                                new AjaxOptions
                                {
                                    HttpMethod = "POST",
                                    OnSuccess = "RemoveRow_GCN_Main_SHTAISAN_TableID",
                                    UpdateTargetId = "divGCN_Main_SHTAISANID",
                                    InsertionMode = InsertionMode.Replace
                                }, Model.CurDC_GIAYCHUNGNHAN.ThuocDangKy ? (object)new { @class = "btn btn-xs btn-heading", @title = "Xóa", @disabled = "" } : (object)new { @class = "btn btn-xs btn-heading", @title = "Xóa" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");

            
            #line 50 "..\..\Views\XLHSGiayChungNhan\_GiayChungNhan_Main_SHTAISAN.cshtml"
                    }
                }

            
            #line default
            #line hidden
WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
    var _GCN_Main_SHTAISAN_TableID;
    function RemoveRow_GCN_Main_SHTAISAN_TableID(objJson) {
        RemoveRowDataTable($('#_GCN_Main_SHTAISAN_TableID'), objJson.RowID);
    }
    $(document).ready(function () {
        _GCN_Main_SHTAISAN_TableID = InitDataTableXLHS($('#_GCN_Main_SHTAISAN_TableID'));
    });
</script>");

        }
    }
}
#pragma warning restore 1591
