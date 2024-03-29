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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/XLHSDangKy/_DonDangKy_KhuChungCu.cshtml")]
    public partial class _Views_XLHSDangKy__DonDangKy_KhuChungCu_cshtml : System.Web.Mvc.WebViewPage<MPLIS.Libraries.Data.XuLyHoSo.Models.VM_XuLyHoSo_DK>
    {
        public _Views_XLHSDangKy__DonDangKy_KhuChungCu_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" class=\'modal fade\'");

WriteLiteral(" id=\'modalformKhuChungCu\'");

WriteLiteral(">\r\n    <input");

WriteLiteral(" id=\"CurKCCID\"");

WriteLiteral(" name=\"CurKCCID\"");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" value=\"\"");

WriteLiteral(" style=\"display:none\"");

WriteLiteral(">\r\n    <div");

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

WriteLiteral(" id=\"title_popup_kcc\"");

WriteLiteral(">Khu Chung Cư</h4>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\'modal-body\'");

WriteLiteral(">\r\n                <div>\r\n                    <ul");

WriteLiteral(" class=\"nav nav-tabs nav-justified\"");

WriteLiteral(">\r\n                        <li");

WriteLiteral(" class=\"active\"");

WriteLiteral("> <a");

WriteLiteral(" class=\"mauchu-tab\"");

WriteLiteral(" href=\"#tabKhu\"");

WriteLiteral(" id=\"openTabKhu\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">Thông tin khu chung cư</a></li>\r\n                        <li>                <a");

WriteLiteral(" class=\"mauchu-tab\"");

WriteLiteral(" href=\"#tabNha\"");

WriteLiteral(" id=\"openTabNha\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">Nhà trong khu chung cư</a></li>\r\n                        <li>                <a");

WriteLiteral(" class=\"mauchu-tab\"");

WriteLiteral(" href=\"#tabHangmuc\"");

WriteLiteral(" id=\"openTabHangmuc\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">Hạng mục ngoài căn hộ</a></li>\r\n\r\n                    </ul>\r\n                   " +
" <div");

WriteLiteral(" class=\"tab-content\"");

WriteLiteral(" id=\"tabs\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"tab-pane fade in active\"");

WriteLiteral(" id=\"tabKhu\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 20 "..\..\Views\XLHSDangKy\_DonDangKy_KhuChungCu.cshtml"
                       Write(Html.Action("_ChiTietKhuChungCu",new {t= ViewBag.ID }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                        <div");

WriteLiteral(" class=\"tab-pane fade\"");

WriteLiteral(" id=\"tabNha\"");

WriteLiteral(">\r\n                        </div>\r\n                        <div");

WriteLiteral(" class=\"tab-pane fade\"");

WriteLiteral(" id=\"tabHangmuc\"");

WriteLiteral(@">
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</div>
<script>
    $(function () {
        var kccid = $('#CurKCCID').val();
        console.log(""kccid"" + kccid);
        $(""#openTabKhu"").on(""click"", function () {
            $.ajax({
                type: ""POST"",
                url: ""/XLHSDangKy/_ChiTietKhuChungCu"",
                data:{t : kccid.trim()},
                dataType: ""html"",
                success: function (response, startus, xhr) {
                    $(""#tabKhu"").html(response);
                },
            });
        });
        $(""#openTabNha"").on(""click"", function () {
            $.ajax({
                type: ""POST"",
                url: ""/XLHSDangKy/_ChiTietNhaChungCu"",
                data: { t: kccid.trim() },
                dataType: ""html"",
                success: function (response, startus, xhr) {
                    $(""#tabNha"").html(response);
                },
            });
        });
        $(""#openTabHangmuc"").on(""click"", function () {
            $.ajax({
                type: ""POST"",
                url: ""/XLHSDangKy/_ChiTietHangMucNCH"",
                data: { t: kccid.trim() },
                dataType: ""html"",
                success: function (response, startus, xhr) {
                    $(""#tabHangmuc"").html(response);
                },
            });
        });

    });

</script>
");

        }
    }
}
#pragma warning restore 1591
