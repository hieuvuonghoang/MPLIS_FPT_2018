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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/XLHSDangKy/NhomNguoi_ToChuc.cshtml")]
    public partial class _Views_XLHSDangKy_NhomNguoi_ToChuc_cshtml : System.Web.Mvc.WebViewPage<MPLIS.Libraries.Data.XuLyHoSo.Models.ToChucLS>
    {
        public _Views_XLHSDangKy_NhomNguoi_ToChuc_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<form");

WriteLiteral(" id=\"formTTToChucID\"");

WriteLiteral(">\r\n");

WriteLiteral("    ");

            
            #line 3 "..\..\Views\XLHSDangKy\NhomNguoi_ToChuc.cshtml"
Write(Html.Hidden("TOCHUCID", Model.TOCHUCID));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 4 "..\..\Views\XLHSDangKy\NhomNguoi_ToChuc.cshtml"
Write(Html.Hidden("TRANGTHAI", Model.TRANGTHAI));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 5 "..\..\Views\XLHSDangKy\NhomNguoi_ToChuc.cshtml"
Write(Html.Hidden("NGUOIDAIDIENID", Model.NGUOIDAIDIENID));

            
            #line default
            #line hidden
WriteLiteral("\r\n    <div");

WriteLiteral(" id=\"divNguoiDaiDienID\"");

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

            
            #line 11 "..\..\Views\XLHSDangKy\NhomNguoi_ToChuc.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\XLHSDangKy\NhomNguoi_ToChuc.cshtml"
                         if (Model.NGUOIDAIDIENID == null)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <button");

WriteLiteral(" id=\"Btn_ChiTiet_NguoiDaiDienID\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-sm btn-default\"");

WriteLiteral("><i");

WriteLiteral(" class=\'fa fa-plus\'");

WriteLiteral("></i> Thêm mới</button>\r\n");

WriteLiteral("                            <button");

WriteLiteral(" id=\"Btn_Xoa_NguoiDaiDienID\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-sm btn-default\"");

WriteLiteral(" disabled><i");

WriteLiteral(" class=\'fa fa-trash\'");

WriteLiteral("></i> Xóa</button>\r\n");

            
            #line 15 "..\..\Views\XLHSDangKy\NhomNguoi_ToChuc.cshtml"
                        }
                        else
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <button");

WriteLiteral(" id=\"Btn_ChiTiet_NguoiDaiDienID\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-sm btn-default\"");

WriteLiteral("><i");

WriteLiteral(" class=\'fa fa-eye\'");

WriteLiteral("></i> Chi tiết</button>\r\n");

WriteLiteral("                            <button");

WriteLiteral(" id=\"Btn_Xoa_NguoiDaiDienID\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-sm btn-default\"");

WriteLiteral("><i");

WriteLiteral(" class=\'fa fa-trash\'");

WriteLiteral("></i> Xóa</button>\r\n");

            
            #line 20 "..\..\Views\XLHSDangKy\NhomNguoi_ToChuc.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </div>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4 text-center p-0\"");

WriteLiteral(">\r\n                    <h3");

WriteLiteral(" class=\"box-title\"");

WriteLiteral(">Người đại diện</h3>\r\n                </div>\r\n            </div>\r\n        </div>\r" +
"\n        <div");

