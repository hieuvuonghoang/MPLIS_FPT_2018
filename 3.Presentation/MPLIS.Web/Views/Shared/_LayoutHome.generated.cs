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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/_LayoutHome.cshtml")]
    public partial class _Views_Shared__LayoutHome_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Shared__LayoutHome_cshtml()
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

WriteLiteral(">\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteAttribute("href", Tuple.Create(" href=\"", 383), Tuple.Create("\"", 413)
, Tuple.Create(Tuple.Create("", 390), Tuple.Create<System.Object, System.Int32>(Href("~/Content/normalize.css")
, 390), false)
);

WriteLiteral(">\r\n    <!-- Bootstrap 3.3.7 -->\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteAttribute("href", Tuple.Create(" href=\"", 473), Tuple.Create("\"", 503)
, Tuple.Create(Tuple.Create("", 480), Tuple.Create<System.Object, System.Int32>(Href("~/Content/bootstrap.css")
, 480), false)
);

WriteLiteral(">\r\n    <!-- Font Awesome -->\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteAttribute("href", Tuple.Create(" href=\"", 560), Tuple.Create("\"", 593)
, Tuple.Create(Tuple.Create("", 567), Tuple.Create<System.Object, System.Int32>(Href("~/Content/font-awesome.css")
, 567), false)
);

WriteLiteral(">\r\n    <!-- Ionicons -->\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteAttribute("href", Tuple.Create(" href=\"", 646), Tuple.Create("\"", 675)
, Tuple.Create(Tuple.Create("", 653), Tuple.Create<System.Object, System.Int32>(Href("~/Content/ionicons.css")
, 653), false)
);

WriteLiteral(">\r\n    <!-- Theme style -->\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteAttribute("href", Tuple.Create(" href=\"", 731), Tuple.Create("\"", 769)
, Tuple.Create(Tuple.Create("", 738), Tuple.Create<System.Object, System.Int32>(Href("~/Content/AdminLTE/AdminLTE.css")
, 738), false)
);

WriteLiteral(">\r\n    <!-- AdminLTE skins -->\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteAttribute("href", Tuple.Create(" href=\"", 828), Tuple.Create("\"", 874)
, Tuple.Create(Tuple.Create("", 835), Tuple.Create<System.Object, System.Int32>(Href("~/Content/AdminLTE/skins/_all-skins.css")
, 835), false)
);

WriteLiteral(">\r\n    <!-- Google fonts -->\r\n    ");

WriteLiteral("\r\n    <!-- Custom css -->\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteAttribute("href", Tuple.Create(" href=\"", 1098), Tuple.Create("\"", 1123)
, Tuple.Create(Tuple.Create("", 1105), Tuple.Create<System.Object, System.Int32>(Href("~/Content/Site.css")
, 1105), false)
);

WriteLiteral(">\r\n</head>\r\n\r\n<body");

WriteLiteral(" class=\"sidebar-mini skin-green-light layout-boxed\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"wrapper\"");

WriteLiteral(">\r\n        <!-- Main Header -->\r\n        <header");

WriteLiteral(" class=\"main-header\"");

WriteLiteral(">\r\n            <!-- Logo -->\r\n            <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" class=\"logo\"");

WriteLiteral(">\r\n                ");

WriteLiteral("\r\n                <span");

WriteLiteral(" class=\"logo-lg\"");

WriteLiteral("><b>ViLIS</b> 3.0</span>\r\n                ");

WriteLiteral("\r\n            </a>\r\n            <!-- Header Navbar -->\r\n            <nav");

WriteLiteral(" class=\"navbar navbar-static-top\"");

WriteLiteral(">\r\n                <!-- Sidebar toggle button-->\r\n                <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" class=\"sidebar-toggle\"");

WriteLiteral(" data-toggle=\"push-menu\"");

WriteLiteral(" role=\"button\"");

WriteLiteral(">\r\n                    <span");

WriteLiteral(" class=\"sr-only\"");

WriteLiteral(">Toggle navigation</span>\r\n                    ");

WriteLiteral("\r\n                </a>\r\n                <div");

WriteLiteral(" class=\"navbar-header\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"navbar-brand\"");

WriteLiteral(" style=\"font-family:\'Times New Roman\', Times, serif;padding-left:4px;padding-righ" +
"t:4px;\"");

WriteLiteral("><b>Hệ thống thông tin đất đai quốc gia đa mục tiêu - MPLIS</b></div>\r\n          " +
"      </div>\r\n                <!-- Navbar Right Menu -->\r\n                <div");

WriteLiteral(" class=\"navbar-right\"");

WriteLiteral(">\r\n                    <ul");

WriteLiteral(" class=\"nav navbar-nav\"");

WriteLiteral(">\r\n                        <li");

WriteLiteral(" class=\"dropdown messages-menu\"");

WriteLiteral(">\r\n                            <!-- Menu Home -->\r\n                            <a" +
"");

