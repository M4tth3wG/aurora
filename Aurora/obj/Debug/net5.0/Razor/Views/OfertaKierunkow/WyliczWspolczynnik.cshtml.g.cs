#pragma checksum "D:\C# Projects\aurora\Aurora\Views\OfertaKierunkow\WyliczWspolczynnik.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5ab449bd4f7dcd645f4f542eb73f01a77f338382816856f75faa4af1bda3f6ac"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_OfertaKierunkow_WyliczWspolczynnik), @"mvc.1.0.view", @"/Views/OfertaKierunkow/WyliczWspolczynnik.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\C# Projects\aurora\Aurora\Views\_ViewImports.cshtml"
using Aurora;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\C# Projects\aurora\Aurora\Views\_ViewImports.cshtml"
using Aurora.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\C# Projects\aurora\Aurora\Views\OfertaKierunkow\WyliczWspolczynnik.cshtml"
using Aurora.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\C# Projects\aurora\Aurora\Views\OfertaKierunkow\WyliczWspolczynnik.cshtml"
using Aurora.Utils;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\C# Projects\aurora\Aurora\Views\OfertaKierunkow\WyliczWspolczynnik.cshtml"
using Aurora.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"5ab449bd4f7dcd645f4f542eb73f01a77f338382816856f75faa4af1bda3f6ac", @"/Views/OfertaKierunkow/WyliczWspolczynnik.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"b9234686976dcc85183016e3ff5f1eceab905438d29f007ff907fe2806fab201", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_OfertaKierunkow_WyliczWspolczynnik : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WyliczWspolczynnikViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "D:\C# Projects\aurora\Aurora\Views\OfertaKierunkow\WyliczWspolczynnik.cshtml"
  
    ViewData["Title"] = "Wylicz swój współczynnik rekrutacyjny";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h3 style=\"margin-bottom: 20px;\">Wyliczanie współczynnika rekrutacyjnego dla kierunku ");
#nullable restore
#line 9 "D:\C# Projects\aurora\Aurora\Views\OfertaKierunkow\WyliczWspolczynnik.cshtml"
                                                                                 Write(Model.NazwaKierunku);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n\r\n<div style=\"text-align: center; margin-bottom: 30px;\">\r\n    <h2 style=\"margin-bottom: 20px;\">Wartość współczynnika: ");
#nullable restore
#line 13 "D:\C# Projects\aurora\Aurora\Views\OfertaKierunkow\WyliczWspolczynnik.cshtml"
                                                       Write(ViewBag.WartoscWR);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n    <h3>Wyniki procentowe z egzaminu maturalnego</h3>\r\n</div>\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ab449bd4f7dcd645f4f542eb73f01a77f338382816856f75faa4af1bda3f6ac5387", async() => {
                WriteLiteral("\r\n    <input type=\"hidden\" id=\"id\" name=\"KierunekID\"");
                BeginWriteAttribute("value", " value=\"", 638, "\"", 663, 1);
#nullable restore
#line 19 "D:\C# Projects\aurora\Aurora\Views\OfertaKierunkow\WyliczWspolczynnik.cshtml"
WriteAttributeValue("", 646, Model.KierunekID, 646, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n    <input type=\"hidden\" id=\"id\" name=\"NazwaKierunku\"");
                BeginWriteAttribute("value", " value=\"", 720, "\"", 748, 1);
