#pragma checksum "/Users/jaredantner/Desktop/chessEngine/Views/Chess/Chess.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "61003c6fcab4f2c4f0cb8230d21ea40624477974"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Chess_Chess), @"mvc.1.0.view", @"/Views/Chess/Chess.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"61003c6fcab4f2c4f0cb8230d21ea40624477974", @"/Views/Chess/Chess.cshtml")]
    public class Views_Chess_Chess : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MvcChess.Models.Board>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
            WriteLiteral(" \n\n");
#nullable restore
#line 4 "/Users/jaredantner/Desktop/chessEngine/Views/Chess/Chess.cshtml"
  
	ViewData["Title"] = "Details";  

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "61003c6fcab4f2c4f0cb8230d21ea406244779742851", async() => {
                WriteLiteral(@" 
	<meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8""></meta> 
	<title>Come and get me!</title>
	<src=""https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js""></script>  
	<link rel=""stylesheet"" href=""../../wwwroot/css/Chess.css"" /> 
");
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
            WriteLiteral(@"
<style> 
	div.game-board { 
		border-style: solid; 
	}
	
	table#game-board{ 
		border-style: solid; 
	} 
	fieldset#game-toolbar button { 
		padding: 9px; 
		margin-right: 0.25em; 
		font-size: larger; 
		cursor: pointer; 
		background-color: #CAECFF; 
		border-color: #6ECCFF; 
		border-radius: 7px; 
	}  
</style>  
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "61003c6fcab4f2c4f0cb8230d21ea406244779744385", async() => {
                WriteLiteral("\n<div class=\"page\"> \n\t<h1>Come and get me!</h1> \n\t<div class=\"body\">  \n\t<div class=\"game-board\">\n \n\t\t<table>   \n");
#nullable restore
#line 40 "/Users/jaredantner/Desktop/chessEngine/Views/Chess/Chess.cshtml"
             for(var i = 0; i < 8; i++){ 

#line default
#line hidden
#nullable disable
                WriteLiteral("\t\t\t\t<tr>\n");
#nullable restore
#line 42 "/Users/jaredantner/Desktop/chessEngine/Views/Chess/Chess.cshtml"
                     for(var j = 0; j < 8; j++){ 

#line default
#line hidden
#nullable disable
                WriteLiteral("\t\t\t\t\t\t<td data-celli=\"${j}\" class=\"Space\"> \n\t\t\t\t\t\t\t\n");
#nullable restore
#line 45 "/Users/jaredantner/Desktop/chessEngine/Views/Chess/Chess.cshtml"
                             if(Model.board[i, j] != null){ 
								

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "/Users/jaredantner/Desktop/chessEngine/Views/Chess/Chess.cshtml"
                                 if(Model.board[i, j].white == true){

#line default
#line hidden
#nullable disable
                WriteLiteral("\t\t\t\t\t\t\t\t\t<div class = \"Piece\" \n\t\t\t\t\t\t\t\t\t\tid=\"piece-${i}-{j}\" \n\t\t\t\t\t\t\t\t\t\tdata-type=\'${Model.board[i, j].label}\' \n\t\t\t\t\t\t\t\t\t\tdata-color=\'White\'> \n\t\t\t\t\t\t\t\t\t</div> \n");
#nullable restore
#line 52 "/Users/jaredantner/Desktop/chessEngine/Views/Chess/Chess.cshtml"
									 
								} 
								else{ 

#line default
#line hidden
#nullable disable
                WriteLiteral("\t\t\t\t\t\t\t\t\t<div class=\"Piece\" \n\t\t\t\t\t\t\t\t\t\tid=\"piece-${i}-${j}\" \n\t\t\t\t\t\t\t\t\t\tdata-type=\'${");
#nullable restore
#line 57 "/Users/jaredantner/Desktop/chessEngine/Views/Chess/Chess.cshtml"
                                                Write(Model.board[i, j].label);

#line default
#line hidden
#nullable disable
                WriteLiteral("}\' \n\t\t\t\t\t\t\t\t\t\tdata-color = \'Black\'> \n\t\t\t\t\t\t\t\t\t</div> \n");
#nullable restore
#line 60 "/Users/jaredantner/Desktop/chessEngine/Views/Chess/Chess.cshtml"
								}

#line default
#line hidden
#nullable disable
#nullable restore
#line 60 "/Users/jaredantner/Desktop/chessEngine/Views/Chess/Chess.cshtml"
                                 
							} 

#line default
#line hidden
#nullable disable
                WriteLiteral("\t\t\t\t\t\t</td> \n");
#nullable restore
#line 63 "/Users/jaredantner/Desktop/chessEngine/Views/Chess/Chess.cshtml"
					} 

#line default
#line hidden
#nullable disable
                WriteLiteral("\t\t\t\t</tr> \n");
#nullable restore
#line 65 "/Users/jaredantner/Desktop/chessEngine/Views/Chess/Chess.cshtml"
			}

#line default
#line hidden
#nullable disable
                WriteLiteral("\t\t</table>  \n\n\n\t\t\t \n\t</div> \t\n\t\n\t<audio id = \"audio\" src=\"http://www.soundjay.com/button/beep-07.mp3\" autostart=\"false\"></audio> \n\t<script data-main=\"/js/index.js\" src=\"/js/require.js\"></script> \n\t\n\t \n");
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
            WriteLiteral(" \n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MvcChess.Models.Board> Html { get; private set; }
    }
}
#pragma warning restore 1591