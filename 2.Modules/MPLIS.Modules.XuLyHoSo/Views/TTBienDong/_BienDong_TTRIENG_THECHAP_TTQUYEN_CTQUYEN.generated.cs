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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/TTBienDong/_BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN.cshtml")]
    public partial class _Views_TTBienDong__BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN_cshtml : System.Web.Mvc.WebViewPage<MPLIS.Libraries.Data.XuLyHoSo.Models.TheChapGiaiChapGCNVM>
    {
        public _Views_TTBienDong__BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN.cshtml"
Write(Html.HiddenFor(model => model.JSONTheChapGCNVM));

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"box box-solid\"");

WriteLiteral(" style=\"margin-bottom: 10px;\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"box-header with-border\"");

WriteLiteral(">\r\n        <h4");

WriteLiteral(" class=\"box-title\"");

WriteLiteral(">Quyền sử dụng đất</h4>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"box-body\"");

WriteLiteral(">\r\n        <table");

WriteLiteral(" class=\"table table-bordered\"");

WriteLiteral(" id=\"QuyenSDDatTableID\"");

WriteLiteral(" data-toggle=\"table\"");

WriteLiteral(@">
            <thead>
                <tr>
                    <th>Đang thế chấp</th>
                    <th>Ngày thế chấp</th>
                    <th>Xã/phường</th>
                    <th>SH tờ bản đồ</th>
                    <th>STT thửa</th>
                    <th>Mục đích sử dụng</th>
                    <th>Diện tích (m<sup>2</sup>)</th>
                </tr>
            </thead>
            <tbody>
");

            
            #line 22 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN.cshtml"
                
            
            #line default
            #line hidden
            
            #line 22 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN.cshtml"
                 if (Model.DSQuyenSuDungDat != null && Model.DSQuyenSuDungDat.Count() > 0)
                {
                    foreach (var objQD in Model.DSQuyenSuDungDat)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <tr>\r\n                            <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n                                <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"QUYENSUDUNGDATID\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1186), Tuple.Create("\"", 1217)
            
            #line 28 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN.cshtml"
      , Tuple.Create(Tuple.Create("", 1194), Tuple.Create<System.Object, System.Int32>(objQD.QUYENSUDUNGDATID
            
            #line default
            #line hidden
, 1194), false)
);

WriteAttribute("checked", Tuple.Create(" checked=\"", 1218), Tuple.Create("\"", 1246)
            
            #line 28 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN.cshtml"
                                        , Tuple.Create(Tuple.Create("", 1228), Tuple.Create<System.Object, System.Int32>(objQD.TRANGTHAIPL
            
            #line default
            #line hidden
, 1228), false)
);

WriteLiteral(" ");

            
            #line 28 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN.cshtml"
                                                                                                                                       Write(Html.Raw(objQD.EnableCheck ? "" : "disabled"));

            
            #line default
            #line hidden
WriteLiteral(" />\r\n                            </td>\r\n                            <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 31 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN.cshtml"
                           Write(objQD.NGAYDANGKYTC);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n");

WriteLiteral("                                ");

            
            #line 34 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN.cshtml"
                           Write(objQD.XaPhuong);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                            <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 37 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN.cshtml"
                           Write(objQD.SHToBanDo);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                            <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 40 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN.cshtml"
                           Write(objQD.STTThua);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                            <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 43 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN.cshtml"
                           Write(objQD.MDSD);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                            <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 46 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN.cshtml"
                           Write(objQD.DienTich);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");

            
            #line 49 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN.cshtml"
                    }
                }

            
            #line default
            #line hidden
WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"box box-solid\"");

WriteLiteral(" style=\"margin-bottom: 10px;\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"box-header with-border\"");

WriteLiteral(">\r\n        <h4");

WriteLiteral(" class=\"box-title\"");

WriteLiteral(">Quyền sở hữu tài sản</h4>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"box-body\"");

WriteLiteral(">\r\n        <table");

WriteLiteral(" class=\"table table-bordered\"");

WriteLiteral(" id=\"QuyenSHTaiSanTableID\"");

