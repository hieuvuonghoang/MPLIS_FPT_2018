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
    
    #line 1 "..\..\Views\XLHSHoSoLuuKho\_HoSoLuuKho_GCN.cshtml"
    using AppCore.Models;
    
    #line default
    #line hidden
    using MPLIS;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/XLHSHoSoLuuKho/_HoSoLuuKho_GCN.cshtml")]
    public partial class _Views_XLHSHoSoLuuKho__HoSoLuuKho_GCN_cshtml : System.Web.Mvc.WebViewPage<HS_HOSO>
    {
        public _Views_XLHSHoSoLuuKho__HoSoLuuKho_GCN_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("    <div");

WriteLiteral("  id=\"divHSLK_GCN\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"box box-primary\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"box-header with-border\"");

WriteLiteral(">\r\n                <h3");

WriteLiteral(" class=\"box-title\"");

WriteLiteral(">Danh sách thông tin giấy chứng nhận</h3>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"box-body\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn-sm btn-inform\"");

WriteLiteral(" id=\"btncapnhatgcn\"");

WriteLiteral(" value=\"Cập nhật từ dữ liệu hồ sơ\"");

WriteLiteral(" />\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                    <table");

WriteLiteral(" id=\"table_HoSoLK_GCN\"");

WriteLiteral(" class=\"table table-bordered\"");

WriteLiteral(">\r\n                        <thead>\r\n                            <tr>\r\n           " +
"                     <th");

WriteLiteral(" class=\"t50\"");

WriteLiteral(" hidden>hsgcnid</th>\r\n                                <th");

WriteLiteral(" class=\"t50\"");

WriteLiteral(">STT</th>\r\n                                <th");

WriteLiteral(" class=\"t100\"");

WriteLiteral(">Số phát hành</th>\r\n                                <th");

WriteLiteral(" class=\"t100\"");

WriteLiteral(">Số vào sổ</th>\r\n                                <th");

WriteLiteral(" class=\"t100\"");

WriteLiteral(">Mã vạch</th>\r\n                                <th");

WriteLiteral(" class=\"t100\"");

WriteLiteral(">Xã</th>\r\n                            </tr>\r\n                        </thead>\r\n");

            
            #line 24 "..\..\Views\XLHSHoSoLuuKho\_HoSoLuuKho_GCN.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\XLHSHoSoLuuKho\_HoSoLuuKho_GCN.cshtml"
                          
                            int rtdtable = 0;
                            if (Model != null)
                            {
                                if (Model.DSGCN != null)
                                {
                                    foreach (var itemtd in Model.DSGCN)
                                    {
                                        rtdtable = rtdtable + 1;

            
            #line default
            #line hidden
WriteLiteral("                                        <tr");

WriteLiteral(" data-id=\"");

            
            #line 33 "..\..\Views\XLHSHoSoLuuKho\_HoSoLuuKho_GCN.cshtml"
                                                Write(itemtd.TCGCNID);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">\r\n                                            <td");

WriteLiteral(" align=\"center\"");

WriteLiteral(" hidden>\r\n");

WriteLiteral("                                                ");

            
            #line 35 "..\..\Views\XLHSHoSoLuuKho\_HoSoLuuKho_GCN.cshtml"
                                           Write(itemtd.TCGCNID);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                            </td>\r\n                            " +
"                <td");

WriteLiteral(" align=\"center\"");

WriteLiteral(">");

            
            #line 37 "..\..\Views\XLHSHoSoLuuKho\_HoSoLuuKho_GCN.cshtml"
                                                          Write(rtdtable);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                                            <td");

WriteLiteral(" align=\"center\"");

WriteLiteral(">");

            
            #line 38 "..\..\Views\XLHSHoSoLuuKho\_HoSoLuuKho_GCN.cshtml"
                                                          Write(itemtd.SOPHATHANH);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                                            <td");

WriteLiteral(" align=\"center\"");

WriteLiteral(">");

            
            #line 39 "..\..\Views\XLHSHoSoLuuKho\_HoSoLuuKho_GCN.cshtml"
                                                          Write(itemtd.SOVAOSO);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                                            <td");

WriteLiteral(" align=\"center\"");

WriteLiteral(">");

            
            #line 40 "..\..\Views\XLHSHoSoLuuKho\_HoSoLuuKho_GCN.cshtml"
                                                          Write(itemtd.MAVACH);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                                            <td");

WriteLiteral(" align=\"center\"");

WriteLiteral(">");

            
            #line 41 "..\..\Views\XLHSHoSoLuuKho\_HoSoLuuKho_GCN.cshtml"
                                                          Write(itemtd.tenxa);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                                        </tr>\r\n");

            
            #line 43 "..\..\Views\XLHSHoSoLuuKho\_HoSoLuuKho_GCN.cshtml"
                                    }
                                }
                            }
                        
            
            #line default
            #line hidden
WriteLiteral(@"
                    </table>

                </div>
            </div>
        </div>

    </div>
<script>
    $(document).ready(function () {
        table_checkthuats = InitDataTableXLHS($('#table_HoSoLK_GCN'));
        $('#btncapnhatgcn').on(""click"", function () {
            $.ajax({
                type: ""POST"",
                url: ""/XLHSHoSoLuuKho/CapNhatGCN"",
                success: function (data) {
                    console.log(data);
                    $('#divHoSoTiepNhanID_GCN').html(data);
                }
            });

        });
    });


</script>



");

        }
    }
}
#pragma warning restore 1591