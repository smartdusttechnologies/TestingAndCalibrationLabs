#pragma checksum "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1b0a4add504275b74e1e31b079a6514e5289163f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Common_Edit), @"mvc.1.0.view", @"/Views/Common/Edit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b0a4add504275b74e1e31b079a6514e5289163f", @"/Views/Common/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87ea9b8a111f12a73c09d93ec0c20de57828e725", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Common_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TestingAndCalibrationLabs.Web.UI.Models.RecordDTO>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("Id"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "Id", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("commonForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Common", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Edit.cshtml"
  
    ViewData["Title"] = "CreateLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral("<style>\r\n    .fixed-bottom {\r\n        position: relative;\r\n    }\r\n</style>\r\n<div class=\"container-fluid\">\r\n    <div>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1b0a4add504275b74e1e31b079a6514e5289163f6861", async() => {
                WriteLiteral("\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1b0a4add504275b74e1e31b079a6514e5289163f7131", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 13 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Edit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1b0a4add504275b74e1e31b079a6514e5289163f8858", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 14 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Edit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Id);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Name = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1b0a4add504275b74e1e31b079a6514e5289163f10909", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 15 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Edit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ModuleId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1b0a4add504275b74e1e31b079a6514e5289163f12673", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 16 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Edit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.UiPageTypeId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1b0a4add504275b74e1e31b079a6514e5289163f14441", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 17 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Edit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.WorkflowStageId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1b0a4add504275b74e1e31b079a6514e5289163f16212", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 18 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Edit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.UpdatedDate);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            <div class=\"row ms-1 me-1\">\r\n");
#nullable restore
#line 20 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Edit.cshtml"
                 foreach (var item in Model.Layout)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Edit.cshtml"
               Write(await Html.PartialAsync("~/Views/Common/Components/_control.cshtml", item));

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Edit.cshtml"
                                                                                               
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </div>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        <div class=""form-group"" style=""margin:6px;"" id=""sub-mt-btn"">
            <input type=""button"" id=""createbtn"" value=""Save"" class=""button-base button-material-primary"" onclick=""AjaxFormSubmit()"" />
        </div>
    </div>
</div>

<div>
    <div class=""d-flex justify-content-center fixed-bottom"">
        <div class=""alert alert-success"" role=""alert"" id=""snackbarsuccess"">
            <div class=""MuiPaper-root MuiPaper-elevation MuiPaper-rounded MuiPaper-elevation6 MuiAlert-root MuiAlert-filledSuccess MuiAlert-filled css-1lgz3mj"" role=""alert"">
                <div class=""MuiAlert-icon css-1l54tgj"">
                    <svg class=""MuiSvgIcon-root MuiSvgIcon-fontSizeInherit css-1cw4hi4"" focusable=""false"" aria-hidden=""true"" viewBox=""0 0 24 24"">
                        <path d=""M20,12A8,8 0 0,1 12,20A8,8 0 0,1 4,12A8,8 0 0,1 12,4C12.76,4 13.5,4.11 14.2, 4.31L15.77,2.74C14.61,2.26 13.34,2 12,2A10,10 0 0,0 2,12A10,10 0 0,0 12,22A10,10 0 0, 0 22,12M7.91,10.08L6.5,11.5L11,16L21,6L19.59,4.58L11,13.1");
            WriteLiteral(@"7L7.91,10.08Z""></path>
                    </svg>
                </div><div class=""MuiAlert-message css-1xsto0d"">Saved successfully!</div>
            </div>
        </div>
    </div>
</div>
<div>
    <div class=""d-flex justify-content-center fixed-bottom"">
        <div role=""alert"" id=""snackbarerror"">
            <div class=""MuiPaper-root MuiPaper-elevation MuiPaper-rounded MuiPaper-elevation6 MuiAlert-root MuiAlert-filledError MuiAlert-filled css-1ufabz4"" role=""alert"">
                <div class=""MuiAlert-icon css-1l54tgj"">
                    <svg class=""MuiSvgIcon-root MuiSvgIcon-fontSizeInherit css-1cw4hi4"" focusable=""false"" viewBox=""0 0 24 24"">
                        <path d=""M11 15h2v2h-2zm0-8h2v6h-2zm.99-5C6.47 2 2 6.48 2 12s4.47 10 9.99 10C17.52 22 22 17.52 22 12S17.52 2 11.99 2zM12 20c-4.42 0-8-3.58-8-8s3.58-8 8-8 8 3.58 8 8-3.58 8-8 8z""></path>
                    </svg>
                </div>
                <div class=""MuiAlert-message css-1xsto0d"" id=""errormessage"">!</div>
   ");
            WriteLiteral(@"         </div>
        </div>
    </div>
</div>

<script>
    //This function will display the success snackbar
    function myFunction() {
        var x = document.getElementById(""snackbarsuccess"");
        x.className = ""show"";
        setTimeout(function () { x.className = x.className.replace(""show"", """"); }, 3000);
    }
    //This function will display the Failure snackbar
    function myFunctionError() {
        var x = document.getElementById(""snackbarerror"");
        x.className = ""show"";
        setTimeout(function () { x.className = x.className.replace(""show"", """"); }, 3000);
    }
</script>
<script type=""text/javascript"">
    var mainModel = JSON.parse('");
#nullable restore
#line 75 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Edit.cshtml"
                           Write(Json.Serialize(Model));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"');
    var updatedDate = mainModel.updatedDate;
    var uiPageTypeId = parseInt($(""#UiPageTypeId"").val())
    var moduleId = parseInt($(""#ModuleId"").val())
    var id = parseInt($(""#Id"").val())
    var url = $(""#commonForm"").attr(""action"");
    AjaxFormSubmit = () => {
        WheelLoader();
        let workflowStageId = parseInt($(""#WorkflowStageId"").val())
        //here I am flatting the hirarchy of Node<Layout> To A List of Layout
        const getMembers = (member) => {

            if (!member.children || !member.children.length) {
                return member.value;
            }
            return [member.value, _.flatMapDeep(member.children, getMembers)];
        }
        var layout = _.flatMapDeep(mainModel.layout, getMembers);
        var fieldValues = [];
        for (let i = 0; i < layout.length; i++) {
            if (layout[i].uiPageMetadata.controlCategoryName == ""DataControl"" && layout[i].uiPageMetadata.multiValueControl != true) {
                var fieldId = ""#"" + l");
            WriteLiteral(@"ayout[i].uiPageMetadata.uiControlTypeName + layout[i].uiPageMetadata.id;
                if ($(fieldId).hasClass(""red-error-border"")) {
                    $(fieldId).removeClass(""red-error-border"").addClass(""black-border"");
                }
                var metadataId = layout[i].uiPageMetadata.id;
                var fieldValue = $(fieldId).val();
                var keyValuepair = {};
                var uiPageData = layout[i].uiPageData;
                if (layout[i].uiPageData != null) {
                    var pageDataId = layout[i].uiPageData.id;
                    var oldValue = layout[i].uiPageData.value;
                    if (oldValue != fieldValue) {
                        keyValuepair.Id = pageDataId;
                        keyValuepair.uiPageMetadataId = metadataId;
                        keyValuepair.RecordId = id;
                        keyValuepair.Value = fieldValue;
                        keyValuepair.UiPageTypeId = uiPageTypeId;
                        fieldValu");
            WriteLiteral(@"es.push(keyValuepair)
                    }
                }
                else {
                    keyValuepair.Id = 0;
                    keyValuepair.uiPageMetadataId = metadataId;
                    keyValuepair.RecordId = id;
                    keyValuepair.Value = fieldValue;
                    keyValuepair.UiPageTypeId = uiPageTypeId;
                    fieldValues.push(keyValuepair)
                }
            }
        }
        $.ajax({
            type: 'POST',
            url: url,
            data: { id, workflowStageId, updatedDate, moduleId, uiPageTypeId, fieldValues },
            success: function (response) {
                myFunction();
                window.location.href = ""/common/edit/"" + id;
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                HideWheelLoader();
                var newresponseJSON = response.responseJSON;     ");
            WriteLiteral(@"               //assiging the values of responseJson to  newresponseJSON
                var newErrorMessage = newresponseJSON.errorMessage;               //assiging the values of errorMessage to  newErrorMessage
                for (var i = 0; i < newErrorMessage.length; i++) {
                    var sourceId = ""#"" + newErrorMessage[i].sourceId;
                    $(sourceId).removeClass(""black-border"").addClass(""red-error-border"");
                    myFunctionError();                                              //Calling myFunctionError javacript function
                    ErrorMessage(NotificationNumbers++, newErrorMessage[i].reason);
                    if (i == 0) {
                        document.getElementById(""errormessage"").innerHTML = newErrorMessage[i].reason;
                    }

                }
            }
        });
    }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TestingAndCalibrationLabs.Web.UI.Models.RecordDTO> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
