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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/TTBienDong/_Popup_DSCHU.cshtml")]
    public partial class _Views_TTBienDong__Popup_DSCHU_cshtml : System.Web.Mvc.WebViewPage<MPLIS.Libraries.Data.XuLyHoSo.Models.DSChuDonVM>
    {
        public _Views_TTBienDong__Popup_DSCHU_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" class=\'modal fade\'");

WriteLiteral(" id=\'modalformDSCHU\'");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\'modal-dialog modal-lg\'");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\'modal-content\'");

WriteLiteral(">\r\n");

            
            #line 6 "..\..\Views\TTBienDong\_Popup_DSCHU.cshtml"
            
            
            #line default
            #line hidden
            
            #line 6 "..\..\Views\TTBienDong\_Popup_DSCHU.cshtml"
             using (Ajax.BeginForm("Add_DSCHUVAO_RTABLE", "TTBienDong", new AjaxOptions()
            {
                OnSuccess = "alert('Thêm chủ đầu vào thành công!')",
                HttpMethod = "Post",
                UpdateTargetId = "divBienDongID_DSCHUVAO_Table",
                InsertionMode = InsertionMode.Replace
            }))
            {

            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" class=\'modal-header\'");

WriteLiteral(">\r\n                    <button");

WriteLiteral(" type=\'button\'");

WriteLiteral(" class=\'close\'");

WriteLiteral(" data-dismiss=\'modal\'");

WriteLiteral(">&times;</button>\r\n                    <h4");

WriteLiteral(" class=\'modal-title\'");

WriteLiteral(">Danh sách chủ trong đăng ký</h4>\r\n                </div>\r\n");

WriteLiteral("                <div");

WriteLiteral(" class=\'modal-body\'");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 19 "..\..\Views\TTBienDong\_Popup_DSCHU.cshtml"
               Write(Html.Hidden("VAITRO", "", new { id = "vaiTroID" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <table");

WriteLiteral(" class=\"table table-bordered\"");

WriteLiteral(" id=\"popuptable_DSCHUVAOID\"");

WriteLiteral(" data-toggle=\"table\"");

WriteLiteral(@">
                        <thead>
                            <tr>
                                <th>Chọn chủ</th>
                                <th>#</th>
                                <th>Loại chủ</th>
                                <th>Tên chủ</th>
                                <th>Địa chỉ</th>
                                <th>Chi tiết</th>
                            </tr>
                        </thead>
");

            
            #line 31 "..\..\Views\TTBienDong\_Popup_DSCHU.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 31 "..\..\Views\TTBienDong\_Popup_DSCHU.cshtml"
                          int rchumoivao = 0;
                            if (Model.DSDangKyChu != null)
                            {
                                foreach (var item in Model.DSDangKyChu)
                                {
                                    rchumoivao = rchumoivao + 1;

            
            #line default
            #line hidden
WriteLiteral("                                    <tr");

WriteLiteral(" data-id=\"");

            
            #line 37 "..\..\Views\TTBienDong\_Popup_DSCHU.cshtml"
                                            Write(item.NGUOIID);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">\r\n                                        <td");

WriteLiteral(" style=\"text-align: center;\"");

WriteLiteral(">\r\n                                            <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"DSCHUVAO_CHON\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1982), Tuple.Create("\"", 2003)
            
            #line 39 "..\..\Views\TTBienDong\_Popup_DSCHU.cshtml"
               , Tuple.Create(Tuple.Create("", 1990), Tuple.Create<System.Object, System.Int32>(item.NGUOIID
            
            #line default
            #line hidden
, 1990), false)
);

WriteLiteral(" />\r\n                                        </td>\r\n                             " +
"           <td");

WriteLiteral(" style=\"text-align: right;\"");

WriteLiteral(">\r\n");

WriteLiteral("                                            ");

            
            #line 42 "..\..\Views\TTBienDong\_Popup_DSCHU.cshtml"
                                       Write(rchumoivao);

            
            #line default
            #line hidden
WriteLiteral(".\r\n                                        </td>\r\n                               " +
"         <td>\r\n");

WriteLiteral("                                            ");

            
            #line 45 "..\..\Views\TTBienDong\_Popup_DSCHU.cshtml"
                                       Write(item.Chu_TenLoaiChu);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                        </td>\r\n                                " +
"        <td>\r\n");

WriteLiteral("                                            ");

            
            #line 48 "..\..\Views\TTBienDong\_Popup_DSCHU.cshtml"
                                       Write(item.Chu_HoTen);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                        </td>\r\n                                " +
"        <td>\r\n");

WriteLiteral("                                            ");

            
            #line 51 "..\..\Views\TTBienDong\_Popup_DSCHU.cshtml"
                                       Write(item.Chu_DiaChi);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                        </td>\r\n                                " +
"        <td");

WriteLiteral(" style=\"text-align: center;\"");

WriteLiteral(">\r\n");

WriteLiteral("                                            ");

            
            #line 54 "..\..\Views\TTBienDong\_Popup_DSCHU.cshtml"
                                       Write(Ajax.ActionLink("Chi tiết", "...", "TTBienDong", new { id = item.NGUOIID },
                                                             new AjaxOptions
                                                             {
                                                                 HttpMethod = "POST",
                                                                 //OnSuccess = "RemoveRow",
                                                                 //UpdateTargetId = "divBienDongID_DSCHUVAO",
                                                                 InsertionMode = InsertionMode.Replace
                                                             }, new { @class = "btn btn-xs btn-heading", @title = "Chi tiết" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                        </td>\r\n                                " +
"    </tr>\r\n");

            
            #line 64 "..\..\Views\TTBienDong\_Popup_DSCHU.cshtml"
                                }
                            }
                        
            
            #line default
            #line hidden
WriteLiteral("\r\n                    </table>\r\n                </div>\r\n");

WriteLiteral("                <div");

WriteLiteral(" class=\'modal-footer\'");

WriteLiteral(" style=\'text-align:center;\'");

WriteLiteral(">\r\n                    <button");

WriteLiteral(" type=\'submit\'");

WriteLiteral(" class=\'btn btn-primary btn-sm pull-right\'");

WriteLiteral(">Thêm vào GCN</button>\r\n                </div>\r\n");

            
            #line 72 "..\..\Views\TTBienDong\_Popup_DSCHU.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
    function toggleCheckeddschuvao(statusDSCHUVAO_CHON) {
        $(""#popuptable_DSCHUVAOID input"").each(function () {
            $(this).prop(""checked"", statusDSCHUVAO_CHON);
        });
    }
    function closeDialogDSCHUVAO() {
        $(""#modalformDSCHU"").modal('hide');
        alert('Thêm chủ đầu vào thành công!');
    }
    $(document).ready(function () {
        $(""#checkall_DSCHUVAO_CHON"").prop(""checked"", false);
        $(""#checkall_DSCHUVAO_CHON"").click(function () {
            var statusDSCHUVAO_CHON = $(""#checkall_DSCHUVAO_CHON"").prop(""checked"");
            toggleCheckeddschuvao(statusDSCHUVAO_CHON);
        });
        $(""#vaiTroID"").val($(""#listchovaitro_ttrieng"").val());
    });
</script>
");

        }
    }
}
#pragma warning restore 1591