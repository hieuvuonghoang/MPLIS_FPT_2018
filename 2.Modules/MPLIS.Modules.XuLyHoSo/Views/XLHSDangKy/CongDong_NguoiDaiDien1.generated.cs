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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/XLHSDangKy/CongDong_NguoiDaiDien.cshtml")]
    public partial class _Views_XLHSDangKy_CongDong_NguoiDaiDien_cshtml : System.Web.Mvc.WebViewPage<MPLIS.Libraries.Data.XuLyHoSo.Models.CongDongLS>
    {
        public _Views_XLHSDangKy_CongDong_NguoiDaiDien_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" id=\"FormCongDong_ChiTietNguoiDaiDienID\"");

WriteLiteral(" class=\"box box-primary m-0\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"box-header with-border\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"row p-0\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-xs-4 p-0\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"pull-left\"");

WriteLiteral(">\r\n");

            
            #line 8 "..\..\Views\XLHSDangKy\CongDong_NguoiDaiDien.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 8 "..\..\Views\XLHSDangKy\CongDong_NguoiDaiDien.cshtml"
                     if (Model.NGUOIDAIDIENID == null)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <button");

WriteLiteral(" id=\"BtnSave_FormCongDong_ChiTietNguoiDaiDienID\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-sm btn-default\"");

WriteLiteral("><i");

WriteLiteral(" class=\'fa fa-plus\'");

WriteLiteral("></i> Thêm mới</button>\r\n");

            
            #line 11 "..\..\Views\XLHSDangKy\CongDong_NguoiDaiDien.cshtml"
                    }
                    else
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <button");

WriteLiteral(" id=\"BtnSave_FormCongDong_ChiTietNguoiDaiDienID\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-sm btn-default\"");

WriteLiteral("><i");

WriteLiteral(" class=\'fa fa-check\'");

WriteLiteral("></i> Lưu thông tin</button>\r\n");

            
            #line 15 "..\..\Views\XLHSDangKy\CongDong_NguoiDaiDien.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                    <button");

WriteLiteral(" id=\"BtnClear_FormCongDong_ChiTietNguoiDaiDienID\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-sm btn-default\"");

WriteLiteral("><i");

WriteLiteral(" class=\'fa fa-trash\'");

WriteLiteral("></i> Xóa trắng</button>\r\n                </div>\r\n            </div>\r\n           " +
" <div");

WriteLiteral(" class=\"col-xs-4 text-center p-0\"");

WriteLiteral(">\r\n                <h3");

WriteLiteral(" class=\"box-title\"");

WriteLiteral(">Thông tin chi tiết Người Đại Diện</h3>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-4 p-0\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"pull-right\"");

WriteLiteral(">\r\n                    <button");

WriteLiteral(" id=\"BtnClose_FormCongDong_ChiTietNguoiDaiDienID\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-box-tool\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-remove\"");

WriteLiteral("></i></button>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    <" +
"/div>\r\n    <div");

