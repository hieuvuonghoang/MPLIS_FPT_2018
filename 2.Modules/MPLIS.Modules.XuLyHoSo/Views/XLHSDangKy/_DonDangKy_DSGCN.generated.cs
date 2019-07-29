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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/XLHSDangKy/_DonDangKy_DSGCN.cshtml")]
    public partial class _Views_XLHSDangKy__DonDangKy_DSGCN_cshtml : System.Web.Mvc.WebViewPage<MPLIS.Libraries.Data.XuLyHoSo.Models.VM_XuLyHoSo_DK>
    {
        public _Views_XLHSDangKy__DonDangKy_DSGCN_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\XLHSDangKy\_DonDangKy_DSGCN.cshtml"
Write(Html.HiddenFor(model => Model.DONDANGKYID));

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"box box-primary\"");

WriteLiteral("  id=\"Div_GCN_DK\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"box-header with-border\"");

WriteLiteral(">\r\n        <h3");

WriteLiteral(" class=\"box-title\"");

WriteLiteral(">Giấy chứng nhận đã đăng ký</h3>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"box-body\"");

WriteLiteral(" style=\"padding-bottom:5px;\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-xs-5\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-xs-5\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 12 "..\..\Views\XLHSDangKy\_DonDangKy_DSGCN.cshtml"
               Write(Html.LabelFor(model => model.ADD_GCN_SOPHATHANH, "Số phát hành", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-7\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 15 "..\..\Views\XLHSDangKy\_DonDangKy_DSGCN.cshtml"
               Write(Html.TextBoxFor(model => model.ADD_GCN_SOPHATHANH, "", new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-5\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-xs-5\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 20 "..\..\Views\XLHSDangKy\_DonDangKy_DSGCN.cshtml"
               Write(Html.LabelFor(model => model.ADD_GCN_MAVACH, "Mã vạch", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-7\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 23 "..\..\Views\XLHSDangKy\_DonDangKy_DSGCN.cshtml"
               Write(Html.TextBoxFor(model => model.ADD_GCN_MAVACH, "", new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n                <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" onclick=\"ADD_GCNClick()\"");

WriteLiteral(" class=\"btn-sm btn-inform\"");

WriteLiteral(">Thêm</button>\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <table");

WriteLiteral(" id=\"table_DSGCNVAOID\"");

WriteLiteral(" class=\"table table-bordered\"");

WriteLiteral(">\r\n                <thead>\r\n                    <tr>\r\n                        <th" +
"");

WriteLiteral(" hidden=\"true\"");

WriteLiteral(@">GCN_ID</th>
                        <th>#</th>
                        <th>Số phát hành</th>
                        <th>Mã vạch</th>
                        <th>Trạng thái</th>
                        <th>Là cha</th>
                        <th>Hành động</th>
                    </tr>
                </thead>
                <tbody>
");

            
            #line 44 "..\..\Views\XLHSDangKy\_DonDangKy_DSGCN.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 44 "..\..\Views\XLHSDangKy\_DonDangKy_DSGCN.cshtml"
                      int rdsgcntable = 0;
                        if (Model != null)
                        {
                            if (Model.GCN_DANGKY != null)
                            {
                                foreach (var item in Model.GCN_DK)
                                {
                                    if (item.themxoa != 3)
                                    {
                                        rdsgcntable = rdsgcntable + 1;

            
            #line default
            #line hidden
WriteLiteral("                                        <tr");

WriteLiteral(" data-id=\"");

            
            #line 54 "..\..\Views\XLHSDangKy\_DonDangKy_DSGCN.cshtml"
                                                Write(item.GIAYCHUNGNHANID);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">\r\n                                            <td");

WriteLiteral(" hidden=\"true\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                ");

            
            #line 56 "..\..\Views\XLHSDangKy\_DonDangKy_DSGCN.cshtml"
                                           Write(item.GIAYCHUNGNHANID);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                            </td>\r\n                            " +
"                <td");

WriteLiteral(" style=\"text-align: right;\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                ");

            
            #line 59 "..\..\Views\XLHSDangKy\_DonDangKy_DSGCN.cshtml"
                                           Write(rdsgcntable);

            
            #line default
            #line hidden
WriteLiteral(".\r\n                                            </td>\r\n                           " +
"                 <td>\r\n");

WriteLiteral("                                                ");

            
            #line 62 "..\..\Views\XLHSDangKy\_DonDangKy_DSGCN.cshtml"
                                           Write(item.SoPhatHanh);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                            </td>\r\n                            " +
"                <td");

WriteLiteral(" style=\"text-align: center;\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                ");

            
            #line 65 "..\..\Views\XLHSDangKy\_DonDangKy_DSGCN.cshtml"
                                           Write(item.MaVach);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                            </td>\r\n                            " +
"                <td");

WriteLiteral(" style=\"text-align: center;\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                ");

            
            #line 68 "..\..\Views\XLHSDangKy\_DonDangKy_DSGCN.cshtml"
                                           Write(item.TrangThai);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                            </td>\r\n                            " +
"                <td");

WriteLiteral(" style=\"text-align: center;\"");

WriteLiteral(">\r\n                                                <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"Array_DSGCNCHA\"");

WriteAttribute("value", Tuple.Create(" value=\"", 3582), Tuple.Create("\"", 3611)
            
            #line 71 "..\..\Views\XLHSDangKy\_DonDangKy_DSGCN.cshtml"
                    , Tuple.Create(Tuple.Create("", 3590), Tuple.Create<System.Object, System.Int32>(item.GIAYCHUNGNHANID
            
            #line default
            #line hidden
, 3590), false)
);

WriteLiteral(" />\r\n                                            </td>\r\n                         " +
"                   <td>\r\n                                                ");

WriteLiteral("\r\n");

WriteLiteral("                                                ");

            
            #line 82 "..\..\Views\XLHSDangKy\_DonDangKy_DSGCN.cshtml"
                                           Write(Ajax.ActionLink("Chi tiết", "_GiayChungNhan", "XLHSGiayChungNhan", new { id = item.GIAYCHUNGNHANID, loaiGCN = 0 },
                                    new AjaxOptions
                                    {
                                        HttpMethod = "POST",
                                        //OnSuccess = "RemoveRow",
                                        UpdateTargetId = "bhs-tabID",
                                        InsertionMode = InsertionMode.Replace
                                    }, new { @class = "btn btn-xs btn-heading", @title = "Chi tiết thông tin GCN" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                <input");

WriteLiteral(" style=\"color:#3c8dbc\"");

WriteLiteral(" class=\"btn btn-xs btn-heading\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" value=\"Xóa\"");

WriteLiteral(" onclick=\"removeRowgcn(this)\"");

WriteLiteral(" />\r\n                                            </td>\r\n                         " +
"               </tr>\r\n");

            
            #line 93 "..\..\Views\XLHSDangKy\_DonDangKy_DSGCN.cshtml"
                                    }

                                }
                            }
                        }
                    
            
            #line default
            #line hidden
WriteLiteral("\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</d" +
"iv>\r\n\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
        InitDataTableXLHS($('#table_DSGCNVAOID'));
    var arrHead = new Array();
    arrHead = ['STT', 'sophathanh', 'mavach', 'trangthai', 'lacha', 'hanhdong'];
    //function ADD_GCNClick() {
    //    $.ajax({
    //        type: ""POST"",
    //        url: ""/XLHSDangKy/ADD_GCNDANGKY"",
    //        data: formDSGCN_ADD.serialize(),
    //        success: function (html) {
    //            $('#divDSGCN_TABLEID').html(html);
    //            //alert(""Thêm thành công"");
    //        },
    //    });
    //};
    function ADD_GCNClick() {
        var sophathanh = $(""#ADD_GCN_SOPHATHANH"").val();
        var mavach = $(""#ADD_GCN_MAVACH"").val();
        var dondangkyid = $('#DONDANGKYID').val();");

WriteLiteral(@"

        $.ajax({
            type: ""POST"",

            url: ""/XLHSDangKy/ADD_GCNDANGKY"",
            data: { sph: sophathanh.trim(), mv: mavach.trim(), dondangky_id: dondangkyid.trim() },
            success: function (data) {
                //  $('#divDSGCN_TABLEID').html(html);
                console.log(""GCNDK"");
                if (data == true) {
                    alert(""GCN đã được gắn vào đăng ký"");
                }
                else if (data == false) {
                    alert(""Không tồn tại Gcn trên hệ thống"");
                }
                else {
                    $('#Div_GCN_DK').html(data);
                }
            },
        });

    };
    function removeRowgcn(oButton) {
        var ans = confirm(""Bạn chắc chắn muốn xóa?"");
        //=== If user pressed Ok then delete the record else do nothing.
        if (ans == true) {
            var empTab = document.getElementById('table_DSGCNVAOID');
            var index = oButton.parentNode.parentNode.rowIndex;
            alert(index);
            var gcnid = empTab.rows[index].cells[0].innerHTML;
            var dondangkyid = $('#DONDANGKYID').val();");

WriteLiteral(@"
            empTab.deleteRow(oButton.parentNode.parentNode.rowIndex);
            $.ajax({
                type: ""POST"",

                url: ""/XLHSDangKy/XOA_GCNDANGKY"",
                dataType: ""html"",
                data: { gcn: gcnid, dondangky_id: dondangkyid },
                success: function (html) {
                    console.log(""SUCCES"");
                    alert(""Xóa  thành công!"");
                    $('#Div_GCN_DK').html(html);
                },
            });

        }

    }
    $(function () {

        ");

WriteLiteral("\r\n    });\r\n</script>\r\n");

        }
    }
}
#pragma warning restore 1591
