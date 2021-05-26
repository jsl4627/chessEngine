#pragma checksum "/Users/jaredantner/Desktop/chessEngine/Views/Chess/Board.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b7a0332a3abd4045bd42ba472b55da839fcd6372"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Chess_Board), @"mvc.1.0.view", @"/Views/Chess/Board.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b7a0332a3abd4045bd42ba472b55da839fcd6372", @"/Views/Chess/Board.cshtml")]
    public class Views_Chess_Board : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MvcChess.Models.Board>
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
            WriteLiteral("\n");
#nullable restore
#line 3 "/Users/jaredantner/Desktop/chessEngine/Views/Chess/Board.cshtml"
  
	ViewData["Title"] = "Details";  

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b7a0332a3abd4045bd42ba472b55da839fcd63722848", async() => {
                WriteLiteral(" \n\t<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\"></meta> \n\t<title>Come and get me!</title>\n\t<src=\"https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js\"></script>  \n");
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
		clear: both; 
		width: 100%; 
		text-align: center; 
	} 


	table#game-board { 
		width: 690px; 
		height: 690px; 
		border-collapse: collapse; 
		background-image: url(""/img/chess_board.svg""); 
	}  

	table#game-board td > div{ 
		width: 85px; 
		height: 85px; 
		background-repeat: no-repeat; 
		background-size: contain; 
	} 

	table#game-board tr td div[data-type=""P""][data-color=""White""] { 
		background-image: url(""/img/white_pawn.svg""); 
	} 
	div[data-type='R'][data-color='White'] { 
		border-style: solid; 
	}


	div[data-type='N'][data-color='White'] { 
		border-style: solid; 
	} 


	div[data-type='B'][data-color='White'] { 
		border-style: solid; 
	} 

 
	div[data-type='Q'][data-color='White'] { 
		border-style: solid; 
	} 



	div[data-type='K'][data-color='White'] { 
		border-style: solid; 
	}
 
	div[data-type='P'][data-color='Black'] { 
		border-style: solid; 
	} 
	
	div[data-type='R'][data-color='Black'] { 
		border-style: solid; 
	} 
	
	div[data-type='N'][data-color='B");
            WriteLiteral(@"lack'] { 
		background-image: url(""/img/black_knight.svg""); 
		border-style: solid; 
	} 
	
	div[data-type='B'][data-color='Black'] { 
		border-style: solid; 
	} 
	
	div[data-type='Q'][data-color='Black'] { 
		border-style: solid; 
	} 
	div[data-type='K'][data-color='Black'] { 
		border-style: solid; 
	} 

	table#game-board td { 
		background-color: rgba(0, 255, 0, 0.4); 
	}
</style>

<style> 
	body{ 
		background: #CAECFF;  
		font-family: 'Trebuchet MS', sans-serif; 
	 	font-size: 14px; 
	} 

	a { 
		color: #2677FF; 
	} 
	
	a:hover { 
		color: #333; 
	} 
	a[disabled] { 
		color: gray; 
		cursor: default; 
	} 

	div.INFO { 
		margin: 10px 0; 
		background: #CAECFF; 
		filter: brightness(115%); 
		border: 1px solid #6ECCFF; 
		-moz-border-radius: 2px; 
		-webkit-border-radius: 2px; 
		padding: 4px; 
		font-size: 13px; 
	} 
	.flex-container { 
		display: flex; 
		flex-flow: row wrap; 
	}  
