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
    
    #line 1 "..\..\Views\XLHSHoSoLuuKho\_HoSoLuuKho_DSFile.cshtml"
    using AppCore.Models;
    
    #line default
    #line hidden
    using MPLIS;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/XLHSHoSoLuuKho/_HoSoLuuKho_DSFile.cshtml")]
    public partial class _Views_XLHSHoSoLuuKho__HoSoLuuKho_DSFile_cshtml : System.Web.Mvc.WebViewPage<HS_HOSO>
    {
        public _Views_XLHSHoSoLuuKho__HoSoLuuKho_DSFile_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(" id=\"divHSLK_DSFile\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"col-xs-8\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"box box-primary\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"box-header with-border\"");

WriteLiteral(">\r\n                    <h3");

WriteLiteral(" class=\"box-title\"");

WriteLiteral(">Danh sách các file đính kèm</h3>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"box-body\"");

WriteLiteral(">\r\n                    <style");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(@">
                        .table td {
                            word-wrap: break-word;
                            word-break: break-all;
                            white-space: normal;
                                 }
                    </style>
                        <table");

WriteLiteral(" id=\"table_HoSoLK_DSFile\"");

WriteLiteral(" class=\"table table-bordered\"");

WriteLiteral(@">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>STT</th>
                                    <th>Loại giấy tờ</th>
                                    <th>Tên tệp dữ liệu</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
");

            
            #line 28 "..\..\Views\XLHSHoSoLuuKho\_HoSoLuuKho_DSFile.cshtml"
                                
            
            #line default
            #line hidden
            
            #line 28 "..\..\Views\XLHSHoSoLuuKho\_HoSoLuuKho_DSFile.cshtml"
                                  
                                    int rdsgcntable = 0;
                                    if (Model != null)
                                    {
                                        if (Model.DSFileDinhKem != null)
                                        {
                                            foreach (var item in Model.DSFileDinhKem)
                                            {
                                                rdsgcntable = rdsgcntable + 1;

            
            #line default
            #line hidden
WriteLiteral("                                                <tr>\r\n                           " +
"                         <td>\r\n");

WriteLiteral("                                                        ");

            
            #line 39 "..\..\Views\XLHSHoSoLuuKho\_HoSoLuuKho_DSFile.cshtml"
                                                   Write(item.THANHPHANHOSOID);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                    </td>\r\n                    " +
"                                <td>\r\n");

WriteLiteral("                                                        ");

            
            #line 42 "..\..\Views\XLHSHoSoLuuKho\_HoSoLuuKho_DSFile.cshtml"
                                                   Write(rdsgcntable);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                    </td>\r\n                    " +
"                                <td>\r\n");

WriteLiteral("                                                        ");

            
            #line 45 "..\..\Views\XLHSHoSoLuuKho\_HoSoLuuKho_DSFile.cshtml"
                                                   Write(item.loaihoso);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                    </td>\r\n                    " +
"                                <td>\r\n");

WriteLiteral("                                                        ");

            
            #line 48 "..\..\Views\XLHSHoSoLuuKho\_HoSoLuuKho_DSFile.cshtml"
                                                   Write(item.TENTEPDULIEU);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                    </td>\r\n                    " +
"                                <td></td>\r\n                                     " +
"           </tr>\r\n");

            
            #line 52 "..\..\Views\XLHSHoSoLuuKho\_HoSoLuuKho_DSFile.cshtml"
                                            }
                                        }
                                    }
                                
            
            #line default
            #line hidden
WriteLiteral("\r\n                            </tbody>\r\n                        </table>\r\n       " +
"             </div>\r\n            </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"box box-primary\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"box-header with-border\"");

WriteLiteral(">\r\n                <h3");

WriteLiteral(" class=\"box-title\"");

WriteLiteral(">Chi tiết file đính kèm</h3>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"box-body\"");

