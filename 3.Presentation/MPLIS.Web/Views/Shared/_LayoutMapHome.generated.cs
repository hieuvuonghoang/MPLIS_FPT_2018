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
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/_LayoutMapHome.cshtml")]
    public partial class _Views_Shared__LayoutMapHome_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Shared__LayoutMapHome_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <meta");

WriteLiteral(" charset=\"utf-8\"");

WriteLiteral(">\r\n    <meta");

WriteLiteral(" http-equiv=\"X-UA-Compatible\"");

WriteLiteral(" content=\"IE=edge\"");

WriteLiteral(">\r\n    <title>Hệ thống thông tin đất đai quốc gia - MPLIS</title>\r\n    <!-- Tell " +
"the browser to be responsive to screen width -->\r\n    <meta");

WriteLiteral(" content=\"width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no\"" +
"");

WriteLiteral(" name=\"viewport\"");

WriteLiteral(">\r\n    <!-- Theme style -->\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteAttribute("href", Tuple.Create(" href=\"", 409), Tuple.Create("\"", 447)
, Tuple.Create(Tuple.Create("", 416), Tuple.Create<System.Object, System.Int32>(Href("~/Content/AdminLTE/AdminLTE.css")
, 416), false)
);

WriteLiteral(" />\r\n    <!-- Bootstrap 3.3.6 -->\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteAttribute("href", Tuple.Create(" href=\"", 509), Tuple.Create("\"", 549)
, Tuple.Create(Tuple.Create("", 516), Tuple.Create<System.Object, System.Int32>(Href("~/Content/bootstrap/bootstrap.css")
, 516), false)
);

WriteLiteral(">\r\n    ");

WriteLiteral("\r\n    <!-- Font Awesome -->\r\n    ");

WriteLiteral("\r\n    <!-- Ionicons -->\r\n    ");

WriteLiteral("\r\n    <!--Theme all-->\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteAttribute("href", Tuple.Create(" href=\"", 977), Tuple.Create("\"", 1014)
, Tuple.Create(Tuple.Create("", 984), Tuple.Create<System.Object, System.Int32>(Href("~/Content/skins/_all-skins.css")
, 984), false)
);

WriteLiteral(">\r\n    <!-- jvectormap -->\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteAttribute("href", Tuple.Create(" href=\"", 1069), Tuple.Create("\"", 1129)
, Tuple.Create(Tuple.Create("", 1076), Tuple.Create<System.Object, System.Int32>(Href("~/Content/jquery/jqueryui/jquery-jvectormap-1.2.2.css")
, 1076), false)
);

