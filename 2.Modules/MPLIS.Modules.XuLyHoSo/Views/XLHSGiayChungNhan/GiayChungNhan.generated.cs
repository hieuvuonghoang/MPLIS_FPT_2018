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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/XLHSGiayChungNhan/GiayChungNhan.cshtml")]
    public partial class _Views_XLHSGiayChungNhan_GiayChungNhan_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_XLHSGiayChungNhan_GiayChungNhan_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" id=\"gcnnavtabID\"");

WriteLiteral(">\r\n    <ul");

WriteLiteral(" class=\"nav nav-tabs nav-justified\"");

WriteLiteral(">\r\n        <li");

WriteLiteral(" id=\"gcn-li1\"");

WriteLiteral(" class=\"active\"");

WriteLiteral(">\r\n            <a");

WriteLiteral(" id=\"gcnopenTab1\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(" href=\"#gcn-tabID\"");

WriteLiteral(">Thông tin giấy chứng nhận</a>\r\n        </li>\r\n        <li");

WriteLiteral(" id=\"gcn-li2\"");

WriteLiteral(">\r\n            <a");

WriteLiteral(" id=\"gcnopenTab2\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(" href=\"#gcn-tabID\"");

WriteLiteral(">Thông tin nghĩa vụ tài chính</a>\r\n        </li>\r\n    </ul>\r\n    <div");

WriteLiteral(" id=\"gcn-tabs-cont\"");

WriteLiteral(" class=\"tab-content\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" id=\"gcn-tabID\"");

WriteLiteral(" class=\"tab-pane fade m-15 in active\"");

WriteLiteral(">\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div");

WriteLiteral(" id=\"divPopup\"");

WriteLiteral("></div>\r\n\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
    $(document).ready(function () {
        $('#xlhsnavtabID .nav-tabs li').removeClass('active');
        $('#bhs-li4').removeClass('disabled');
        $('#bhs-li4').addClass('active');
        $('#gcnopenTab1').on('click', function () {
            $('#gcn-tabID').load('/XLHSGiayChungNhan/GiayChungNhan_Main');
        });
        $('#gcnopenTab2').on(""click"", function () {
            console.log('Tab2 Click!');
        });
        $('#gcnopenTab1').click();
    })
</script>
");

        }
    }
}
#pragma warning restore 1591