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
    
    #line 1 "..\..\Views\XLHSHoSoLuuKho\_PopUp_ViTriLuu.cshtml"
    using AppCore.Models;
    
    #line default
    #line hidden
    using MPLIS;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/XLHSHoSoLuuKho/_PopUp_ViTriLuu.cshtml")]
    public partial class _Views_XLHSHoSoLuuKho__PopUp_ViTriLuu_cshtml : System.Web.Mvc.WebViewPage<AppCore.Models.HS_VITRILUUTRU>
    {
        public _Views_XLHSHoSoLuuKho__PopUp_ViTriLuu_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" class=\'modal fade\'");

WriteLiteral(" id=\'modalformViTriLuu\'");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\'modal-dialog\'");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\'modal-content\'");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\'modal-header\'");

WriteLiteral(">\r\n                <button");

WriteLiteral(" id=\"closebt\"");

WriteLiteral(" type=\'button\'");

WriteLiteral(" class=\'close\'");

WriteLiteral(" data-dismiss=\'modal\'");

WriteLiteral(">&times;</button>\r\n                <h4");

WriteLiteral(" class=\'modal-title\'");

WriteLiteral(" id=\"title_popup_vitriluu\"");

WriteLiteral(">Vị trí lưu trữ</h4>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\'modal-body\'");

WriteLiteral(" id=\"modalformViTriLuu_body\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 11 "..\..\Views\XLHSHoSoLuuKho\_PopUp_ViTriLuu.cshtml"
           Write(Html.HiddenFor(m => m.VITRILUUTRUID, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                    <div>\r\n                        <div");

WriteLiteral(" class=\"col-xs-3\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 15 "..\..\Views\XLHSHoSoLuuKho\_PopUp_ViTriLuu.cshtml"
                       Write(Html.LabelFor(Model => Model.MAVITRILUUTRU, "Mã vị trí lưu trữ", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                        <div");

WriteLiteral(" class=\"col-xs-7\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 18 "..\..\Views\XLHSHoSoLuuKho\_PopUp_ViTriLuu.cshtml"
                       Write(Html.TextBoxFor(Model => Model.MAVITRILUUTRU, new { @class = "form-control input-sm", @readonly = "true" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </d" +
"iv>\r\n                <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                    <div>\r\n                        <div");

WriteLiteral(" class=\"col-xs-3\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 25 "..\..\Views\XLHSHoSoLuuKho\_PopUp_ViTriLuu.cshtml"
                       Write(Html.LabelFor(Model => Model.TENVITRILUUTRU, "Tên vị trí lưu trữ", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                        <div");

WriteLiteral(" class=\"col-xs-7\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 28 "..\..\Views\XLHSHoSoLuuKho\_PopUp_ViTriLuu.cshtml"
                       Write(Html.TextBoxFor(m => m.TENVITRILUUTRU, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </d" +
"iv>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\'modal-footer\'");

WriteLiteral(" style=\'text-align:center;\'");

WriteLiteral(">\r\n                <button");

WriteLiteral(" type=\'submit\'");

WriteLiteral(" id=\"btnthemvitriluu\"");

WriteLiteral(" class=\'t100 btn btn-primary btn-sm pull-right\'");

WriteLiteral(">Lưu</button>\r\n                <button");

WriteLiteral(" type=\'submit\'");

WriteLiteral(" id=\"btnlammoivitriluu\"");

WriteLiteral(" class=\'t100 btn btn-primary btn-sm pull-left\'");

WriteLiteral(">Làm mới</button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n<scrip" +
"t>\r\n    $(document).ready(function () {\r\n        $(\'#btnthemvitriluu\').on(\'click" +
"\', function () {\r\n            var loai = $(\'#MAVITRILUUTRU\').val();\r\n           " +
" var ten = $(\'#TENVITRILUUTRU\').val();\r\n            var id = $(\'#VITRILUUTRUID\')" +
".val();\r\n            $.ajax({\r\n                type: \"POST\",\r\n                ur" +
"l: \"/XLHSHoSoLuuKho/CapNhatViTri\",\r\n                data: { Loai: loai, ten: ten" +
",id:id },\r\n                success: function (data) {\r\n                    $(\'#d" +
"rpKeHSLuuKho\').html();\r\n                    console.log(data);\r\n                " +
"    if (data.trangthai == \"capnhat\") {\r\n                        $(\'#closebt\').cl" +
"ick();\r\n                        if (data.vitrima == \"001\") {\r\n                  " +
"          var drpphong = document.getElementById(\'drpPhongHSLuuKho\');\r\n         " +
"                   drpphong.options[drpphong.selectedIndex].innerHTML = data.vit" +
"riten;\r\n                        }\r\n                        else if (data.vitrima" +
" == \"002\") {\r\n                            var drpke = document.getElementById(\'d" +
"rpKeHSLuuKho\');\r\n                            drpke.options[drpke.selectedIndex]." +
"innerHTML = data.vitriten;\r\n                        }\r\n                        e" +
"lse if (data.vitrima == \"003\") {\r\n                            var drpngan = docu" +
"ment.getElementById(\'drpNganHSLuuKho\');\r\n                            drpngan.opt" +
"ions[drpngan.selectedIndex].innerHTML = data.vitriten;\r\n                        " +
"}\r\n                        else if (data.vitrima == \"004\") {\r\n                  " +
"          var drphop = document.getElementById(\'drpHopHSLuuKho\');\r\n             " +
"               drphop.options[drphop.selectedIndex].innerHTML = data.vitriten;\r\n" +
"                        }\r\n                    }\r\n                    else {\r\n  " +
"                      if (data.vitrima == \"001\") {\r\n                            " +
"var option = new Option(data.vitriten, data.vitriid); $(\'#drpPhongHSLuuKho\').app" +
"end($(option));\r\n                        }\r\n                        else if (dat" +
"a.vitrima == \"002\") {\r\n                            var option = new Option(data." +
"vitriten, data.vitriid); $(\'#drpKeHSLuuKho\').append($(option));\r\n               " +
"         }\r\n                        else if (data.vitrima == \"003\") {\r\n         " +
"                   var option = new Option(data.vitriten, data.vitriid); $(\'#drp" +
"NganHSLuuKho\').append($(option));\r\n                        }\r\n                  " +
"      else if (data.vitrima == \"004\") {\r\n                            var option " +
"= new Option(data.vitriten, data.vitriid); $(\'#drpHopHSLuuKho\').append($(option)" +
");\r\n                        }\r\n                        $(\'#VITRILUUTRUID\').val(\"" +
"\");\r\n                        $(\'#TENVITRILUUTRU\').val(\"\");\r\n                    " +
"}\r\n\r\n                }\r\n            });\r\n\r\n        });\r\n        $(\'#btnlammoivit" +
"riluu\').on(\'click\', function () {\r\n            $(\'#VITRILUUTRUID\').val(\"\");\r\n   " +
"         $(\'#TENVITRILUUTRU\').val(\"\");\r\n        });\r\n    });\r\n</script>");

        }
    }
}
#pragma warning restore 1591