#pragma checksum "D:\FER - diplomski\INFSUS\ProdajaPica\Views\Narudzba\Show.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ec5b2373671afde6711cc275767502e7dffbb5ad"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Narudzba_Show), @"mvc.1.0.view", @"/Views/Narudzba/Show.cshtml")]
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
#line 1 "D:\FER - diplomski\INFSUS\ProdajaPica\Views\_ViewImports.cshtml"
using ProdajaPica;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\FER - diplomski\INFSUS\ProdajaPica\Views\_ViewImports.cshtml"
using ProdajaPica.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\FER - diplomski\INFSUS\ProdajaPica\Views\_ViewImports.cshtml"
using ProdajaPica.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec5b2373671afde6711cc275767502e7dffbb5ad", @"/Views/Narudzba/Show.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c8a3ba93988a5f4eae0f6d9935a778e05e7c3a16", @"/Views/_ViewImports.cshtml")]
    public class Views_Narudzba_Show : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NarudzbaViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "PreviousNext", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary cancel"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\FER - diplomski\INFSUS\ProdajaPica\Views\Narudzba\Show.cshtml"
  
    ViewBag.Title = "Narudzba br. " + @Model.Id;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ec5b2373671afde6711cc275767502e7dffbb5ad5204", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 8 "D:\FER - diplomski\INFSUS\ProdajaPica\Views\Narudzba\Show.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n    <hr />\r\n\r\n    <div class=\"text-center\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec5b2373671afde6711cc275767502e7dffbb5ad6820", async() => {
                WriteLiteral("\r\n            Uredi\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 13 "D:\FER - diplomski\INFSUS\ProdajaPica\Views\Narudzba\Show.cshtml"
                                                              WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 13 "D:\FER - diplomski\INFSUS\ProdajaPica\Views\Narudzba\Show.cshtml"
                                                                                         WriteLiteral(ViewBag.Page);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 14 "D:\FER - diplomski\INFSUS\ProdajaPica\Views\Narudzba\Show.cshtml"
                WriteLiteral(ViewBag.Sort);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["sort"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-sort", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["sort"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 14 "D:\FER - diplomski\INFSUS\ProdajaPica\Views\Narudzba\Show.cshtml"
                                                    WriteLiteral(ViewBag.Ascending);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["ascending"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-ascending", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["ascending"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 15 "D:\FER - diplomski\INFSUS\ProdajaPica\Views\Narudzba\Show.cshtml"
                    WriteLiteral(ViewBag.Position);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["position"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-position", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["position"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec5b2373671afde6711cc275767502e7dffbb5ad11925", async() => {
                WriteLiteral("\r\n            Natrag\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 18 "D:\FER - diplomski\INFSUS\ProdajaPica\Views\Narudzba\Show.cshtml"
                                  WriteLiteral(ViewBag.Page);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 18 "D:\FER - diplomski\INFSUS\ProdajaPica\Views\Narudzba\Show.cshtml"
                                                                 WriteLiteral(ViewBag.Sort);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["sort"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-sort", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["sort"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 19 "D:\FER - diplomski\INFSUS\ProdajaPica\Views\Narudzba\Show.cshtml"
                     WriteLiteral(ViewBag.Ascending);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["ascending"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-ascending", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["ascending"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 19 "D:\FER - diplomski\INFSUS\ProdajaPica\Views\Narudzba\Show.cshtml"
                                                             WriteLiteral(ViewBag.Position);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["position"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-position", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["position"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    </div>

    <div class=""my-5"">
        <div class=""row mb-3"">
            <b>Kupac</b>
        </div>
        <div class=""row mb-3"">
            <div class=""col-sm-2"">
                Naziv:
            </div>
            <div class=""col-sm-4"">
                ");
#nullable restore
#line 33 "D:\FER - diplomski\INFSUS\ProdajaPica\Views\Narudzba\Show.cshtml"
           Write(Model.Kupac.NazivObjekta);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
        </div>

        <div class=""my-5"">
            <div class=""row mb-3"">
                <b>Informacije narudzbe</b>
            </div>
            <div class=""row mb-3"">
                <div class=""col-sm-2"">
                    Status:
                </div>
                <div class=""col-sm-4"">
                    ");
#nullable restore
#line 46 "D:\FER - diplomski\INFSUS\ProdajaPica\Views\Narudzba\Show.cshtml"
               Write(Model.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"row mb-3\">\r\n                <div class=\"col-sm-2\">\r\n                    Napomena:\r\n                </div>\r\n                <div class=\"col-sm-4\">\r\n                    ");
#nullable restore
#line 54 "D:\FER - diplomski\INFSUS\ProdajaPica\Views\Narudzba\Show.cshtml"
               Write(Model.Napomena);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"row mb-3\">\r\n                <div class=\"col-sm-2\">\r\n                    Datum:\r\n                </div>\r\n                <div class=\"col-sm-4\">\r\n");
            WriteLiteral("                    ");
#nullable restore
#line 63 "D:\FER - diplomski\INFSUS\ProdajaPica\Views\Narudzba\Show.cshtml"
               Write(Model.Datum);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"row mb-3\">\r\n                <div class=\"col-sm-2\">\r\n                    Iznos:\r\n                </div>\r\n                <div class=\"col-sm-4\">\r\n                    ");
#nullable restore
#line 71 "D:\FER - diplomski\INFSUS\ProdajaPica\Views\Narudzba\Show.cshtml"
               Write(Model.Iznos);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </div>
            </div>
        </div>


        <div class=""row mb-5"">
            <div class=""col text-center"">
                <h4>
                    Proizvodi
                </h4>
            </div>
            <table class=""table table-striped"">
                <thead>
                    <tr>
");
#nullable restore
#line 86 "D:\FER - diplomski\INFSUS\ProdajaPica\Views\Narudzba\Show.cshtml"
                          
                            string[] naslovi = { "Naziv", "Cijena", "Kolicina" };
                            for (int i = 0; i < naslovi.Length; i++)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <th class=\"text-center\">\r\n                                    ");
#nullable restore
#line 91 "D:\FER - diplomski\INFSUS\ProdajaPica\Views\Narudzba\Show.cshtml"
                               Write(naslovi[i]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </th>\r\n");
#nullable restore
#line 93 "D:\FER - diplomski\INFSUS\ProdajaPica\Views\Narudzba\Show.cshtml"
                            }
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <th></th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
#nullable restore
#line 99 "D:\FER - diplomski\INFSUS\ProdajaPica\Views\Narudzba\Show.cshtml"
                     foreach (var proizvod in Model.Proizvod)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td class=\"text-left col-sm-6\">\r\n                                ");
#nullable restore
#line 103 "D:\FER - diplomski\INFSUS\ProdajaPica\Views\Narudzba\Show.cshtml"
                           Write(proizvod.Naziv);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td class=\"text-right col-sm-2\">\r\n                                ");
#nullable restore
#line 106 "D:\FER - diplomski\INFSUS\ProdajaPica\Views\Narudzba\Show.cshtml"
                           Write(proizvod.Cijena);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td class=\"text-center col-sm-2\">\r\n                                ");
#nullable restore
#line 109 "D:\FER - diplomski\INFSUS\ProdajaPica\Views\Narudzba\Show.cshtml"
                           Write(proizvod.Kolicina);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 112 "D:\FER - diplomski\INFSUS\ProdajaPica\Views\Narudzba\Show.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n\r\n");
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NarudzbaViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
