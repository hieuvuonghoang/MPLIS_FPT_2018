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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/XLHSDangKy/NhomNguoi_VoChong.cshtml")]
    public partial class _Views_XLHSDangKy_NhomNguoi_VoChong_cshtml : System.Web.Mvc.WebViewPage<MPLIS.Libraries.Data.XuLyHoSo.Models.VoChongLS>
    {
        public _Views_XLHSDangKy_NhomNguoi_VoChong_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<form");

WriteLiteral(" id=\"formTTVoChongID\"");

WriteLiteral(">\r\n");

WriteLiteral("    ");

            
            #line 3 "..\..\Views\XLHSDangKy\NhomNguoi_VoChong.cshtml"
Write(Html.Hidden("VOCHONGID", Model.VOCHONGID));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 4 "..\..\Views\XLHSDangKy\NhomNguoi_VoChong.cshtml"
Write(Html.Hidden("TRANGTHAI", Model.TRANGTHAI));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 5 "..\..\Views\XLHSDangKy\NhomNguoi_VoChong.cshtml"
Write(Html.Hidden("VO", Model.VO));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 6 "..\..\Views\XLHSDangKy\NhomNguoi_VoChong.cshtml"
Write(Html.Hidden("CHONG", Model.CHONG));

            
            #line default
            #line hidden
WriteLiteral("\r\n    <div");

WriteLiteral(" id=\"divChongID\"");

WriteLiteral(" class=\"box box-primary m-10\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"box-header with-border\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"row p-0\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-xs-4 p-0\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"pull-left\"");

WriteLiteral(">\r\n");

            
            #line 12 "..\..\Views\XLHSDangKy\NhomNguoi_VoChong.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 12 "..\..\Views\XLHSDangKy\NhomNguoi_VoChong.cshtml"
                         if (Model.CHONG == null)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <button");

WriteLiteral(" id=\"Btn_ChiTiet_ChongID\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-sm btn-default\"");

WriteLiteral("><i");

WriteLiteral(" class=\'fa fa-plus\'");

WriteLiteral("></i> Thêm mới</button>\r\n");

WriteLiteral("                            <button");

WriteLiteral(" id=\"Btn_Xoa_ChongID\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-sm btn-default\"");

WriteLiteral(" disabled><i");

WriteLiteral(" class=\'fa fa-trash\'");

WriteLiteral("></i> Xóa</button>\r\n");

            
            #line 16 "..\..\Views\XLHSDangKy\NhomNguoi_VoChong.cshtml"
                        }
                        else
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <button");

WriteLiteral(" id=\"Btn_ChiTiet_ChongID\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-sm btn-default\"");

WriteLiteral("><i");

WriteLiteral(" class=\'fa fa-eye\'");

WriteLiteral("></i> Chi tiết</button>\r\n");

WriteLiteral("                            <button");

WriteLiteral(" id=\"Btn_Xoa_ChongID\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-sm btn-default\"");

WriteLiteral("><i");

WriteLiteral(" class=\'fa fa-trash\'");

WriteLiteral("></i> Xóa</button>\r\n");

            
            #line 21 "..\..\Views\XLHSDangKy\NhomNguoi_VoChong.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </div>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4 text-center p-0\"");

WriteLiteral(">\r\n                    <h3");

WriteLiteral(" class=\"box-title\"");

WriteLiteral(">Chồng</h3>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        " +
"<div");