</style>
<style> 
	div[id=""test""] > button{ 
		height = 85px; 
		width: 85px;  
	}
	table#game-board td > div[data-type='.'");
            WriteLiteral(@"] > button { 
		height: 85px; 
		width: 85px; 
	}  
	table#game-board td > div[data-type='P'][data-color='White'] > button{
		height: 85px; 
		width: 85px;  
		background-repeat: no-repeat; 
		background-size: contain; 
		background-image: url(""/img/white_pawn.svg""); 
		background-color: 'red';  
	}

	  
	table#game-board td > div[data-type='R'][data-color='White'] > button{
		height: 85px; 
		width: 85px;  
		background-repeat: no-repeat; 
		background-size: contain; 
		background-image: url(""/img/white_rook.svg""); 
	}  

	table#game-board td > div[data-type='N'][data-color='White'] > button{
		height: 85px; 
		width: 85px;  
		background-repeat: no-repeat; 
		background-size: contain; 
		background-image: url(""/img/white_knight.svg""); 
	}
	  
	table#game-board td > div[data-type='B'][data-color='White'] > button{
		height: 85px; 
		width: 85px;  
		background-repeat: no-repeat; 
		background-size: contain; 
		background-image: url(""/img/white_bishop.svg""); 
	}  
	
	table#game-board td > div[data-type='Q'][d");
            WriteLiteral(@"ata-color='White'] > button{
		height: 85px; 
		width: 85px;  
		background-repeat: no-repeat; 
		background-size: contain; 
		background-image: url(""/img/white_queen.svg""); 
	} 
	 
	table#game-board td > div[data-type='K'][data-color='White'] > button{
		height: 85px; 
		width: 85px;  
		background-repeat: no-repeat; 
		background-size: contain; 
		background-image: url(""/img/white_king.svg""); 
	} 

	 
	table#game-board td > div[data-type='P'][data-color='Black'] > button{
		height: 85px; 
		width: 85px;  
		background-repeat: no-repeat; 
		background-size: contain; 
		background-image: url(""/img/black_pawn.svg""); 
	}

	  
	table#game-board td > div[data-type='R'][data-color='Black'] > button{
		height: 85px; 
		width: 85px;  
		background-repeat: no-repeat; 
		background-size: contain; 
		background-image: url(""/img/black_rook.svg""); 
	}  

	table#game-board td > div[data-type='N'][data-color='Black'] > button{
		height: 85px; 
		width: 85px;  
		background-repeat: no-repeat; 
		background-size: contain; 
	");
            WriteLiteral(@"	background-image: url(""/img/black_knight.svg""); 
	}
	  
	table#game-board td > div[data-type='B'][data-color='Black'] > button{
		height: 85px; 
		width: 85px;  
		background-repeat: no-repeat; 
		background-size: contain; 
		background-image: url(""/img/black_bishop.svg""); 
	}  
	
	table#game-board td > div[data-type='Q'][data-color='Black'] > button{
		height: 85px; 
		width: 85px;  
		background-repeat: no-repeat; 
		background-size: contain; 
		background-image: url(""/img/black_queen.svg""); 
	} 
	 
	table#game-board td > div[data-type='K'][data-color='Black'] > button{
		height: 85px; 
		width: 85px;  
		background-repeat: no-repeat; 
		background-size: contain; 
		background-image: url(""/img/black_king.svg""); 
	}  
