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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/TTBienDong/_BienDong_BD.cshtml")]
    public partial class _Views_TTBienDong__BienDong_BD_cshtml : System.Web.Mvc.WebViewPage<MPLIS.Libraries.Data.XuLyHoSo.Models.TTChungBienDongVM>
    {
        public _Views_TTBienDong__BienDong_BD_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<form");

WriteLiteral(" id=\"IDformBienDong_BD\"");

WriteLiteral(">\r\n");

WriteLiteral("    ");

            
            #line 4 "..\..\Views\TTBienDong\_BienDong_BD.cshtml"
Write(Html.HiddenFor(model => model.BIENDONGID));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 5 "..\..\Views\TTBienDong\_BienDong_BD.cshtml"
Write(Html.HiddenFor(model => model.QUYETDINHID));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 6 "..\..\Views\TTBienDong\_BienDong_BD.cshtml"
Write(Html.HiddenFor(model => model.MABIENDONG));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 7 "..\..\Views\TTBienDong\_BienDong_BD.cshtml"
Write(Html.HiddenFor(model => model.isCOTTRIENG, new { id = "ckisCOTTRIENGID" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 8 "..\..\Views\TTBienDong\_BienDong_BD.cshtml"
Write(Html.HiddenFor(model => model.HOSOTIEPNHANID));

            
            #line default
            #line hidden
WriteLiteral("\r\n    <div");

WriteLiteral(" class=\"box box-primary\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"box-header with-border\"");

WriteLiteral(">\r\n            <h3");

WriteLiteral(" class=\"box-title\"");

WriteLiteral(">Chỉ số biến động</h3>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"box-body\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 16 "..\..\Views\TTBienDong\_BienDong_BD.cshtml"
               Write(Html.LabelFor(model => model.MAHOSOTHUTUCDANGKY, "STT hồ sơ ĐK", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 19 "..\..\Views\TTBienDong\_BienDong_BD.cshtml"
               Write(Html.TextBoxFor(model => model.MAHOSOTHUTUCDANGKY, "", new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 22 "..\..\Views\TTBienDong\_BienDong_BD.cshtml"
               Write(Html.LabelFor(model => model.SOTHUTU, "STT biến động", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 25 "..\..\Views\TTBienDong\_BienDong_BD.cshtml"
               Write(Html.TextBoxFor(model => model.SOTHUTU, "", new { @class = "form-control input-sm", @type = "number" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(" id=\"divLoaiBienDongID\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 30 "..\..\Views\TTBienDong\_BienDong_BD.cshtml"
               Write(Html.LabelFor(model => model.LOAIBIENDONGID, "Loại biến động", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 33 "..\..\Views\TTBienDong\_BienDong_BD.cshtml"
               Write(Html.DropDownListFor(model => model.LOAIBIENDONGID, ViewBag.DM_LOAIBIENDONG_list as SelectList, new { id = "ListLoaibiendongid", @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 38 "..\..\Views\TTBienDong\_BienDong_BD.cshtml"
               Write(Html.LabelFor(model => model.MAHSTTDANGKY, "Mã hồ sơ đăng ký", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 41 "..\..\Views\TTBienDong\_BienDong_BD.cshtml"
               Write(Html.TextBoxFor(model => model.MAHSTTDANGKY, "", new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 44 "..\..\Views\TTBienDong\_BienDong_BD.cshtml"
               Write(Html.LabelFor(model => model.THOIDIEMBIENDONG, "Thời điểm biến động", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 47 "..\..\Views\TTBienDong\_BienDong_BD.cshtml"
               Write(Html.TextBoxFor(model => model.THOIDIEMBIENDONG, "{0:yyyy-MM-dd}", new { @type = "date", @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 52 "..\..\Views\TTBienDong\_BienDong_BD.cshtml"
               Write(Html.LabelFor(model => model.SOQUYETDINH, "Quyết định liên quan", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 55 "..\..\Views\TTBienDong\_BienDong_BD.cshtml"
               Write(Html.TextBoxFor(model => model.SOQUYETDINH, "", new { id = "quyetdinhlienquanRL", @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-6\"");

WriteLiteral(">\r\n                    <button");

WriteLiteral(" class=\"btn-sm btn-inform\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" onclick=\"ChiTietQuyetDinh()\"");

WriteLiteral(">Chi tiết quyết định</button>\r\n                </div>\r\n            </div>\r\n      " +
"  </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"box box-primary\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"box-header with-border\"");

WriteLiteral(">\r\n            <h3");

WriteLiteral(" class=\"box-title\"");

WriteLiteral(">Thông tin hợp đồng, công chứng</h3>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"box-body\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 70 "..\..\Views\TTBienDong\_BienDong_BD.cshtml"
               Write(Html.LabelFor(model => model.SOHOPDONG, "Số hợp đồng", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 73 "..\..\Views\TTBienDong\_BienDong_BD.cshtml"
               Write(Html.TextBoxFor(model => model.SOHOPDONG, "", new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 76 "..\..\Views\TTBienDong\_BienDong_BD.cshtml"
               Write(Html.LabelFor(model => model.SOCONGCHUNG, "Số công chứng", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 79 "..\..\Views\TTBienDong\_BienDong_BD.cshtml"
               Write(Html.TextBoxFor(model => model.SOCONGCHUNG, "", new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 84 "..\..\Views\TTBienDong\_BienDong_BD.cshtml"
               Write(Html.LabelFor(model => model.QUYENCONGCHUNG, "Quyển công chứng", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 87 "..\..\Views\TTBienDong\_BienDong_BD.cshtml"
               Write(Html.TextBoxFor(model => model.QUYENCONGCHUNG, "", new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 90 "..\..\Views\TTBienDong\_BienDong_BD.cshtml"
               Write(Html.LabelFor(model => model.NGAYHOPDONG, "Ngày hợp đồng", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 93 "..\..\Views\TTBienDong\_BienDong_BD.cshtml"
               Write(Html.TextBoxFor(model => model.NGAYHOPDONG, "{0:yyyy-MM-dd}", new { @type = "date", @class = "form-control input-sm datepicker" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 98 "..\..\Views\TTBienDong\_BienDong_BD.cshtml"
               Write(Html.LabelFor(model => model.NGAYCONGCHUNG, "Ngày công chứng", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 101 "..\..\Views\TTBienDong\_BienDong_BD.cshtml"
               Write(Html.TextBoxFor(model => model.NGAYCONGCHUNG, "{0:yyyy-MM-dd}", new { @type = "date", @class = "form-control input-sm datepicker" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 104 "..\..\Views\TTBienDong\_BienDong_BD.cshtml"
               Write(Html.LabelFor(model => model.NGAYTRUOCBA, "Ngày trước bạ", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 107 "..\..\Views\TTBienDong\_BienDong_BD.cshtml"
               Write(Html.TextBoxFor(model => model.NGAYTRUOCBA, "{0:yyyy-MM-dd}", new { @type = "date", @class = "form-control input-sm datepicker" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 112 "..\..\Views\TTBienDong\_BienDong_BD.cshtml"
               Write(Html.LabelFor(model => model.NOICONGCHUNG, "Nơi công chứng", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 115 "..\..\Views\TTBienDong\_BienDong_BD.cshtml"
               Write(Html.TextBoxFor(model => model.NOICONGCHUNG, "", new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <di" +
"v");

WriteLiteral(" class=\"box box-primary\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"box-header with-border\"");

WriteLiteral(">\r\n            <h3");

WriteLiteral(" class=\"box-title\"");

WriteLiteral(">Thông tin biến động</h3>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"box-body\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 127 "..\..\Views\TTBienDong\_BienDong_BD.cshtml"
               Write(Html.LabelFor(model => model.LYDOBIENDONG, "Lý do biến động", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 130 "..\..\Views\TTBienDong\_BienDong_BD.cshtml"
               Write(Html.TextBoxFor(model => model.LYDOBIENDONG, "", new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 135 "..\..\Views\TTBienDong\_BienDong_BD.cshtml"
               Write(Html.LabelFor(model => model.NOIDUNGBIENDONG, "Nội dung biến động", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 138 "..\..\Views\TTBienDong\_BienDong_BD.cshtml"
               Write(Html.TextAreaFor(model => model.NOIDUNGBIENDONG, new { @class = "form-control", @rows = "3" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 143 "..\..\Views\TTBienDong\_BienDong_BD.cshtml"
               Write(Html.LabelFor(model => model.NOIDUNGHOPDONG, "Nội dung hợp đồng", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 146 "..\..\Views\TTBienDong\_BienDong_BD.cshtml"
               Write(Html.TextAreaFor(model => model.NOIDUNGHOPDONG, new { @class = "form-control", @rows = "3" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</form>" +
"\r\n\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
    //divLoaiBienDongID
    $(function () {
        if ($('#ListLoaibiendongid').val() != ""444444"") {
            $('#btn_ThongTinRieng_BDID').hide();
        }
        $('#ListLoaibiendongid').change(function () {
            var ckcottrienghaykoc = $('#ListLoaibiendongid').val();
            if ((ckcottrienghaykoc == ""444444"") || (ckcottrienghaykoc == ""45555555"")) {
                $('#divBienDongID_TTRIENG_THECHAP_CTQUYEN').load(""/TTBienDong/_BienDong_TTRIENG_THECHAP_TTQUYEN"", function (responseTxt, statusTxt, xhr) {
                });
                $('#div_BienDong_TTRIENG_ID').show();
                $('#btn_ThongTinRieng_BDID').show();
            }
            else {
                $('#divBienDongID_TTRIENG_THECHAP_CTQUYEN').html("""");
                $('#div_BienDong_TTRIENG_ID').hide();
                $('#btn_ThongTinRieng_BDID').hide();
            }
        });
    });
    function ChiTietQuyetDinh() {
        $.ajax({
            type: ""GET"",
            url: ""/TTBienDong/_PopupQuyetDinh"",
            success: function (html) {
                $('#dialogformQuyetDinhID').html(html);
                var options = {
                    backdrop: ""static"",
                    show: true
                }
                $(""#modalChiTietQDID"").modal(options);
            },
        });
    }
</script>
");

        }
    }
}
#pragma warning restore 1591