WriteLiteral(" class=\"box-body\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 32 "..\..\Views\XLHSDangKy\NhomNguoi_VoChong.cshtml"
               Write(Html.LabelFor(model => model.CMTCHONG, "CMT / Hộ chiếu", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

            
            #line 35 "..\..\Views\XLHSDangKy\NhomNguoi_VoChong.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 35 "..\..\Views\XLHSDangKy\NhomNguoi_VoChong.cshtml"
                     if (Model.TRANGTHAI == 2)
                    {
                        
            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\XLHSDangKy\NhomNguoi_VoChong.cshtml"
                   Write(Html.TextBoxFor(model => model.CMTCHONG, new { @class = "form-control input-sm", @disabled = "" }));

            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\XLHSDangKy\NhomNguoi_VoChong.cshtml"
                                                                                                                           
                    }
                    else if (Model.TRANGTHAI == 1)
                    {
                        
            
            #line default
            #line hidden
            
            #line 41 "..\..\Views\XLHSDangKy\NhomNguoi_VoChong.cshtml"
                   Write(Html.TextBoxFor(model => model.CMTCHONG, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
            
            #line 41 "..\..\Views\XLHSDangKy\NhomNguoi_VoChong.cshtml"
                                                                                                           
                    }

            
            #line default
            #line hidden
WriteLiteral("                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 45 "..\..\Views\XLHSDangKy\NhomNguoi_VoChong.cshtml"
               Write(Html.LabelFor(model => model.ChongCN.HOTEN, "Họ tên", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 48 "..\..\Views\XLHSDangKy\NhomNguoi_VoChong.cshtml"
               Write(Html.TextBoxFor(model => model.ChongCN.HOTEN, new { @class = "form-control input-sm", @disabled = "" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <di" +
"v");

WriteLiteral(" id=\"divChiTietChongID\"");

WriteLiteral(" class=\"m-10\"");

WriteLiteral(">\r\n    </div>\r\n    <div");

WriteLiteral(" id=\"divVoID\"");

WriteLiteral(" class=\"box box-primary m-10\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"box-header with-border\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"row p-0\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-xs-4 p-0\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"pull-left\"");

WriteLiteral(">\r\n");

            
            #line 60 "..\..\Views\XLHSDangKy\NhomNguoi_VoChong.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 60 "..\..\Views\XLHSDangKy\NhomNguoi_VoChong.cshtml"
                         if (Model.VO == null)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <button");

WriteLiteral(" id=\"Btn_ChiTiet_VoID\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-sm btn-default\"");

WriteLiteral("><i");

WriteLiteral(" class=\'fa fa-plus\'");

WriteLiteral("></i> Thêm mới</button>\r\n");

WriteLiteral("                            <button");

WriteLiteral(" id=\"Btn_Xoa_VoID\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-sm btn-default\"");

WriteLiteral(" disabled><i");

WriteLiteral(" class=\'fa fa-trash\'");

WriteLiteral("></i> Xóa</button>\r\n");

            
            #line 64 "..\..\Views\XLHSDangKy\NhomNguoi_VoChong.cshtml"
                        }
                        else
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <button");

WriteLiteral(" id=\"Btn_ChiTiet_VoID\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-sm btn-default\"");

WriteLiteral("><i");

WriteLiteral(" class=\'fa fa-eye\'");

WriteLiteral("></i> Chi tiết</button>\r\n");

WriteLiteral("                            <button");

WriteLiteral(" id=\"Btn_Xoa_VoID\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-sm btn-default\"");

WriteLiteral("><i");

WriteLiteral(" class=\'fa fa-trash\'");

WriteLiteral("></i> Xóa</button>\r\n");

            
            #line 69 "..\..\Views\XLHSDangKy\NhomNguoi_VoChong.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </div>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4 text-center p-0\"");

WriteLiteral(">\r\n                    <h3");

WriteLiteral(" class=\"box-title\"");

WriteLiteral(">Vợ</h3>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <di" +
"v");

WriteLiteral(" class=\"box-body\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 80 "..\..\Views\XLHSDangKy\NhomNguoi_VoChong.cshtml"
               Write(Html.LabelFor(model => model.CMTVO, "CMT / Hộ chiếu", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 83 "..\..\Views\XLHSDangKy\NhomNguoi_VoChong.cshtml"
               Write(Html.TextBoxFor(model => model.CMTVO, new { @class = "form-control input-sm", @disabled = "" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 86 "..\..\Views\XLHSDangKy\NhomNguoi_VoChong.cshtml"
               Write(Html.LabelFor(model => model.VoCN.HOTEN, "Họ tên", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 89 "..\..\Views\XLHSDangKy\NhomNguoi_VoChong.cshtml"
               Write(Html.TextBoxFor(model => model.VoCN.HOTEN, new { @class = "form-control input-sm", @disabled = "" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <di" +
"v");

WriteLiteral(" id=\"divChiTietVoID\"");

WriteLiteral(" class=\"m-10\"");

WriteLiteral(">\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"box box-primary m-10\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"box-header with-border\"");

WriteLiteral(">\r\n            <h3");

WriteLiteral(" class=\"box-title\"");

WriteLiteral(">Địa chỉ</h3>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"box-body\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 103 "..\..\Views\XLHSDangKy\NhomNguoi_VoChong.cshtml"
               Write(Html.LabelFor(model => model.DIACHI, "Địa chỉ", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 106 "..\..\Views\XLHSDangKy\NhomNguoi_VoChong.cshtml"
               Write(Html.TextAreaFor(model => model.DIACHI, new { @class = "form-control", @rows = "3" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</form>" +
"\r\n\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n\r\n    $(document).ready(function () {\r\n\r\n        var divProcessBar = \"<div cla" +
"ss=\'overlay\'> <i class=\'fa fa-refresh fa-spin\'></i> </div>\";\r\n\r\n        $(\'#Btn_" +
"ChiTiet_ChongID\').on(\'click\', function () {\r\n\r\n            $(\'#BtnClose_FormVoCh" +
"ong_ChiTietVoID\').click();\r\n\r\n            $(\'#divChongID\').append(divProcessBar)" +
";\r\n\r\n            $.ajax({\r\n                type: \"POST\",\r\n                url: \"" +
"/XLHSDangKy/NhomNguoi_VoChong_Chong\",\r\n                dataType: \"html\",\r\n      " +
"          success: function (html) {\r\n                    $(\'#divChongID\').addCl" +
"ass(\'d-none\');\r\n                    $(\'#divChiTietChongID\').html(html);\r\n       " +
"         },\r\n                error: function (jqXHR, textStatus, errorThrown) {\r" +
"\n                    alert(\'Lỗi: \' + errorThrown);\r\n                },\r\n        " +
"        complete: function () {\r\n                    $(\'.overlay\', $(\'#divChongI" +
"D\')).remove();\r\n                }\r\n            })\r\n\r\n        })\r\n\r\n        $(\'#B" +
"tn_ChiTiet_VoID\').on(\'click\', function () {\r\n\r\n            $(\'#BtnClose_FormVoCh" +
"ong_ChiTietChongID\').click();\r\n\r\n            $(\'#divVoID\').append(divProcessBar)" +
";\r\n\r\n            $.ajax({\r\n                type: \"POST\",\r\n                url: \"" +
"/XLHSDangKy/NhomNguoi_VoChong_Vo\",\r\n                dataType: \"html\",\r\n         " +
"       success: function (html) {\r\n                    $(\'#divVoID\').addClass(\'d" +
"-none\');\r\n                    $(\'#divChiTietVoID\').html(html);\r\n                " +
"},\r\n                error: function (jqXHR, textStatus, errorThrown) {\r\n        " +
"            alert(\'Lỗi: \' + errorThrown);\r\n                },\r\n                c" +
"omplete: function () {\r\n                    $(\'.overlay\', $(\'#divVoID\')).remove(" +
");\r\n                }\r\n            })\r\n\r\n        })\r\n\r\n        $(\'#Btn_Xoa_Chong" +
"ID\').on(\'click\', function () {\r\n            if (confirm(\"Xác nhận xóa Chồng?\")) " +
"{\r\n                $(\'#divChongID\').append(divProcessBar);\r\n                $.aj" +
"ax({\r\n                    type: \"POST\",\r\n                    url: \'/XLHSDangKy/N" +
"homNguoi_VoChong_XoaChong\',\r\n                    dataType: \"html\",\r\n            " +
"        success: function (html) {\r\n                        var objVoChong = For" +
"mToObject($(\'#formTTVoChongID\'));\r\n                        $(\'#divChiTietChu_VoC" +
"hongID\')\r\n                            .html(html)\r\n                            ." +
"ready(function () {\r\n                                $(\'#formTTVoChongID [name=D" +
"IACHI]\').val(objVoChong[\'DIACHI\']);\r\n                            })\r\n           " +
"         },\r\n                    error: function (jqXHR, textStatus, errorThrown" +
") {\r\n                        alert(\'Lỗi: \' + errorThrown);\r\n                    " +
"},\r\n                    complete: function () {\r\n                        $(\'.ove" +
"rlay\', $(\'#divChongID\')).remove();\r\n                    }\r\n                })\r\n " +
"           }\r\n        })\r\n\r\n        $(\'#Btn_Xoa_VoID\').on(\'click\', function () {" +
"\r\n            if (confirm(\"Xác nhận xóa Vợ?\")) {\r\n                $(\'#divVoID\')." +
"append(divProcessBar);\r\n                $.ajax({\r\n                    type: \"POS" +
"T\",\r\n                    url: \'/XLHSDangKy/NhomNguoi_VoChong_XoaVo\',\r\n          " +
"          dataType: \"html\",\r\n                    success: function (html) {\r\n   " +
"                     var objVoChong = FormToObject($(\'#formTTVoChongID\'));\r\n    " +
"                    $(\'#divChiTietChu_VoChongID\')\r\n                            ." +
"html(html)\r\n                            .ready(function () {\r\n                  " +
"              $(\'#formTTVoChongID [name=DIACHI]\').val(objVoChong[\'DIACHI\']);\r\n  " +
"                          });\r\n                    },\r\n                    error" +
": function (jqXHR, textStatus, errorThrown) {\r\n                        alert(\'Lỗ" +
"i: \' + errorThrown);\r\n                    },\r\n                    complete: func" +
"tion () {\r\n                        $(\'.overlay\', $(\'#divVoID\')).remove();\r\n     " +
"               }\r\n                })\r\n            }\r\n        })\r\n\r\n    })\r\n\r\n</s" +
"cript>\r\n");

        }
    }
}
#pragma warning restore 1591