#nullable restore
#line 20 "D:\C# Projects\aurora\Aurora\Views\OfertaKierunkow\WyliczWspolczynnik.cshtml"
WriteAttributeValue("", 728, Model.NazwaKierunku, 728, 20, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">
    <div class=""rr-form-table-container"">
        <table class=""rr-form-table"">
            <thead>
                <tr>
                    <th>Przedmiot</th>
                    <th>Poziom podstawowy</th>
                    <th>Poziom rozszerzony</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td><label for=""MatPodst"">Matematyka</label></td>
                    <td><input type=""number"" id=""MatPodst"" name=""WynikiMaturalne[MatPodst]"" min=""0"" max=""100""");
                BeginWriteAttribute("value", " value=", 1282, "", 1323, 1);
#nullable restore
#line 33 "D:\C# Projects\aurora\Aurora\Views\OfertaKierunkow\WyliczWspolczynnik.cshtml"
WriteAttributeValue("", 1289, Model.wynikiMaturalne["MatPodst"], 1289, 34, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" oninput=\"ograniczDoMaksimum(this)\"></td>\r\n                    <td><input type=\"number\" id=\"MatRoz\" name=\"WynikiMaturalne[MatRoz]\" min=\"0\" max=\"100\"");
                BeginWriteAttribute("value", " value=", 1471, "", 1510, 1);
#nullable restore
#line 34 "D:\C# Projects\aurora\Aurora\Views\OfertaKierunkow\WyliczWspolczynnik.cshtml"
WriteAttributeValue("", 1478, Model.wynikiMaturalne["MatRoz"], 1478, 32, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" oninput=""ograniczDoMaksimum(this)""></td>
                </tr>
                <tr>
                    <td><label for=""FizPodst"">Fizyka</label></td> 
                    <td><input type=""number"" id=""FizPodst"" name=""WynikiMaturalne[FizPodst]"" min=""0"" max=""100""");
                BeginWriteAttribute("value", " value=", 1775, "", 1816, 1);
#nullable restore
#line 38 "D:\C# Projects\aurora\Aurora\Views\OfertaKierunkow\WyliczWspolczynnik.cshtml"
WriteAttributeValue("", 1782, Model.wynikiMaturalne["FizPodst"], 1782, 34, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" oninput=\"ograniczDoMaksimum(this)\"></td>\r\n                    <td><input type=\"number\" id=\"FizRoz\" name=\"WynikiMaturalne[FizRoz]\" min=\"0\" max=\"100\"");
                BeginWriteAttribute("value", " value=", 1964, "", 2003, 1);
#nullable restore
#line 39 "D:\C# Projects\aurora\Aurora\Views\OfertaKierunkow\WyliczWspolczynnik.cshtml"
WriteAttributeValue("", 1971, Model.wynikiMaturalne["FizRoz"], 1971, 32, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" oninput=""ograniczDoMaksimum(this)""></td>
                </tr>
                <tr>
                    <td><label for=""PolPodst"">Język polski</label></td>
                    <td><input type=""number"" id=""PolPodst"" name=""WynikiMaturalne[PolPodst]"" min=""0"" max=""100""");
                BeginWriteAttribute("value", " value=", 2273, "", 2314, 1);
#nullable restore
#line 43 "D:\C# Projects\aurora\Aurora\Views\OfertaKierunkow\WyliczWspolczynnik.cshtml"
WriteAttributeValue("", 2280, Model.wynikiMaturalne["PolPodst"], 2280, 34, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" oninput=\"ograniczDoMaksimum(this)\"></td>\r\n                    <td><input type=\"number\" id=\"PolRoz\" name=\"WynikiMaturalne[PolRoz]\" min=\"0\" max=\"100\"");
                BeginWriteAttribute("value", " value=", 2462, "", 2501, 1);
#nullable restore
#line 44 "D:\C# Projects\aurora\Aurora\Views\OfertaKierunkow\WyliczWspolczynnik.cshtml"
WriteAttributeValue("", 2469, Model.wynikiMaturalne["PolRoz"], 2469, 32, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" oninput=""ograniczDoMaksimum(this)""></td>
                </tr>
                <tr>
                    <td><label for=""ObcPodst"">Język obcy</label></td>
                    <td><input type=""number"" id=""ObcPodst"" name=""WynikiMaturalne[ObcPodst]"" min=""0"" max=""100""");
                BeginWriteAttribute("value", " value=", 2769, "", 2810, 1);
#nullable restore
#line 48 "D:\C# Projects\aurora\Aurora\Views\OfertaKierunkow\WyliczWspolczynnik.cshtml"
WriteAttributeValue("", 2776, Model.wynikiMaturalne["ObcPodst"], 2776, 34, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" oninput=\"ograniczDoMaksimum(this)\"></td>\r\n                    <td><input type=\"number\" id=\"ObcRoz\" name=\"WynikiMaturalne[ObcRoz]\" min=\"0\" max=\"100\"");
                BeginWriteAttribute("value", " value=", 2958, "", 2997, 1);