WriteAttribute("href", Tuple.Create(" href=\"", 2471), Tuple.Create("\"", 2490)
, Tuple.Create(Tuple.Create("", 2478), Tuple.Create<System.Object, System.Int32>(Href("~/Home/Index")
, 2478), false)
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

WriteLiteral("></a>\r\n                        </li>\r\n                        <li");

WriteLiteral(" class=\"dropdown tasks-menu\"");

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
"               <li");

WriteLiteral(" class=\"dropdown user user-menu\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 64 "..\..\Views\Shared\_LayoutHome.cshtml"
                       Write(Html.Action("GenerateAnhDaiDien", "Home"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </li>\r\n                    </ul>\r\n                </div" +
">\r\n            </nav>\r\n        </header>\r\n        <!-- Left side column. contain" +
"s the logo and sidebar -->\r\n        <aside");

WriteLiteral(" class=\"main-sidebar\"");

WriteLiteral(">\r\n            <!-- sidebar: style can be found in sidebar.less -->\r\n            " +
"");

WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 74 "..\..\Views\Shared\_LayoutHome.cshtml"
       Write(Html.Action("GenerateMenu", "Home"));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </aside>\r\n\r\n        <!-- Content Wrapper. Contains page content -->\r\n  " +
"      <div");

WriteLiteral(" class=\"content-wrapper\"");

WriteLiteral(" id=\"ContentSection\"");

WriteLiteral(">\r\n            <!-- Your Page Content Here -->\r\n");

WriteLiteral("            ");

            
            #line 80 "..\..\Views\Shared\_LayoutHome.cshtml"
       Write(RenderBody());

            
            #line default
            #line hidden
WriteLiteral("\r\n            <!-- /.content -->\r\n            <!-- /.content-wrapper -->\r\n       " +
" </div>\r\n        <!-- Main Footer -->\r\n");

WriteLiteral("        ");

            
            #line 85 "..\..\Views\Shared\_LayoutHome.cshtml"
   Write(Html.Action("_MainFooter", "Home"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n    <div");

WriteLiteral(" id=\"loading-img\"");

WriteLiteral("></div>\r\n    <div");

WriteLiteral(" class=\"control-sidebar-bg\"");

WriteLiteral("></div>\r\n\r\n    <div");

WriteLiteral(" class=\"container\"");

WriteLiteral(" id=\"GenerateDoiMatKhaudlg\"");

WriteLiteral(">\r\n        <!-- Modal -->\r\n");

WriteLiteral("        ");

            
            #line 92 "..\..\Views\Shared\_LayoutHome.cshtml"
   Write(Html.Action("GenerateDoiMatKhau", "Home"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n    <!--End Thay đổi mật khẩu-->\r\n    <!--Popup Thông tin cá nhân--" +
">\r\n    <div");

WriteLiteral(" class=\"container\"");

WriteLiteral(" id=\"GenerateThongTinCaNhandlg\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 97 "..\..\Views\Shared\_LayoutHome.cshtml"
   Write(Html.Action("GenerateThongTinCaNhan", "Home"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n    <!--End Thông tin cá nhân-->\r\n    <div");

WriteLiteral(" class=\"container\"");

WriteLiteral(" id=\"genChonDonViHanhChinhdlg\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 101 "..\..\Views\Shared\_LayoutHome.cshtml"
   Write(Html.Action("genChonDonViHanhChinh", "Home"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n    ");

WriteLiteral("\r\n\r\n    <!-- jQuery 3.3.1 -->\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 4919), Tuple.Create("\"", 4948)
, Tuple.Create(Tuple.Create("", 4925), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/jquery.min.js")
, 4925), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 4972), Tuple.Create("\"", 5014)
, Tuple.Create(Tuple.Create("", 4978), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/jquery.unobtrusive-ajax.js")
, 4978), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 5038), Tuple.Create("\"", 5076)
, Tuple.Create(Tuple.Create("", 5044), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/jquery.validate.min.js")
, 5044), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 5100), Tuple.Create("\"", 5150)
, Tuple.Create(Tuple.Create("", 5106), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/jquery.validate.unobtrusive.min.js")
, 5106), false)
);

WriteLiteral("></script>\r\n    <!-- Bootstrap 3.3.7 -->\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 5204), Tuple.Create("\"", 5236)
, Tuple.Create(Tuple.Create("", 5210), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/bootstrap.min.js")
, 5210), false)
);

WriteLiteral("></script>\r\n    <!-- SlimScroll -->\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 5285), Tuple.Create("\"", 5344)
, Tuple.Create(Tuple.Create("", 5291), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/plugins/slimScroll/jquery.slimscroll.min.js")
, 5291), false)
);

WriteLiteral("></script>\r\n    <!-- AdminLTE App -->\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 5395), Tuple.Create("\"", 5431)
, Tuple.Create(Tuple.Create("", 5401), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/AdminLTE/adminlte.js")
, 5401), false)
);

