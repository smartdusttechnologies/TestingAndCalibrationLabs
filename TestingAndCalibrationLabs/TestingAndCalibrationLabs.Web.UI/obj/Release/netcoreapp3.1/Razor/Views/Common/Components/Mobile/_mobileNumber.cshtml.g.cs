#pragma checksum "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\Mobile\_mobileNumber.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e9a55690d58ee427801930cd116f90f2cf6c54a6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Common_Components_Mobile__mobileNumber), @"mvc.1.0.view", @"/Views/Common/Components/Mobile/_mobileNumber.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e9a55690d58ee427801930cd116f90f2cf6c54a6", @"/Views/Common/Components/Mobile/_mobileNumber.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87ea9b8a111f12a73c09d93ec0c20de57828e725", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Common_Components_Mobile__mobileNumber : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TestingAndCalibrationLabs.Web.UI.Models.Node<TestingAndCalibrationLabs.Web.UI.Models.LayoutDTO>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"col-lg-6  col-sm-12 col-xs-12 mt-3 form-element-for-common-control  right-pd-frm-input\">\r\n    <input class=\"form-input width-full black-border\" type=\"tel\"");
            BeginWriteAttribute("id", " id=\"", 270, "\"", 350, 2);
#nullable restore
#line 3 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\Mobile\_mobileNumber.cshtml"
WriteAttributeValue("", 275, Model.Value.UiPageMetadata.UiControlTypeName, 275, 45, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\Mobile\_mobileNumber.cshtml"
WriteAttributeValue("", 320, Model.Value.UiPageMetadata.Id, 320, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" placeholder=\" \"");
            BeginWriteAttribute("name", " name=\"", 367, "\"", 449, 2);
#nullable restore
#line 3 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\Mobile\_mobileNumber.cshtml"
WriteAttributeValue("", 374, Model.Value.UiPageMetadata.UiControlTypeName, 374, 45, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\Mobile\_mobileNumber.cshtml"
WriteAttributeValue("", 419, Model.Value.UiPageMetadata.Id, 419, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" onchange=\"this.setAttribute(\'value\',this.value)\" maxlength=\"10\" />\r\n    <label class=\"form-label\"");
            BeginWriteAttribute("for", " for=\"", 548, "\"", 629, 2);
#nullable restore
#line 4 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\Mobile\_mobileNumber.cshtml"
WriteAttributeValue("", 554, Model.Value.UiPageMetadata.UiControlTypeName, 554, 45, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\Mobile\_mobileNumber.cshtml"
WriteAttributeValue("", 599, Model.Value.UiPageMetadata.Id, 599, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        ");
#nullable restore
#line 5 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\Mobile\_mobileNumber.cshtml"
   Write(Model.Value.UiPageMetadata.UiControlDisplayName);

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\Mobile\_mobileNumber.cshtml"
                                                         if (Model.Value.UiPageMetadata.IsRequired)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <span class=\"red-color\">*</span>\r\n");
#nullable restore
#line 8 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\Mobile\_mobileNumber.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e9a55690d58ee427801930cd116f90f2cf6c54a68019", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 9 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\Mobile\_mobileNumber.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.Value.UiPageMetadata.UiControlDisplayName);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n<script>\r\n    $(document).ready(function () {\r\n        var idOfRecord = $(\"#Id\").val();\r\n        var modelData = JSON.parse(\'");
#nullable restore
#line 14 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\Mobile\_mobileNumber.cshtml"
                               Write(Json.Serialize(Model));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"');
        var uiPageData = modelData.value.uiPageData;
        if (idOfRecord != undefined && uiPageData != null) {
            var lookupCategoryId = modelData.value.uiPageMetadata.moduleId;
            var id = ""#"" + modelData.value.uiPageMetadata.uiControlTypeName + modelData.value.uiPageMetadata.id;
            var val = uiPageData.value;
            $(id).val(val);
        }
    });
</script>");
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