#nullable restore
#line 49 "D:\C# Projects\aurora\Aurora\Views\OfertaKierunkow\WyliczWspolczynnik.cshtml"
WriteAttributeValue("", 2965, Model.wynikiMaturalne["ObcRoz"], 2965, 32, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" oninput=""ograniczDoMaksimum(this)""></td>
                </tr>
                <tr>
                    <td><label for=""BioPodst"">Biologia</label></td>
                    <td><input type=""number"" id=""BioPodst"" name=""WynikiMaturalne[BioPodst]"" min=""0"" max=""100""");
                BeginWriteAttribute("value", " value=", 3263, "", 3304, 1);
#nullable restore
#line 53 "D:\C# Projects\aurora\Aurora\Views\OfertaKierunkow\WyliczWspolczynnik.cshtml"
WriteAttributeValue("", 3270, Model.wynikiMaturalne["BioPodst"], 3270, 34, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" oninput=\"ograniczDoMaksimum(this)\"></td>\r\n                    <td><input type=\"number\" id=\"BioRoz\" name=\"WynikiMaturalne[BioRoz]\" min=\"0\" max=\"100\"");
                BeginWriteAttribute("value", " value=", 3452, "", 3493, 1);
#nullable restore
#line 54 "D:\C# Projects\aurora\Aurora\Views\OfertaKierunkow\WyliczWspolczynnik.cshtml"
WriteAttributeValue("", 3459, Model.wynikiMaturalne["BioPodst"], 3459, 34, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" oninput=""ograniczDoMaksimum(this)""></td>
                </tr>
                <tr>
                    <td><label for=""ChePodst"">Chemia</label></td>
                    <td><input type=""number"" id=""ChePodst"" name=""WynikiMaturalne[ChePodst]"" min=""0"" max=""100""");
                BeginWriteAttribute("value", " value=", 3757, "", 3798, 1);
#nullable restore
#line 58 "D:\C# Projects\aurora\Aurora\Views\OfertaKierunkow\WyliczWspolczynnik.cshtml"
WriteAttributeValue("", 3764, Model.wynikiMaturalne["ChePodst"], 3764, 34, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" oninput=\"ograniczDoMaksimum(this)\"></td>\r\n                    <td><input type=\"number\" id=\"CheRoz\" name=\"WynikiMaturalne[CheRoz]\" min=\"0\" max=\"100\"");
                BeginWriteAttribute("value", " value=", 3946, "", 3985, 1);
#nullable restore
#line 59 "D:\C# Projects\aurora\Aurora\Views\OfertaKierunkow\WyliczWspolczynnik.cshtml"
WriteAttributeValue("", 3953, Model.wynikiMaturalne["CheRoz"], 3953, 32, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" oninput=""ograniczDoMaksimum(this)""></td>
                </tr>
                <tr>
                    <td><label for=""GeoPodst"">Geografia</label></td>
                    <td><input type=""number"" id=""GeoPodst"" name=""WynikiMaturalne[GeoPodst]"" min=""0"" max=""100""");
                BeginWriteAttribute("value", " value=", 4252, "", 4293, 1);
#nullable restore
#line 63 "D:\C# Projects\aurora\Aurora\Views\OfertaKierunkow\WyliczWspolczynnik.cshtml"
WriteAttributeValue("", 4259, Model.wynikiMaturalne["GeoPodst"], 4259, 34, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" oninput=\"ograniczDoMaksimum(this)\"></td>\r\n                    <td><input type=\"number\" id=\"GeoRoz\" name=\"WynikiMaturalne[GeoRoz]\" min=\"0\" max=\"100\"");
                BeginWriteAttribute("value", " value=", 4441, "", 4480, 1);
#nullable restore
#line 64 "D:\C# Projects\aurora\Aurora\Views\OfertaKierunkow\WyliczWspolczynnik.cshtml"
WriteAttributeValue("", 4448, Model.wynikiMaturalne["GeoRoz"], 4448, 32, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" oninput=""ograniczDoMaksimum(this)""></td>
                </tr>
                <tr>
                    <td><label for=""InfoPodst"">Informatyka</label></td>
                    <td><input type=""number"" id=""InfoPodst"" name=""WynikiMaturalne[InfoPodst]"" min=""0"" max=""100""");
                BeginWriteAttribute("value", " value=", 4752, "", 4794, 1);