WriteLiteral(" class=\"box-body\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 31 "..\..\Views\XLHSDangKy\NhomNguoi_ToChuc.cshtml"
               Write(Html.LabelFor(model => model.CMTNGUOIDAIDIEN, "CMT / Hộ chiếu", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

            
            #line 34 "..\..\Views\XLHSDangKy\NhomNguoi_ToChuc.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 34 "..\..\Views\XLHSDangKy\NhomNguoi_ToChuc.cshtml"
                     if (Model.TRANGTHAI == 2)
                    {
                        
            
            #line default
            #line hidden
            
            #line 36 "..\..\Views\XLHSDangKy\NhomNguoi_ToChuc.cshtml"
                   Write(Html.TextBoxFor(model => model.CMTNGUOIDAIDIEN, new { @class = "form-control input-sm", @disabled = "" }));

            
            #line default
            #line hidden
            
            #line 36 "..\..\Views\XLHSDangKy\NhomNguoi_ToChuc.cshtml"
                                                                                                                                  
                    }
                    else if (Model.TRANGTHAI == 1)
                    {
                        
            
            #line default
            #line hidden
            
            #line 40 "..\..\Views\XLHSDangKy\NhomNguoi_ToChuc.cshtml"
                   Write(Html.TextBoxFor(model => model.CMTNGUOIDAIDIEN, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
            
            #line 40 "..\..\Views\XLHSDangKy\NhomNguoi_ToChuc.cshtml"
                                                                                                                  
                    }

            
            #line default
            #line hidden
WriteLiteral("                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 44 "..\..\Views\XLHSDangKy\NhomNguoi_ToChuc.cshtml"
               Write(Html.LabelFor(model => model.NguoiDaiDien.HOTEN, "Họ tên", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 47 "..\..\Views\XLHSDangKy\NhomNguoi_ToChuc.cshtml"
               Write(Html.TextBoxFor(model => model.NguoiDaiDien.HOTEN, new { @class = "form-control input-sm", @disabled = "" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <di" +
"v");

WriteLiteral(" id=\"divTCCTNguoiDaiDienID\"");

WriteLiteral(" class=\"m-10\"");

WriteLiteral(">\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"box box-primary m-10\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"box-body\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 58 "..\..\Views\XLHSDangKy\NhomNguoi_ToChuc.cshtml"
               Write(Html.LabelFor(model => model.MASOTHUE, "Mã số thuế", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 61 "..\..\Views\XLHSDangKy\NhomNguoi_ToChuc.cshtml"
               Write(Html.TextBoxFor(model => model.MASOTHUE, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 64 "..\..\Views\XLHSDangKy\NhomNguoi_ToChuc.cshtml"
               Write(Html.LabelFor(model => model.MADOANHNGHIEP, "Mã doanh nghiệp", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 67 "..\..\Views\XLHSDangKy\NhomNguoi_ToChuc.cshtml"
               Write(Html.TextBoxFor(model => model.MADOANHNGHIEP, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 72 "..\..\Views\XLHSDangKy\NhomNguoi_ToChuc.cshtml"
               Write(Html.LabelFor(model => model.TENTOCHUC, "Tên tổ chức", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 75 "..\..\Views\XLHSDangKy\NhomNguoi_ToChuc.cshtml"
               Write(Html.TextBoxFor(model => model.TENTOCHUC, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 80 "..\..\Views\XLHSDangKy\NhomNguoi_ToChuc.cshtml"
               Write(Html.LabelFor(model => model.TENTOCHUCTA, "Tên tiếng anh", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 83 "..\..\Views\XLHSDangKy\NhomNguoi_ToChuc.cshtml"
               Write(Html.TextBoxFor(model => model.TENTOCHUCTA, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 86 "..\..\Views\XLHSDangKy\NhomNguoi_ToChuc.cshtml"
               Write(Html.LabelFor(model => model.TENVIETTAT, "Tên viết tắt", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 89 "..\..\Views\XLHSDangKy\NhomNguoi_ToChuc.cshtml"
               Write(Html.TextBoxFor(model => model.TENVIETTAT, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 94 "..\..\Views\XLHSDangKy\NhomNguoi_ToChuc.cshtml"
               Write(Html.LabelFor(model => model.SOQUYETDINH, "Số quyết định", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 97 "..\..\Views\XLHSDangKy\NhomNguoi_ToChuc.cshtml"
               Write(Html.TextBoxFor(model => model.SOQUYETDINH, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 100 "..\..\Views\XLHSDangKy\NhomNguoi_ToChuc.cshtml"
               Write(Html.LabelFor(model => model.NGAYQUYETDINH, "Ngày quyết định", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 103 "..\..\Views\XLHSDangKy\NhomNguoi_ToChuc.cshtml"
               Write(Html.TextBoxFor(model => model.NGAYQUYETDINH, "{0:yyyy-MM-dd}", new { @class = "form-control input-sm", type = "date" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 108 "..\..\Views\XLHSDangKy\NhomNguoi_ToChuc.cshtml"
               Write(Html.LabelFor(model => model.DIACHI, "Địa chỉ tổ chức", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 111 "..\..\Views\XLHSDangKy\NhomNguoi_ToChuc.cshtml"
               Write(Html.TextAreaFor(model => model.DIACHI, new { @class = "form-control", @rows = "3" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-xs-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 116 "..\..\Views\XLHSDangKy\NhomNguoi_ToChuc.cshtml"
               Write(Html.LabelFor(model => model.LOAITOCHUC, "Loại tổ chức", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 119 "..\..\Views\XLHSDangKy\NhomNguoi_ToChuc.cshtml"
               Write(Html.DropDownListFor(model => model.LOAITOCHUC, new SelectList(ViewBag.dSDoiTuongSuDung, "DOITUONGSUDUNGID", "TENDOITUONGSUDUNG"), "---- Lựa chọn ----", new { @class = "input-sm form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</form>" +
"\r\n\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n\r\n    $(document).ready(function () {\r\n\r\n        var divProcessBar = \"<div cla" +
"ss=\'overlay\'> <i class=\'fa fa-refresh fa-spin\'></i> </div>\";\r\n\r\n        $(\'#Btn_" +
"ChiTiet_NguoiDaiDienID\').on(\'click\', function () {\r\n\r\n            $(\'#divNguoiDa" +
"iDienID\').append(divProcessBar);\r\n\r\n            $.ajax({\r\n                type: " +
"\"POST\",\r\n                url: \"/XLHSDangKy/NhomNguoi_ToChuc_NguoiDaiDien\",\r\n    " +
"            dataType: \"html\",\r\n                success: function (html) {\r\n     " +
"               $(\'#divNguoiDaiDienID\').addClass(\'d-none\');\r\n                    " +
"$(\'#divTCCTNguoiDaiDienID\').html(html);\r\n                },\r\n                err" +
"or: function (jqXHR, textStatus, errorThrown) {\r\n                    alert(\'Lỗi:" +
" \' + errorThrown);\r\n                },\r\n                complete: function () {\r" +
"\n                    $(\'.overlay\', $(\'#divNguoiDaiDienID\')).remove();\r\n         " +
"       }\r\n            })\r\n\r\n        })\r\n\r\n        $(\'#Btn_Xoa_NguoiDaiDienID\').o" +
"n(\'click\', function () {\r\n            if (confirm(\"Xác nhận xóa Người Đại Diện?\"" +
")) {\r\n                $(\'#divNguoiDaiDienID\').append(divProcessBar);\r\n          " +
"      $.ajax({\r\n                    type: \"POST\",\r\n                    url: \'/XL" +
"HSDangKy/NhomNguoi_ToChuc_XoaNguoiDaiDien\',\r\n                    dataType: \"html" +
"\",\r\n                    success: function (html) {\r\n                        $(\'#" +
"formTTToChucID [name=LOAITOCHUC]\').prop(\'disabled\', false);\r\n                   " +
"     var objToChuc = FormToObject($(\'#formTTToChucID\'));\r\n                      " +
"  $(\'#formTTToChucID [name=LOAITOCHUC]\').prop(\'disabled\', true);\r\n              " +
"          console.log(objToChuc);\r\n                        $(\'#divChiTietChu_ToC" +
"hucID\')\r\n                            .html(html)\r\n                            .r" +
"eady(function () {\r\n                                $(\'#formTTToChucID [name=MAS" +
"OTHUE]\').val(objToChuc[\'MASOTHUE\']);\r\n                                $(\'#formTT" +
"ToChucID [name=MADOANHNGHIEP]\').val(objToChuc[\'MADOANHNGHIEP\']);\r\n              " +
"                  $(\'#formTTToChucID [name=TENTOCHUC]\').val(objToChuc[\'TENTOCHUC" +
"\']);\r\n                                $(\'#formTTToChucID [name=TENTOCHUCTA]\').va" +
"l(objToChuc[\'TENTOCHUCTA\']);\r\n                                $(\'#formTTToChucID" +
" [name=TENVIETTAT]\').val(objToChuc[\'TENVIETTAT\']);\r\n                            " +
"    $(\'#formTTToChucID [name=SOQUYETDINH]\').val(objToChuc[\'SOQUYETDINH\']);\r\n    " +
"                            $(\'#formTTToChucID [name=NGAYQUYETDINH]\').val(objToC" +
"huc[\'NGAYQUYETDINH\']);\r\n                                $(\'#formTTToChucID [name" +
"=DIACHI]\').val(objToChuc[\'DIACHI\']);\r\n                                $(\'#formTT" +
"ToChucID [name=LOAITOCHUC]\').val(objToChuc[\'LOAITOCHUC\']);\r\n                    " +
"        });\r\n                    },\r\n                    error: function (jqXHR," +
" textStatus, errorThrown) {\r\n                        alert(\'Lỗi: \' + errorThrown" +
");\r\n                    },\r\n                    complete: function () {\r\n       " +
"                 $(\'.overlay\', $(\'#divNguoiDaiDienID\')).remove();\r\n             " +
"       }\r\n                })\r\n            }\r\n        })\r\n\r\n    })\r\n\r\n</script>\r\n" +
"\r\n");

        }
    }
}
#pragma warning restore 1591