WriteLiteral(">\r\n                <style");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(@">
                    .btn-file {
                        position: relative;
                        overflow: hidden;
                    }
                        .btn-file input[type=file] {
                            position: absolute;
                            top: 0;
                            right: 0;
                            min-width: 100%;
                            min-height: 100%;
                            font-size: 100px;
                            text-align: right;
                            filter: alpha(opacity=0);
                            opacity: 0;
                            outline: none;
                            cursor: inherit;
                            display: block;
                        }
                </style>
                <form");

WriteLiteral(" id=\"ChiTietFile\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 88 "..\..\Views\XLHSHoSoLuuKho\_HoSoLuuKho_DSFile.cshtml"
               Write(Html.HiddenFor(m=>m.file.HOSOID, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 89 "..\..\Views\XLHSHoSoLuuKho\_HoSoLuuKho_DSFile.cshtml"
               Write(Html.HiddenFor(m => m.file.THANHPHANHOSOID, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 90 "..\..\Views\XLHSHoSoLuuKho\_HoSoLuuKho_DSFile.cshtml"
               Write(Html.HiddenFor(m => m.file.DUONGDAN, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 93 "..\..\Views\XLHSHoSoLuuKho\_HoSoLuuKho_DSFile.cshtml"
                       Write(Html.LabelFor(Model => Model.file.GIAYTOKEMTHEOHSID, "Loại giấy tờ", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                        <div");

WriteLiteral(" class=\"col-xs-7\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 96 "..\..\Views\XLHSHoSoLuuKho\_HoSoLuuKho_DSFile.cshtml"
                       Write(Html.DropDownListFor(m => m.file.GIAYTOKEMTHEOHSID, new SelectList(ViewBag.Listfilehoso, "GIAYTOKEMTHEOHSID", "TENGIAYTOKEMTHEOHS"),"", new { @class = "form-control input-sm", @id = "drpfileHSLuuKho" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                   " +
" <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"col-xs-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 101 "..\..\Views\XLHSHoSoLuuKho\_HoSoLuuKho_DSFile.cshtml"
                       Write(Html.LabelFor(Model => Model.file.TENTEPDULIEU, "Tên file", new { @class = "pull-right control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                        <div");

WriteLiteral(" class=\"col-xs-7\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 104 "..\..\Views\XLHSHoSoLuuKho\_HoSoLuuKho_DSFile.cshtml"
                       Write(Html.TextBoxFor(m => m.file.TENTEPDULIEU, new { @class = "form-control input-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                   " +
" <div");

WriteLiteral(" class=\"row\"");

WriteLiteral("enctype=\"multipart/form-data\"");

WriteLiteral(">\r\n                        <span");

WriteLiteral(" class=\"btn btn-xs btn-heading btn-file\"");

WriteLiteral(">\r\n                            upload\r\n                            <input");

WriteLiteral(" type=\"file\"");

WriteLiteral(" id=\"file_upload\"");

WriteLiteral("multiple>\r\n                        </span>\r\n                        <iframe");

WriteLiteral(" id=\'hiddenIframe\'");

WriteLiteral(" src=\"\"");

WriteLiteral(" style=\"display:none; visibility:hidden;\"");

WriteLiteral("></iframe>\r\n                        <input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-xs btn-heading\"");

WriteLiteral(" value=\"download\"");

WriteLiteral("  id=\"btnDownLoad\"");

WriteLiteral("/>\r\n                    </div>\r\n                </form>\r\n            </div>\r\n    " +
"        <div");

WriteLiteral(" class=\"box-footer\"");

WriteLiteral(" style=\"border-top: 1px solid #d2d6de;\"");

WriteLiteral(">\r\n                <button");

WriteLiteral(" class=\"btn-sm btn-inform pull-right\"");

WriteLiteral(" style=\"margin-left: 5px;\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" id=\"btnLuuThongTinFile\"");

WriteLiteral(">Lưu thông tin</button>\r\n                <button");

WriteLiteral(" class=\"btn-sm btn-inform pull-right\"");

WriteLiteral(" style=\"margin-right: 5px;\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" onclick=\"LamMoiFile()\"");

WriteLiteral(">Làm mới</button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n<scrip" +
"t>\r\n\r\n    $(document).ready(function () {\r\n        var columns = [\r\n{ \"data\": \"T" +
"HANHPHANHOSOID\" },\r\n{ \"data\": \"STT\" },\r\n{ \"data\": \"loaihoso\" },\r\n{ \"data\": \"TENT" +
"EPDULIEU\" },\r\n{ \"data\": null }\r\n        ]\r\n        var columnDefs = [\r\n         " +
"   {\r\n                \"targets\": 0,\r\n                \"className\": \"hidden\"\r\n    " +
"        },\r\n            {\r\n                \"targets\": -1,\r\n                \"rend" +
"er\": function () {\r\n                    return \"<input type=\\\"button\\\" class=\\\"b" +
"tn btn-xs btn-heading\\\" value=\\\"Xem\\\" onclick=\\\"chitiet(this)\\\" />\\\r\n           " +
"          <input type=\\\"button\\\" class=\\\"btn btn-xs btn-heading\\\" value=\\\"Xóa\\\"" +
" onclick=\\\"xoa(this)\\\" />\";\r\n                },\r\n                \"className\": \"t" +
"ext-center\"\r\n            },\r\n            {\r\n                \"targets\": 1,\r\n     " +
"           \"className\": \"text-right\"\r\n            },\r\n            {\r\n           " +
"     \"targets\": [2, 3],\r\n                \"className\": \"text-center\"\r\n           " +
" }\r\n        ]\r\n        var options = {\r\n            \"pageLength\": 5,\r\n          " +
"  \"ordering\": false,\r\n            \"autoWidth\": false,\r\n            \"columns\": co" +
"lumns,\r\n            \"columnDefs\": columnDefs,\r\n            \"info\": false,\r\n     " +
"       \"lengthChange\": false,\r\n            \"searching\": false\r\n        }\r\n      " +
"  var tableDSFile = $(\'#table_HoSoLK_DSFile\').DataTable(options);\r\n        $(\'#f" +
"ile_upload\').change(function () {\r\n            console.log(\"click-upload\");\r\n   " +
"         var filedata = document.getElementById(\"file_upload\");\r\n            con" +
"sole.log(filedata.files);\r\n            formdata = false;\r\n            if (window" +
".FormData) {\r\n                formdata = new FormData();\r\n            }\r\n       " +
"     var i = 0, len = filedata.files.length, img, reader, file;\r\n\r\n            f" +
"or (; i < len; i++) {\r\n                file = filedata.files[i];\r\n\r\n            " +
"    if (window.FileReader) {\r\n                    reader = new FileReader();\r\n  " +
"                  //reader.onloadend = function (e) {\r\n                    //   " +
" showUploadedItem(e.target.result, file.fileName);\r\n                   // };\r\n  " +
"                  reader.readAsDataURL(file);\r\n                }\r\n              " +
"  if (formdata) {\r\n                    formdata.append(\"file\", file);\r\n         " +
"       }\r\n            }\r\n            for (var p of formdata) {\r\n                " +
"console.log(p);\r\n            }\r\n            $.ajax({\r\n                type: \"POS" +
"T\",\r\n                url: \"/XLHSHoSoLuuKho/UpLoadFile\",\r\n                success" +
": function (result) {\r\n                    $(\'#file_HOSOID\').val(result.hosoinfo" +
"r.HOSOID);\r\n                    $(\'#file_THANHPHANHOSOID\').val(result.hosoinfor." +
"THANHPHANHOSOID);\r\n                    $.ajax({\r\n                        type: \"" +
"POST\",\r\n                        url: \"http://localhost:51022/api/UpLoadFile?toke" +
"n=\" + result.token + \"&loaifile=\" + result.loaifile + \"&xa=\" + result.xa + \"&huy" +
"en=\" + result.huyen + \"&tinh=\" + result.tinh + \"&nam=\" + result.nam + \"&bohoso=\"" +
" + result.bohoso + \"&donvi=\" + result.donvi,\r\n                        data: form" +
"data,\r\n                        type: \"POST\", processData: false,\r\n              " +
"          dataType: \'json\',\r\n                        contentType: false,\r\n      " +
"                  success: function (data) {\r\n                            consol" +
"e.log(data);\r\n                            for (var i = 0; i < data.length;i++){\r" +
"\n                                $(\'#file_DUONGDAN\').val(data[i].DuongDan);\r\n   " +
"                             $(\'#file_TENTEPDULIEU\').val(data[i].TenFile);\r\n    " +
"                        }\r\n\r\n                        },\r\n                       " +
" error: function (er) {\r\n                            console.log(er);\r\n         " +
"               }\r\n                    })\r\n                }\r\n            });\r\n  " +
"         \r\n        });\r\n      tableDSFile.rows().nodes().on(\"click\", \"tbody tr\"," +
" function () {\r\n            console.log(\"CLICK\");\r\n            if (tableDSFile.r" +
"ows().nodes().length > 0) {\r\n                if ($(tableDSFile.row(this).node())" +
".attr(\'class\').indexOf(\'activerow\') != -1) {\r\n                    $(tableDSFile." +
"row(this).node()).removeClass(\'activerow\');\r\n                } else {\r\n         " +
"           $(tableDSFile.rows().nodes()).removeClass(\'activerow\');\r\n            " +
"        $(tableDSFile.row(this).node()).addClass(\'activerow\');\r\n                " +
"} var idfile = $(this)[0].cells[0].innerHTML;\r\n                $.ajax({\r\n       " +
"             type: \"POST\",\r\n                    url: \"/XLHSHoSoLuuKho/ChiTietFil" +
"e\",\r\n                    data: { idfile: idfile.trim() },\r\n                    s" +
"uccess: function (data) {\r\n                        $(\'#file_HOSOID\').val(data.hs" +
"id);\r\n                        $(\'#file_THANHPHANHOSOID\').val(data.fileid);\r\n    " +
"                    $(\'#file_DUONGDAN\').val(data.duongdan);\r\n                   " +
"     $(\'#file_TENTEPDULIEU\').val(data.tenfile);\r\n                        $(\'#fil" +
"e_GIAYTOKEMTHEOHSID\').val(data.loaifile);\r\n                    }\r\n              " +
"  })\r\n            }\r\n\r\n        })\r\n      tableDSFile.rows().nodes().on(\"click\", " +
"\"tbody tr input\", function (event) {\r\n            event.stopPropagation();\r\n    " +
"  });\r\n      $(\'#btnLuuThongTinFile\').on(\"click\", function () {\r\n          var f" +
"ormdata = $(\"#ChiTietFile\").serializeArray();\r\n          $.ajax({\r\n             " +
" type: \"POST\",\r\n              url: \"/XLHSHoSoLuuKho/CapNhatFile\",\r\n             " +
" //  data: formDonDangKy_DSTAISAN.serialize(),\r\n              data: formdata,\r\n " +
"             success: function (data) {\r\n                  console.log(data);\r\n " +
"                 if (data == \"dacofile\") {\r\n                      alert(\"da co f" +
"ile\");\r\n                  }\r\n                  if (data == \"cantaomoihoso\") {\r\n " +
"                     alert(\"can tao moi ho so\");\r\n                  }\r\n         " +
"         else {\r\n                      var objfile = { \"THANHPHANHOSOID\": data.f" +
"ileid, \"STT\": tableDSFile.rows().nodes().length + 1, \"loaihoso\": data.loaifile, " +
"\"TENTEPDULIEU\": data.tenfile };\r\n                      console.log(objfile);\r\n  " +
"                    tableDSFile.row.add(objfile).draw();\r\n                  }\r\n\r" +
"\n              },\r\n          });\r\n      });\r\n      $(\'#btnDownLoad\').on(\'click\'," +
" function () {\r\n          $.ajax({\r\n              type: \"GET\",\r\n              ur" +
"l: \"/XLHSHoSoLuuKho/DownLoadFile\",\r\n              success: function (data) {\r\n  " +
"                $(\'#hiddenIframe\').attr(\'src\', \'http://localhost:51022/api/DownL" +
"oadFile?url=\' + $(\'#file_DUONGDAN\').val() + \'&token=\' + data);\r\n              }," +
"\r\n          });\r\n      });\r\n    });\r\n    function LamMoiFile() {\r\n        $(\'#fi" +
"le_THANHPHANHOSOID\').val(\"\");\r\n        $(\'#file_DUONGDAN\').val(\"\");\r\n        $(\'" +
"#file_TENTEPDULIEU\').val(\"\");\r\n        $(\'#file_GIAYTOKEMTHEOHSID\').val(\"\");\r\n  " +
"  }\r\n    function xoa() {\r\n        alert(\"xoa\");\r\n    }\r\n</script>");

        }
    }
}
#pragma warning restore 1591