#nullable restore
#line 68 "D:\C# Projects\aurora\Aurora\Views\OfertaKierunkow\WyliczWspolczynnik.cshtml"
WriteAttributeValue("", 4759, Model.wynikiMaturalne["InfoPodst"], 4759, 35, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" oninput=\"ograniczDoMaksimum(this)\"></td>\r\n                    <td><input type=\"number\" id=\"InfoRoz\" name=\"WynikiMaturalne[InfoRoz]\" min=\"0\" max=\"100\"");
                BeginWriteAttribute("value", " value=", 4944, "", 4984, 1);
#nullable restore
#line 69 "D:\C# Projects\aurora\Aurora\Views\OfertaKierunkow\WyliczWspolczynnik.cshtml"
WriteAttributeValue("", 4951, Model.wynikiMaturalne["InfoRoz"], 4951, 33, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" oninput=""ograniczDoMaksimum(this)""></td>
                </tr>                
                <tr>
                    <td><label for=""EgzRys"">Egzamin z rysunku</label></td>
                    <td colspan=""2""><input type=""number"" id=""InfoPodst"" name=""WynikiMaturalne[EgzRys]"" min=""0""");
                BeginWriteAttribute("value", " value=", 5274, "", 5313, 1);
#nullable restore
#line 73 "D:\C# Projects\aurora\Aurora\Views\OfertaKierunkow\WyliczWspolczynnik.cshtml"
WriteAttributeValue("", 5281, Model.wynikiMaturalne["EgzRys"], 5281, 32, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@"></td>
                </tr>
            </tbody>
        </table>
    </div>

    <div style=""text-align: center; margin-top: 20px;"">
        <button type=""submit"" style=""display: inline-block;"">Submit</button>
        <button type=""button"" onclick=""history.back()"" style=""display: inline-block; margin-left: 10px;"">Powrót</button>
    </div>

");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 18 "D:\C# Projects\aurora\Aurora\Views\OfertaKierunkow\WyliczWspolczynnik.cshtml"
AddHtmlAttributeValue("", 532, Url.Action("WyliczWspolczynnik", "OfertaKierunkow"), 532, 52, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 87 "D:\C# Projects\aurora\Aurora\Views\OfertaKierunkow\WyliczWspolczynnik.cshtml"
 if (ViewBag.PopUpMessage != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""modal fade"" id=""myModal"">
        <div class=""modal-dialog"">
            <div class=""modal-content"">

                <div class=""modal-header"">
                    <h4 class=""modal-title""></h4>
                    <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
                </div>

                <div class=""modal-body"">
                    <p style=""text-align: center"">");
#nullable restore
#line 99 "D:\C# Projects\aurora\Aurora\Views\OfertaKierunkow\WyliczWspolczynnik.cshtml"
                                             Write(ViewBag.PopUpMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div>\r\n\r\n                <div class=\"modal-footer\">\r\n                    <button type=\"button\" class=\"btn btn-danger\" data-dismiss=\"modal\">Zamknij</button>\r\n                </div>\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            WriteLiteral("    <script>\r\n        $(document).ready(function () {\r\n            var popUpMessage = \'");
#nullable restore
#line 112 "D:\C# Projects\aurora\Aurora\Views\OfertaKierunkow\WyliczWspolczynnik.cshtml"
                           Write(Html.Raw(ViewBag.PopUpMessage));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n\r\n            if (popUpMessage.trim() !== \'\') {\r\n                $(\'#myModal\').modal(\'show\');\r\n            }\r\n        });\r\n    </script>\r\n");
#nullable restore
#line 119 "D:\C# Projects\aurora\Aurora\Views\OfertaKierunkow\WyliczWspolczynnik.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WyliczWspolczynnikViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591