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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/XLHSDangKy/_DangKy.cshtml")]
    public partial class _Views_XLHSDangKy__DangKy_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_XLHSDangKy__DangKy_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" id=\"divDonDangKyID\"");

WriteLiteral(" class=\"m-15\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"row panel\"");

WriteLiteral(" style=\"margin-bottom: 5px;\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"btn btn-default btn-block tab-doc\"");

WriteLiteral(" style=\"text-align:left;\"");

WriteLiteral(">\r\n            <a");

WriteLiteral(" style=\"color: blue;font-weight: bold;\"");

WriteLiteral(" data-toggle=\"collapse\"");

WriteLiteral(" data-parent=\"#divDonDangKyID\"");

WriteLiteral(" href=\"#collapse_DonDangKy_DSGCN\"");

WriteLiteral(">\r\n                Danh sách GCN trong đăng ký\r\n            </a>\r\n            <bu" +
"tton");

WriteLiteral(" class=\"btn-xs btn-heading pull-right\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" onclick=\"LuuDonDangKy_DSGCN()\"");

WriteLiteral(">Cập nhật</button>\r\n        </div>\r\n        <div");

WriteLiteral(" id=\"collapse_DonDangKy_DSGCN\"");

WriteLiteral(" class=\"panel-collapse collapse in\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" id=\"divDonDangKyID_DSGCN\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 11 "..\..\Views\XLHSDangKy\_DangKy.cshtml"
           Write(Html.Partial("_DonDangKy_DSGCN"));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"row panel\"");

WriteLiteral(" style=\"margin-bottom: 5px;\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"btn btn-default btn-block tab-doc\"");

WriteLiteral(" style=\"text-align:left;\"");

WriteLiteral(">\r\n            <a");

WriteLiteral(" style=\"color: blue;font-weight: bold;\"");

WriteLiteral(" data-toggle=\"collapse\"");

WriteLiteral(" data-parent=\"#divDonDangKyID\"");

WriteLiteral(" href=\"#collapse_DonDangKy_DSCHU\"");

WriteLiteral(">\r\n                Danh sách Chủ trong đăng ký\r\n            </a>\r\n            ");

WriteLiteral("\r\n        </div>\r\n        <div");

WriteLiteral(" id=\"collapse_DonDangKy_DSCHU\"");

WriteLiteral(" class=\"panel-collapse collapse\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" id=\"divDonDangKyID_DSCHU\"");

WriteLiteral(">\r\n                ");

WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"row panel\"");

WriteLiteral(" style=\"margin-bottom: 5px;\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"btn btn-default btn-block tab-doc\"");

WriteLiteral(" style=\"text-align:left;\"");

WriteLiteral(">\r\n            <a");

WriteLiteral(" style=\"color: blue;font-weight: bold;\"");

WriteLiteral(" data-toggle=\"collapse\"");

WriteLiteral(" data-parent=\"#divDonDangKyID\"");

WriteLiteral(" href=\"#collapse_DonDangKy_DSTHUA\"");

WriteLiteral(">\r\n                Danh sách Thửa trong đăng ký\r\n            </a>\r\n            <b" +
"utton");

WriteLiteral(" class=\"btn-xs btn-heading pull-right\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" onclick=\"LuuDonDangKy_DSTHUA()\"");

WriteLiteral(">Cập nhật</button>\r\n        </div>\r\n        <div");

WriteLiteral(" id=\"collapse_DonDangKy_DSTHUA\"");

WriteLiteral(" class=\"panel-collapse collapse\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" id=\"divDonDangKyID_DSTHUA\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 37 "..\..\Views\XLHSDangKy\_DangKy.cshtml"
           Write(Html.Partial("_DonDangKy_DSTHUA"));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"row panel\"");

WriteLiteral(" style=\"margin-bottom: 5px;\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"btn btn-default btn-block tab-doc\"");

WriteLiteral(" style=\"text-align:left;\"");

WriteLiteral(">\r\n            <a");

WriteLiteral(" style=\"color: blue;font-weight: bold;\"");

WriteLiteral(" data-toggle=\"collapse\"");

WriteLiteral(" data-parent=\"#divDonDangKyID\"");

WriteLiteral(" href=\"#collapse_DonDangKy_DSTAISAN\"");

WriteLiteral(">\r\n                Danh sách tài sản trong đăng ký\r\n            </a>\r\n           " +
" <button");

WriteLiteral(" class=\"btn-xs btn-heading pull-right\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" onclick=\"LuuDonDangKy_DSTAISAN()\"");

WriteLiteral(">Cập nhật</button>\r\n        </div>\r\n        <div");

WriteLiteral(" id=\"collapse_DonDangKy_DSTAISAN\"");