WriteLiteral(">\r\n    <!--custome css-->\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 1166), Tuple.Create("\"", 1201)
, Tuple.Create(Tuple.Create("", 1173), Tuple.Create<System.Object, System.Int32>(Href("~/Content/MplisCSS/style.css")
, 1173), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n    <!--css dung chung ca he thong-->\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 1272), Tuple.Create("\"", 1297)
, Tuple.Create(Tuple.Create("", 1279), Tuple.Create<System.Object, System.Int32>(Href("~/Content/Site.css")
, 1279), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteAttribute("href", Tuple.Create(" href=\"", 1346), Tuple.Create("\"", 1376)
, Tuple.Create(Tuple.Create("", 1353), Tuple.Create<System.Object, System.Int32>(Href("~/Content/fileinput.css")
, 1353), false)
);

WriteLiteral(">\r\n\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 1391), Tuple.Create("\"", 1434)
, Tuple.Create(Tuple.Create("", 1398), Tuple.Create<System.Object, System.Int32>(Href("~/Content/skins/skin-black-light.css")
, 1398), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 1466), Tuple.Create("\"", 1507)
, Tuple.Create(Tuple.Create("", 1473), Tuple.Create<System.Object, System.Int32>(Href("~/Content/telerik/kendo.common.css")
, 1473), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 1539), Tuple.Create("\"", 1581)
, Tuple.Create(Tuple.Create("", 1546), Tuple.Create<System.Object, System.Int32>(Href("~/Content/telerik/kendo.default.css")
, 1546), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n    ");

WriteLiteral(" <!-- bị xung dot với trang quan ly mau giay to -->\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 1738), Tuple.Create("\"", 1805)
, Tuple.Create(Tuple.Create("", 1745), Tuple.Create<System.Object, System.Int32>(Href("~/Content/bootstrap/bootstrapui/bootstrap-datetimepicker.css")
, 1745), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 1839), Tuple.Create("\"", 1882)
, Tuple.Create(Tuple.Create("", 1845), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/jquery/jquery-1.10.2.min.js")
, 1845), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 1906), Tuple.Create("\"", 1973)
, Tuple.Create(Tuple.Create("", 1912), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/MplisScripts/WebGIS/Scripts/jquery-ui-1.11.4.min.js")
, 1912), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 1997), Tuple.Create("\"", 2039)
, Tuple.Create(Tuple.Create("", 2003), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/bootstrap/bootstrap.min.js")
, 2003), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 2063), Tuple.Create("\"", 2132)
, Tuple.Create(Tuple.Create("", 2069), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/bootstrap/bootstrapui/bootstrap-datetimepicker.min.js")
, 2069), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 2156), Tuple.Create("\"", 2207)
, Tuple.Create(Tuple.Create("", 2162), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/jquery/jqueryui/AdminLTE/app.min.js")
, 2162), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 2231), Tuple.Create("\"", 2271)
, Tuple.Create(Tuple.Create("", 2237), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/MplisScripts/function.js")
, 2237), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 2295), Tuple.Create("\"", 2325)
, Tuple.Create(Tuple.Create("", 2301), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/jquery.site.js")
, 2301), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 2349), Tuple.Create("\"", 2387)
, Tuple.Create(Tuple.Create("", 2355), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/jquery.validate.min.js")
, 2355), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 2411), Tuple.Create("\"", 2468)
, Tuple.Create(Tuple.Create("", 2417), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/jquery/jquery.validate.unobtrusive.min.js")
, 2417), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 2492), Tuple.Create("\"", 2532)
, Tuple.Create(Tuple.Create("", 2498), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/jquery.dataTables.min.js")
, 2498), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 2556), Tuple.Create("\"", 2588)
, Tuple.Create(Tuple.Create("", 2562), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/fileinput.min.js")
, 2562), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 2612), Tuple.Create("\"", 2652)
, Tuple.Create(Tuple.Create("", 2618), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/telerik/kendo.all.min.js")
, 2618), false)
);

