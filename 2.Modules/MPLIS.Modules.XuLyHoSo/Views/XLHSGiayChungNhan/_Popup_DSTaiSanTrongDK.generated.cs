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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/XLHSGiayChungNhan/_Popup_DSTaiSanTrongDK.cshtml")]
    public partial class _Views_XLHSGiayChungNhan__Popup_DSTaiSanTrongDK_cshtml : System.Web.Mvc.WebViewPage<MPLIS.Libraries.Data.XuLyHoSo.Models.DanhSachTaiSanVM>
    {
        public _Views_XLHSGiayChungNhan__Popup_DSTaiSanTrongDK_cshtml()
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

WriteLiteral(">Danh sách tài sản trong đăng ký</h4>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\'modal-body\'");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 11 "..\..\Views\XLHSGiayChungNhan\_Popup_DSTaiSanTrongDK.cshtml"
           Write(Html.HiddenFor(Model => Model.GiayChungNhanID));

            
            #line default
            #line hidden
WriteLiteral("\r\n                <table");

WriteLiteral(" class=\"table table-bordered\"");

WriteLiteral(" id=\"popuptableSHTAISAN_THUAID\"");

WriteLiteral(" data-toggle=\"table\"");

WriteLiteral(">\r\n                    <thead>\r\n                        <tr>\r\n                   " +
"         <th><input");

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

            
            #line 24 "..\..\Views\XLHSGiayChungNhan\_Popup_DSTaiSanTrongDK.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\XLHSGiayChungNhan\_Popup_DSTaiSanTrongDK.cshtml"
                         if (Model.DSTaiSanVM != null && Model.DSTaiSanVM.Count > 0)
                        {
                            int stt = 0;
                            foreach (var item in Model.DSTaiSanVM)
                            {
                                stt++;

            
            #line default
            #line hidden
WriteLiteral("                                <tr");

WriteLiteral(" data-id=\"");

            
            #line 30 "..\..\Views\XLHSGiayChungNhan\_Popup_DSTaiSanTrongDK.cshtml"
                                        Write(item.TaiSanGanLienVoiDatID);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">\r\n                                    <td");

WriteLiteral(" style=\'text-align: center;\'");

WriteLiteral(">\r\n                                        <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"DSSHTAISANTHUA_CHON\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1646), Tuple.Create("\"", 1681)
            
            #line 32 "..\..\Views\XLHSGiayChungNhan\_Popup_DSTaiSanTrongDK.cshtml"
                 , Tuple.Create(Tuple.Create("", 1654), Tuple.Create<System.Object, System.Int32>(item.TaiSanGanLienVoiDatID
            
            #line default
            #line hidden
, 1654), false)
);

WriteLiteral(" />\r\n                                    </td>\r\n                                 " +
"   <td");

WriteLiteral(" style=\"text-align: right;\"");

WriteLiteral(">\r\n");

WriteLiteral("                                        ");

            
            #line 35 "..\..\Views\XLHSGiayChungNhan\_Popup_DSTaiSanTrongDK.cshtml"
                                   Write(stt);

            
            #line default
            #line hidden
WriteLiteral(".\r\n                                    </td>\r\n                                   " +
" <td>\r\n");

WriteLiteral("                                        ");

            
            #line 38 "..\..\Views\XLHSGiayChungNhan\_Popup_DSTaiSanTrongDK.cshtml"
                                   Write(item.LoaiTaiSan);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    </td>\r\n                                    " +
"<td>\r\n");

WriteLiteral("                                        ");

            
            #line 41 "..\..\Views\XLHSGiayChungNhan\_Popup_DSTaiSanTrongDK.cshtml"
                                   Write(item.TenTaiSan);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    </td>\r\n                                    " +
"<td");

WriteLiteral(" style=\"text-align: center;\"");

WriteLiteral(">\r\n");

WriteLiteral("                                        ");

            
            #line 44 "..\..\Views\XLHSGiayChungNhan\_Popup_DSTaiSanTrongDK.cshtml"
                                   Write(item.DienTich);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    </td>\r\n                                    " +
"<td");

WriteLiteral(" style=\"text-align: center;\"");

WriteLiteral(">\r\n");

WriteLiteral("                                        ");

            
            #line 47 "..\..\Views\XLHSGiayChungNhan\_Popup_DSTaiSanTrongDK.cshtml"
                                   Write(Ajax.ActionLink("Chi tiết", "", "", new { id = item.TaiSanGanLienVoiDatID },
                                            new AjaxOptions
                                            {
                                                HttpMethod = "POST",
                                                //OnSuccess = "RemoveRow",
                                                //UpdateTargetId = "divBienDongID_DSCHUVAO",
                                                InsertionMode = InsertionMode.Replace
                                            }, new { @class = "btn btn-xs btn-heading", @title = "Chi tiết" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    </td>\r\n                                </tr" +
">\r\n");

            
            #line 57 "..\..\Views\XLHSGiayChungNhan\_Popup_DSTaiSanTrongDK.cshtml"
                            }
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n     " +
"       <div");

WriteLiteral(" class=\'modal-footer\'");

WriteLiteral(" style=\'text-align:center;\'");

WriteLiteral(">\r\n                <button");

WriteLiteral(" type=\'button\'");

WriteLiteral(" class=\'btn btn-primary btn-sm pull-right\'");

WriteLiteral(" onclick=\"GCN_QSHTS_ThemGCN()\"");

WriteLiteral(">Thêm vào GCN</button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n<" +
"script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
    var tableSHTAISAN
    function GCN_QSHTS_ThemGCN() {
        $.ajax({
            type: ""POST"",
            url: ""/XLHSGiayChungNhan/Add_DSSHTAISAN_RTABLE_THUA"",
            data: { dSSHTaiSan: GetDSCheck(tableSHTAISAN), GiayChungNhanID: $('#GiayChungNhanID').attr('value') },
            success: function (html) {
                $('#divGCN_Main_SHTaiSanID').html(html);
                alert(""Thêm quyền sở hữu tài sản thành công!"");
            },
        });
    }
    $(document).ready(function () {
        //Draw DataTable cho TaiSan
        tableSHTAISAN = InitDataTableXLHS($('#popuptableSHTAISAN_THUAID'));
        //Xử lý checkBox cho tableSHTAISAN
        ProcessCheckBox(tableSHTAISAN, $('#checkall_QuyenSHTAISANThua'));
    });
</script>

");

        }
    }
}
#pragma warning restore 1591