WriteLiteral(" class=\"panel-collapse collapse\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" id=\"divDonDangKyID_DSTAISAN\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 50 "..\..\Views\XLHSDangKy\_DangKy.cshtml"
           Write(Html.Action("_DonDangKy_DSTAISAN"));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div");

WriteLiteral(" id=\"dialogformTaiLieuDoDacID\"");

WriteLiteral(">\r\n    ");

WriteLiteral("\r\n</div>\r\n<div");

WriteLiteral(" id=\"dialogformKHUCHUNGCU\"");

WriteLiteral(">\r\n    ");

WriteLiteral("\r\n</div>\r\n<div");

WriteLiteral(" id=\"dialogformNHACHUNGCU\"");

WriteLiteral(">\r\n    ");

WriteLiteral("\r\n</div>\r\n<div");

WriteLiteral(" id=\"dialogformDIACHI\"");

WriteLiteral(">\r\n</div>\r\n<div");

WriteLiteral(" id=\"dialogKQTKCaNhan\"");

WriteLiteral(">\r\n</div>\r\n<div");

WriteLiteral(" id=\"dialogKQTKHoGiaDinh\"");

WriteLiteral(">\r\n</div>\r\n<div");

WriteLiteral(" id=\"dialogKQTKVoChong\"");

WriteLiteral(">\r\n</div>\r\n<div");

WriteLiteral(" id=\"dialogKQTKToChuc\"");

WriteLiteral(">\r\n</div>\r\n<div");

WriteLiteral(" id=\"dialogKQTKTCongDong\"");

WriteLiteral(">\r\n</div>\r\n<div");

WriteLiteral(" id=\"dialogKQTKNhomNguoi\"");

WriteLiteral(">\r\n</div>\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n    //var formDonDangKy_DSGCN = $(\'#formDSGCN_ADDID\');\r\n    function LuuDonDan" +
"gKy_DSGCN() {\r\n        //document.getElementById(\'DONDANGKYID\').value\r\n        /" +
"/ alert(\'123\');\r\n        var dondk = document.getElementById(\'DONDANGKYID\').valu" +
"e;\r\n        var listgcn = [];\r\n        // var empTab = document.getElementById(\'" +
"table_DSGCNVAOID\');\r\n        var rowLength = 0;\r\n        rowLength = $(\"#table_D" +
"SGCNVAOID td\").closest(\"tr\").length;// empTab.rows.length;\r\n        if (rowLengt" +
"h == 0) return;\r\n        // alert(rowLength);\r\n        for (var i = 1; i <= rowL" +
"ength; i += 1) {\r\n            // var row = empTab.rows[i];\r\n            var objg" +
"cn = {};\r\n            objgcn.idgcn = document.getElementById(\'table_DSGCNVAOID\')" +
".rows[i].cells[0].innerText.trim();\r\n            //alert(row.cells[0].innerText)" +
";\r\n            listgcn.push(objgcn);\r\n\r\n        }\r\n        $.ajax({\r\n           " +
" type: \"POST\",\r\n            url: \"/XLHSDangKy/Save_formDonDangKy_DSGCN\",\r\n      " +
"      dataType: \"json\",\r\n            success: function (html) {\r\n               " +
" //$(\'#divDonDangKyID_DSGCN\').html(html);\r\n                if (html === \"true\") " +
"{\r\n                    $(\'#bhs-li2\').click();\r\n                    alert(\"Cập n" +
"hật thành công\");\r\n                }\r\n            },\r\n        });\r\n    };\r\n    " +
"var formDonDangKy_DSCHU = $(\'#IDformDonDangKy_DSCHU\');\r\n    function LuuDonDangK" +
"y_DSCHU() {\r\n        $.ajax({\r\n            type: \"POST\",\r\n            url: \"/XLH" +
"SDangKy/Save_formDonDangKy_DSCHU\",\r\n            //  data: formDonDangKy_DSCHU.se" +
"rialize(),\r\n            dataType: \"json\",\r\n            success: function (data) " +
"{\r\n                //$(\'#divDonDangKyID_DSCHU\').html(html);\r\n                if " +
"(data === \"true\") {\r\n                    alert(\"Lưu thành công\");\r\n             " +
"   }\r\n                else {\r\n                    alert(\"Có lỗi xảy ra!!!\");\r" +
"\n                }\r\n\r\n            },\r\n        });\r\n    };\r\n    //var formDonDang" +
"Ky_DSTHUA = $(\'#IDformDonDangKy_DSTHUA\');\r\n    function LuuDonDangKy_DSTHUA() {\r" +
"\n        $.ajax({\r\n            type: \"POST\",\r\n            url: \"/XLHSDangKy/Save" +
"_formDonDangKy_DSTHUA\",\r\n            // data: formDonDangKy_DSTHUA.serialize(),\r" +
"\n            dataType: \"json\",\r\n            success: function (data) {\r\n        " +
"        //   $(\'#divDonDangKyID_DSTHUA\').html(data);\r\n                if (data =" +
"= \"true\") {\r\n                    $(\'#bhs-li2\').click();\r\n                    ale" +
"rt(\"Lưu thành công\");\r\n                }\r\n                else {\r\n              " +
"      alert(\"Có lỗi xảy ra!\");\r\n                }\r\n\r\n            },\r\n        " +
"});\r\n    };\r\n    var formDonDangKy_DSTAISAN = $(\'#IDformDonDangKy_DSTAISAN\');\r\n " +
"   function LuuDonDangKy_DSTAISAN() {\r\n        var dt = document.getElementById(" +
"\"JSONTSThua\").value;\r\n        $.ajax({\r\n            type: \"POST\",\r\n            u" +
"rl: \"/XLHSDangKy/Save_formDonDangKy_DSTAISAN\",\r\n            //  data: formDonDan" +
"gKy_DSTAISAN.serialize(),\r\n            data: { JsonTSThua: dt },\r\n            da" +
"taType: \"json\",\r\n            success: function (data) {\r\n                if (dat" +
"a == \"true\") {\r\n                    alert(\"Cập nhật thành công\");\r\n           " +
"     }\r\n                else {\r\n                    alert(\"Có lỗi xảy ra!\");\r" +
"\n                }\r\n            },\r\n        });\r\n    };\r\n\r\n    $(document).ready" +
"(function () {\r\n        trigger_tab_doc();\r\n        $.ajax({\r\n            type: " +
"\"POST\",\r\n            url: \"/XLHSDangKy/Form_DanhSachChu\",\r\n            dataType:" +
" \"html\",\r\n            success: function (html) {\r\n                $(\'#divDonDang" +
"KyID_DSCHU\').html(html);\r\n            }\r\n        })\r\n    });\r\n</script>\r\n");

        }
    }
}
#pragma warning restore 1591
