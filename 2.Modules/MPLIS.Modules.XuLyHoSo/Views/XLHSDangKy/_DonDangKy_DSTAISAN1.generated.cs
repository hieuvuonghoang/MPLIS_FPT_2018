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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/XLHSDangKy/_DonDangKy_DSTAISAN.cshtml")]
    public partial class _Views_XLHSDangKy__DonDangKy_DSTAISAN_cshtml : System.Web.Mvc.WebViewPage<MPLIS.Libraries.Data.XuLyHoSo.Models.VM_XuLyHoSo_DK>
    {
        public _Views_XLHSDangKy__DonDangKy_DSTAISAN_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("    <form");

WriteLiteral(" id=\"IDformDonDangKy_DSTAISAN\"");

WriteLiteral(">\r\n        <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id=\"iddstaisan\"");

WriteLiteral(" />\r\n        <input");

WriteLiteral(" id=\"CurTSID\"");

WriteLiteral(" name=\"CurTSID\"");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" value=\"\"");

WriteLiteral(" style=\"display:none\"");

WriteLiteral(">\r\n        <input");

WriteLiteral(" id=\"CurCHID\"");

WriteLiteral(" name=\"CurCHID\"");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" value=\"\"");

WriteLiteral(" style=\"display:none\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-xs-7\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"box box-primary\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"box-header with-border\"");

WriteLiteral(">\r\n                        <h3");

WriteLiteral(" class=\"box-title\"");

WriteLiteral(">Chi tiết tài sản</h3>\r\n                        <input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-primary btn-sm btn-heading pull-right\"");

WriteLiteral(" id=\"btndiachi\"");

WriteLiteral(" value=\"Địa chỉ\"");

WriteLiteral(" />\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"box-body\"");

WriteLiteral(" id=\"tabs\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"tab-pane fade in active\"");

WriteLiteral(" id=\"tabTaiSan\"");

WriteLiteral(">\r\n");

            
            #line 15 "..\..\Views\XLHSDangKy\_DonDangKy_DSTAISAN.cshtml"
                            
            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\XLHSDangKy\_DonDangKy_DSTAISAN.cshtml"
                              Html.RenderAction("_DonDangKy_TSNHARIENGLE", "XLHSDangKy");
            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </d" +
"iv>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-5\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"box box-primary\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"box-header with-border\"");

WriteLiteral(" >\r\n                        <h3");

WriteLiteral(" class=\"box-title\"");

WriteLiteral(" id=\"headerthuataisan\"");

WriteLiteral(">Nằm trên thửa</h3>\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"box-body\"");

WriteLiteral(" id=\"bodythuataisan\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" id=\"thuataisan\"");

WriteLiteral(">\r\n");

            
            #line 27 "..\..\Views\XLHSDangKy\_DonDangKy_DSTAISAN.cshtml"
                            
            
            #line default
            #line hidden
            
            #line 27 "..\..\Views\XLHSDangKy\_DonDangKy_DSTAISAN.cshtml"
                              Html.RenderPartial("_lstThuaTaiSan"); 
            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                        <div");

WriteLiteral("  id=\"thuataisancanho\"");

WriteLiteral(" hidden>\r\n                            <div>\r\n                                <ul");

WriteLiteral(" class=\"nav nav-tabs nav-justified\"");

WriteLiteral(">\r\n                                    <li");

WriteLiteral(" class=\"active\"");

WriteLiteral("> <a");

WriteLiteral(" class=\"mauchu-tab\"");

WriteLiteral(" href=\"#tabThuaCanHo\"");

WriteLiteral(" id=\"openTabThuaCanHo\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">Thông tin thửa</a></li>\r\n                                    <li>               " +
" <a");

WriteLiteral(" class=\"mauchu-tab\"");

WriteLiteral(" href=\"#tabHangMucCanHo\"");

WriteLiteral(" id=\"openTabHangMucCanHo\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(" onclick=\"OpentabHM()\"");

WriteLiteral(">Hạng mục ngoài căn hộ</a></li>\r\n                                </ul>\r\n         " +
"                       <div");