WriteLiteral(" class=\"box-body p-0\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 30 "..\..\Views\XLHSDangKy\CongDong_NguoiDaiDien.cshtml"
   Write(Html.Partial("ChiTietChu_CaNhan", Model.CurCaNhan));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n\r\n        $(document).ready(function () {\r\n\r\n            var divProcessBar = \"" +
"<div class=\'overlay\'> <i class=\'fa fa-refresh fa-spin\'></i> </div>\";\r\n\r\n        " +
"    $(\'#BtnClose_FormCongDong_ChiTietNguoiDaiDienID\').on(\'click\', function () {\r" +
"\n                $(\'#divNguoiDaiDienID\').removeClass(\"d-none\");\r\n               " +
" $(\'#FormCongDong_ChiTietNguoiDaiDienID\').remove();\r\n            })\r\n\r\n         " +
"   $(\'#BtnSave_FormCongDong_ChiTietNguoiDaiDienID\').on(\'click\', function () {\r\n " +
"               $(\'#FormToChuc_ChiTietNguoiDaiDienID\').append(divProcessBar);\r\n  " +
"              var objNguoiDaiDien = {};\r\n                objNguoiDaiDien = FormT" +
"oObject($(\'#formTTCaNhanID\'));\r\n                var TableGiayToID = $(\'#TableGia" +
"yToID\').DataTable();\r\n                var dSGiayTo = [];\r\n                $.each" +
"(TableGiayToID.rows().nodes(), function () {\r\n                    var curRow = T" +
"ableGiayToID.row(this).data();\r\n                    var objGiayTo = {};\r\n       " +
"             for (var temp in curRow) {\r\n                        objGiayTo[temp]" +
" = curRow[temp];\r\n                    }\r\n                    dSGiayTo.push(objGi" +
"ayTo);\r\n                })\r\n                for (var temp in dSGiayTo) {\r\n      " +
"              if (dSGiayTo[temp][\"LAGIAYTOINGCN\"] == \"True\") {\r\n                " +
"        dSGiayTo[temp][\"LAGIAYTOINGCN\"] = \"true\";\r\n                    } else {\r" +
"\n                        dSGiayTo[temp][\"LAGIAYTOINGCN\"] = \"false\";\r\n           " +
"         }\r\n                    dSGiayTo[temp][\"NGAYCAP\"] = ConverDatatime(dSGia" +
"yTo[temp][\"NGAYCAP\"]);\r\n                    delete dSGiayTo[temp][\"STT\"];\r\n     " +
"               delete dSGiayTo[temp][\"TenLoaiGiayTo\"];\r\n                    dele" +
"te dSGiayTo[temp][\"TRANGTHAI\"];\r\n                }\r\n                objNguoiDaiD" +
"ien[\"DSGiayToTuyThan\"] = dSGiayTo;\r\n                console.log(objNguoiDaiDien)" +
";\r\n                $.ajax({\r\n                    type: \"POST\",\r\n                " +
"    url: \'/XLHSDangKy/Save_FormCongDong_ChiTietNguoiDaiDienID\',\r\n               " +
"     data: { data: JSON.stringify(objNguoiDaiDien) },\r\n                    dataT" +
"ype: \"html\",\r\n                    success: function (html) {\r\n                  " +
"      if ($(\'#formTTCongDongID [name=NGUOIDAIDIENID]\').val() == \"\") {\r\n         " +
"                   alert(\'Thêm mới thông tin Người Đại Diện thành công!\');\r\n    " +
"                    } else {\r\n                            alert(\'Cập nhật thông " +
"tin Người Đại Diện thành công!\');\r\n                        }\r\n                  " +
"      var objCongDong = FormToObject($(\'#formTTCongDongID\'));\r\n                 " +
"       console.log(objCongDong);\r\n                        $(\'#divChiTietChu_Cong" +
"DongID\')\r\n                            .html(html)\r\n                            ." +
"ready(function () {\r\n                                $(\'#formTTCongDongID [name=" +
"TENCONGDONG]\').val(objCongDong[\'TENCONGDONG\']);\r\n                               " +
" $(\'#formTTCongDongID [name=DIACHI]\').val(objCongDong[\'DIACHI\']);\r\n             " +
"               });\r\n                    },\r\n                    error: function " +
"(jqXHR, textStatus, errorThrown) {\r\n                        alert(\'Lỗi: \' + erro" +
"rThrown);\r\n                    },\r\n                    complete: function () {\r\n" +
"                        $(\'.overlay\', $(\'#FormCongDong_ChiTietNguoiDaiDienID\'))." +
"remove();\r\n                    }\r\n                })\r\n            })\r\n\r\n        " +
"    $(\'#BtnClear_FormCongDong_ChiTietNguoiDaiDienID\').on(\'click\', function () {\r" +
"\n                $(\'#FormCongDong_ChiTietNguoiDaiDienID\').append(divProcessBar);" +
"\r\n                $.ajax({\r\n                    type: \"POST\",\r\n                 " +
"   url: \'/XLHSDangKy/XoaTrang_FormCongDong_ChiTietNguoiDaiDienID\',\r\n            " +
"        dataType: \"html\",\r\n                    success: function (html) {\r\n     " +
"                   $(\'#divCDCTNguoiDaiDienID\').html(html);\r\n                    " +
"},\r\n                    error: function (jqXHR, textStatus, errorThrown) {\r\n    " +
"                    alert(\'Lỗi: \' + errorThrown);\r\n                    },\r\n     " +
"               complete: function () {\r\n                        $(\'.overlay\', $(" +
"\'#FormCongDong_ChiTietNguoiDaiDienID\')).remove();\r\n                    }\r\n      " +
"          })\r\n            })\r\n\r\n        })\r\n\r\n    </script>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
