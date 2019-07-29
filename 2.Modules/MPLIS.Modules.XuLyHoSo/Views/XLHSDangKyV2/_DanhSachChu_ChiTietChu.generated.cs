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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/XLHSDangKyV2/_DanhSachChu_ChiTietChu.cshtml")]
    public partial class _Views_XLHSDangKyV2__DanhSachChu_ChiTietChu_cshtml : System.Web.Mvc.WebViewPage<MPLIS.Libraries.Data.XuLyHoSo.Models.DangKyNguoiVM>
    {
        public _Views_XLHSDangKyV2__DanhSachChu_ChiTietChu_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\XLHSDangKyV2\_DanhSachChu_ChiTietChu.cshtml"
  
    string title = "Thông tin chi tiết chủ";
    switch (Model.Chu.LOAIDOITUONGID)
    {
        case "1":
            title += " Cá Nhân";
            break;
        case "2":
            title += " Hộ Gia Đình";
            break;
        case "3":
            title += " Vợ Chồng";
            break;
        case "4":
            title += " Tổ Chức";
            break;
        case "5":
            title += " Cộng Đồng";
            break;
        case "6":
            title += " Nhóm Người";
            break;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" id=\"divDSChu_ChiTietChuID\"");

WriteLiteral(" class=\"box box-primary m-0\"");

WriteLiteral(">\r\n    <form");

WriteLiteral(" id=\"formNguoiID\"");

WriteLiteral(" class=\"d-none\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 30 "..\..\Views\XLHSDangKyV2\_DanhSachChu_ChiTietChu.cshtml"
   Write(Html.Hidden("NGUOIID", Model.Chu.NGUOIID));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 31 "..\..\Views\XLHSDangKyV2\_DanhSachChu_ChiTietChu.cshtml"
   Write(Html.Hidden("CHITIETID", Model.Chu.CHITIETID));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 32 "..\..\Views\XLHSDangKyV2\_DanhSachChu_ChiTietChu.cshtml"
   Write(Html.Hidden("DOITUONGSUDUNGID", Model.Chu.DOITUONGSUDUNGID));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 33 "..\..\Views\XLHSDangKyV2\_DanhSachChu_ChiTietChu.cshtml"
   Write(Html.Hidden("TRANGTHAI", Model.Chu.TRANGTHAI));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 34 "..\..\Views\XLHSDangKyV2\_DanhSachChu_ChiTietChu.cshtml"
   Write(Html.Hidden("LOAIDOITUONGID", Model.Chu.LOAIDOITUONGID));

            
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

WriteLiteral(">\r\n                    <button");

WriteLiteral(" id=\"BtnSave_FormChiTietChuID\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-sm btn-default\"");

WriteLiteral("><i");

WriteLiteral(" class=\'fa fa-check\'");

WriteLiteral("></i> Lưu thông tin</button>\r\n                    <button");

WriteLiteral(" id=\"BtnClear_FormChiTietChuID\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-sm btn-default\"");

WriteLiteral("><i");

WriteLiteral(" class=\'fa fa-trash\'");

WriteLiteral("></i> Xóa trắng</button>\r\n                </div>\r\n            </div>\r\n           " +
" <div");

WriteLiteral(" class=\"col-xs-4 text-center p-0\"");

WriteLiteral(">\r\n                <h3");

WriteLiteral(" class=\"box-title\"");

WriteLiteral(">");

            
            #line 45 "..\..\Views\XLHSDangKyV2\_DanhSachChu_ChiTietChu.cshtml"
                                 Write(Html.Raw(title));

            
            #line default
            #line hidden
WriteLiteral("</h3>\r\n            </div>\r\n            <div");

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

            
            #line 53 "..\..\Views\XLHSDangKyV2\_DanhSachChu_ChiTietChu.cshtml"
                       Write(Html.DropDownListFor(model => model.Chu.DOITUONGSUDUNGID, new SelectList(Model.DSDoiTuongSuDung, "DOITUONGSUDUNGID", "TENDOITUONGSUDUNG"), "---- Chọn đối tượng sử dụng ----", new { @class = "input-sm form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                   " +
" <div");

WriteLiteral(" class=\"col-xs-3 p-0\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"pull-right\"");

WriteLiteral(">\r\n                            <button");

WriteLiteral(" id=\"btnClose_divDSChu_ChiTietChuID\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-box-tool\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-remove\"");

WriteLiteral("></i></button>\r\n                        </div>\r\n                    </div>\r\n     " +
"           </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n    <div");

WriteLiteral(" class=\"box-body p-0\"");

WriteLiteral(">\r\n");

            
            #line 67 "..\..\Views\XLHSDangKyV2\_DanhSachChu_ChiTietChu.cshtml"
        
            
            #line default
            #line hidden
            
            #line 67 "..\..\Views\XLHSDangKyV2\_DanhSachChu_ChiTietChu.cshtml"
          

        
            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
        $(document).ready(function () {
            $('#btnClose_divDSChu_ChiTietChuID').on('click', function () {
                $('#tableDangKyChuID_wrapper').removeClass(""d-none"");
                $('#divDSChu_ChiTietChuID').remove();
            })
        })
    </script>
</div>
");

        }
    }
}
#pragma warning restore 1591