WriteLiteral("></script>\r\n    <!-- Custom scripts -->\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 5484), Tuple.Create("\"", 5517)
, Tuple.Create(Tuple.Create("", 5490), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/MplisUtilities.js")
, 5490), false)
);

WriteLiteral("></script>\r\n</body>\r\n</html>\r\n\r\n");

WriteLiteral("\r\n<script");

WriteLiteral(" language=\"javascript\"");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">

    function readURL(input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $('#file')
                    .attr('src', e.target.result)
                    .width(80)
                    .height(90);
            };

            reader.readAsDataURL(input.files[0]);
        }
    }
    function thoatdmk() {
        //alert(""dfgdgdgdgfdgd"");
        document.ThoatDoiMatKhau.submit(); // Submit form co thuoc tinh 'name' là: ThoatDoiMatKhau (chu y: phuong thuc truyen du lieu là kieu POST - dung cho Form)

    }

    ");

WriteLiteral("\r\n    function KiemTraNhapXacNhanMatKhau() {\r\n        if ($(\"#txtMatKhauHienTai\")" +
".val() == \"\") {\r\n            alert(\"Chưa nhập mật khẩu hiện tại !\");\r\n          " +
"  return false;\r\n        }\r\n        else {\r\n            if ($(\"#txtMatKhauMoi\")." +
"val() == \"\") {\r\n                alert(\"Chưa nhập mật khẩu mới !\");\r\n            " +
"    return false;\r\n            }\r\n            else {\r\n                if ($(\"#tx" +
"tXacNhanMatKhau\").val() == \"\") {\r\n                    alert(\"Chưa nhập xác nhận " +
"mật khẩu !\");\r\n                    return false;\r\n                }\r\n           " +
"     else {\r\n                    if ($(\"#txtMatKhauMoi\").val() == $(\"#txtXacNhan" +
"MatKhau\").val()) {\r\n                        if ($(\"#txtMatKhauMoi\").val() == $(\"" +
"#txtMatKhauHienTai\").val()) {\r\n                            alert(\"Không nhập mật" +
" khẩu mới trùng với mật khẩu hiện tại !\");\r\n                            return f" +
"alse;\r\n                        }\r\n                        else {\r\n              " +
"              return true;\r\n                        }\r\n                    }\r\n  " +
"                  else {\r\n                        alert(\"Nhập xác nhận mật khẩu " +
"sai !\");\r\n                        return false;\r\n                    }\r\n        " +
"        }\r\n            }\r\n        }\r\n    }\r\n\r\n    //--- Hàm thay đổi mật khẩu --" +
"-\r\n    function ThayDoiMatKhau() {\r\n        if (KiemTraNhapXacNhanMatKhau()) {\r\n" +
"            var matKhauHienTai = document.getElementById(\"txtMatKhauHienTai\").va" +
"lue;\r\n            var matKhauMoi = document.getElementById(\"txtMatKhauMoi\").valu" +
"e;\r\n            var xacNhanMatKhau = document.getElementById(\"txtXacNhanMatKhau\"" +
").value;\r\n\r\n            if (confirm(\"Thay đổi mật khẩu hiện tại ?\")) {\r\n        " +
"        $.ajax({\r\n                    url: \'/Home/ThayDoiMatKhau\',\r\n            " +
"        data: {\r\n                        matKhauHienTai: matKhauHienTai,\r\n      " +
"                  matKhauMoi: matKhauMoi,\r\n                        xacNhanMatKha" +
"u: xacNhanMatKhau\r\n                    },\r\n                }).done(function (dat" +
"a) {\r\n                    if (data && data != \"\")\r\n                        alert" +
"(data);\r\n                });\r\n            }\r\n        }\r\n    }\r\n\r\n    $(function " +
"() {\r\n        var $backdrop = null;\r\n        $(\'.mplis_menu\').click(function (e)" +
" {\r\n            e.preventDefault();\r\n            var url = $(this).attr(\'href\');" +
"\r\n            var res = url.split(\"/\");\r\n\r\n            $.ajax({\r\n               " +
" url: url,\r\n                //beforeSend: OnBeginWork,\r\n                beforeSe" +
"nd: function onBegin(vObject) {\r\n                    $backdrop = $(\'<div><div cl" +
"ass=\"modal222\"></div></div>\').appendTo(document.body);\r\n                    $(\'#" +
"image_loading\').show();\r\n                },\r\n                complete: function " +
"onComplete(vObject) {\r\n                    $($backdrop).fadeOut(100, function ()" +
" {\r\n                        $(\'.modal222\').parent().remove();\r\n                 " +
"   });\r\n                    $(\'#image_loading\').hide();\r\n                },\r\n   " +
"             success: function (html) {\r\n                    $(\'#ContentSection\'" +
").html(html);\r\n                }\r\n            });\r\n        });\r\n    });\r\n\r\n</scr" +
"ipt>");

        }
    }
}
#pragma warning restore 1591
