#pragma checksum "C:\Users\Brian Chong\Desktop\SP Year 3\CSC\Assignment 1\Task 6\Task 6\Views\Home\pauseResult.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "21b1365e192c67a6f061355f4b98c24f719f5914"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_pauseResult), @"mvc.1.0.view", @"/Views/Home/pauseResult.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/pauseResult.cshtml", typeof(AspNetCore.Views_Home_pauseResult))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\Brian Chong\Desktop\SP Year 3\CSC\Assignment 1\Task 6\Task 6\Views\_ViewImports.cshtml"
using Task_6;

#line default
#line hidden
#line 2 "C:\Users\Brian Chong\Desktop\SP Year 3\CSC\Assignment 1\Task 6\Task 6\Views\_ViewImports.cshtml"
using Task_6.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"21b1365e192c67a6f061355f4b98c24f719f5914", @"/Views/Home/pauseResult.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f72129f1f23687658569d646ebd943f77110f892", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_pauseResult : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 172, true);
            WriteLiteral("<div id=\"statusResult\"></div>\r\n<a href=\"https://localhost:44318/\">Back to home</a>\r\n\r\n<script>\r\n    var res = document.getElementById(\'statusResult\');\r\n    \r\n    var msg = ");
            EndContext();
            BeginContext(173, 15, false);
#line 7 "C:\Users\Brian Chong\Desktop\SP Year 3\CSC\Assignment 1\Task 6\Task 6\Views\Home\pauseResult.cshtml"
         Write(ViewBag.message);

#line default
#line hidden
            EndContext();
            BeginContext(188, 175, true);
            WriteLiteral(";\r\n    if (msg == \"Subscription paused\") {\r\n        res.textContent(\"Subscription paused\");\r\n    } else {\r\n        res.textContent(\"Subscription resumed\");\r\n    }\r\n</script>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
