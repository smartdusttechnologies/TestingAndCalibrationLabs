#pragma checksum "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\CollapsableSection\_collapsableSection.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "25feacef480fc4737fd0d77d27cf16c8eb627fee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Common_Components_CollapsableSection__collapsableSection), @"mvc.1.0.view", @"/Views/Common/Components/CollapsableSection/_collapsableSection.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\_ViewImports.cshtml"
using TestingAndCalibrationLabs.Web.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\_ViewImports.cshtml"
using TestingAndCalibrationLabs.Web.UI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\_ViewImports.cshtml"
using System.Linq;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\_ViewImports.cshtml"
using TestingAndCalibrationLabs.Business.Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"25feacef480fc4737fd0d77d27cf16c8eb627fee", @"/Views/Common/Components/CollapsableSection/_collapsableSection.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87ea9b8a111f12a73c09d93ec0c20de57828e725", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Common_Components_CollapsableSection__collapsableSection : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TestingAndCalibrationLabs.Web.UI.Models.Node<TestingAndCalibrationLabs.Web.UI.Models.LayoutDTO>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"accordion accordion-flush\"");
            BeginWriteAttribute("id", " id=\"", 142, "\"", 192, 2);
            WriteAttributeValue("", 147, "accordionFlush-", 147, 15, true);
#nullable restore
#line 2 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\CollapsableSection\_collapsableSection.cshtml"
WriteAttributeValue("", 162, Model.Value.UiPageMetadata.Id, 162, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 3 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\CollapsableSection\_collapsableSection.cshtml"
     foreach (var item in Model.Children)
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\CollapsableSection\_collapsableSection.cshtml"
         if (Model.Children.First() == item)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"accordion-item\">\r\n                <h2 class=\"accordion-header\"");
            BeginWriteAttribute("id", " id=\"", 389, "\"", 429, 2);
            WriteAttributeValue("", 394, "flush-", 394, 6, true);
#nullable restore
#line 8 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\CollapsableSection\_collapsableSection.cshtml"
WriteAttributeValue("", 400, item.Value.UiPageMetadata.Id, 400, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <button class=\"accordion-button collapsed\" type=\"button\" data-bs-toggle=\"collapse\" data-bs-target=\"#flush-");
#nullable restore
#line 9 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\CollapsableSection\_collapsableSection.cshtml"
                                                                                                                         Write(item.Value.UiPageMetadata.UiControlTypeName);

#line default
#line hidden
#nullable disable
            WriteLiteral("-");
#nullable restore
#line 9 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\CollapsableSection\_collapsableSection.cshtml"
                                                                                                                                                                      Write(item.Value.UiPageMetadata.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" aria-expanded=\"true\"");
            BeginWriteAttribute("aria-controls", " aria-controls=\"", 655, "\"", 751, 4);
            WriteAttributeValue("", 671, "flush-", 671, 6, true);
#nullable restore
#line 9 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\CollapsableSection\_collapsableSection.cshtml"
WriteAttributeValue("", 677, item.Value.UiPageMetadata.UiControlTypeName, 677, 44, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 721, "-", 721, 1, true);
#nullable restore
#line 9 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\CollapsableSection\_collapsableSection.cshtml"
WriteAttributeValue("", 722, item.Value.UiPageMetadata.Id, 722, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <span class=\"fab fa-leanpub me-2\"></span>\r\n                        ");
#nullable restore
#line 11 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\CollapsableSection\_collapsableSection.cshtml"
                   Write(item.Value.UiPageMetadata.UiControlDisplayName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </button>\r\n                </h2>\r\n                <div");
            BeginWriteAttribute("id", " id=\"", 969, "\"", 1054, 4);
            WriteAttributeValue("", 974, "flush-", 974, 6, true);
#nullable restore
#line 14 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\CollapsableSection\_collapsableSection.cshtml"
WriteAttributeValue("", 980, item.Value.UiPageMetadata.UiControlTypeName, 980, 44, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1024, "-", 1024, 1, true);
#nullable restore
#line 14 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\CollapsableSection\_collapsableSection.cshtml"
WriteAttributeValue("", 1025, item.Value.UiPageMetadata.Id, 1025, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"accordion-collapse collapse show\"");
            BeginWriteAttribute("aria-labelledby", " aria-labelledby=\"", 1096, "\"", 1149, 2);
            WriteAttributeValue("", 1114, "flush-", 1114, 6, true);
#nullable restore
#line 14 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\CollapsableSection\_collapsableSection.cshtml"
WriteAttributeValue("", 1120, item.Value.UiPageMetadata.Id, 1120, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-bs-parent=\"#accordionFlush-");
#nullable restore
#line 14 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\CollapsableSection\_collapsableSection.cshtml"
                                                                                                                                                                                                                                     Write(Model.Value.UiPageMetadata.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                    <div class=\"accordion-body\">\r\n");
#nullable restore
#line 17 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\CollapsableSection\_collapsableSection.cshtml"
                         foreach (var node in @item.Children)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\CollapsableSection\_collapsableSection.cshtml"
                       Write(await Html.PartialAsync("~/Views/Common/Components/_control.cshtml", node));

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\CollapsableSection\_collapsableSection.cshtml"
                                                                                                       
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 25 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\CollapsableSection\_collapsableSection.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"accordion-item\">\r\n                <h2 class=\"accordion-header\"");
            BeginWriteAttribute("id", " id=\"", 1776, "\"", 1816, 2);
            WriteAttributeValue("", 1781, "flush-", 1781, 6, true);
