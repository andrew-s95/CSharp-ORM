#pragma checksum "/Users/andrew627/Desktop/C#/ORM/WeddingPlanner/Views/Home/WeddingInfoPage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fb74a1009a70532314e4f789cb48019e862b9006"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_WeddingInfoPage), @"mvc.1.0.view", @"/Views/Home/WeddingInfoPage.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/WeddingInfoPage.cshtml", typeof(AspNetCore.Views_Home_WeddingInfoPage))]
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
#line 1 "/Users/andrew627/Desktop/C#/ORM/WeddingPlanner/Views/_ViewImports.cshtml"
using WeddingPlanner;

#line default
#line hidden
#line 2 "/Users/andrew627/Desktop/C#/ORM/WeddingPlanner/Views/_ViewImports.cshtml"
using WeddingPlanner.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fb74a1009a70532314e4f789cb48019e862b9006", @"/Views/Home/WeddingInfoPage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e9e38482b8beecdb199b7be73dfa5c3d6a2f574", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_WeddingInfoPage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Wedding>
    {
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(15, 33, true);
            WriteLiteral("<!DOCTYPE html>\n<html lang=\"en\">\n");
            EndContext();
            BeginContext(48, 206, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fb74a1009a70532314e4f789cb48019e862b90063350", async() => {
                BeginContext(54, 193, true);
                WriteLiteral("\n    <meta charset=\"UTF-8\">\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\n    <meta http-equiv=\"X-UA-Compatible\" content=\"ie=edge\">\n    <title>Wedding Info</title>\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(254, 1, true);
            WriteLiteral("\n");
            EndContext();
            BeginContext(255, 431, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fb74a1009a70532314e4f789cb48019e862b90064714", async() => {
                BeginContext(261, 9, true);
                WriteLiteral("\n    <h1>");
                EndContext();
                BeginContext(271, 15, false);
#line 11 "/Users/andrew627/Desktop/C#/ORM/WeddingPlanner/Views/Home/WeddingInfoPage.cshtml"
   Write(Model.WedderOne);

#line default
#line hidden
                EndContext();
                BeginContext(286, 3, true);
                WriteLiteral(" & ");
                EndContext();
                BeginContext(290, 15, false);
#line 11 "/Users/andrew627/Desktop/C#/ORM/WeddingPlanner/Views/Home/WeddingInfoPage.cshtml"
                      Write(Model.WedderTwo);

#line default
#line hidden
                EndContext();
                BeginContext(305, 149, true);
                WriteLiteral("\'s Wedding</h1><br>\n    <a href=\"dashboard\" class=\"btn btn-primary\">Dashboard</a> <a href=\"/logout\" class=\"btn btn-danger\">Log Out</a>\n    <h3>Date: ");
                EndContext();
                BeginContext(455, 42, false);
#line 13 "/Users/andrew627/Desktop/C#/ORM/WeddingPlanner/Views/Home/WeddingInfoPage.cshtml"
         Write(Model.Date.ToString("dddd, dd MMMM yyyy "));

#line default
#line hidden
                EndContext();
                BeginContext(497, 40, true);
                WriteLiteral("</h3><br>\n    <h4>Guests:</h4>\n    <ul>\n");
                EndContext();
#line 16 "/Users/andrew627/Desktop/C#/ORM/WeddingPlanner/Views/Home/WeddingInfoPage.cshtml"
         foreach (var ass in @Model.Associations)
        {

#line default
#line hidden
                BeginContext(597, 16, true);
                WriteLiteral("            <li>");
                EndContext();
                BeginContext(614, 19, false);
#line 18 "/Users/andrew627/Desktop/C#/ORM/WeddingPlanner/Views/Home/WeddingInfoPage.cshtml"
           Write(ass.Guest.FirstName);

#line default
#line hidden
                EndContext();
                BeginContext(633, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(635, 18, false);
#line 18 "/Users/andrew627/Desktop/C#/ORM/WeddingPlanner/Views/Home/WeddingInfoPage.cshtml"
                                Write(ass.Guest.LastName);

#line default
#line hidden
                EndContext();
                BeginContext(653, 6, true);
                WriteLiteral("</li>\n");
                EndContext();
#line 19 "/Users/andrew627/Desktop/C#/ORM/WeddingPlanner/Views/Home/WeddingInfoPage.cshtml"
        }

#line default
#line hidden
                BeginContext(669, 10, true);
                WriteLiteral("    </ul>\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(686, 9, true);
            WriteLiteral("\n</html>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Wedding> Html { get; private set; }
    }
}
#pragma warning restore 1591