WriteLiteral(" data-toggle=\"table\"");

WriteLiteral(@">
            <thead>
                <tr>
                    <th>Đang thế chấp</th>
                    <th>Ngày thế chấp</th>
                    <th>Loại tài sản</th>
                    <th>Tên tài sản</th>
                    <th>Diện tích (m<sup>2</sup>)</th>
                </tr>
            </thead>
            <tbody>
");

            
            #line 71 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN.cshtml"
                
            
            #line default
            #line hidden
            
            #line 71 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN.cshtml"
                 if (Model.DSQuyenSoHuuTaiSan != null && Model.DSQuyenSoHuuTaiSan.Count() > 0)
                {
                    foreach (var objQTS in Model.DSQuyenSoHuuTaiSan)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <tr>\r\n                            <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n                                <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"QUYENSOHUUTAISANID\"");

WriteAttribute("value", Tuple.Create(" value=\"", 3274), Tuple.Create("\"", 3308)
            
            #line 77 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN.cshtml"
        , Tuple.Create(Tuple.Create("", 3282), Tuple.Create<System.Object, System.Int32>(objQTS.QUYENSOHUUTAISANID
            
            #line default
            #line hidden
, 3282), false)
);

WriteAttribute("checked", Tuple.Create(" checked=\"", 3309), Tuple.Create("\"", 3338)
            
            #line 77 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN.cshtml"
                                             , Tuple.Create(Tuple.Create("", 3319), Tuple.Create<System.Object, System.Int32>(objQTS.TRANGTHAIPL
            
            #line default
            #line hidden
, 3319), false)
);

WriteLiteral(" ");

            
            #line 77 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN.cshtml"
                                                                                                                                             Write(Html.Raw(objQTS.EnableCheck ? "" : "disabled"));

            
            #line default
            #line hidden
WriteLiteral(" />\r\n                            </td>\r\n                            <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 80 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN.cshtml"
                           Write(objQTS.NGAYDANGKYTC);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                            <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 83 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN.cshtml"
                           Write(objQTS.LoaiTaiSan);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                            <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 86 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN.cshtml"
                           Write(objQTS.TenTaiSan);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                            <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 89 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN.cshtml"
                           Write(objQTS.DienTich);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");

            
            #line 92 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN.cshtml"
                    }
                }

            
            #line default
            #line hidden
WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n<div");

WriteLiteral(" class=\"box box-solid\"");

WriteLiteral(" style=\"margin-bottom: 10px;\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"box-header with-border\"");

WriteLiteral(">\r\n        <h4");

WriteLiteral(" class=\"box-title\"");

WriteLiteral(">Quyền quản lý đất</h4>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"box-body\"");

WriteLiteral(">\r\n        <table");

WriteLiteral(" class=\"table table-bordered\"");

WriteLiteral(" id=\"QuyenQLDatTableID\"");

WriteLiteral(" data-toggle=\"table\"");