#nullable restore
#line 29 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\CollapsableSection\_collapsableSection.cshtml"
WriteAttributeValue("", 1787, item.Value.UiPageMetadata.Id, 1787, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <button class=\"accordion-button collapsed\" type=\"button\" data-bs-toggle=\"collapse\" data-bs-target=\"#flush-");
#nullable restore
#line 30 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\CollapsableSection\_collapsableSection.cshtml"
                                                                                                                         Write(item.Value.UiPageMetadata.UiControlTypeName);

#line default
#line hidden
#nullable disable
            WriteLiteral("-");
#nullable restore
#line 30 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\CollapsableSection\_collapsableSection.cshtml"
                                                                                                                                                                      Write(item.Value.UiPageMetadata.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" aria-expanded=\"true\"");
            BeginWriteAttribute("aria-controls", " aria-controls=\"", 2042, "\"", 2138, 4);
            WriteAttributeValue("", 2058, "flush-", 2058, 6, true);
#nullable restore
#line 30 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\CollapsableSection\_collapsableSection.cshtml"
WriteAttributeValue("", 2064, item.Value.UiPageMetadata.UiControlTypeName, 2064, 44, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2108, "-", 2108, 1, true);
#nullable restore
#line 30 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\CollapsableSection\_collapsableSection.cshtml"
WriteAttributeValue("", 2109, item.Value.UiPageMetadata.Id, 2109, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <span class=\"fab fa-leanpub me-2\"></span>\r\n                        ");
#nullable restore
#line 32 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\CollapsableSection\_collapsableSection.cshtml"
                   Write(item.Value.UiPageMetadata.UiControlDisplayName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </button>\r\n                </h2>\r\n                <div");
            BeginWriteAttribute("id", " id=\"", 2356, "\"", 2441, 4);
            WriteAttributeValue("", 2361, "flush-", 2361, 6, true);
#nullable restore
#line 35 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\CollapsableSection\_collapsableSection.cshtml"
WriteAttributeValue("", 2367, item.Value.UiPageMetadata.UiControlTypeName, 2367, 44, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2411, "-", 2411, 1, true);
#nullable restore
#line 35 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\CollapsableSection\_collapsableSection.cshtml"
WriteAttributeValue("", 2412, item.Value.UiPageMetadata.Id, 2412, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"accordion-collapse collapse\"");
            BeginWriteAttribute("aria-labelledby", " aria-labelledby=\"", 2478, "\"", 2531, 2);
            WriteAttributeValue("", 2496, "flush-", 2496, 6, true);
#nullable restore
#line 35 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\CollapsableSection\_collapsableSection.cshtml"
WriteAttributeValue("", 2502, item.Value.UiPageMetadata.Id, 2502, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-bs-parent=\"#accordionFlush-");
#nullable restore
#line 35 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\CollapsableSection\_collapsableSection.cshtml"
                                                                                                                                                                                                                                Write(Model.Value.UiPageMetadata.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                    <div class=\"accordion-body\">\r\n                        <div class=\"row ms-1 me-1\">\r\n");
#nullable restore
#line 38 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\CollapsableSection\_collapsableSection.cshtml"
                         foreach (var node in @item.Children)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\CollapsableSection\_collapsableSection.cshtml"
                       Write(await Html.PartialAsync("~/Views/Common/Components/_control.cshtml", node));

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\CollapsableSection\_collapsableSection.cshtml"
                                                                                                       
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 46 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\CollapsableSection\_collapsableSection.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\CollapsableSection\_collapsableSection.cshtml"
         
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TestingAndCalibrationLabs.Web.UI.Models.Node<TestingAndCalibrationLabs.Web.UI.Models.LayoutDTO>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
