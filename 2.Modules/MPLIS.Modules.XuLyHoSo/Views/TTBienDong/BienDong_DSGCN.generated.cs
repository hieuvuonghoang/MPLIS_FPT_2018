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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/TTBienDong/BienDong_DSGCN.cshtml")]
    public partial class _Views_TTBienDong_BienDong_DSGCN_cshtml : System.Web.Mvc.WebViewPage<MPLIS.Libraries.Data.XuLyHoSo.Models.DSGCNBDVM>
    {
        public _Views_TTBienDong_BienDong_DSGCN_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<form");

WriteLiteral(" id=\"formDSGCNBDVMID\"");

WriteLiteral(">\r\n");

WriteLiteral("    ");

            
            #line 4 "..\..\Views\TTBienDong\BienDong_DSGCN.cshtml"
Write(Html.HiddenFor(model => model.JSONCha));

            
            #line default
            #line hidden
WriteLiteral("\r\n    ");

WriteLiteral("\r\n    <div");

WriteLiteral(" id=\"divBienDongID_DSGCNVAO\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 7 "..\..\Views\TTBienDong\BienDong_DSGCN.cshtml"
   Write(Html.Partial("BienDong_DSGCNVAO"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n    <div");

WriteLiteral(" id=\"divBienDongID_DSGCNRA\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 10 "..\..\Views\TTBienDong\BienDong_DSGCN.cshtml"
   Write(Html.Partial("BienDong_DSGCNRA"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</form>\r\n\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n    $(document).ready(function () {\r\n\r\n        var TableGCNVaoID = $(\'#TableGC" +
"NVaoID\').DataTable();\r\n\r\n        var TableGCNRaID = $(\'#TableGCNRaID\').DataTable" +
"();\r\n\r\n        var curGCNRaID = \"\";\r\n\r\n        var objJSONCha = {};\r\n\r\n        /" +
"/Xử lý chuỗi JSONCha trên hai Table:\r\n\r\n        TableGCNRaID.rows().nodes().on(\'" +
"click\', \'tbody tr\', function (event) {\r\n            if (TableGCNRaID.data().coun" +
"t() > 0) {\r\n                if (curGCNRaID != TableGCNRaID.row(this).data().GIAY" +
"CHUNGNHANID) {\r\n                    curGCNRaID = TableGCNRaID.row(this).data().G" +
"IAYCHUNGNHANID;\r\n                    $(TableGCNRaID.rows().nodes()).removeClass(" +
"\'activerow\');\r\n                    $(TableGCNRaID.row(this).node()).addClass(\'ac" +
"tiverow\');\r\n                    $.each(TableGCNVaoID.rows().nodes(), function ()" +
" {\r\n                        $(\'[type=checkbox]\', this).prop(\'disabled\', false);\r" +
"\n                        $(\'[type=checkbox]\', this).prop(\'checked\', false);\r\n   " +
"                 })\r\n                    objJSONCha = JSON.parse($(\'#JSONCha\').v" +
"al());\r\n                    var dSGCNCha = null;\r\n                    for (var t" +
"emp in objJSONCha) {\r\n                        if (temp == curGCNRaID) {\r\n       " +
"                     dSGCNCha = objJSONCha[temp];\r\n                            b" +
"reak;\r\n                        }\r\n                    }\r\n                    if(" +
"dSGCNCha != null) {\r\n                        for(var temp in dSGCNCha) {\r\n      " +
"                      $.each(TableGCNVaoID.rows().nodes(), function() {\r\n       " +
"                         if (TableGCNVaoID.row(this).data().GIAYCHUNGNHANID == d" +
"SGCNCha[temp]) {\r\n                                    $(\'[type=checkbox]\', this)" +
".prop(\'checked\', true);\r\n                                }\r\n                    " +
"        })\r\n                        }\r\n                    }\r\n                } " +
"else {\r\n                    curGCNRaID = \"\";\r\n                    $(TableGCNRaID" +
".row(this).node()).removeClass(\'activerow\');\r\n                    $.each(TableGC" +
"NVaoID.rows().nodes(), function () {\r\n                        $(\'[type=checkbox]" +
"\', this).prop(\'disabled\', true);\r\n                        $(\'[type=checkbox]\', t" +
"his).prop(\'checked\', false);\r\n                    })\r\n                }\r\n       " +
"     }\r\n        })\r\n\r\n        TableGCNVaoID.rows().nodes().on(\'click\', \'tbody tr" +
" [type=checkbox]\', function (event) {\r\n            if (TableGCNVaoID.data().coun" +
"t() > 0 && curGCNRaID != \"\") {\r\n                objJSONCha = JSON.parse($(\'#JSON" +
"Cha\').val());\r\n                var dSGCNCha = null;\r\n                for (var te" +
"mp in objJSONCha) {\r\n                    if (temp == curGCNRaID) {\r\n            " +
"            dSGCNCha = objJSONCha[temp];\r\n                        break;\r\n      " +
"              }\r\n                }\r\n                if (dSGCNCha == null) {\r\n   " +
"                 objJSONCha[curGCNRaID] = [];\r\n                    dSGCNCha = ob" +
"jJSONCha[curGCNRaID];\r\n                }\r\n                console.log($(this));\r" +
"\n                if ($(this).is(\':checked\')) {\r\n                    console.log(" +
"\'Checked\');\r\n                    dSGCNCha.push(TableGCNVaoID.row($(this).parents" +
"(\'tr\')).data().GIAYCHUNGNHANID);\r\n                } else {\r\n                    " +
"console.log(\'Not Checked\');\r\n                    var index = -1;\r\n              " +
"      for (var temp in dSGCNCha) {\r\n                        if (dSGCNCha[temp] =" +
"= TableGCNVaoID.row($(this).parents(\'tr\')).data().GIAYCHUNGNHANID) {\r\n          " +
"                  index = temp;\r\n                            break;\r\n           " +
"             }\r\n                    }\r\n                    if (index != -1) {\r\n " +
"                       dSGCNCha.splice(index, 1);\r\n                    }\r\n      " +
"          }\r\n                console.log(objJSONCha);\r\n                $(\'#JSONC" +
"ha\').val(JSON.stringify(objJSONCha));\r\n            }\r\n        })\r\n    })\r\n</scri" +
"pt>\r\n");

        }
    }
}
#pragma warning restore 1591