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
    using MPLIS.Modeles.QuanTriQuyTrinh;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/DiagramWorkflow/_QuyTrinh_CauHinhXuLy_KhuVucHanhChinh.cshtml")]
    public partial class _Views_DiagramWorkflow__QuyTrinh_CauHinhXuLy_KhuVucHanhChinh_cshtml : System.Web.Mvc.WebViewPage<MPLIS.Libraries.Data.QuanTriQuyTrinh.Models.CauHinhXuLyVM>
    {
        public _Views_DiagramWorkflow__QuyTrinh_CauHinhXuLy_KhuVucHanhChinh_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<table");

WriteLiteral(" id=\"Table_KVHanhChinh_ID\"");

WriteLiteral(" class=\"table table-bordered\"");

WriteLiteral(">\r\n    <thead>\r\n        <tr>\r\n            <th></th>\r\n            <th>#</th>\r\n    " +
"        <th></th>\r\n            <th>Mã KVHC</th>\r\n            <th>Tên KVHC</th>\r\n" +
"        </tr>\r\n    </thead>\r\n    <tbody>\r\n");

            
            #line 14 "..\..\Views\DiagramWorkflow\_QuyTrinh_CauHinhXuLy_KhuVucHanhChinh.cshtml"
        
            
            #line default
            #line hidden
            
            #line 14 "..\..\Views\DiagramWorkflow\_QuyTrinh_CauHinhXuLy_KhuVucHanhChinh.cshtml"
         if (Model.DSKhuVucHanhChinh != null && Model.DSKhuVucHanhChinh.Count > 0)
        {
            int sTT = 0;
            foreach (var item in Model.DSKhuVucHanhChinh)
            {
                sTT++;

            
            #line default
            #line hidden
WriteLiteral("                <tr>\r\n                    <td>\r\n");

WriteLiteral("                        ");

            
            #line 22 "..\..\Views\DiagramWorkflow\_QuyTrinh_CauHinhXuLy_KhuVucHanhChinh.cshtml"
                   Write(item.KVHCID);

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");

WriteLiteral("                        ");

            
            #line 25 "..\..\Views\DiagramWorkflow\_QuyTrinh_CauHinhXuLy_KhuVucHanhChinh.cshtml"
                   Write(sTT);

            
            #line default
            #line hidden
WriteLiteral(".\r\n                    </td>\r\n                    <td>\r\n                    </td>" +
"\r\n                    <td>\r\n");

WriteLiteral("                        ");

            
            #line 30 "..\..\Views\DiagramWorkflow\_QuyTrinh_CauHinhXuLy_KhuVucHanhChinh.cshtml"
                   Write(item.MAKVHC);

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");

WriteLiteral("                        ");

            
            #line 33 "..\..\Views\DiagramWorkflow\_QuyTrinh_CauHinhXuLy_KhuVucHanhChinh.cshtml"
                   Write(item.TENKVHC);

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");

            
            #line 36 "..\..\Views\DiagramWorkflow\_QuyTrinh_CauHinhXuLy_KhuVucHanhChinh.cshtml"
            }
        }

            
            #line default
            #line hidden
WriteLiteral("    </tbody>\r\n</table>\r\n\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
    $(document).ready(function () {
        var columns = [
            { ""data"": ""KVHCID"" },
            { ""data"": ""STT"" },
            { ""data"": null },
            { ""data"": ""MAKVHC"" },
            { ""data"": ""TENKVHC"" }
        ]
        var columnDefs = [
            {
                ""targets"": 0,
                ""visible"": false
            },
            {
                ""targets"": [1],
                ""className"": ""text-right""
            },
            {
                ""targets"": [2],
                ""render"": function () {
                    return ""<input type='checkbox'/>"";
                },
                ""className"": ""text-center""
            }
        ]
        var options = {
            ""pageLength"": 5,
            ""lengthChange"": false,
            ""ordering"": false,
            ""info"": false,
            ""searching"": false,
            ""autoWidth"": false,
            ""language"": {
                ""url"": ""https://cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Vietnamese.json""
            },
            ""columns"": columns,
            ""columnDefs"": columnDefs,
            ""dom"": ""<'row p-0'<'col-sm-12 p-0'tr>><'row p-0'<'col-sm-6 p-0'><'col-sm-6 p-0'p>>""
        }

        var Table_KVHanhChinh_ID = $('#Table_KVHanhChinh_ID').DataTable(options);

    })
</script>

");

        }
    }
}
#pragma warning restore 1591
