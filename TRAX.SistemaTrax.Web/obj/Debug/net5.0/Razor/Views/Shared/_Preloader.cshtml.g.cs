#pragma checksum "C:\Users\ivan.tapia\source\repos\TRAX.SistemaTrax.Web\TRAX.SistemaTrax.Web\Views\Shared\_Preloader.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "26da543afb4a507fc031421c6b698c5e67beb7e7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Preloader), @"mvc.1.0.view", @"/Views/Shared/_Preloader.cshtml")]
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
#line 1 "C:\Users\ivan.tapia\source\repos\TRAX.SistemaTrax.Web\TRAX.SistemaTrax.Web\Views\_ViewImports.cshtml"
using TRAX.SistemaTrax.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ivan.tapia\source\repos\TRAX.SistemaTrax.Web\TRAX.SistemaTrax.Web\Views\_ViewImports.cshtml"
using TRAX.SistemaTrax.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"26da543afb4a507fc031421c6b698c5e67beb7e7", @"/Views/Shared/_Preloader.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0875bff876993da04845c0fd7ce2f0bca823fbe5", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Preloader : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<style>
    .loader-page {
    position: fixed;
    z-index: 25000;
    background: rgb(91, 87, 86 );
    left: 0px;
    top: 0px;
    height: 100%;
    width: 100%;
    display: flex;
    align-items: center;
    justify-content: center;
    transition:all .3s ease;
  }
  .loader-page::before {
    content: """";
    position: absolute;
    border: 2px solid rgb(50, 150, 176);
    width: 150px;
    height: 150px;
    border-radius: 50%;
    box-sizing: border-box;
    border-left: 2px solid rgba(50, 150, 176,0);
    border-top: 2px solid rgba(50, 150, 176,0);
    animation: rotarload 1s linear infinite;
    transform: rotate(0deg);
  }
  ");
            WriteLiteral(@"@keyframes rotarload {
      0%   {transform: rotate(0deg)}
      100% {transform: rotate(360deg)}
  }
  .loader-page::after {
    content: """";
    position: absolute;
    border: 2px solid rgba(50, 150, 176,.5);
    width: 150px;
    height: 150px;
    border-radius: 50%;
    box-sizing: border-box;
    border-left: 2px solid rgba(50, 150, 176, 0);
    border-top: 2px solid rgba(50, 150, 176, 0);
    animation: rotarload 1s ease-out infinite;
    transform: rotate(0deg);
  }
</style>
<div class=""loader-page""></div>



");
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
