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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Lichsu/LichSu.cshtml")]
    public partial class _Views_Lichsu_LichSu_cshtml : System.Web.Mvc.WebViewPage<MPLIS.Libraries.Data.XuLyHoSo.Models.ObjLichSu>
    {
        public _Views_Lichsu_LichSu_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<link");

WriteAttribute("href", Tuple.Create(" href=\"", 5), Tuple.Create("\"", 55)
, Tuple.Create(Tuple.Create("", 12), Tuple.Create<System.Object, System.Int32>(Href("~/Content/XuLyHoSo/css/font-awesome.min.css")
, 12), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 83), Tuple.Create("\"", 136)
, Tuple.Create(Tuple.Create("", 90), Tuple.Create<System.Object, System.Int32>(Href("~/Content/XuLyHoSo/css/jquery.orgchart.min.css")
, 90), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 164), Tuple.Create("\"", 203)
, Tuple.Create(Tuple.Create("", 171), Tuple.Create<System.Object, System.Int32>(Href("~/Content/XuLyHoSo/css/style.css")
, 171), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n");

WriteLiteral("\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 306), Tuple.Create("\"", 363)
, Tuple.Create(Tuple.Create("", 312), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/XuLyHoSo/Orchart/js/js/jquery.orgchart.js")
, 312), false)
);

WriteLiteral("></script>\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 381), Tuple.Create("\"", 420)
, Tuple.Create(Tuple.Create("", 388), Tuple.Create<System.Object, System.Int32>(Href("~/Content/XuLyHoSo/XLHSstyle.css")
, 388), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n\r\n    \r\n");

WriteLiteral("\r\n");

WriteLiteral("\r\n\r\n");

WriteLiteral("<body>\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-xs-4 form-group\"");

WriteLiteral(">\r\n            <fieldset>\r\n                <legend>\r\n                    Cây lịc" +
"h sử\r\n                </legend>\r\n                <div");

WriteLiteral(" id=\"IdCayLichSu\"");

WriteLiteral(">\r\n\r\n                </div>\r\n            </fieldset>\r\n        </div>\r\n        <di" +
"v");

WriteLiteral(" class=\"col-xs-8 form-group\"");

WriteLiteral(">\r\n            <fieldset>\r\n                <legend>\r\n                    Thông ti" +
"n thuộc tính\r\n                </legend>\r\n                <div");

WriteLiteral(" id=\"divLichSuID\"");

WriteLiteral(">\r\n                    ");

WriteLiteral("\r\n                </div>\r\n            </fieldset>\r\n        </div>\r\n    </div>\r\n</" +
"body>\r\n\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n    $(function () {\r\n        var abc=  ");

            
            #line 44 "..\..\Views\Lichsu\LichSu.cshtml"
             Write(Html.Raw(Json.Encode(Model)));

            
            #line default
            #line hidden
WriteLiteral(";\r\n        //var js = JSON.parse(\'abc\');\r\n      //  alert(abc);\r\n        var data" +
"scource = {\r\n            \'name\': \'GCN\',\r\n            \'GCN\': \'12345678\',\r\n       " +
"     \'SOTO\': \'12\',\r\n            \'SOTHUA\': \'123\',\r\n            \'CHU\': \'abc\',\r\n   " +
"         \'LAGCN\': \'Y\',\r\n            //\'name\': \'Bo Miao\', \'title\': \'department ma" +
"nager\',\r\n            \'children\': [\r\n              {\r\n                  \'name\': \'" +
"Biến động\', \'GCN\': \'Tách Thửa\',\r\n                  \'SOTO\': \'33\',\r\n          " +
"        \'SOTHUA\': \'123\',\r\n                  \'CHU\': \'aaaaaaaaaaaaaaaaaa\', \'LAGCN\'" +
": \'N\', \'className\': \'middle-level\',\r\n                  \'children\': [\r\n          " +
"          {\r\n                        \'name\': \'GCN\',\r\n                        \'GC" +
"N\': \'3333333333333\',\r\n                        \'SOTO\': \'12\',\r\n                   " +
"     \'SOTHUA\': \'33\',\r\n                        \'CHU\': \'xxxxxxxxxxxxxxxxx\',\r\n     " +
"                   \'LAGCN\': \'Y\',\r\n                    },\r\n                    {\r" +
"\n                        \'name\': \'GCN\',\r\n                        \'GCN\': \'2222222" +
"222222\',\r\n                        \'SOTO\': \'12\',\r\n                        \'SOTHUA" +
"\': \'22\',\r\n                        \'CHU\': \'tttttttttttttttttttt\',\r\n              " +
"          \'LAGCN\': \'Y\',\r\n                        //\'children\': [\r\n              " +
"          //  { \'name\': \'To To\', \'title\': \'engineer\', \'className\': \'pipeline1\' }" +
",\r\n                        //  { \'name\': \'Fei Fei\', \'title\': \'engineer\', \'classN" +
"ame\': \'pipeline1\' },\r\n                        //  { \'name\': \'Xuan Xuan\', \'title\'" +
": \'engineer\', \'className\': \'pipeline1\' }\r\n                        //]\r\n         " +
"           }\r\n                  ]\r\n              }\r\n\r\n            ]\r\n        };\r" +
"\n\r\n\r\n        $(\'#IdCayLichSu\').orgchart({\r\n            \'data\': abc,\r\n           " +
" \'GCN\': \'GCN\',\r\n            \'SOTO\': \'SOTO\',\r\n            \'SOTHUA\': \'SOTHUA\',\r\n  " +
"          \'CHU\': \'CHU\',\r\n            //\'nodeContent2\': \'name\',\r\n            \'nod" +
"eId\': \'GCN\'\r\n        });\r\n        //var abc = new model1();\r\n        //ko.applyB" +
"indings(abc);\r\n\r\n        //load gcn\r\n        try {\r\n            $.ajax({\r\n      " +
"          url: \'/Lichsu/_GCNLS\',\r\n                type: \'POST\',\r\n               " +
" dataType: \'html\',\r\n                contentType: \'application/html\',\r\n          " +
"      success: function (_partial) {\r\n                    $(\'#divLichSuID\').html" +
"(_partial);\r\n                },\r\n                error: function (err) {\r\n      " +
"              alert(err.status + \" : \" + err.statusText);\r\n                }\r\n  " +
"          });\r\n        } catch (e) {\r\n            // window.location.href = \'/Ho" +
"me/Read/\';\r\n        }\r\n    });\r\n\r\n\r\n</script>\r\n");

        }
    }
}
#pragma warning restore 1591
