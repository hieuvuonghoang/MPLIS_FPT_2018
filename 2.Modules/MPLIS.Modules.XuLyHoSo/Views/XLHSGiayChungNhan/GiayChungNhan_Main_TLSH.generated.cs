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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/XLHSGiayChungNhan/GiayChungNhan_Main_TLSH.cshtml")]
    public partial class _Views_XLHSGiayChungNhan_GiayChungNhan_Main_TLSH_cshtml : System.Web.Mvc.WebViewPage<MPLIS.Libraries.Data.XuLyHoSo.Models.GiayChungNhanLS>
    {
        public _Views_XLHSGiayChungNhan_GiayChungNhan_Main_TLSH_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" class=\"box\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"box-body\"");

WriteLiteral(">\r\n        <table");

WriteLiteral(" id=\"TableTVNNID\"");

WriteLiteral(" class=\"table table-bordered\"");

WriteLiteral(@">
            <thead>
                <tr>
                    <th></th>
                    <th>#</th>
                    <th>Tên thành viên</th>
                    <th>Loại chủ</th>
                    <th>Số giấy tờ</th>
                    <th>Vai trò</th>
                    <th>TLSH</th>
                </tr>
            </thead>
            <tbody>
");

            
            #line 18 "..\..\Views\XLHSGiayChungNhan\GiayChungNhan_Main_TLSH.cshtml"
                
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\XLHSGiayChungNhan\GiayChungNhan_Main_TLSH.cshtml"
                 if (Model.DSTyLeSoHuu != null && Model.DSTyLeSoHuu.Count > 0)
                {
                    int sTT = 0;
                    foreach (var item in Model.DSTyLeSoHuu)
                    {
                        sTT++;

            
            #line default
            #line hidden
WriteLiteral("                        <tr>\r\n                            <td>");

            
            #line 25 "..\..\Views\XLHSGiayChungNhan\GiayChungNhan_Main_TLSH.cshtml"
                           Write(item.THANHVIENID);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                            <td>");

            
            #line 26 "..\..\Views\XLHSGiayChungNhan\GiayChungNhan_Main_TLSH.cshtml"
                           Write(sTT);

            
            #line default
            #line hidden
WriteLiteral(".</td>\r\n                            <td>");

            
            #line 27 "..\..\Views\XLHSGiayChungNhan\GiayChungNhan_Main_TLSH.cshtml"
                           Write(item.HOTEN);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                            <td>");

            
            #line 28 "..\..\Views\XLHSGiayChungNhan\GiayChungNhan_Main_TLSH.cshtml"
                           Write(item.TENLOAICHU);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                            <td>");

            
            #line 29 "..\..\Views\XLHSGiayChungNhan\GiayChungNhan_Main_TLSH.cshtml"
                           Write(item.SOGIAYTO);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                            <td>\r\n");

            
            #line 31 "..\..\Views\XLHSGiayChungNhan\GiayChungNhan_Main_TLSH.cshtml"
                                
            
            #line default
            #line hidden
            
            #line 31 "..\..\Views\XLHSGiayChungNhan\GiayChungNhan_Main_TLSH.cshtml"
                                 if (item.ISNGUOIDAIDIEN == 1)
                                {
                                    
            
            #line default
            #line hidden
            
            #line 33 "..\..\Views\XLHSGiayChungNhan\GiayChungNhan_Main_TLSH.cshtml"
                               Write(Html.Raw("Đại diện"));

            
            #line default
            #line hidden
            
            #line 33 "..\..\Views\XLHSGiayChungNhan\GiayChungNhan_Main_TLSH.cshtml"
                                                         
                                }
                                else
                                {
                                    
            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\XLHSGiayChungNhan\GiayChungNhan_Main_TLSH.cshtml"
                               Write(Html.Raw("Thành viên"));

            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\XLHSGiayChungNhan\GiayChungNhan_Main_TLSH.cshtml"
                                                           
                                }

            
            #line default
            #line hidden
WriteLiteral("                            </td>\r\n                            <td>");

            
            #line 40 "..\..\Views\XLHSGiayChungNhan\GiayChungNhan_Main_TLSH.cshtml"
                           Write(item.TILESOHUU);

            
            #line default
            #line hidden
WriteLiteral("%</td>\r\n                        </tr>\r\n");

            
            #line 42 "..\..\Views\XLHSGiayChungNhan\GiayChungNhan_Main_TLSH.cshtml"
                    }
                }

            
            #line default
            #line hidden
WriteLiteral("            </tbody>\r\n        </table>\r\n        <button");

WriteLiteral(" id=\"btnSumit_TableTVNNID\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default btn-sm\"");

WriteLiteral(" disabled><i");

WriteLiteral(" class=\'fa fa-check\'");

WriteLiteral("></i> Lưu thông tin</button>\r\n    </div>\r\n</div>\r\n\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
    $(document).ready(function () {

        var columns = [
            { ""data"": ""THANHVIENID"" },
            { ""data"": ""STT"" },
            { ""data"": ""HOTEN"" },
            { ""data"": ""TENLOAICHU"" },
            { ""data"": ""SOGIAYTO"" },
            { ""data"": ""TenVaiTro"" },
            { ""data"": ""TLSH"" }
        ]
        var columnDefs = [
            {
                ""targets"": 0,
                ""visible"": false
            },
            {
                ""targets"": -1,
                ""className"": ""text-center TLSH""
            },
            {
                ""targets"": [1],
                ""className"": ""text-right""
            },
            {
                ""targets"": [3, 4, 5],
                ""className"": ""text-center""
            }
        ]

        var options = {
            ""pageLength"": 5,
            ""ordering"": false,
            ""autoWidth"": false,
            ""columns"": columns,
            ""columnDefs"": columnDefs,
            ""dom"": ""t<'row p-0'<'col-xs-6 p-0'<'row p-0'<'col-xs-6 p-0'<'#divBTAddQuyenQLDat'>>>><'col-xs-6 p-0'<'pull-right'p>>>"",
            //""dom"": ""t<'row p-0' <'col-xs-12 p-0' <'pull-right'p> > >"",
            ""initComplete"": function () {
                initComplete();
            }
        }

        function initComplete() {
            
        }

        var TableTVNNID = $('#TableTVNNID').DataTable(options);

        if ('");

            
            #line 100 "..\..\Views\XLHSGiayChungNhan\GiayChungNhan_Main_TLSH.cshtml"
        Write(Model.ChinhSua);

            
            #line default
            #line hidden
WriteLiteral(@"' == 'True') {
            TableTVNNID.rows().nodes().on('dblclick', 'tbody tr', function () {
                if (TableTVNNID.data().count() > 0) {
                    var curRow = TableTVNNID.row($(this));
                    $.ajax({
                        type: ""POST"",
                        url: ""/XLHSGiayChungNhan/Popup_SetTLSH"",
                        data: { thanhVienID: curRow.data().THANHVIENID },
                        dataType: ""html"",
                        success: function (html) {
                            $('#divPopup')
                                .html(html)
                                .ready(function () {
                                    var options = {
                                        ""backdrop"": ""static"",
                                        ""show"": true
                                    }
                                    $(""#modalSetGCNTLSHID"").modal(options);
                                });
                        }
                    })
                }
            })
        }

    })

</script>
");

        }
    }
}
#pragma warning restore 1591