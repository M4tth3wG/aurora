#pragma checksum "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "79e315feeee6f5c213d3cfada56495907379e33e1278db16771f05799e86b5fb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_OfertaKierunkow_Index), @"mvc.1.0.view", @"/Views/OfertaKierunkow/Index.cshtml")]
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
#line 1 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\_ViewImports.cshtml"
using Aurora;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\_ViewImports.cshtml"
using Aurora.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"
using Aurora.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"
using Aurora.Utils;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"79e315feeee6f5c213d3cfada56495907379e33e1278db16771f05799e86b5fb", @"/Views/OfertaKierunkow/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"b9234686976dcc85183016e3ff5f1eceab905438d29f007ff907fe2806fab201", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_OfertaKierunkow_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<KierunekStudiow>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"
  
    ViewData["Title"] = "Oferta";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-md-3\">\r\n        <div class=\"form-inline pull-left\">\r\n");
#nullable restore
#line 12 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"
                 using (Html.BeginForm("Index", "OfertaKierunkow", FormMethod.Get, new { @class = "form-group", id = "searchForm" }))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""custom-dropdown"">
                    <label for=""txtSearchFilter"">Wyszukaj kierunek:</label>
                    <input type=""text"" class=""form-control"" placeholder=""Wyszukaj kierunek"" id=""txtSearchFilter"" name=""searchFilter""");
            BeginWriteAttribute("value", " value=\"", 627, "\"", 656, 1);
#nullable restore
#line 16 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"
WriteAttributeValue("", 635, ViewBag.SearchFilter, 635, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                    <button type=\"submit\" class=\"btn btn-secondary\">Szukaj</button>\r\n                        ");
#nullable restore
#line 18 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"
                   Write(Html.Hidden("filterPoziom", TempData["FilterPoziom"]));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 19 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"
                   Write(Html.Hidden("filterForma", TempData["FilterForma"]));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 20 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"
                   Write(Html.Hidden("filterJezyk", TempData["FilterJezyk"]));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 21 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"
                   Write(Html.Hidden("filterWydzial", TempData["FilterWydzial"]));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 22 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"
                   Write(Html.Hidden("filterMiejsce", TempData["FilterMiejsce"]));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n");
#nullable restore
#line 24 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"

                }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n    <div class=\"col-md-9\">\r\n        <div class=\"form-inline pull-right\">\r\n");
#nullable restore
#line 30 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"
                 using (Html.BeginForm("index", "OfertaKierunkow", FormMethod.Get, new { @class = "form-group", id = "filterForm" }))
                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"custom-dropdown\">\r\n\r\n                    <label for=\"filterPoziom\">Poziom studiów:</label>\r\n                        ");
#nullable restore
#line 36 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"
                   Write(Html.DropDownList("filterPoziom", new SelectList(ViewBag.FilterOptionsPoziom, "Value", "Text", ViewBag.SelectedFilterPoziom), new { onchange = "submitFilterForm();", @value = ViewBag.SelectedFilterPoziom, style = "width: 200px;" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"custom-dropdown\">\r\n                    <label for=\"filterForma\">Forma studiów:</label>\r\n                        ");
#nullable restore
#line 40 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"
                   Write(Html.DropDownList("filterForma", new SelectList(ViewBag.FilterOptionsForma, "Value", "Text", ViewBag.SelectedFilterForma), new { onchange = "submitFilterForm();", @value = ViewBag.SelectedFilterForma, style = "width: 200px;" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"custom-dropdown\">\r\n                    <label for=\"filterJezyk\">Język wykładowy:</label>\r\n                        ");
#nullable restore
#line 44 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"
                   Write(Html.DropDownList("filterJezyk", new SelectList(ViewBag.FilterOptionsJezyk, "Value", "Text", ViewBag.SelectedFilterJezyk), new { onchange = "submitFilterForm();", @value = ViewBag.SelectedFilterJezyk, style = "width: 200px;" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"custom-dropdown\">\r\n                    <label for=\"filterWydzial\">Wydział kierunku</label>\r\n                        ");
#nullable restore
#line 48 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"
                   Write(Html.DropDownList("filterWydzial", new SelectList(ViewBag.FilterOptionsWydzial, "Value", "Text", ViewBag.SelectedFilterWydzial), new { onchange = "submitFilterForm();", @value = ViewBag.SelectedFilterWydzial, style = "width: 200px;" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"custom-dropdown\">\r\n                    <label for=\"filterOption1\">Miejsce studiów:</label>\r\n                        ");
#nullable restore
#line 52 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"
                   Write(Html.DropDownList("filterMiejsce", new SelectList(ViewBag.FilterOptionsMiejsce, "Value", "Text", ViewBag.SelectedFilterMiejsce), new { onchange = "submitFilterForm();", @value = ViewBag.SelectedFilterMiejsce, style = "width: 200px;" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n");
            WriteLiteral("                <input type=\"hidden\" name=\"searchFilter\"");
            BeginWriteAttribute("value", " value=\"", 3514, "\"", 3543, 1);
#nullable restore
#line 56 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"
WriteAttributeValue("", 3522, ViewBag.SearchFilter, 3522, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                <input type=\"hidden\" name=\"filterPoziom\"");
            BeginWriteAttribute("value", " value=\"", 3605, "\"", 3638, 1);
#nullable restore
#line 57 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"
WriteAttributeValue("", 3613, TempData["FilterPoziom"], 3613, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                <input type=\"hidden\" name=\"filterForma\"");
            BeginWriteAttribute("value", " value=\"", 3699, "\"", 3731, 1);
#nullable restore
#line 58 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"
WriteAttributeValue("", 3707, TempData["FilterForma"], 3707, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                <input type=\"hidden\" name=\"filterJezyk\"");
            BeginWriteAttribute("value", " value=\"", 3792, "\"", 3824, 1);
#nullable restore
#line 59 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"
WriteAttributeValue("", 3800, TempData["FilterJezyk"], 3800, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                <input type=\"hidden\" name=\"filterWydzial\"");
            BeginWriteAttribute("value", " value=\"", 3887, "\"", 3921, 1);
#nullable restore
#line 60 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"
WriteAttributeValue("", 3895, TempData["FilterWydzial"], 3895, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                <input type=\"hidden\" name=\"filterMiejsce\"");
            BeginWriteAttribute("value", " value=\"", 3984, "\"", 4018, 1);
#nullable restore
#line 61 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"
WriteAttributeValue("", 3992, TempData["FilterMiejsce"], 3992, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
#nullable restore
#line 62 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n\r\n</div>\r\n\r\n");
#nullable restore
#line 68 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"
 if (Model.Any())

{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n        <table class=\"table\">\r\n            <thead>\r\n            <th> </th>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 77 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"
                 foreach (var kierunek in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr class=\"application-row\">\r\n                        <td class=\"my-td\">Kierunek: ");
#nullable restore
#line 80 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"
                                               Write(kierunek.NazwaKierunku);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"my-td\">Forma studiów: ");
#nullable restore
#line 81 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"
                                                     Write(EnumUtils.ConvertIDToTypeAsString<FormaStudiow>(kierunek.FormaStudiow));

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </td>
                        <td class=""my-td""> <button class=""btn btn-secondary"" style=""margin-right: 5px; width: 100%;"">Współcz. rekrutacji</button></td>
                        <td class=""my-td""> <button class=""btn btn-secondary"" style=""margin-right: 5px; width: 100%"">Procedury rekrutacji</button></td>
                        <td class=""my-td""> <button class=""btn btn-secondary"" style=""margin-right: 5px; width: 100%"">Aplikuj</button></td>
                    </tr>
");
            WriteLiteral("                    <tr class=\"application-row\">\r\n                        <td class=\"my-td\">");
#nullable restore
#line 88 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"
                                      Write(EnumUtils.ConvertIDToTypeAsString<NazwaWydzialu>(kierunek.Wydzial));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                        <td class=\"my-td\">Poziom studiów:  ");
#nullable restore
#line 89 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"
                                                       Write(EnumUtils.ConvertIDToTypeAsString<PoziomStudiow>(kierunek.PoziomStudiow));

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </td>
                        <td class=""my-td""> <button class=""btn btn-secondary"" style=""margin-right: 5px; width: 100%"">Terminy rekrutacji</button></td>
                        <td class=""my-td""> <button class=""btn btn-secondary"" style=""margin-right: 5px; width: 100%"">Progi punktowe</button></td>
                        <td class=""my-td""></td>
                    </tr>
");
            WriteLiteral("                    <tr class=\"application-row\">\r\n                        <td class=\"my-td\">Dodaj do ulubionych</td>\r\n                        <td class=\"my-td\">Język wykładowy: ");
#nullable restore
#line 97 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"
                                                       Write(EnumUtils.ConvertIDToTypeAsString<Jezyk>(kierunek.JezykWykladowy));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"my-td\"></td>\r\n                        <td class=\"my-td\"></td>\r\n                        <td class=\"my-td\"></td>\r\n                    </tr>\r\n");
            WriteLiteral("                    <tr class=\"application-row\" style=\"height: 40px;\"></tr>\r\n");
#nullable restore
#line 104 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n");
#nullable restore
#line 108 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"


}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p style=\"padding: 20px; text-align: center\">");
#nullable restore
#line 113 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"
                                            Write(ViewBag.PopUpMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 114 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 117 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"
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
#line 129 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"
                                             Write(ViewBag.PopUpMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div>\r\n\r\n                <div class=\"modal-footer\">\r\n                    <button type=\"button\" class=\"btn btn-danger\" data-dismiss=\"modal\">Zamknij</button>\r\n                </div>\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            WriteLiteral("    <script>\r\n        $(document).ready(function () {\r\n            var popUpMessage = \'");
#nullable restore
#line 142 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"
                           Write(Html.Raw(ViewBag.PopUpMessage));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n\r\n            if (popUpMessage.trim() !== \'\') {\r\n                $(\'#myModal\').modal(\'show\');\r\n            }\r\n        });\r\n    </script>\r\n");
#nullable restore
#line 149 "C:\Users\Igor\Documents\GitHub\aurora\Aurora\Views\OfertaKierunkow\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


<script>
    function submitFilterForm() {
        document.getElementById(""filterForm"").submit();
        document.getElementById(""searchForm"").elements[""filterPoziom""].value = document.getElementById(""filterPoziom"").value;
        document.getElementById(""searchForm"").elements[""filterForma""].value = document.getElementById(""filterForma"").value;
        document.getElementById(""searchForm"").elements[""filterJezyk""].value = document.getElementById(""filterJezyk"").value;
        document.getElementById(""searchForm"").elements[""filterWydzial""].value = document.getElementById(""filterWydzial"").value;
        document.getElementById(""searchForm"").elements[""filterMiejsce""].value = document.getElementById(""filterMiejsce"").value;

</script>




");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<KierunekStudiow>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
