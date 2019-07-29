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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/TTBienDong/_BienDong_DSTHUARA.cshtml")]
    public partial class _Views_TTBienDong__BienDong_DSTHUARA_cshtml : System.Web.Mvc.WebViewPage<MPLIS.Libraries.Data.XuLyHoSo.Models.DSThuaBDVM>
    {
        public _Views_TTBienDong__BienDong_DSTHUARA_cshtml()
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

WriteLiteral(">Danh sách thửa đầu ra</h3>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"box-body\"");

WriteLiteral(">\r\n        <table");

WriteLiteral(" id=\"table_DSTHUARAID\"");

WriteLiteral(" class=\"table table-bordered\"");

WriteLiteral(@">
            <thead>
                <tr>
                    <th>#</th>
                    <th>Xã/phường</th>
                    <th>SH tờ bản đồ</th>
                    <th>STT thửa</th>
                    <th>DT pháp lý (m2)</th>
                    <th>Địa chỉ</th>
                </tr>
            </thead>
            <tbody>
");

            
            #line 20 "..\..\Views\TTBienDong\_BienDong_DSTHUARA.cshtml"
                
            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\TTBienDong\_BienDong_DSTHUARA.cshtml"
                 if (Model.DSThua != null && Model.DSThua.Count() > 0)
                {
                    int rowDSTHUARAID = 0;
                    foreach (var item in Model.DSThua)
                    {
                        if (item.LOAITHUABD == "R")
                        {
                            rowDSTHUARAID = rowDSTHUARAID + 1;

            
            #line default
            #line hidden
WriteLiteral("                            <tr");

WriteLiteral(" data-id=\"");

            
            #line 28 "..\..\Views\TTBienDong\_BienDong_DSTHUARA.cshtml"
                                    Write(item.THUADATID);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">\r\n                                <td");

WriteLiteral(" class=\"text-right\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 30 "..\..\Views\TTBienDong\_BienDong_DSTHUARA.cshtml"
                               Write(rowDSTHUARAID);

            
            #line default
            #line hidden
WriteLiteral(".\r\n                                </td>\r\n                                <td>\r\n");

WriteLiteral("                                    ");

            
            #line 33 "..\..\Views\TTBienDong\_BienDong_DSTHUARA.cshtml"
                               Write(item.XaPhuong);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </td>\r\n                                <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 36 "..\..\Views\TTBienDong\_BienDong_DSTHUARA.cshtml"
                               Write(item.SHToBanDo);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </td>\r\n                                <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 39 "..\..\Views\TTBienDong\_BienDong_DSTHUARA.cshtml"
                               Write(item.STTThua);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </td>\r\n                                <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 42 "..\..\Views\TTBienDong\_BienDong_DSTHUARA.cshtml"
                               Write(item.DienTich);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n");

WriteLiteral("                                    ");

            
            #line 45 "..\..\Views\TTBienDong\_BienDong_DSTHUARA.cshtml"
                               Write(item.DiaChi);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </td>\r\n                            </tr>\r\n");

            
            #line 48 "..\..\Views\TTBienDong\_BienDong_DSTHUARA.cshtml"
                        }
                    }
                }

            
            #line default
            #line hidden
WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
    var W_DSTHUARAID;
    $(""#btn_dialog_DSTHUARAID"").button().on(""click"", function () {
        $.ajax({
            type: ""GET"",
            url: ""/TTBienDong/_Popup_DSTHUARA"",
            success: function (html) {
                $('#dialogformDSTHUARAID').html(html);
                W_DSTHUARAID = $(""#dialogformDSTHUARAID"").dialog({
                    autoOpen: false,
                    height: 400,
                    width: 800,
                    modal: true,
                    buttons: {
                        Cancel: function () {
                            W_DSTHUARAID.dialog(""close"");
                        }
                    },
                });
                W_DSTHUARAID.dialog(""open"");
            },
        });
    });
    $(document).ready(function () {
        InitDataTableXLHS($('#table_DSTHUARAID'));
    })
</script>");

        }
    }
}
#pragma warning restore 1591
