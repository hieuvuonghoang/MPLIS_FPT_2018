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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/XLHSGiayChungNhan/Popup_SetTLSH.cshtml")]
    public partial class _Views_XLHSGiayChungNhan_Popup_SetTLSH_cshtml : System.Web.Mvc.WebViewPage<MPLIS.Libraries.Data.XuLyHoSo.Models.GCNTiLeSoHuuVM>
    {
        public _Views_XLHSGiayChungNhan_Popup_SetTLSH_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" class=\'modal fade\'");

WriteLiteral(" id=\'modalSetGCNTLSHID\'");

WriteLiteral(" role=\"dialog\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\'modal-dialog modal-dialog-centered\'");

WriteLiteral(" role=\"document\"");

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

WriteLiteral(">Tỷ lệ sở hữu cho thành viên</h4>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\'modal-body\'");

WriteLiteral(">\r\n                <form");

WriteLiteral(" id=\"formTLSHID\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 12 "..\..\Views\XLHSGiayChungNhan\Popup_SetTLSH.cshtml"
               Write(Html.HiddenFor(model => model.GCNTILESHID));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"col-xs-3\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 15 "..\..\Views\XLHSGiayChungNhan\Popup_SetTLSH.cshtml"
                       Write(Html.LabelFor(model => model.TILESOHUU, "Tỷ lệ sở hữu", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                        <div");

WriteLiteral(" class=\"col-xs-9\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 18 "..\..\Views\XLHSGiayChungNhan\Popup_SetTLSH.cshtml"
                       Write(Html.TextBoxFor(model => model.TILESOHUU, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                   " +
" <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"col-xs-3\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 23 "..\..\Views\XLHSGiayChungNhan\Popup_SetTLSH.cshtml"
                       Write(Html.LabelFor(model => model.LOAIDTMIENGIAMID, "Loại đối tượng miễn giảm", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                        <div");

WriteLiteral(" class=\"col-xs-9\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 26 "..\..\Views\XLHSGiayChungNhan\Popup_SetTLSH.cshtml"
                       Write(Html.DropDownListFor(model => model.LOAIDTMIENGIAMID, new SelectList(ViewBag.dSLoaiMienGiam, "LOAIDTMIENGIAMID", "TENLOAIDOITUONG"), "-- Chọn --", new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </f" +
"orm>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\'modal-footer\'");

WriteLiteral(">\r\n                <button");

WriteLiteral(" id=\"btnSubmit_formTLSHID\"");

WriteLiteral(" type=\'button\'");

WriteLiteral(" class=\'btn btn-default btn-sm pull-right\'");

WriteLiteral("><i");

WriteLiteral(" class=\'fa fa-check\'");

WriteLiteral("></i> Xong</button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<s" +
"cript");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
    $(document).ready(function () {
        $('#btnSubmit_formTLSHID').on('click', function () {
            var objTLSH = FormToObject($('#formTLSHID'))
            $.ajax({
                type: ""POST"",
                url: ""/XLHSGiayChungNhan/Save_Popup_SetTLSH"",
                data: { data: JSON.stringify(objTLSH) },
                dataType: ""json"",
                success: function () {
                    $.ajax({
                        type: ""POST"",
                        url: ""/XLHSGiayChungNhan/GiayChungNhan_Main_TLSH"",
                        dataType: ""html"",
                        success: function (html) {
                            $('#divGCN_TLSH_ID').html(html);
                        }
                    })
                }
            })
        })
    })
</script>
");

        }
    }
}
#pragma warning restore 1591
