#pragma checksum "C:\Users\Brian Chong\Desktop\SP Year 3\CSC\Assignment 1\Task 6\Task 6\Views\Home\SubscribeResult.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0a07999151c5e875cf18b5803fffff711da14ca7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_SubscribeResult), @"mvc.1.0.view", @"/Views/Home/SubscribeResult.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/SubscribeResult.cshtml", typeof(AspNetCore.Views_Home_SubscribeResult))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a07999151c5e875cf18b5803fffff711da14ca7", @"/Views/Home/SubscribeResult.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f72129f1f23687658569d646ebd943f77110f892", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_SubscribeResult : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 166, true);
            WriteLiteral("<div id=\"result\"></div>\r\n<a href=\"https://localhost:44318/\">Back to home</a>\r\n<script src=\"https://js.stripe.com/v3/\"></script>\r\n\r\n<script>\r\n    const subscription = ");
            EndContext();
            BeginContext(167, 30, false);
#line 6 "C:\Users\Brian Chong\Desktop\SP Year 3\CSC\Assignment 1\Task 6\Task 6\Views\Home\SubscribeResult.cshtml"
                    Write(Html.Raw(ViewBag.subscription));

#line default
#line hidden
            EndContext();
            BeginContext(197, 317, true);
            WriteLiteral(@";
    const { latest_invoice } = subscription;
    const { payment_intent } = latest_invoice;

    var res = document.getElementById('result');

    if (payment_intent) {
        const { client_secret, status } = payment_intent;

        if (status === 'requires_action') {
            var stripe = Stripe('");
            EndContext();
            BeginContext(515, 17, false);
#line 16 "C:\Users\Brian Chong\Desktop\SP Year 3\CSC\Assignment 1\Task 6\Task 6\Views\Home\SubscribeResult.cshtml"
                            Write(ViewBag.stripeKey);

#line default
#line hidden
            EndContext();
            BeginContext(532, 780, true);
            WriteLiteral(@"');

            stripe.confirmCardPayment(client_secret).then(function(result) {
                if (result.error) {
                    // Display error message in your UI.
                    // The card was declined (i.e. insufficient funds, card has expired, etc)
                    res.textContent = result.error.message;
                } else {
                    // Show a success message to your customer
                    res.textContent = ""Your subscription was successfully authenticated""
                }
            });
        } else {
            // No additional information was needed
            // Show a success message to your customer
            res.textContent = ""Your subscription was successfully setup""
        }
    }
</script>");
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