WriteLiteral(" class=\"tab-content\"");

WriteLiteral(" id=\"tabs\"");

WriteLiteral(">\r\n                                    <div");

WriteLiteral(" class=\"tab-pane fade in active\"");

WriteLiteral(" id=\"tabThuaCanHo\"");

WriteLiteral(">\r\n");

            
            #line 37 "..\..\Views\XLHSDangKy\_DonDangKy_DSTAISAN.cshtml"
                                        
            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\XLHSDangKy\_DonDangKy_DSTAISAN.cshtml"
                                          Html.RenderPartial("_lstThuaTSCH"); 
            
            #line default
            #line hidden
WriteLiteral("\r\n                                    </div>\r\n                                   " +
" <div");

WriteLiteral(" class=\"tab-pane fade\"");

WriteLiteral(" id=\"tabHangMucCanHo\"");

WriteLiteral(">\r\n");

            
            #line 40 "..\..\Views\XLHSDangKy\_DonDangKy_DSTAISAN.cshtml"
                                        
            
            #line default
            #line hidden
            
            #line 40 "..\..\Views\XLHSDangKy\_DonDangKy_DSTAISAN.cshtml"
                                          Html.RenderPartial("_lstcheckhangmucNCH"); 
            
            #line default
            #line hidden
WriteLiteral(@"
                                    </div>
                                </div>
                            </div>      
                         </div>
                    </div>
                 </div>
            </div>
        </div>
        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"box-footer\"");

WriteLiteral(" style=\"border-top: 1px solid #d2d6de;\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-xs-5\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-primary btn-sm btn-heading\"");

WriteLiteral(" style=\"margin-left:10px;\"");

WriteLiteral("  id=\"btnthemmoitaisan\"");

WriteLiteral(" value=\"Lưu vào Danh sách\"");

WriteLiteral(" onclick=\"ThemMoiTS()\"");

WriteLiteral(" />\r\n                        <input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-primary btn-sm btn-heading pull-right\"");

WriteLiteral(" id=\"btnlammoitaisan\"");

WriteLiteral(" value=\"Làm mới\"");