</style> 
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b7a0332a3abd4045bd42ba472b55da839fcd63728999", async() => {
                WriteLiteral(@"

<div class=""page""> 
	<h1>Come and get me!</h1>
	<div id=""test""> 
		<button></button> 
	</div> 
	<div class=""body""> 
	<div id=""game-controls""> 
		<fieldset id=""game-info""> 
			<legend>Info</legend> 

			<div> 
				<table data-color = 'White'> 
					<tr> 
						<td><img src=""/img/white_pawn.svg""/></td> 
						<td class=""name"">White</td>  
					</tr> 
				</table> 
				<table data-color = 'Black'> 
					<tr> 
						<td><img src=""/img/black_pawn.svg""/></td> 
						<td class=""name"">Black</td> 
					</tr> 
				</table> 
			</div> 
		</fieldset> 

		<fieldset id = ""game-toolbar""> 
			<legend>Controls</legend> 
			<div class=""toolbar""></div> 
		</fieldset> 
	</div> 
								
	<div class=""game-board"">
		<table id=""game-board"">   
");
#nullable restore
#line 271 "/Users/jaredantner/Desktop/chessEngine/Views/Chess/Board.cshtml"
             for(var i = 0; i < 8; i++){ 

#line default
#line hidden
#nullable disable
                WriteLiteral("\t\t\t\t<tr>\n");
#nullable restore
#line 273 "/Users/jaredantner/Desktop/chessEngine/Views/Chess/Board.cshtml"
                     for(var j = 0; j < 8; j++){ 

#line default
#line hidden
#nullable disable
                WriteLiteral("\t\t\t\t\t\t<td class = \"Space\">\t\n");
#nullable restore
#line 275 "/Users/jaredantner/Desktop/chessEngine/Views/Chess/Board.cshtml"
                             if(Model.board[i, j] != null){ 
								

#line default
#line hidden
#nullable disable
#nullable restore
#line 276 "/Users/jaredantner/Desktop/chessEngine/Views/Chess/Board.cshtml"
                                 if(Model.board[i, j].white == true){

#line default
#line hidden
#nullable disable
                WriteLiteral("\t\t\t\t\t\t\t\t\t<div class = \"Piece\" \n\t\t\t\t\t\t\t\t\t\tid=\"piece-${i}-{j}\" \n\t\t\t\t\t\t\t\t\t\tdata-type = ");
#nullable restore
#line 279 "/Users/jaredantner/Desktop/chessEngine/Views/Chess/Board.cshtml"
                                               Write(Model.board[i, j].label);

#line default
#line hidden
#nullable disable
                WriteLiteral("    \n\t\t\t\t\t\t\t\t\t\tdata-color=\"White\"> \n\t\t\t\t\t\t\t\t\t\t<button> </button> \n\t\t\t\t\t\t\t\t\t</div> \n");
#nullable restore
#line 283 "/Users/jaredantner/Desktop/chessEngine/Views/Chess/Board.cshtml"
									 
								} 
								else{ 

#line default
#line hidden
#nullable disable
                WriteLiteral("\t\t\t\t\t\t\t\t\t<div class=\"Piece\" \n\t\t\t\t\t\t\t\t\t\tid=\"piece-${i}-${j}\" \n\t\t\t\t\t\t\t\t\t\tdata-type= ");
#nullable restore
#line 288 "/Users/jaredantner/Desktop/chessEngine/Views/Chess/Board.cshtml"
                                              Write(Model.board[i, j].label);

#line default
#line hidden
#nullable disable
                WriteLiteral("  \n\n\t\t\t\t\t\t\t\t\t\tdata-color = \"Black\">\n\t\t\t\t\t\t\t\t\t\t<button> </button>  \n\t\t\t\t\t\t\t\t\t</div> \n");
#nullable restore
#line 293 "/Users/jaredantner/Desktop/chessEngine/Views/Chess/Board.cshtml"
								}

#line default
#line hidden
#nullable disable
#nullable restore
#line 293 "/Users/jaredantner/Desktop/chessEngine/Views/Chess/Board.cshtml"
                                 
							}
							else{ 

#line default
#line hidden
#nullable disable
                WriteLiteral("\t\t\t\t\t\t\t\t<div class = \"Piece\" \n\t\t\t\t\t\t\t\t\tid=\"piece-${i}-{j}\" \n\t\t\t\t\t\t\t\t\tdata-type = \".\"> \n\t\t\t\t\t\t\t\t\t<button> </button>\n\t\t\t\t\t\t\t\t</div> \n");
#nullable restore
#line 301 "/Users/jaredantner/Desktop/chessEngine/Views/Chess/Board.cshtml"
							}  

#line default
#line hidden
#nullable disable
                WriteLiteral("\t\t\t\t\t\t\t\t\n\t\t\t\t\t\t\t\t\t\n\t\t\t\t\t\t\t\n\t\t\t\t\t\t</td> \n");
#nullable restore
#line 306 "/Users/jaredantner/Desktop/chessEngine/Views/Chess/Board.cshtml"
					} 

#line default
#line hidden
#nullable disable
                WriteLiteral("\t\t\t\t</tr> \n");
#nullable restore
#line 308 "/Users/jaredantner/Desktop/chessEngine/Views/Chess/Board.cshtml"
			}

#line default
#line hidden
#nullable disable
                WriteLiteral(@"		</table>  


			 
	</div> 	
	
	<script>
		let element = document.getElementById(""test"");
		e2 = element.querySelector(""button""); 
		e2.onclick = function(){ 
			e2.style.backgroundColor = 'red';
		};
	</script>

	<script>
		
		let element = document.getElementById(""game-board"");
		let color_white = true;  
		for(int i = 0; i < 8; i++){ 
			for(int j = 0; j < 8; j++){
				if(color_white){ 
					element.getElementById(""piece-${i}-${j}"").querySelector(""button"").style.backgroundColor = ""red""; 
				} 
				else{ 	
					element.getElementById(""piece-${i}-${j}"").querySelector(""button"").style.backgroundColor = ""blue""; 
				}
				color_white = !color_white;  
			} 
		} 
				 
				
		let start_row = undefined; 
		let start_col = undefined; 

		let end_row = undefined; 
		let end_col = undefined; 

		for(int i = 0; i < 8; i++){ 
			for(int j = 0; j < 8; j++){ 
				current_element = element.getElementById(""piece-${i}-${j}""); 
				current_element.querySelector(""button"").onclick = function(){ 
					if(start_row == undefin");
                WriteLiteral(@"ed){ 
						start_row = i; 
						start_col = j;
					} 
					else{ 
						end_row = i; 
						end_col = j;
						// make_move(start_row, start_col, end_row, end_col);  
					}  
				} 
			}
		}  
	</script>


	 	
	<script>
		let element = document.getElementById(""test"");
		e2 = element.querySelector(""button""); 
		e2.onclick = function(){ 
			e2.style.backgroundColor = 'red';
		};
	</script>
");
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
            WriteLiteral("\n \n\n \n");
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