WriteLiteral(@">
            <thead>
                <tr>
                    <th>Đang thế chấp</th>
                    <th>Ngày thế chấp</th>
                    <th>Xã/phường</th>
                    <th>SH tờ bản đồ</th>
                    <th>STT thửa</th>
                    <th>Mục đích sử dụng</th>
                    <th>Diện tích (m<sup>2</sup>)</th>
                </tr>
            </thead>
            <tbody>
");

            
            #line 117 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN.cshtml"
                
            
            #line default
            #line hidden
            
            #line 117 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN.cshtml"
                 if (Model.DSQuyenQuanLyDat != null && Model.DSQuyenQuanLyDat.Count() > 0)
                {
                    foreach (var objQQLD in Model.DSQuyenQuanLyDat)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <tr>\r\n                            <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n                                <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"QUYENSUDUNGDATID\"");

WriteAttribute("value", Tuple.Create(" value=\"", 5195), Tuple.Create("\"", 5228)
            
            #line 123 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN.cshtml"
      , Tuple.Create(Tuple.Create("", 5203), Tuple.Create<System.Object, System.Int32>(objQQLD.QUYENQUANLYDATID
            
            #line default
            #line hidden
, 5203), false)
);

WriteAttribute("checked", Tuple.Create(" checked=\"", 5229), Tuple.Create("\"", 5259)
            
            #line 123 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN.cshtml"
                                          , Tuple.Create(Tuple.Create("", 5239), Tuple.Create<System.Object, System.Int32>(objQQLD.TRANGTHAIPL
            
            #line default
            #line hidden
, 5239), false)
);

WriteLiteral(" ");

            
            #line 123 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN.cshtml"
                                                                                                                                           Write(Html.Raw(objQQLD.EnableCheck ? "" : "disabled"));

            
            #line default
            #line hidden
WriteLiteral(" />\r\n                            </td>\r\n                            <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 126 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN.cshtml"
                           Write(objQQLD.NGAYDANGKYTC);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n");

WriteLiteral("                                ");

            
            #line 129 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN.cshtml"
                           Write(objQQLD.XaPhuong);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                            <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 132 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN.cshtml"
                           Write(objQQLD.SHToBanDo);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                            <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 135 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN.cshtml"
                           Write(objQQLD.STTThua);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                            <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 138 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN.cshtml"
                           Write(objQQLD.MDSD);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                            <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 141 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN.cshtml"
                           Write(objQQLD.DienTich);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");

            
            #line 144 "..\..\Views\TTBienDong\_BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN.cshtml"
                    }
                }

            
            #line default
            #line hidden
WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n    $(document).ready(function () {\r\n        InitDataTableXLHS($(\'#QuyenSDDatT" +
"ableID\'));\r\n        InitDataTableXLHS($(\'#QuyenSHTaiSanTableID\'));\r\n        Init" +
"DataTableXLHS($(\'#QuyenQLDatTableID\'));\r\n        $(\"#QuyenSDDatTableID input\").c" +
"hange(function () {\r\n            var obj = JSON.parse($(\"#JSONTheChapGCNVM\").val" +
"());\r\n            for (var i = 0; i < obj.DSQuyen.length; i++) {\r\n              " +
"  if (obj.DSQuyen[i].ISQuyen == \"QSDDAT\" && obj.DSQuyen[i].IDQuyen == $(this).va" +
"l()) {\r\n                    obj.DSQuyen[i].TrangThaiPL = $(this).is(\':checked\') " +
"? true : false;\r\n                }\r\n            }\r\n            $(\"#JSONTheChapGC" +
"NVM\").val(JSON.stringify(obj));\r\n        })\r\n        $(\"#QuyenSHTaiSanTableID in" +
"put\").change(function () {\r\n            var obj = JSON.parse($(\"#JSONTheChapGCNV" +
"M\").val());\r\n            for (var i = 0; i < obj.DSQuyen.length; i++) {\r\n       " +
"         if (obj.DSQuyen[i].ISQuyen == \"QTS\" && obj.DSQuyen[i].IDQuyen == $(this" +
").val()) {\r\n                    obj.DSQuyen[i].TrangThaiPL = $(this).is(\':checke" +
"d\') ? true : false;\r\n                }\r\n            }\r\n            $(\"#JSONTheCh" +
"apGCNVM\").val(JSON.stringify(obj));\r\n        })\r\n        $(\"#QuyenQLDatTableID i" +
"nput\").change(function () {\r\n            var obj = JSON.parse($(\"#JSONTheChapGCN" +
"VM\").val());\r\n            for (var i = 0; i < obj.DSQuyen.length; i++) {\r\n      " +
"          if (obj.DSQuyen[i].ISQuyen == \"QQLDAT\" && obj.DSQuyen[i].IDQuyen == $(" +
"this).val()) {\r\n                    obj.DSQuyen[i].TrangThaiPL = $(this).is(\':ch" +
"ecked\') ? true : false;\r\n                }\r\n            }\r\n            $(\"#JSONT" +
"heChapGCNVM\").val(JSON.stringify(obj));\r\n        })\r\n    })\r\n</script>\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
