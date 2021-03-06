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
    using MPLIS.Modeles.QuanTriQuyTrinh;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/DiagramWorkflow/DesignDiagram.cshtml")]
    public partial class _Views_DiagramWorkflow_DesignDiagram_cshtml : System.Web.Mvc.WebViewPage<AppCore.Models.QT_QUYTRINH>
    {
        public _Views_DiagramWorkflow_DesignDiagram_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\DiagramWorkflow\DesignDiagram.cshtml"
  
    var strXML = "";
    if (Model != null)
    {
        strXML = Model.XML;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 140), Tuple.Create("\"", 187)
, Tuple.Create(Tuple.Create("", 146), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/bpmn-js/dist/bpmn-viewer.min.js")
, 146), false)
);

WriteLiteral("></script>\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 205), Tuple.Create("\"", 256)
, Tuple.Create(Tuple.Create("", 212), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/bpmn-js/dist/assets/diagram-js.css")
, 212), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 284), Tuple.Create("\"", 343)
, Tuple.Create(Tuple.Create("", 291), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/bpmn-js/dist/assets/bpmn-font/css/bpmn.css")
, 291), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 373), Tuple.Create("\"", 421)
, Tuple.Create(Tuple.Create("", 379), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/bpmn-js/dist/bpmn-modeler.min.js")
, 379), false)
);

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 441), Tuple.Create("\"", 470)
, Tuple.Create(Tuple.Create("", 447), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/jquery.min.js")
, 447), false)
);

WriteLiteral("></script>\r\n\r\n<h2>Thiết kế quy trình: ");

            
            #line 16 "..\..\Views\DiagramWorkflow\DesignDiagram.cshtml"
                   Write(Model.TENQUYTRINH);

            
            #line default
            #line hidden
WriteLiteral("</h2>\r\n\r\n<div");

WriteLiteral(" id=\"qlqt_canvas\"");

WriteLiteral("></div>\r\n\r\n<script>\r\n    var BpmnViewer = window.BpmnJS;\r\n    var bpmnViewer = ne" +
"w BpmnViewer({\r\n        container: \'#qlqt_canvas\',\r\n        width: \'100%\',\r\n    " +
"    height: \'100%\'\r\n    });\r\n    $(document).ready(function () {\r\n        var di" +
"agramXML = \'");

            
            #line 28 "..\..\Views\DiagramWorkflow\DesignDiagram.cshtml"
                     Write(Html.Raw(strXML));

            
            #line default
            #line hidden
WriteLiteral("\';\r\n        diagramXML = decodeURI(diagramXML);\r\n        if (diagramXML == \"\")\r\n " +
"           diagramXML = \"<?xml version=\'1.0\' encoding=\'UTF-8\'?>\" +\r\n            " +
"\"<definitions xmlns=\'http://www.omg.org/spec/BPMN/20100524/MODEL\' xmlns:bpmndi=\'" +
"http://www.omg.org/spec/BPMN/20100524/DI\' xmlns:omgdc=\'http://www.omg.org/spec/D" +
"D/20100524/DC\' xmlns:xsi=\'http://www.w3.org/2001/XMLSchema-instance\' targetNames" +
"pace=\'\' xsi:schemaLocation=\'http://www.omg.org/spec/BPMN/20100524/MODEL http://w" +
"ww.omg.org/spec/BPMN/2.0/20100501/BPMN20.xsd\'>\" +\r\n            \" <process id=\'Pr" +
"ocess_1w8xey7\' />\" +\r\n            \"<bpmndi:BPMNDiagram id=\'sid-74620812-92c4-44e" +
"5-949c-aa47393d3830\'>\" +\r\n                \"<bpmndi:BPMNPlane id=\'sid-cdcae759-2a" +
"f7-4a6d-bd02-53f3352a731d\' bpmnElement=\'Process_1w8xey7\' />\" +\r\n                " +
"\"<bpmndi:BPMNLabelStyle id=\'sid-e0502d32-f8d1-41cf-9c4a-cbb49fecf581\'>\" +\r\n     " +
"            \"<omgdc:Font name=\'Arial\' size=\'11\' isBold=\'false\' isItalic=\'false\' " +
"isUnderline=\'false\' isStrikeThrough=\'false\' />\" +\r\n                \"</bpmndi:BPM" +
"NLabelStyle>\" +\r\n                \"<bpmndi:BPMNLabelStyle id=\'sid-84cb49fd-2f7c-4" +
"4fb-8950-83c3fa153d3b\'>\" +\r\n                  \"<omgdc:Font name=\'Arial\' size=\'12" +
"\' isBold=\'false\' isItalic=\'false\' isUnderline=\'false\' isStrikeThrough=\'false\' />" +
"\" +\r\n                \"</bpmndi:BPMNLabelStyle>\" +\r\n              \"</bpmndi:BPMND" +
"iagram>\" +\r\n            \"</definitions>\";\r\n        bpmnViewer.importXML(diagramX" +
"ML, function (err) {\r\n            if (err) {\r\n                return console.err" +
"or(\'could not import BPMN 2.0 diagram\', err);\r\n            }\r\n            else {" +
"\r\n                bpmnViewer.get(\'canvas\').zoom(\'fit-viewport\');\r\n            }\r" +
"\n        });\r\n    });\r\n\r\n\r\n\r\n    function PutXML() {\r\n        bpmnViewer.saveXML" +
"({ format: true }, function (err, xml) {\r\n\r\n            if (err) {\r\n            " +
"    console.error(\'diagram save failed\', err);\r\n            } else {\r\n          " +
"      $(\"#txtXML\").val(encodeURI(xml));\r\n                bpmnViewer.saveSVG({ fo" +
"rmat: true }, function (err, svg) {\r\n                    if (err) {\r\n           " +
"             console.error(\'diagram save failed\', err);\r\n                       " +
" return false;\r\n                    } else {\r\n                        $(\"#txtSVG" +
"\").val(encodeURI(svg));\r\n                        $(\"#frmEditDiagram\").submit();\r" +
"\n                        return true;\r\n                    }\r\n\r\n                " +
"});\r\n\r\n            }\r\n\r\n        });\r\n\r\n    }\r\n    function ZoomAll() {\r\n        " +
"if (bpmnViewer) {\r\n            bpmnViewer.get(\'canvas\').zoom(\'fit-viewport\');\r\n " +
"       }\r\n    }\r\n    function CreateFileDownload() {\r\n        bpmnViewer.saveXML" +
"({ format: true }, function (err, xml) {\r\n            if (err) {\r\n              " +
"  console.error(\'diagram save failed\', err);\r\n            } else {\r\n\r\n          " +
"      $(\"#btnDownloadXml\").attr(\"href\", \"data:application/bpmn20-xml;charset=UTF" +
"-8,\" + encodeURI(xml));\r\n\r\n            }\r\n        });\r\n    }\r\n</script>");

        }
    }
}
#pragma warning restore 1591
