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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/XLHSDangKy/HoGiaDinh_ChiTietThanhVien.cshtml")]
    public partial class _Views_XLHSDangKy_HoGiaDinh_ChiTietThanhVien_cshtml : System.Web.Mvc.WebViewPage<MPLIS.Libraries.Data.XuLyHoSo.Models.HoGiaDinhThanhVienLS>
    {
        public _Views_XLHSDangKy_HoGiaDinh_ChiTietThanhVien_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" id=\"FormHGD_ChiTietTVID\"");

WriteLiteral(" class=\"box box-primary m-0\"");

WriteLiteral(">\r\n    <form");

WriteLiteral(" id=\"formHoGiaDinhThanhVienID\"");

WriteLiteral(" class=\"d-none\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 5 "..\..\Views\XLHSDangKy\HoGiaDinh_ChiTietThanhVien.cshtml"
   Write(Html.Hidden("HOGIADINHTVID", Model.HOGIADINHTVID));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 6 "..\..\Views\XLHSDangKy\HoGiaDinh_ChiTietThanhVien.cshtml"
   Write(Html.Hidden("HOGIADINHID", Model.HOGIADINHID));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 7 "..\..\Views\XLHSDangKy\HoGiaDinh_ChiTietThanhVien.cshtml"
   Write(Html.Hidden("CANHANID", Model.CANHANID));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 8 "..\..\Views\XLHSDangKy\HoGiaDinh_ChiTietThanhVien.cshtml"
   Write(Html.Hidden("TRANGTHAI", Model.TRANGTHAI));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 9 "..\..\Views\XLHSDangKy\HoGiaDinh_ChiTietThanhVien.cshtml"
   Write(Html.Hidden("QHVOICHUHOID", Model.QHVOICHUHOID));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </form>\r\n    <div");

WriteLiteral(" class=\"box-header with-border\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"row p-0\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-xs-4 p-0\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"pull-left\"");

WriteLiteral(">\r\n");

            
            #line 15 "..\..\Views\XLHSDangKy\HoGiaDinh_ChiTietThanhVien.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\XLHSDangKy\HoGiaDinh_ChiTietThanhVien.cshtml"
                     if (Model.TRANGTHAI == 1)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <button");

WriteLiteral(" id=\"BtnSave_FormHGD_ChiTietTVID\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-sm btn-default\"");

WriteLiteral("><i");

WriteLiteral(" class=\'fa fa-plus\'");

WriteLiteral("></i> Thêm mới</button>\r\n");

            
            #line 18 "..\..\Views\XLHSDangKy\HoGiaDinh_ChiTietThanhVien.cshtml"
                    }
                    else if (Model.TRANGTHAI == 2)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <button");

WriteLiteral(" id=\"BtnSave_FormHGD_ChiTietTVID\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-sm btn-default\"");

WriteLiteral("><i");

WriteLiteral(" class=\'fa fa-check\'");

WriteLiteral("></i> Lưu thông tin</button>\r\n");

            
            #line 22 "..\..\Views\XLHSDangKy\HoGiaDinh_ChiTietThanhVien.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                    <button");

WriteLiteral(" id=\"BtnClear_FormHGD_ChiTietTVID\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-sm btn-default\"");

WriteLiteral("><i");

WriteLiteral(" class=\'fa fa-trash\'");

WriteLiteral("></i> Xóa trắng</button>\r\n                </div>\r\n            </div>\r\n           " +
" <div");

WriteLiteral(" class=\"col-xs-4 text-center p-0\"");

WriteLiteral(">\r\n                <h3");

WriteLiteral(" class=\"box-title\"");

WriteLiteral(">Thông tin chi tiết thành viên</h3>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-xs-4 p-0\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"row p-0\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"col-xs-3 p-0\"");

