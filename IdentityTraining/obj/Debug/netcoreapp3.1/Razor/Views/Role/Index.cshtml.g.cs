#pragma checksum "C:\Users\Blackerback\OneDrive\Masaüstü\Identity\IdentityTraining\IdentityTraining\Views\Role\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dc7384384ebadeccbb9d4446f3bc90335ca66da4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Role_Index), @"mvc.1.0.view", @"/Views/Role/Index.cshtml")]
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
#line 2 "C:\Users\Blackerback\OneDrive\Masaüstü\Identity\IdentityTraining\IdentityTraining\Views\_ViewImports.cshtml"
using IdentityTraining.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Blackerback\OneDrive\Masaüstü\Identity\IdentityTraining\IdentityTraining\Views\_ViewImports.cshtml"
using IdentityTraining.Context;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dc7384384ebadeccbb9d4446f3bc90335ca66da4", @"/Views/Role/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c37d4e51c227c552c4c7debc333be4741fdd8d7", @"/Views/_ViewImports.cshtml")]
    public class Views_Role_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AppRole>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Blackerback\OneDrive\Masaüstü\Identity\IdentityTraining\IdentityTraining\Views\Role\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <table class=\"table table-sm table-hover\">\r\n        <tr>\r\n            <td>Id</td>\r\n            <td>Ad</td>\r\n        </tr>\r\n");
#nullable restore
#line 12 "C:\Users\Blackerback\OneDrive\Masaüstü\Identity\IdentityTraining\IdentityTraining\Views\Role\Index.cshtml"
         if (Model.Count() > 0)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\Blackerback\OneDrive\Masaüstü\Identity\IdentityTraining\IdentityTraining\Views\Role\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 17 "C:\Users\Blackerback\OneDrive\Masaüstü\Identity\IdentityTraining\IdentityTraining\Views\Role\Index.cshtml"
                   Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 18 "C:\Users\Blackerback\OneDrive\Masaüstü\Identity\IdentityTraining\IdentityTraining\Views\Role\Index.cshtml"
                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 20 "C:\Users\Blackerback\OneDrive\Masaüstü\Identity\IdentityTraining\IdentityTraining\Views\Role\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\Blackerback\OneDrive\Masaüstü\Identity\IdentityTraining\IdentityTraining\Views\Role\Index.cshtml"
             
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td colspan=\"2\">Role bulunmuyor</td>\r\n            </tr>\r\n");
#nullable restore
#line 27 "C:\Users\Blackerback\OneDrive\Masaüstü\Identity\IdentityTraining\IdentityTraining\Views\Role\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AppRole>> Html { get; private set; }
    }
}
#pragma warning restore 1591