WriteLiteral(@"></script>

    <!--Map Styles and Scripts-->
    <script>
        var dojoConfig = {
            parseOnLoad: false,
            isDebug: true,
            packages: [
                {
                    name: ""agsjs"",
                    location: location.pathname.replace(/\/[^/]+$/, """") + '/../Scripts/MplisScripts/WebGIS/agsjs'
                }
            ]
        };
    </script>
    <!--Thư viện css của bản đồ-->
    <!--Thư viện css của hãng esri-->
    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 3145), Tuple.Create("\"", 3184)
, Tuple.Create(Tuple.Create("", 3152), Tuple.Create<System.Object, System.Int32>(Href("~/Content/MplisCSS/esri/esri.css")
, 3152), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 3216), Tuple.Create("\"", 3259)
, Tuple.Create(Tuple.Create("", 3223), Tuple.Create<System.Object, System.Int32>(Href("~/Content/MplisCSS/WebGIS/mapgis.css")
, 3223), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 3291), Tuple.Create("\"", 3332)
, Tuple.Create(Tuple.Create("", 3298), Tuple.Create<System.Object, System.Int32>(Href("~/Content/MplisCSS/WebGIS/dojo.css")
, 3298), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 3364), Tuple.Create("\"", 3406)
, Tuple.Create(Tuple.Create("", 3371), Tuple.Create<System.Object, System.Int32>(Href("~/Content/MplisCSS/WebGIS/claro.css")
, 3371), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 3438), Tuple.Create("\"", 3484)
, Tuple.Create(Tuple.Create("", 3445), Tuple.Create<System.Object, System.Int32>(Href("~/Content/MplisCSS/WebGIS/claroGrid.css")
, 3445), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 3516), Tuple.Create("\"", 3565)
, Tuple.Create(Tuple.Create("", 3523), Tuple.Create<System.Object, System.Int32>(Href("~/Content/MplisCSS/WebGIS/EnhancedGrid.css")
, 3523), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n\r\n    <!--Thư viện css cho công cụ bản đồ-->\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 3643), Tuple.Create("\"", 3692)
, Tuple.Create(Tuple.Create("", 3650), Tuple.Create<System.Object, System.Int32>(Href("~/Content/MplisCSS/WebGIS/font-awesome.css")
, 3650), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 3724), Tuple.Create("\"", 3770)
, Tuple.Create(Tuple.Create("", 3731), Tuple.Create<System.Object, System.Int32>(Href("~/Content/MplisCSS/WebGIS/ui.jqgrid.css")
, 3731), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 3802), Tuple.Create("\"", 3848)
, Tuple.Create(Tuple.Create("", 3809), Tuple.Create<System.Object, System.Int32>(Href("~/Content/MplisCSS/WebGIS/jquery-ui.css")
, 3809), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 3880), Tuple.Create("\"", 3908)
, Tuple.Create(Tuple.Create("", 3887), Tuple.Create<System.Object, System.Int32>(Href("~/Content/Ace/ace.css")
, 3887), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n\r\n    <!--Thư viện cho cập nhật dữ liệu-->\r\n    ");

WriteLiteral("\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteAttribute("href", Tuple.Create(" href=\"", 4065), Tuple.Create("\"", 4122)
, Tuple.Create(Tuple.Create("", 4072), Tuple.Create<System.Object, System.Int32>(Href("~/Content/plugins/fileupload/jquery.fileupload.css")
, 4072), false)
);

WriteLiteral(">\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 4135), Tuple.Create("\"", 4178)
, Tuple.Create(Tuple.Create("", 4142), Tuple.Create<System.Object, System.Int32>(Href("~/Content/MplisCSS/WebGIS/panels.css")
, 4142), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n\r\n    <!--Thư viện trực tuyến javascript api-->\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 4261), Tuple.Create("\"", 4328)
, Tuple.Create(Tuple.Create("", 4267), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/MplisScripts/WebGIS/Scripts/jquery-migrate-1.2.1.js")
, 4267), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 4352), Tuple.Create("\"", 4400)
, Tuple.Create(Tuple.Create("", 4358), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/MplisScripts/WebGIS/utilities.js")
, 4358), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 4424), Tuple.Create("\"", 4478)
, Tuple.Create(Tuple.Create("", 4430), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/plugins/fileupload/jquery.ui.widget.js")
, 4430), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 4502), Tuple.Create("\"", 4557)
, Tuple.Create(Tuple.Create("", 4508), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/plugins/fileupload/jquery.fileupload.js")
, 4508), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 4581), Tuple.Create("\"", 4631)
, Tuple.Create(Tuple.Create("", 4587), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/jquery/jquery.noty.packaged.min.js")
, 4587), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 4655), Tuple.Create("\"", 4704)
, Tuple.Create(Tuple.Create("", 4661), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/jquery/jquery.unobtrusive-ajax.js")
, 4661), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 4728), Tuple.Create("\"", 4766)
, Tuple.Create(Tuple.Create("", 4734), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/gis/terraformer.min.js")
, 4734), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 4790), Tuple.Create("\"", 4842)
, Tuple.Create(Tuple.Create("", 4796), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/gis/terraformer-arcgis-parser.min.js")
, 4796), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 4866), Tuple.Create("\"", 4912)
, Tuple.Create(Tuple.Create("", 4872), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/plugins/inputmask/inputmask.js")
, 4872), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 4936), Tuple.Create("\"", 4989)
, Tuple.Create(Tuple.Create("", 4942), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/plugins/inputmask/jquery.inputmask.js")
, 4942), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 5013), Tuple.Create("\"", 5077)
, Tuple.Create(Tuple.Create("", 5019), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/MplisScripts/WebGIS/Scripts/jquery.jqGrid.min.js")
, 5019), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 5101), Tuple.Create("\"", 5162)
, Tuple.Create(Tuple.Create("", 5107), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/MplisScripts/WebGIS/Scripts/grid.locale-en.js")
, 5107), false)
);

WriteLiteral("></script>\r\n\r\n    <!--Thư viện javascript ArcGis JavaAPI-->\r\n    <script");

WriteLiteral(" src=\"http://js.arcgis.com/3.18/\"");

WriteLiteral("></script>\r\n    \r\n    ");

WriteLiteral("\r\n    <!--Load danh sách xã được phân quyền cho người dùng-->\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 5443), Tuple.Create("\"", 5496)
, Tuple.Create(Tuple.Create("", 5449), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/MplisScripts/WebGIS/Tools/loaddsXa.js")
, 5449), false)
);

WriteLiteral("></script>\r\n    <!--Xuất dữ liệu-->\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 5545), Tuple.Create("\"", 5600)
, Tuple.Create(Tuple.Create("", 5551), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/MplisScripts/WebGIS/Tools/exportdata.js")
, 5551), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 5624), Tuple.Create("\"", 5675)
, Tuple.Create(Tuple.Create("", 5630), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/MplisScripts/WebGIS/MapUtilities.js")
, 5630), false)
);

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" src=\"https://cdn.rawgit.com/Chaussette/esri.symbol.MultiLineTextSymbol/master/es" +
"ri.symbol.MultiLineTextSymbol.js\"");

WriteLiteral("></script>\r\n    <style>\r\n        .toppanel {\r\n            top: 20px !important;\r\n" +
"        }\r\n\r\n        .modeless {\r\n            top: 10%;\r\n            left: 50%;\r" +
"\n            bottom: auto;\r\n            right: auto;\r\n            margin-left: -" +
"300px;\r\n        }\r\n\r\n        .modal {\r\n            background: rgba(0,0,0,0);\r\n " +
"       }\r\n\r\n        .content {\r\n            min-height: unset;\r\n            padd" +
"ing: unset;\r\n            margin-right: auto;\r\n            margin-left: auto;\r\n  " +
"          padding-left: unset;\r\n            padding-right: unset;\r\n        }\r\n\r\n" +
"        table {\r\n            white-space: nowrap;\r\n        }\r\n\r\n        .table-f" +
"ixed thead {\r\n            width: 97%;\r\n        }\r\n\r\n        .table-fixed tbody {" +
"\r\n            height: 230px;\r\n            overflow-y: auto;\r\n            width: " +
"100%;\r\n        }\r\n\r\n        .table-fixed thead, .table-fixed tbody, .table-fixed" +
" tr, .table-fixed td, .table-fixed th {\r\n            display: block;\r\n        }\r" +
"\n\r\n            .table-fixed tbody td, .table-fixed thead > tr > th {\r\n          " +
"      border-bottom-width: 0;\r\n                float: left;\r\n            }\r\n\r\n  " +
"      #myProgress {\r\n            width: 100%;\r\n            height: 20px;\r\n      " +
"      background-color: #ddd;\r\n        }\r\n\r\n        #myBar {\r\n            positi" +
"on: relative;\r\n            width: 0%;\r\n            height: 20px;\r\n            ba" +
"ckground-color: #3CB371;\r\n        }\r\n\r\n        #label {\r\n            text-align:" +
" center;\r\n            color: white;\r\n            height: 20px;\r\n            widt" +
"h: 100%;\r\n        }\r\n    </style>\r\n\r\n</head>\r\n<body");

WriteLiteral(" class=\"hold-transition skin-black-light sidebar-mini\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"wrapper\"");

WriteLiteral(">\r\n        <!-- Main Header -->\r\n        <header");

WriteLiteral(" class=\"main-header\"");

WriteLiteral(">\r\n            <!-- Logo -->\r\n            <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" class=\"logo\"");

WriteLiteral(">\r\n                <!-- mini logo for sidebar mini 50x50 pixels -->\r\n            " +
"    <span");

WriteLiteral(" class=\"logo-mini\"");

WriteLiteral("><b>ViLIS</b></span>\r\n                <!-- logo for regular state and mobile devi" +
"ces -->\r\n                <span");

WriteLiteral(" class=\"logo-lg\"");

WriteLiteral("><b>ViLIS 3.0</b></span>\r\n            </a>\r\n            <!-- Header Navbar -->\r\n " +
"           <nav");

WriteLiteral(" class=\"navbar navbar-static-top\"");

WriteLiteral(" role=\"navigation\"");

WriteLiteral(">\r\n                <!-- Sidebar toggle button-->\r\n                <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" class=\"sidebar-toggle\"");

WriteLiteral(" data-toggle=\"offcanvas\"");

WriteLiteral(" role=\"button\"");

WriteLiteral(">\r\n                    <span");

WriteLiteral(" class=\"sr-only\"");

WriteLiteral(">Toggle navigation</span>\r\n                    <span");

WriteLiteral(" class=\"logo-mini \"");

WriteLiteral(" style=\"font-family:\'Times New Roman\', Times, serif; font-size:16px;\"");

WriteLiteral("> &nbsp; &nbsp; Hệ thống thông tin đất đai quốc gia đa mục tiêu - MPLIS</span>\r\n " +
"               </a>\r\n\r\n                <!-- Navbar Right Menu -->\r\n             " +
"   <div");

WriteLiteral(" class=\"navbar-custom-menu\"");

WriteLiteral(">\r\n\r\n                    <ul");

WriteLiteral(" class=\"nav navbar-nav\"");

WriteLiteral(">\r\n\r\n                        <li");

WriteLiteral(" class=\"dropdown messages-menu\"");

WriteLiteral(">\r\n                            <!-- Menu Home -->\r\n                            <a" +
"");

WriteAttribute("href", Tuple.Create(" href=\"", 8694), Tuple.Create("\"", 8713)
, Tuple.Create(Tuple.Create("", 8701), Tuple.Create<System.Object, System.Int32>(Href("~/Home/Index")
, 8701), false)
);

WriteLiteral(" class=\"fa fa-home\"");

WriteLiteral(" data-toggle=\"tooltip\"");

WriteLiteral(" data-placement=\"bottom\"");

WriteLiteral(" title=\"Trang chủ\"");

WriteLiteral("></a>\r\n                        </li>\r\n                        <!-- Notifications " +
"Menu -->\r\n                        <li");

WriteLiteral(" class=\"dropdown notifications-menu\"");

WriteLiteral(">\r\n                            <!-- Menu Bản đồ -->\r\n                            " +
"<a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" class=\"fa fa-chain\"");

WriteLiteral(" data-toggle=\"tooltip\"");

WriteLiteral(" data-placement=\"bottom\"");

WriteLiteral(" title=\"Bản đồ\"");

WriteLiteral("></a>\r\n                        </li>\r\n                        <!-- Tasks Menu -->" +
"\r\n                        <li");

WriteLiteral(" class=\"dropdown tasks-menu dvhc_home\"");

WriteLiteral(">\r\n                            <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" class=\"tooltipx\"");

WriteLiteral(" data-placement=\"bottom\"");

WriteLiteral(" title=\"Đổi đơn vị hành chính làm việc\"");

WriteLiteral(" data-toggle=\"modal\"");

WriteLiteral(" data-target=\"#doiDVHC\"");

WriteLiteral(">\r\n                                <i");

WriteLiteral(" class=\"fa fa-building-o\"");

WriteLiteral("></i>\r\n                            </a>\r\n                        </li>\r\n         " +
"               <!-- User Account Menu -->\r\n                        <li");

WriteLiteral(" class=\"dropdown user user-menu\"");

WriteLiteral(">\r\n                            <!-- Menu Toggle Button -->\r\n                     " +
"       ");

WriteLiteral("\r\n");

WriteLiteral("                            ");

            
            #line 217 "..\..\Views\Shared\_LayoutMapHome.cshtml"
                       Write(Html.Partial("_AnhDaiDien"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            ");

WriteLiteral(@"
                        </li>
                    </ul>
                    <!-- Control Sidebar Toggle Button -->
                </div>
            </nav>
        </header>
        <!-- Left side column. contains the logo and sidebar -->
        <aside");

WriteLiteral(" class=\"main-sidebar\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 227 "..\..\Views\Shared\_LayoutMapHome.cshtml"
       Write(Html.Partial("_LeftMenu"));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </aside>\r\n\r\n        <!-- Content Wrapper. Contains page content -->\r\n\r\n" +
"        <div");

WriteLiteral(" class=\"content-wrapper\"");

WriteLiteral(">\r\n            <section");

WriteLiteral(" class=\"content\"");

WriteLiteral(" id=\"ContentSection\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 234 "..\..\Views\Shared\_LayoutMapHome.cshtml"
           Write(RenderBody());

            
            #line default
            #line hidden
WriteLiteral("\r\n                <div");

WriteLiteral(" id=\"loading-img\"");

WriteLiteral("></div>\r\n            </section>\r\n        </div>\r\n        <!-- /.content-wrapper -" +
"->\r\n        <!-- Main Footer -->\r\n");

WriteLiteral("        ");

            
            #line 240 "..\..\Views\Shared\_LayoutMapHome.cshtml"
   Write(Html.Action("_MainFooter", "Home"));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n        <!-- Control Sidebar -->\r\n        <aside");

WriteLiteral(" class=\"control-sidebar control-sidebar-dark\"");

WriteLiteral(">\r\n            <!-- Create the tabs -->\r\n            <ul");

WriteLiteral(" class=\"nav nav-tabs nav-justified control-sidebar-tabs\"");

WriteLiteral(">\r\n                <li");

WriteLiteral(" class=\"active\"");

WriteLiteral("><a");

WriteLiteral(" href=\"#control-sidebar-home-tab\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-home\"");

WriteLiteral("></i></a></li>\r\n                <li><a");

WriteLiteral(" href=\"#control-sidebar-settings-tab\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-gears\"");

WriteLiteral("></i></a></li>\r\n            </ul>\r\n            <!-- Tab panes -->\r\n        </asid" +
"e>\r\n        <div");

WriteLiteral(" class=\"control-sidebar-bg\"");

WriteLiteral("></div>\r\n    </div>\r\n    <!-- ./wrapper -->\r\n    <!--Popup thay đổi mật khẩu-->\r\n" +
"    ");

WriteLiteral(@"
    <script>
        $('document').ready(function () {
            $('#doimkbt').click(function () {
                window.location.hash = '#doimk';
            });
            if (window.location.hash && window.location.hash == '#doimk') {
                $('#DoiMatKhau').modal('show');
            }
            if ($(""#HienThiPopUp"").val() == ""co"") {
                $('#DoiMatKhau').modal('show');
            }
            $(""#txtDuongDanUrl"").val(window.location.href);
            $(""#txtDuongDanUrl2"").val(window.location.href);
            $(""#txtUrlThayDoiThongTinNguoiDung"").val(window.location.href);
        });
    </script>
    ");

WriteLiteral("\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
        function KiemTraNhapXacNhanMatKhau() {
            if ($(""#txtMatKhauMoi"").val() == $(""#txtXacNhanMatKhau"").val()) {
                if ($(""#txtMatKhauMoi"").val() == $(""#txtMatKhauHienTai"").val()) {
                    alert(""Không nhập mật khẩu mới trùng với mật khẩu hiện tại !"");
                    return false;
                }
                else {
                    return true;
                }
            }
            else {
                alert(""Nhập xác nhận mật khẩu sai !"");
                return false;
            }
        }
    </script>
    ");

WriteLiteral("\r\n    <div");

WriteLiteral(" class=\"container\"");

WriteLiteral(" id=\"GenerateDoiMatKhaudlg\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 297 "..\..\Views\Shared\_LayoutMapHome.cshtml"
   Write(Html.Action("GenerateDoiMatKhau", "Home"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n");

            
            #line 299 "..\..\Views\Shared\_LayoutMapHome.cshtml"
    
            
            #line default
            #line hidden
            
            #line 299 "..\..\Views\Shared\_LayoutMapHome.cshtml"
     using (Html.BeginForm("ThoatDoiMatKhau", "Home", FormMethod.Post, new { @name = "ThoatDoiMatKhau" }))
    {

            
            #line default
            #line hidden
WriteLiteral("        <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" class=\"text\"");

WriteLiteral(" name=\"txtDuongDanUrl2\"");

WriteLiteral(" id=\"txtDuongDanUrl2\"");

WriteLiteral(" value=\"\"");

WriteLiteral(" />\r\n");

            
            #line 302 "..\..\Views\Shared\_LayoutMapHome.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("    <!--End Thay đổi mật khẩu-->\r\n    <!--Popup Thông tin cá nhân-->\r\n    <div");

WriteLiteral(" class=\"container\"");

WriteLiteral(" id=\"GenerateThongTinCaNhandlg\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 306 "..\..\Views\Shared\_LayoutMapHome.cshtml"
   Write(Html.Action("GenerateThongTinCaNhan", "Home"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n    <!--End Thông tin cá nhân-->\r\n    <div");

WriteLiteral(" class=\"container\"");

WriteLiteral(" id=\"genChonDonViHanhChinhdlg\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 310 "..\..\Views\Shared\_LayoutMapHome.cshtml"
   Write(Html.Action("genChonDonViHanhChinh", "Home"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</body>\r\n</html>\r\n\r\n");

WriteLiteral("\r\n");

WriteLiteral("\r\n<script");

WriteLiteral(" language=\"javascript\"");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n\r\n    function readURL(input) {\r\n        if (input.files && input.files[0]) {\r" +
"\n            var reader = new FileReader();\r\n\r\n            reader.onload = funct" +
"ion (e) {\r\n                $(\'#file\')\r\n                    .attr(\'src\', e.target" +
".result)\r\n                    .width(80)\r\n                    .height(90);\r\n    " +
"        };\r\n\r\n            reader.readAsDataURL(input.files[0]);\r\n        }\r\n    " +
"}\r\n    function thoatdmk() {\r\n        //alert(\"dfgdgdgdgfdgd\");\r\n        documen" +
"t.ThoatDoiMatKhau.submit(); // Submit form co thuoc tinh \'name\' là: ThoatDoiMatK" +
"hau (chu y: phuong thuc truyen du lieu là kieu POST - dung cho Form)\r\n\r\n    }\r\n " +
"   // ham MenuMauBanhMy\r\n    //function MenuMauBanhMy() {\r\n    //    debugger\r\n " +
"   //    var abc = $(this).attr(\'menuId\');\r\n    //    alert(abc);\r\n    //    doc" +
"ument.cookie = \"MenuMauBanhMy = \" + abc;\r\n    //}\r\n    // chon ung dung khi refr" +
"esh ai trang\r\n    window.onbeforeunload = function (e) {\r\n        // xoa cookie " +
"xac dinh UngDung duoc chon\r\n        document.cookie = \"UngDungDuocChon=; expires" +
"=Thu, 01 Jan 1970 00:00:00 UTC; path=/\";\r\n        // Khoi tao UngDung duoc chon\r" +
"\n        var ungDung = $(\"#UngDungDuocChon\").attr(\'ThuTuXapSep\');\r\n        docum" +
"ent.cookie = \"UngDungDuocChon =\" + ungDung + \"; path=/\";\r\n    }\r\n    $(document)" +
".on(\'click\', \'.MenuMauBanhMyId\', function () {\r\n        // xoa cookie xac dinh U" +
"ngDung duoc chon\r\n        document.cookie = \"UngDungDuocChon=; expires=Thu, 01 J" +
"an 1970 00:00:00 UTC; path=/\";\r\n        // Khoi tao UngDung duoc chon\r\n        v" +
"ar ungDung = $(\"#UngDungDuocChon\").attr(\'ThuTuXapSep\');\r\n        document.cookie" +
" = \"UngDungDuocChon =\" + ungDung + \"; path=/\";\r\n\r\n        // xoa cookie MenuMauB" +
"anhMy\r\n        document.cookie = \"MenuMauBanhMy=; expires=Thu, 01 Jan 1970 00:00" +
":00 UTC; path=/\";\r\n        // khoi tao cookie luu controller trong url\r\n        " +
"var chuoiUrl = $(this).attr(\'href\');\r\n        if (chuoiUrl != \"\") {\r\n           " +
" chuoiUrl = chuoiUrl.substring(chuoiUrl.indexOf(\"/\") + 1);\r\n            chuoiUrl" +
" = chuoiUrl.substring(0, chuoiUrl.indexOf(\"/\"));\r\n        }\r\n        document.co" +
"okie = \"ControllerTrongUrl =\" + chuoiUrl + \"; path=/\";\r\n        // khoi tao cook" +
"ie luu ten chuoi menu\r\n        document.cookie = \"MenuMauBanhMy =\" + encodeURICo" +
"mponent($(this).text() + \"~^\") + getCookie(\"MenuMauBanhMy\") + \"; path=/\";\r\n     " +
"   TimChaCuaNode($(this).attr(\'khoachaid\'))\r\n    });\r\n\r\n    function TimChaCuaNo" +
"de(khoaChaIdCuaNode) {\r\n        $(\".MenuMauBanhMyId\").each(function () {\r\n      " +
"      if ($(this).attr(\'menuid\') == khoaChaIdCuaNode) {\r\n                documen" +
"t.cookie = \"MenuMauBanhMy =\" + encodeURIComponent($(this).text() + \"~^\") + getCo" +
"okie(\"MenuMauBanhMy\") + \"; path=/\";\r\n                TimChaCuaNode($(this).attr(" +
"\'khoachaid\'))\r\n                return false;\r\n            }\r\n        })\r\n    }\r\n" +
"\r\n    function getCookie(cname) {\r\n        var name = cname + \"=\";\r\n        var " +
"ca = document.cookie.split(\';\');\r\n        for (var i = 0; i < ca.length; i++) {\r" +
"\n            var c = ca[i];\r\n            while (c.charAt(0) == \' \') {\r\n         " +
"       c = c.substring(1);\r\n            }\r\n            if (c.indexOf(name) == 0)" +
" {\r\n                return c.substring(name.length, c.length);\r\n            }\r\n " +
"       }\r\n        return \"\";\r\n    }\r\n    //$(document).ready(function () {\r\n    " +
"//    debugger\r\n    //    var controllerTrongUrl = getCookie(\"ControllerTrongUrl" +
"\");\r\n    //    var urlHienTai = window.location.pathname;\r\n    //    if (urlHien" +
"Tai != \"\") {\r\n    //        urlHienTai = urlHienTai.substring(urlHienTai.indexOf" +
"(\"/\") + 1);\r\n    //        urlHienTai = urlHienTai.substring(0, urlHienTai.index" +
"Of(\"/\"));\r\n    //    }\r\n    //    if(controllerTrongUrl != urlHienTai){\r\n    // " +
"       // xoa cookie\r\n    //        document.cookie = \"MenuMauBanhMy=; expires=T" +
"hu, 01 Jan 1970 00:00:00 UTC; path=/\";\r\n    //    }\r\n    //});\r\n\r\n    // duy tri" +
" session de ket noi voi server (khong dung cach nay)\r\n\r\n    //function heartBeat" +
"() {\r\n    //    $.get(\"/Home/ThongBaoQuyenNguoiDung?\", function (data) { });\r\n  " +
"  //}\r\n\r\n    //$(function () {\r\n    //    setInterval(\"heartBeat()\", 1000 * 30);" +
" // 30s gửi request một lần\r\n    //});\r\n\r\n    $(function () {\r\n        var $back" +
"drop = null;\r\n        $(\'.mplis_menu\').click(function (e) {\r\n            e.preve" +
"ntDefault();\r\n            var url = $(this).attr(\'href\');\r\n            var res =" +
" url.split(\"/\");\r\n\r\n            $.ajax({\r\n                url: url,\r\n           " +
"     //beforeSend: OnBeginWork,\r\n                beforeSend: function onBegin(vO" +
"bject) {\r\n                    $backdrop = $(\'<div><div class=\"modal222\"></div></" +
"div>\').appendTo(document.body);\r\n                    $(\'#image_loading\').show();" +
"\r\n                },\r\n                complete: function onComplete(vObject) {\r\n" +
"                    $($backdrop).fadeOut(100, function () {\r\n                   " +
"     $(\'.modal222\').parent().remove();\r\n                    });\r\n               " +
"     $(\'#image_loading\').hide();\r\n                },\r\n                success: f" +
"unction (html) {\r\n                    $(\'#ContentSection\').html(html);\r\n        " +
"        }\r\n            });\r\n\r\n        });\r\n\r\n    });\r\n\r\n</script>\r\n");

        }
    }
}
#pragma warning restore 1591