WriteLiteral(">\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"col-xs-6 p-0\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"pull-right\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 35 "..\..\Views\XLHSDangKy\HoGiaDinh_ChiTietThanhVien.cshtml"
                       Write(Html.DropDownList("CB_QHVOICHUHOID", new SelectList(ViewBag.dSQuanHe, "QHVOICHUHOID", "TENQUANHE"), "---- Chọn vai trò ----", new { @class = "form-control input-sm", @id = "CB_QHVOICHUHOID" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                   " +
" <div");

WriteLiteral(" class=\"col-xs-3 p-0\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"pull-right\"");

WriteLiteral(">\r\n                            <button");

WriteLiteral(" id=\"BtnClose_FormHGD_ChiTietTVID\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-box-tool\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-remove\"");

WriteLiteral("></i></button>\r\n                        </div>\r\n                    </div>\r\n     " +
"           </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"box-body p-0\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 48 "..\..\Views\XLHSDangKy\HoGiaDinh_ChiTietThanhVien.cshtml"
   Write(Html.Partial("ChiTietChu_CaNhan", Model.ThanhVien));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n\r\n        $(document).ready(function () {\r\n\r\n            $(\'#BtnClose_FormHGD_" +
"ChiTietTVID\').on(\'click\', function () {\r\n                $(\'#FormHGD_ChiTietTVID" +
"\').siblings().removeClass(\"d-none\");\r\n                $(\'#FormHGD_ChiTietTVID\')." +
"remove();\r\n            })\r\n\r\n            $(\'#BtnSave_FormHGD_ChiTietTVID\').on(\'c" +
"lick\', function () {\r\n                var objHoGiaDinhThanhVien = FormToObject($" +
"(\'#formHoGiaDinhThanhVienID\'));\r\n                var TableGiayToID = $(\'#TableGi" +
"ayToID\').DataTable();\r\n                var dSGiayTo = [];\r\n                $.eac" +
"h(TableGiayToID.rows().nodes(), function () {\r\n                    var curRow = " +
"TableGiayToID.row(this).data();\r\n                    var objGiayTo = {};\r\n      " +
"              for (var temp in curRow) {\r\n                        objGiayTo[temp" +
"] = curRow[temp];\r\n                    }\r\n                    dSGiayTo.push(objG" +
"iayTo);\r\n                })\r\n                for (var temp in dSGiayTo) {\r\n     " +
"               if (dSGiayTo[temp][\"LAGIAYTOINGCN\"] == \"True\") {\r\n               " +
"         dSGiayTo[temp][\"LAGIAYTOINGCN\"] = \"true\";\r\n                    } else {" +
"\r\n                        dSGiayTo[temp][\"LAGIAYTOINGCN\"] = \"false\";\r\n          " +
"          }\r\n                    dSGiayTo[temp][\"NGAYCAP\"] = ConverDatatime(dSGi" +
"ayTo[temp][\"NGAYCAP\"]);\r\n                    delete dSGiayTo[temp][\"STT\"];\r\n    " +
"                delete dSGiayTo[temp][\"TenLoaiGiayTo\"];\r\n                    del" +
"ete dSGiayTo[temp][\"TRANGTHAI\"];\r\n                }\r\n                objHoGiaDin" +
"hThanhVien[\"ThanhVien\"] = FormToObject($(\'#formTTCaNhanID\'));\r\n                o" +
"bjHoGiaDinhThanhVien[\"ThanhVien\"][\"DSGiayToTuyThan\"] = dSGiayTo;\r\n              " +
"  console.log(objHoGiaDinhThanhVien);\r\n                $.ajax({\r\n               " +
"     type: \"POST\",\r\n                    url: \'/XLHSDangKy/Save_FormHGD_ChiTietTV" +
"ID\',\r\n                    data: { data: JSON.stringify(objHoGiaDinhThanhVien) }," +
"\r\n                    dataType: \"json\",\r\n                    success: function (" +
"result) {\r\n                        console.log(result);\r\n                       " +
" if (result.success) {\r\n                            if (\'");

            
            #line 93 "..\..\Views\XLHSDangKy\HoGiaDinh_ChiTietThanhVien.cshtml"
                            Write(Model.TRANGTHAI);

            
            #line default
            #line hidden
WriteLiteral("\' == \'1\') {\r\n                                $(\'#BtnClear_FormHGD_ChiTietTVID\').c" +
"lick();\r\n                            }\r\n                            var TableTVH" +
"GDID = $(\'#TableTVHGDID\').DataTable();\r\n                            var objTemp " +
"= null;\r\n                            var rowEle = null;\r\n                       " +
"     $.each(TableTVHGDID.rows().nodes(), function () {\r\n                        " +
"        var curRow = TableTVHGDID.row(this).data();\r\n                           " +
"     if (curRow.HOGIADINHTVID == result.obj.HOGIADINHTVID) {\r\n                  " +
"                  objTemp = TableTVHGDID.row(this).data();\r\n                    " +
"                rowEle = this;\r\n                                    return false" +
";\r\n                                }\r\n                            })\r\n          " +
"                  if (objTemp != null) {\r\n                                result" +
".obj.STT = TableTVHGDID.row(rowEle).data().STT;\r\n                               " +
" TableTVHGDID.row(rowEle).data(result.obj).draw();\r\n                            " +
"} else {\r\n                                result.obj.STT = TableTVHGDID.data().c" +
"ount() + 1;\r\n                                result.obj.STT += \".\";\r\n           " +
"                     TableTVHGDID.row.add(result.obj).draw();\r\n                 " +
"           }\r\n                            $.ajax({\r\n                            " +
"    type: \"POST\",\r\n                                url: \'/XLHSDangKy/HoGiaDinh_G" +
"etThongTin\',\r\n                                dataType: \"json\",\r\n               " +
"                 success: function (hoGiaDinh) {\r\n                              " +
"      console.log(hoGiaDinh);\r\n                                    $(\'#formTTHoG" +
"iaDinhID [name=CHUHO]\').val(hoGiaDinh.CHUHO);\r\n                                 " +
"   $(\'#formTTHoGiaDinhID [name=VOCHONG]\').val(hoGiaDinh.VOCHONG);\r\n             " +
"                       $(\'#formTTHoGiaDinhID [name=CMTCHUHO]\').val(hoGiaDinh.CMT" +
"CHUHO);\r\n                                    $(\'#formTTHoGiaDinhID [name=CHUHO_H" +
"OTEN]\').val(hoGiaDinh.CHUHO_HOTEN);\r\n                                    $(\'#for" +
"mTTHoGiaDinhID [name=CMTVOCHONG]\').val(hoGiaDinh.CMTVOCHONG);\r\n                 " +
"                   $(\'#formTTHoGiaDinhID [name=VOCHONG_HOTEN]\').val(hoGiaDinh.VO" +
"CHONG_HOTEN);\r\n                                }\r\n                            })" +
"\r\n                        }\r\n                        alert(result.mes);\r\n       " +
"             }\r\n                })\r\n            })\r\n\r\n            $(\'#BtnClear_F" +
"ormHGD_ChiTietTVID\').on(\'click\', function () {\r\n                $.ajax({\r\n      " +
"              type: \"POST\",\r\n                    url: \'/XLHSDangKy/HoGiaDinh_The" +
"mMoiThanhVien\',\r\n                    dataType: \"html\",\r\n                    succ" +
"ess: function (html) {\r\n                        $(\'#FormHGD_ChiTietTVID\').remove" +
"();\r\n                        $(\'#HGDDSTVID\').append(html);\r\n                    " +
"}\r\n                })\r\n            })\r\n\r\n            $(\'#CB_QHVOICHUHOID\').on(\'c" +
"hange\', function () {\r\n                $(\'#formHoGiaDinhThanhVienID [name=QHVOIC" +
"HUHOID]\').val($(\'#CB_QHVOICHUHOID\').val());\r\n            })\r\n\r\n            $(\'#C" +
"B_QHVOICHUHOID\').val(\'");

            
            #line 151 "..\..\Views\XLHSDangKy\HoGiaDinh_ChiTietThanhVien.cshtml"
                                  Write(Model.QHVOICHUHOID);

            
            #line default
            #line hidden
WriteLiteral("\')\r\n\r\n        })\r\n\r\n    </script>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
