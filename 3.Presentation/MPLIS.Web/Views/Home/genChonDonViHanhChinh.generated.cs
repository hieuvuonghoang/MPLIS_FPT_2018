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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Home/genChonDonViHanhChinh.cshtml")]
    public partial class _Views_Home_genChonDonViHanhChinh_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Home_genChonDonViHanhChinh_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<!--Đổi đơn vị hành chính-->\r\n<div");

WriteLiteral(" class=\"modal fade\"");

WriteLiteral(" id=\"doiDVHC\"");

WriteLiteral(" tabindex=\"-1\"");

WriteLiteral(" role=\"dialog\"");

WriteLiteral(" aria-labelledby=\"myModalLabel\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"modal-dialog\"");

WriteLiteral(" role=\"document\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"modal-content\"");

WriteLiteral(">\r\n            <form");

WriteLiteral(" action=\"/Home/chonDVHC\"");

WriteLiteral(" method=\"post\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" name=\"curURL\"");

WriteAttribute("value", Tuple.Create(" value=\"", 321), Tuple.Create("\"", 354)
            
            #line 6 "..\..\Views\Home\genChonDonViHanhChinh.cshtml"
, Tuple.Create(Tuple.Create("", 329), Tuple.Create<System.Object, System.Int32>(Request.Url.PathAndQuery
            
            #line default
            #line hidden
, 329), false)
);

WriteLiteral(" />\r\n                <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" name=\"LoaiNguoiDung\"");

WriteAttribute("value", Tuple.Create(" value=\"", 417), Tuple.Create("\"", 447)
            
            #line 7 "..\..\Views\Home\genChonDonViHanhChinh.cshtml"
, Tuple.Create(Tuple.Create("", 425), Tuple.Create<System.Object, System.Int32>(ViewBag.LOAINGUOIDUNG
            
            #line default
            #line hidden
, 425), false)
);

WriteLiteral("/>\r\n                <div");

WriteLiteral(" class=\"modal-header\"");

WriteLiteral(">\r\n                    <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"close\"");

WriteLiteral(" data-dismiss=\"modal\"");

WriteLiteral(" aria-label=\"Close\"");

WriteLiteral("><span");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(">&times;</span></button>\r\n                    <h4");

WriteLiteral(" class=\"modal-title\"");

WriteLiteral(" id=\"myModalLabel\"");

WriteLiteral(">Chọn đơn vị hành chính làm việc</h4>\r\n                </div>\r\n                <d" +
"iv");

WriteLiteral(" class=\"modal-body\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                        <label>Huyện</label>\r\n                        <select");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" name=\"HUYENID\"");

WriteLiteral(">\r\n");

            
            #line 16 "..\..\Views\Home\genChonDonViHanhChinh.cshtml"
                            
            
            #line default
            #line hidden
            
            #line 16 "..\..\Views\Home\genChonDonViHanhChinh.cshtml"
                             foreach (var item in ViewBag.HuyenNguoiDung)
                            {
                                if (!string.IsNullOrEmpty(ViewBag.HUYENID) && ViewBag.HUYENID == @item.HUYENID)
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    <option");

WriteAttribute("value", Tuple.Create(" value=\"", 1267), Tuple.Create("\"", 1288)
            
            #line 20 "..\..\Views\Home\genChonDonViHanhChinh.cshtml"
, Tuple.Create(Tuple.Create("", 1275), Tuple.Create<System.Object, System.Int32>(item.HUYENID
            
            #line default
            #line hidden
, 1275), false)
);

WriteLiteral(" selected>");

            
            #line 20 "..\..\Views\Home\genChonDonViHanhChinh.cshtml"
                                                                      Write(item.TENHUYEN);

            
            #line default
            #line hidden
WriteLiteral("</option>\r\n");

            
            #line 21 "..\..\Views\Home\genChonDonViHanhChinh.cshtml"
                                }
                                else
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    <option");

