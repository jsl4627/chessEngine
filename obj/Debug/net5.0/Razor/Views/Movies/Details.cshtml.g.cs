#pragma checksum "/Users/jaredantner/Desktop/chessEngine/Views/Movies/Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5b0d405cbff8dc74e279c64103d66a410453f711"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movies_Details), @"mvc.1.0.view", @"/Views/Movies/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5b0d405cbff8dc74e279c64103d66a410453f711", @"/Views/Movies/Details.cshtml")]
    public class Views_Movies_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MvcMovie.Models.Movie>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "/Users/jaredantner/Desktop/chessEngine/Views/Movies/Details.cshtml"
   
	ViewData["Title"] = "Details"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h1>Details</h1> \n\n<div> \n\t<h4>Movie</h4> \n\t<hr /> \n\t<dl class=\"row\"> \n\t\t<dt class=\"col-sm-2\"> \n\t\t\t");
#nullable restore
#line 14 "/Users/jaredantner/Desktop/chessEngine/Views/Movies/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral(" \n\t\t</dt> \n\t\t<dd class=\"col-sm-10\"> \n\t\t\t");
#nullable restore
#line 17 "/Users/jaredantner/Desktop/chessEngine/Views/Movies/Details.cshtml"
       Write(Html.DisplayFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral(" \n\t\t</dd> \n\t\t<dt class=\"col-sm-2\"> \n\t\t\t");
#nullable restore
#line 20 "/Users/jaredantner/Desktop/chessEngine/Views/Movies/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ReleaseDate));

#line default
#line hidden
#nullable disable
            WriteLiteral(" \n\t\t</dt> \n\t\t<dd class = \"col-sm-10\"> \n\t\t\t");
#nullable restore
#line 23 "/Users/jaredantner/Desktop/chessEngine/Views/Movies/Details.cshtml"
       Write(Html.DisplayFor(model => model.ReleaseDate));

#line default
#line hidden
#nullable disable
            WriteLiteral(" \n\t\t</dd> \n\t\t<dt class=\"col-sm-2\"> \n\t\t\t");
#nullable restore
#line 26 "/Users/jaredantner/Desktop/chessEngine/Views/Movies/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Genre));

#line default
#line hidden
#nullable disable
            WriteLiteral(" \n\t\t</dt> \n\t\t<dd class=\"col-sm-10\"> \n\t\t\t");
#nullable restore
#line 29 "/Users/jaredantner/Desktop/chessEngine/Views/Movies/Details.cshtml"
       Write(Html.DisplayFor(model => model.Genre));

#line default
#line hidden
#nullable disable
            WriteLiteral(" \n\t\t</dd> \n\t\t<dt class=\"col-sm-2\"> \n\t\t\t");
#nullable restore
#line 32 "/Users/jaredantner/Desktop/chessEngine/Views/Movies/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral(" \n\t\t</dt> \n\t\t<dd class=\"col-sm-10\"> \n\t\t\t");
#nullable restore
#line 35 "/Users/jaredantner/Desktop/chessEngine/Views/Movies/Details.cshtml"
       Write(Html.DisplayFor(model => model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral(" \n\t\t</dd> \n\t</dl> \n</div> \n<div> \n\t<a asp-action=\"Edit\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 837, "\"", 861, 1);
#nullable restore
#line 40 "/Users/jaredantner/Desktop/chessEngine/Views/Movies/Details.cshtml"
WriteAttributeValue("", 852, Model.Id, 852, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a> | \n\t<a asp-actions=\"Index\">Back to List</a> \n</div> \n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MvcMovie.Models.Movie> Html { get; private set; }
    }
}
#pragma warning restore 1591