WriteLiteral(" />\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-7\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 57 "..\..\Views\XLHSDangKy\_DonDangKy_DSTAISAN.cshtml"
                       Write(Html.Label("Chọn loại tài sản", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                        <div");

WriteLiteral(" class=\"col-xs-8\"");

WriteLiteral(">\r\n                            <select");

WriteLiteral(" class=\"form-control input-sm\"");

WriteLiteral(" title=\"chọn loại tài sản\"");

WriteLiteral(" id=\"drpchontaisan\"");

WriteLiteral(">\r\n                                <option");

WriteLiteral(" value=\"1\"");

WriteLiteral(">Nhà ở riêng lẻ</option>\r\n                                <option");

WriteLiteral(" value=\"2\"");

WriteLiteral(" hidden=\"true\"");

WriteLiteral(">khu nhà chung cư,nhà hỗn hợp</option>\r\n                                <option");

WriteLiteral(" value=\"3\"");

WriteLiteral(" hidden=\"true\"");

WriteLiteral(">nhà chung cư</option>\r\n                                <option");

WriteLiteral(" value=\"4\"");

WriteLiteral(">Căn hộ</option>\r\n                                <option");

WriteLiteral(" value=\"5\"");

WriteLiteral(" hidden=\"true\"");

WriteLiteral(">Hạng mục sở hữu ngoài căn hộ</option>\r\n                                <option");

WriteLiteral(" value=\"6\"");

WriteLiteral(">Công trình xây dựng</option>\r\n                                <option");

WriteLiteral(" value=\"7\"");

WriteLiteral(">Công trình ngầm</option>\r\n                                <option");

WriteLiteral(" value=\"8\"");

WriteLiteral(">Hạng mục của công trình xây dựng</option>\r\n                                <opti" +
"on");

WriteLiteral(" value=\"9\"");

WriteLiteral(">Rừng sản xuất là rừng trồng</option>\r\n                                <option");

WriteLiteral(" value=\"10\"");

WriteLiteral(">Cây lâu năm</option>\r\n                            </select>\r\n                   " +
"     </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n       " +
" <div");

WriteLiteral(" id=\"divTAISANDANGKY\"");

WriteLiteral(">\r\n");

            
            #line 77 "..\..\Views\XLHSDangKy\_DonDangKy_DSTAISAN.cshtml"
            
            
            #line default
            #line hidden
            
            #line 77 "..\..\Views\XLHSDangKy\_DonDangKy_DSTAISAN.cshtml"
              Html.RenderPartial("_lstTaiSanDK");
            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</form>\r\n<script>\r\n    $(document).ready(function () {\r\n        var" +
" table_checkthuats;\r\n        var table_checkthuatsch;\r\n        var table_checkhm" +
"ch;\r\n        var table_TS;\r\n        //tạo datatable cho bảng table_DSTAISAN\r\n   " +
"     //xử lý chọn trong select list drpchontaisan\r\n        $(\'#drpchontaisan\').c" +
"hange(function () {\r\n                $(\'#thuataisan\').show();\r\n                $" +
"(\'#thuataisancanho\').hide();\r\n                if ($(this).val() == \"1\") {\r\n     " +
"               $(\'#iddstaisan\').val(\"0\");\r\n                    $.ajax({\r\n       " +
"                 type: \"GET\",\r\n                        url: \"/XLHSDangKy/_DonDan" +
"gKy_TSNHARIENGLE\",\r\n                        success: function (response, startus" +
", xhr) {\r\n                            $(\'#tabTaiSan\').html(response);\r\n         " +
"               }\r\n                    });\r\n                }\r\n                el" +
"se if ($(this).val() == \"4\") {\r\n                    $(\'#thuataisan\').hide();\r\n  " +
"                  $(\'#thuataisancanho\').show();\r\n                    $.ajax({\r\n " +
"                       type: \"GET\",\r\n                        url: \"/XLHSDangKy/L" +
"oadCanHo\",\r\n                        success: function (response, startus, xhr) {" +
"\r\n                            $(\'#iddstaisan\').val(\"3\");\r\n                      " +
"      $(\'#tabTaiSan\').html(response);\r\n                            $(\'#openTabTh" +
"uaCanHo\').click();\r\n                        }\r\n                    });\r\n        " +
"        }\r\n                else if ($(this).val() == \"6\") {\r\n                   " +
" $.ajax({\r\n                        type: \"GET\",\r\n                        url: \"/" +
"XLHSDangKy/LoadCongTrinhXayDung\",\r\n                        success: function (re" +
"sponse, startus, xhr) {\r\n                            $(\'#iddstaisan\').val(\"5\");\r" +
"\n                            $(\'#tabTaiSan\').html(response);\r\n                  " +
"      }\r\n                    });\r\n                }\r\n                else if ($(" +
"this).val() == \"7\") {\r\n                    $.ajax({\r\n                        typ" +
"e: \"GET\",\r\n                        url: \"/XLHSDangKy/LoadCongTrinhNgam\",\r\n      " +
"                  success: function (response, startus, xhr) {\r\n                " +
"            $(\'#iddstaisan\').val(\"6\");\r\n                            $(\'#tabTaiSa" +
"n\').html(response);\r\n                        }\r\n                    });\r\n       " +
"         }\r\n                else if ($(this).val() == \"8\") {\r\n                  " +
"  $.ajax({\r\n                        type: \"GET\",\r\n                        url: \"" +
"/XLHSDangKy/LoadHangMucCongTrinh\",\r\n                        success: function (r" +
"esponse, startus, xhr) {\r\n                            $(\'#iddstaisan\').val(\"7\");" +
"\r\n                            $(\'#tabTaiSan\').html(response);\r\n                 " +
"       }\r\n                    });\r\n                }\r\n                else if ($" +
"(this).val() == \"9\") {\r\n                    $.ajax({\r\n                        ty" +
"pe: \"GET\",\r\n                        url: \"/XLHSDangKy/LoadRungTrong\",\r\n         " +
"               success: function (response, startus, xhr) {\r\n                   " +
"         $(\'#iddstaisan\').val(\"8\");\r\n                            $(\'#tabTaiSan\')" +
".html(response);\r\n                        }\r\n                    });\r\n          " +
"      }\r\n                else if ($(this).val() == \"10\") {\r\n                    " +
"$.ajax({\r\n                        type: \"GET\",\r\n                        url: \"/X" +
"LHSDangKy/LoadCayLauNam\",\r\n                        success: function (response, " +
"startus, xhr) {\r\n                            $(\'#iddstaisan\').val(\"9\");\r\n       " +
"                     $(\'#tabTaiSan\').html(response);\r\n                        }\r" +
"\n                    });\r\n                }\r\n            });\r\n        //làm mới\r" +
"\n        $(\"#btnlammoitaisan\").on(\"click\", function () {\r\n            $(\'#CurTSI" +
"D\').val(\"\");\r\n            $(\'#CurCHID\').val(\"\");\r\n                if ($(\"#drpcho" +
"ntaisan\").val() == \"1\") {\r\n                    $.ajax({\r\n                       " +
" type: \"GET\",\r\n                        url: \"/XLHSDangKy/_DonDangKy_TSNHARIENGLE" +
"\",\r\n                        success: function (response, startus, xhr) {\r\n      " +
"                      $(\'#iddstaisan\').val(\"0\");\r\n                            $(" +
"\'#tabTaiSan\').html(response);\r\n                        }\r\n                    })" +
";\r\n                }\r\n                else if ($(\"#drpchontaisan\").val() == \"4\")" +
" {\r\n                    $.ajax({\r\n                        type: \"GET\",\r\n        " +
"                url: \"/XLHSDangKy/LoadCanHo\",\r\n                        success: " +
"function (response, startus, xhr) {\r\n                            $(\'#iddstaisan\'" +
").val(\"3\");\r\n                            $(\'#tabTaiSan\').html(response);\r\n      " +
"                      $(\'#openTabThuaCanHo\').click();\r\n                         " +
"   document.getElementById(\'CurCHID\').value = \"\";\r\n                        }\r\n  " +
"                  });\r\n                }\r\n                else if ($(\'#drpchonta" +
"isan\').val() == \"6\") {\r\n                    $.ajax({\r\n                        ty" +
"pe: \"GET\",\r\n                        url: \"/XLHSDangKy/LoadCongTrinhXayDung\",\r\n  " +
"                      success: function (response, startus, xhr) {\r\n            " +
"                $(\'#iddstaisan\').val(\"5\");\r\n                            $(\'#tabT" +
"aiSan\').html(response);\r\n                        }\r\n                    });\r\n   " +
"             }\r\n                else if ($(\'#drpchontaisan\').val() == \"7\") {\r\n  " +
"                  $.ajax({\r\n                        type: \"GET\",\r\n              " +
"          url: \"/XLHSDangKy/LoadCongTrinhNgam\",\r\n                        success" +
": function (response, startus, xhr) {\r\n                            $(\'#iddstaisa" +
"n\').val(\"6\");\r\n                            $(\'#tabTaiSan\').html(response);\r\n    " +
"                    }\r\n                    });\r\n                }\r\n             " +
"   else if ($(\'#drpchontaisan\').val() == \"8\") {\r\n                    $.ajax({\r\n " +
"                       type: \"GET\",\r\n                        url: \"/XLHSDangKy/L" +
"oadHangMucCongTrinh\",\r\n                        success: function (response, star" +
"tus, xhr) {\r\n                            $(\'#iddstaisan\').val(\"7\");\r\n           " +
"                 $(\'#tabTaiSan\').html(response);\r\n                        }\r\n   " +
"                 });\r\n                }\r\n                else if ($(\'#drpchontai" +
"san\').val() == \"9\") {\r\n                    $.ajax({\r\n                        typ" +
"e: \"GET\",\r\n                        url: \"/XLHSDangKy/LoadRungTrong\",\r\n          " +
"              success: function (response, startus, xhr) {\r\n                    " +
"        $(\'#iddstaisan\').val(\"8\");\r\n                            $(\'#tabTaiSan\')." +
"html(response);\r\n                        }\r\n                    });\r\n           " +
"     }\r\n                else if ($(\'#drpchontaisan\').val() == \"10\") {\r\n         " +
"           $.ajax({\r\n                        type: \"GET\",\r\n                     " +
"   url: \"/XLHSDangKy/LoadCayLauNam\",\r\n                        success: function " +
"(response, startus, xhr) {\r\n                            $(\'#iddstaisan\').val(\"9\"" +
");\r\n                            $(\'#tabTaiSan\').html(response);\r\n               " +
"         }\r\n                    });\r\n                }\r\n            });\r\n       " +
" //xử lý nút thêm mới tài sản\r\n        //mở tab thửa căn hộ khi select list là c" +
"ăn hộ\r\n        $(\"#openTabThuaCanHo\").on(\"click\", function () {\r\n               " +
" document.getElementById(\'headerthuataisan\').innerHTML = \"Nằm trên thửa\";\r\n     " +
"           $.ajax({\r\n                    type: \"POST\",\r\n                    url:" +
" \"/XLHSDangKy/_lstThuaTSCH\",     \r\n                    success: function (html) " +
"{\r\n                        if ($(\'#CurTSID\').val().trim() != null && $(\'#CurTSID" +
"\').val().trim() != \"\")\r\n                        CheckRowThuaTSCH($(\'#CurTSID\').v" +
"al().trim());\r\n                        console.log(\"OPENTAB\");\r\n                " +
"        \r\n                    },\r\n                });\r\n        });\r\n        $(\"#" +
"btndiachi\").on(\"click\", function () {\r\n            var taisanid = $(\"#CurCHID\")." +
"val();\r\n            $.ajax({\r\n                type: \"POST\",\r\n                url" +
": \"/XLHSDangKy/_DiaChiTaiSan\",\r\n                data: { id: taisanid.trim() },\r\n" +
"                success: function (html) {\r\n                    $(\'#dialogformDI" +
"ACHI\').html(html);\r\n                    var options = {\r\n                       " +
" \"backdrop\": \"static\",\r\n                        \"show\": true\r\n                  " +
"  }\r\n                    $(\"#modalformDiaChi\").modal(options);\r\n                " +
"    }\r\n            });\r\n        });\r\n        });\r\n        $(function () {\r\n     " +
"       $(\"#tabTaiSan\").click();            \r\n        });\r\n        function Opent" +
"abHM() {\r\n            document.getElementById(\'headerthuataisan\').innerHTML = \"D" +
"anh sách hạng mục\";\r\n            $.ajax({\r\n                type: \"POST\",\r\n      " +
"          url: \"/XLHSDangKy/_lstcheckhangmucNCH\",\r\n                success: func" +
"tion (html) {\r\n                    console.log(\"OPENTAB\");\r\n                    " +
"if ($(\'#CurCHID\').val().trim() != null && $(\'#CurCHID\').val().trim() != \"\")\r\n   " +
"                     CheckRowHM($(\'#CurCHID\').val().trim());\r\n                  " +
"  else\r\n                        $(\'#tabHangMucCanHo\').html(html);\r\n             " +
"   },\r\n            });\r\n        }\r\n\r\n        function removeRow(button) {\r\n     " +
"       var ans = confirm(\"Bạn chắc chắn muốn xóa?\");\r\n            //=== If " +
"user pressed Ok then delete the record else do nothing.\r\n            if (ans == " +
"true) {\r\n                var empTab = document.getElementById(\'table_DSTAISAN\');" +
"\r\n                var index = button.parentNode.parentNode.rowIndex;\r\n          " +
"      var taisanid = empTab.rows[index].cells[0].innerHTML;\r\n                var" +
" taisanchitietid = empTab.rows[index].cells[5].innerHTML;\r\n                var L" +
"oaitaisanID = empTab.rows[index].cells[7].innerHTML;\r\n                var dondk " +
"= $(\'#DONDANGKYID\').val();\r\n                    $.ajax({\r\n                      " +
"  type: \"POST\",\r\n                        url: \"/XLHSDangKy/XoaTaiSanDK\",\r\n      " +
"                  dataType: \"html\",\r\n                        data: { taisanid: t" +
"aisanid.trim(), dondangky_id: dondk.trim()},\r\n                        success: f" +
"unction (html) {\r\n                            console.log(\"SUCCES\");\r\n          " +
"                  alert(\"Xóa  thành công!\");\r\n                            $(\'#" +
"divTAISANDANGKY\').html(html);\r\n                        },\r\n                    }" +
");\r\n            }\r\n        }\r\n        function ThemMoiTS() {\r\n            var do" +
"ndk = $(\'#DONDANGKYID\').val();\r\n            var formdata;\r\n            if ($(\"#d" +
"rpchontaisan\").val() == \"1\") {\r\n                 formdata = $(\"#ThemMoiNhaRiengL" +
"e\").serializeArray();\r\n                console.log(\"them moi nha rieng le\" + for" +
"mdata);\r\n                formdata.push({\r\n                    name: \"LoaiTaiSan\"" +
",\r\n                    value: 1\r\n                });\r\n                formdata.p" +
"ush({\r\n                    name: \"dSSHTaiSan\",\r\n                    value: GetDS" +
"Check(table_checkthuats)\r\n                });\r\n            }\r\n            else i" +
"f ($(\"#drpchontaisan\").val() == \"4\") {\r\n                var formdata = $(\"#ThemM" +
"oiCanHo\").serializeArray();\r\n                console.log(\"canho\" + formdata)\r\n  " +
"              formdata.push({\r\n                    name: \"LoaiTaiSan\",\r\n        " +
"            value: 4\r\n                });\r\n                if (table_checkhmch !" +
"= null) {\r\n                    formdata.push({\r\n                        name: \"d" +
"Shmch\",\r\n                        value: GetDSCheck(table_checkhmch)\r\n           " +
"         });\r\n                }\r\n                formdata.push({\r\n              " +
"      name: \"dSSHTaiSan\",\r\n                    value: GetDSCheck(table_checkthua" +
"tsch)\r\n                });\r\n            }\r\n            else if ($(\"#drpchontaisa" +
"n\").val() == \"6\") {\r\n                var formdata = $(\"#ThemMoiCongTrinhXayDung\"" +
").serializeArray();\r\n                formdata.push({\r\n                    name: " +
"\"LoaiTaiSan\",\r\n                    value: 6\r\n                });\r\n              " +
"  formdata.push({\r\n                    name: \"dSSHTaiSan\",\r\n                    " +
"value: GetDSCheck(table_checkthuats)\r\n                });\r\n            }\r\n      " +
"      else if ($(\"#drpchontaisan\").val() == \"7\") {\r\n                var formdata" +
" = $(\"#ThemMoiCongTrinhNgam\").serializeArray();\r\n                console.log(\"co" +
"ng trinh ngam them :\" + formdata);\r\n                formdata.push({\r\n           " +
"         name: \"LoaiTaiSan\",\r\n                    value: 7\r\n                });\r" +
"\n                formdata.push({\r\n                    name: \"dSSHTaiSan\",\r\n     " +
"               value: GetDSCheck(table_checkthuats)\r\n                });\r\n      " +
"      }\r\n            else if ($(\"#drpchontaisan\").val() == \"8\") {\r\n             " +
"   var formdata = $(\"#ThemMoiHangMucCongTrinh\").serializeArray();\r\n             " +
"   formdata.push({\r\n                    name: \"LoaiTaiSan\",\r\n                   " +
" value: 8\r\n                });\r\n                formdata.push({\r\n               " +
"     name: \"dSSHTaiSan\",\r\n                    value: GetDSCheck(table_checkthuat" +
"s)\r\n                });\r\n            }\r\n            else if ($(\"#drpchontaisan\")" +
".val() == \"9\") {\r\n                var formdata = $(\"#ThemMoiRung\").serializeArra" +
"y();\r\n                formdata.push({\r\n                    name: \"LoaiTaiSan\",\r\n" +
"                    value: 9\r\n                });\r\n                formdata.push" +
"({\r\n                    name: \"dSSHTaiSan\",\r\n                    value: GetDSChe" +
"ck(table_checkthuats)\r\n                });\r\n            }\r\n            else if (" +
"$(\"#drpchontaisan\").val() == \"10\") {\r\n                var formdata = $(\"#ThemMoi" +
"CayLauNam\").serializeArray();\r\n                formdata.push({\r\n                " +
"    name: \"LoaiTaiSan\",\r\n                    value: 10\r\n                });\r\n   " +
"             formdata.push({\r\n                    name: \"dSSHTaiSan\",\r\n         " +
"           value: GetDSCheck(table_checkthuats)\r\n                });\r\n          " +
"  }\r\n            $.ajax({\r\n                type: \"POST\",\r\n                url: \"" +
"/XLHSDangKy/ThemMoiTaiSanDK\",\r\n                data: formdata,\r\n                " +
"success: function (html) {\r\n                    alert(\"Lưu thành công\");\r\n      " +
"              $(\'#divTAISANDANGKY\').html(html);\r\n                }\r\n            " +
"});\r\n        }\r\n        function CheckRow(TSID) {\r\n            var data = docume" +
"nt.getElementById(\"JSONTSThua\").value;\r\n            console.log(\"json value:\" + " +
"data);\r\n            var obj = JSON.parse(data);\r\n            console.log(\"json a" +
"rray:\" + obj[TSID]);\r\n            var arr = obj[TSID];\r\n            table_checkt" +
"huats.$(\"input\", { \"page\": \"all\" }).each(function () {\r\n                var chec" +
"ked = false;\r\n                var id = this.id;\r\n                console.log(\"id" +
" row:\" + id);\r\n                for (i = 0; i < arr.length; i++)\r\n               " +
"     if (id == arr[i]) {\r\n                        $(this).prop(\"checked\", true);" +
"\r\n                        checked = true;\r\n                    }\r\n              " +
"  if (!checked) $(this).prop(\"checked\", false);\r\n            });\r\n\r\n        }\r\n " +
"       function CheckRowHM(TSID) {\r\n            var data = document.getElementBy" +
"Id(\"JSONCanHoHM\").value;\r\n            console.log(\"json value:\" + data);\r\n      " +
"      var obj = JSON.parse(data);\r\n            console.log(\"json array:\" + obj[T" +
"SID]);\r\n            var arr = obj[TSID];\r\n            table_checkhmch.$(\"input\"," +
" { \"page\": \"all\" }).each(function () {\r\n                var checked = false;\r\n  " +
"              var id = this.id;\r\n                console.log(\"id row:\" + id);\r\n " +
"               for (i = 0; i < arr.length; i++)\r\n                    if (id == a" +
"rr[i]) {\r\n                        $(this).prop(\"checked\", true);\r\n              " +
"          checked = true;\r\n                        console.log(\"check?\");\r\n     " +
"               }\r\n                if (!checked) $(this).prop(\"checked\", false);\r" +
"\n            });\r\n        }\r\n        function CheckRowThuaTSCH(TSID) {\r\n        " +
"    var data = document.getElementById(\"JSONTSThua\").value;\r\n            console" +
".log(\"json value:\" + data);\r\n            var obj = JSON.parse(data);\r\n          " +
"  console.log(\"json array:\" + obj[TSID]);\r\n            var arr = obj[TSID];\r\n   " +
"         table_checkthuatsch.$(\"input\", { \"page\": \"all\" }).each(function () {\r\n " +
"               var checked = false;\r\n                var id = this.id;\r\n        " +
"        console.log(\"id row:\" + id);\r\n                for (i = 0; i < arr.length" +
"; i++)\r\n                    if (id == arr[i]) {\r\n                        $(this)" +
".prop(\"checked\", true);\r\n                        checked = true;\r\n              " +
"      }\r\n                if (!checked) $(this).prop(\"checked\", false);\r\n        " +
"    });\r\n        }\r\n</script>\r\n");

        }
    }
}
#pragma warning restore 1591