WriteAttribute("value", Tuple.Create(" value=\"", 1475), Tuple.Create("\"", 1496)
            
            #line 24 "..\..\Views\Home\genChonDonViHanhChinh.cshtml"
, Tuple.Create(Tuple.Create("", 1483), Tuple.Create<System.Object, System.Int32>(item.HUYENID
            
            #line default
            #line hidden
, 1483), false)
);

WriteLiteral(">");

            
            #line 24 "..\..\Views\Home\genChonDonViHanhChinh.cshtml"
                                                             Write(item.TENHUYEN);

            
            #line default
            #line hidden
WriteLiteral("</option>\r\n");

            
            #line 25 "..\..\Views\Home\genChonDonViHanhChinh.cshtml"
                                }
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </select>\r\n                    </div>\r\n                  " +
"  <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                        <label>Xã</label>\r\n                        <select");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" name=\"XAID\"");

WriteLiteral(">\r\n");

            
            #line 32 "..\..\Views\Home\genChonDonViHanhChinh.cshtml"
                            
            
            #line default
            #line hidden
            
            #line 32 "..\..\Views\Home\genChonDonViHanhChinh.cshtml"
                             foreach (var item in ViewBag.XaNguoiDung)
                            {
                                if (!string.IsNullOrEmpty(ViewBag.XAID) && ViewBag.XAID == @item.XAID)
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    <option");

WriteLiteral(" data-huyenid=\"");

            
            #line 36 "..\..\Views\Home\genChonDonViHanhChinh.cshtml"
                                                     Write(item.HUYENID);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2122), Tuple.Create("\"", 2140)
            
            #line 36 "..\..\Views\Home\genChonDonViHanhChinh.cshtml"
, Tuple.Create(Tuple.Create("", 2130), Tuple.Create<System.Object, System.Int32>(item.XAID
            
            #line default
            #line hidden
, 2130), false)
);

WriteLiteral(" selected>");

            
            #line 36 "..\..\Views\Home\genChonDonViHanhChinh.cshtml"
                                                                                                Write(item.TENXA);

            
            #line default
            #line hidden
WriteLiteral("</option>\r\n");

            
            #line 37 "..\..\Views\Home\genChonDonViHanhChinh.cshtml"
                                }
                                else
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    <option");

WriteLiteral("  data-huyenid=\"");

            
            #line 40 "..\..\Views\Home\genChonDonViHanhChinh.cshtml"
                                                      Write(item.HUYENID);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2354), Tuple.Create("\"", 2372)
            
            #line 40 "..\..\Views\Home\genChonDonViHanhChinh.cshtml"
 , Tuple.Create(Tuple.Create("", 2362), Tuple.Create<System.Object, System.Int32>(item.XAID
            
            #line default
            #line hidden
, 2362), false)
);

WriteLiteral(">");

            
            #line 40 "..\..\Views\Home\genChonDonViHanhChinh.cshtml"
                                                                                        Write(item.TENXA);

            
            #line default
            #line hidden
WriteLiteral("</option>\r\n");

            
            #line 41 "..\..\Views\Home\genChonDonViHanhChinh.cshtml"
                                }
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </select>\r\n");

            
            #line 44 "..\..\Views\Home\genChonDonViHanhChinh.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 44 "..\..\Views\Home\genChonDonViHanhChinh.cshtml"
                         if (!string.IsNullOrEmpty(ViewBag.XAID))
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" class=\"is_selected_dvhc\"");

WriteLiteral(" value=\"1\"");

WriteLiteral("/>\r\n");

            
            #line 47 "..\..\Views\Home\genChonDonViHanhChinh.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                        <select");

WriteLiteral(" class=\"hidden xa_temp\"");

WriteLiteral(">\r\n\r\n                        </select>\r\n                    </div>\r\n             " +
"   </div>\r\n                <div");

WriteLiteral(" class=\"modal-footer\"");

WriteLiteral(">\r\n                    <button");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(">Chọn</button>\r\n                </div>\r\n            </form>\r\n\r\n        </div>\r\n  " +
"  </div>\r\n</div>\r\n<!--End Đổi đơn vị hành chính-->");

        }
    }
}
#pragma warning restore 1591
