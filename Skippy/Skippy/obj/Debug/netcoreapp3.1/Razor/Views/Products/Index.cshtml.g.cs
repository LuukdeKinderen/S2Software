#pragma checksum "C:\Users\Luukd\OneDrive\Documenten\Fontys\SS2\S2Software\Skippy\Skippy\Views\Products\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e2d2d3cbccddf7f563f6aa86c698ce45facaaa5f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Products_Index), @"mvc.1.0.view", @"/Views/Products/Index.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Luukd\OneDrive\Documenten\Fontys\SS2\S2Software\Skippy\Skippy\Views\_ViewImports.cshtml"
using Skippy;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Luukd\OneDrive\Documenten\Fontys\SS2\S2Software\Skippy\Skippy\Views\_ViewImports.cshtml"
using Skippy.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2d2d3cbccddf7f563f6aa86c698ce45facaaa5f", @"/Views/Products/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7e20f45e686beb70cd41067caad222e71754fb6f", @"/Views/_ViewImports.cshtml")]
    public class Views_Products_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Logic.Product>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<h1>Producten</h1>\r\n<ul>\r\n");
#nullable restore
#line 6 "C:\Users\Luukd\OneDrive\Documenten\Fontys\SS2\S2Software\Skippy\Skippy\Views\Products\Index.cshtml"
     foreach (Logic.Product product in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>");
#nullable restore
#line 8 "C:\Users\Luukd\OneDrive\Documenten\Fontys\SS2\S2Software\Skippy\Skippy\Views\Products\Index.cshtml"
       Write(Html.ActionLink(product.titel, "Product", new { id = product.id}));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </li>\r\n");
#nullable restore
#line 9 "C:\Users\Luukd\OneDrive\Documenten\Fontys\SS2\S2Software\Skippy\Skippy\Views\Products\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>\r\n<div>\r\n    \r\n    ");
#nullable restore
#line 13 "C:\Users\Luukd\OneDrive\Documenten\Fontys\SS2\S2Software\Skippy\Skippy\Views\Products\Index.cshtml"
Write(Html.ActionLink("Toevoegen", "Create"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Logic.Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591
