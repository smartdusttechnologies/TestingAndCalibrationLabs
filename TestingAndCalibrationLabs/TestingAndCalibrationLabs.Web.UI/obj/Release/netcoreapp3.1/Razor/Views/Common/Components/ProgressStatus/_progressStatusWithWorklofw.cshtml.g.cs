#pragma checksum "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\ProgressStatus\_progressStatusWithWorklofw.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "72cc92b5c3617d8451cf5b587ddedf9e2f6bbf61"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Common_Components_ProgressStatus__progressStatusWithWorklofw), @"mvc.1.0.view", @"/Views/Common/Components/ProgressStatus/_progressStatusWithWorklofw.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"72cc92b5c3617d8451cf5b587ddedf9e2f6bbf61", @"/Views/Common/Components/ProgressStatus/_progressStatusWithWorklofw.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87ea9b8a111f12a73c09d93ec0c20de57828e725", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Common_Components_ProgressStatus__progressStatusWithWorklofw : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TestingAndCalibrationLabs.Web.UI.Models.Node<TestingAndCalibrationLabs.Web.UI.Models.LayoutDTO>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"
<style>
    .non-clickable{
        
    }
    h2 {
        color: #2F8D46;
    }
    #form {
        text-align: center;
        position: relative;
        margin-top: 20px
    }
        #form fieldset {
            background: white;
            border: 0 none;
            border-radius: 0.5rem;
            box-sizing: border-box;
            width: 100%;
            margin: 0;
            padding-bottom: 20px;
            position: relative
        }
    .finish {
        text-align: center
    }
    #form .previous-step, .next-step {
        width: 100px;
        font-weight: bold;
        color: white;
        border: 0 none;
        border-radius: 0px;
        cursor: pointer;
        padding: 10px 5px;
        margin: 10px 5px 10px 0px;
        float: right
    }
    .form, .previous-step {
        width: 110px;
        font-weight: bold;
        color: white;
        border: 0 none;
        border-radius: 0px;
        cursor: pointer;
        padding: 10px");
            WriteLiteral(@" 5px;
        margin: 10px 5px 10px 0px;
        float: left;
        background: #2F8D46;
        margin-top : 10px;
    }
    .form, .next-step {
        background: #2F8D46;
    }
    #form .previous-step:hover,
    #form .previous-step:focus {
        background-color: #fa9e4d;
    }
    #form .next-step:hover,
    #form .next-step:focus {
        background-color: #2F8D46;
    }
    .text {
        color: #2F8D46;
        font-weight: normal
    }
    #progressbar {
        margin-bottom: 30px;
        overflow: hidden;
        color: lightgrey;
        pointer-events: none;
    }
        #progressbar .active {
            color: #2F8D46
        }
        #progressbar li:before {
            text-align: center;
            width: 50px;
            height: 50px;
            line-height: 45px;
            display: block;
            font-size: 20px;
            color: #ffffff;
            background: lightgray;
            border-radius: 50%;
            margin: 0 au");
            WriteLiteral(@"to 10px auto;
            padding: 2px
        }
        #progressbar li:after {
            content: '';
            width: 100%;
            height: 2px;
            background: lightgray;
            position: absolute;
            left: 0;
            top: 25px;
            z-index: -1
        }
        #progressbar li.active:before,
        #progressbar li.active:after {
            background: #2F8D46
        }
    .progress {
        height: 20px
    }
    .progress-bar {
        background-color: #2F8D46
    }
</style>
<div class=""container"">
    <div class=""row justify-content-center"">
        <div");
            BeginWriteAttribute("class", " class=\"", 2792, "\"", 2800, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n            <div class=\"px-0 pt-4 pb-0 mt-3 mb-3\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "72cc92b5c3617d8451cf5b587ddedf9e2f6bbf617563", async() => {
                WriteLiteral("\r\n                    <ul id=\"progressbar\">\r\n");
#nullable restore
#line 116 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\ProgressStatus\_progressStatusWithWorklofw.cshtml"
                          
                            int count = 1;
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 119 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\ProgressStatus\_progressStatusWithWorklofw.cshtml"
                         foreach (var item in Model.Children)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 121 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\ProgressStatus\_progressStatusWithWorklofw.cshtml"
                             if (item.Children.Count() > 0)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <li class=\"active btn-step\"");
                BeginWriteAttribute("id", " id=\"", 3273, "\"", 3312, 2);
                WriteAttributeValue("", 3278, "step-", 3278, 5, true);
#nullable restore
#line 123 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\ProgressStatus\_progressStatusWithWorklofw.cshtml"
WriteAttributeValue("", 3283, item.Value.UiPageMetadata.Id, 3283, 29, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                    <input class=\"btn-select\" type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 3391, "\"", 3437, 2);
                WriteAttributeValue("", 3399, "fieldset_", 3399, 9, true);
#nullable restore
#line 124 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\ProgressStatus\_progressStatusWithWorklofw.cshtml"
WriteAttributeValue("", 3408, item.Value.UiPageMetadata.Id, 3408, 29, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("name", " name=\"", 3438, "\"", 3451, 1);
#nullable restore
#line 124 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\ProgressStatus\_progressStatusWithWorklofw.cshtml"
WriteAttributeValue("", 3445, count, 3445, 6, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                    <strong>");
#nullable restore
#line 125 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\ProgressStatus\_progressStatusWithWorklofw.cshtml"
                                       Write(item.Value.UiPageMetadata.UiControlDisplayName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</strong>\r\n                                </li>\r\n");
#nullable restore
#line 127 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\ProgressStatus\_progressStatusWithWorklofw.cshtml"
                                ++count;
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <li");
                BeginWriteAttribute("id", " id=\"", 3769, "\"", 3808, 2);
                WriteAttributeValue("", 3774, "step-", 3774, 5, true);
#nullable restore
#line 131 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\ProgressStatus\_progressStatusWithWorklofw.cshtml"
WriteAttributeValue("", 3779, item.Value.UiPageMetadata.Id, 3779, 29, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"btn-step\">\r\n                                    <input class=\"btn-select\" type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 3904, "\"", 3950, 2);
                WriteAttributeValue("", 3912, "fieldset_", 3912, 9, true);
#nullable restore
#line 132 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\ProgressStatus\_progressStatusWithWorklofw.cshtml"
WriteAttributeValue("", 3921, item.Value.UiPageMetadata.Id, 3921, 29, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("name", " name=\"", 3951, "\"", 3964, 1);
#nullable restore
#line 132 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\ProgressStatus\_progressStatusWithWorklofw.cshtml"
WriteAttributeValue("", 3958, count, 3958, 6, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                    <strong>");
#nullable restore
#line 133 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\ProgressStatus\_progressStatusWithWorklofw.cshtml"
                                       Write(item.Value.UiPageMetadata.UiControlDisplayName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</strong>\r\n                                </li>\r\n");
#nullable restore
#line 135 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\ProgressStatus\_progressStatusWithWorklofw.cshtml"
                                ++@count;
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 136 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\ProgressStatus\_progressStatusWithWorklofw.cshtml"
                             
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </ul>\r\n                    <div class=\"progress\">\r\n                        <div class=\"progress-bar\"></div>\r\n                    </div> <br>\r\n");
#nullable restore
#line 142 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\ProgressStatus\_progressStatusWithWorklofw.cshtml"
                     foreach (var item in Model.Children)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <fieldset");
                BeginWriteAttribute("id", " id=\"", 4487, "\"", 4530, 2);
                WriteAttributeValue("", 4492, "fieldset_", 4492, 9, true);
#nullable restore
#line 144 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\ProgressStatus\_progressStatusWithWorklofw.cshtml"
WriteAttributeValue("", 4501, item.Value.UiPageMetadata.Id, 4501, 29, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                            <div class=\"row ms-1 me-1\">\r\n");
#nullable restore
#line 146 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\ProgressStatus\_progressStatusWithWorklofw.cshtml"
                             foreach (var node in item.Children)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 148 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\ProgressStatus\_progressStatusWithWorklofw.cshtml"
                           Write(await Html.PartialAsync("~/Views/Common/Components/_control.cshtml", node));

#line default
#line hidden
#nullable disable
#nullable restore
#line 148 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\ProgressStatus\_progressStatusWithWorklofw.cshtml"
                                                                                                           
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                            </div>\r\n                        </fieldset>\r\n");
#nullable restore
#line 152 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\ProgressStatus\_progressStatusWithWorklofw.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n<script>\r\n    $(document).ready(function () {\r\n        var currentGfgStep, nextGfgStep, previousGfgStep;\r\n        var opacity;\r\n        var current = 1;\r\n        var modelData = JSON.parse(\'");
#nullable restore
#line 163 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\Common\Components\ProgressStatus\_progressStatusWithWorklofw.cshtml"
                               Write(Json.Serialize(Model));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"');
        var steps = modelData.children.length;
        var percentofWidth = parseFloat(100 / steps)  ;
        percentofWidth = percentofWidth;
        var str = ""#progressbar li {list-style-type:none;font-size:15px;width:"" + percentofWidth + ""%;float:left;position: relative;font-weight:400; text-align:center;}"";
        var utrstyle = document.createElement(""style"")
        utrstyle.innerText = str;
        document.head.appendChild(utrstyle);
        for (var i = 0; steps > i; i++) {
           
            var stepId = ""#step-"" + modelData.children[i].value.uiPageMetadata.id;
            var contentCount = i + 1;
            var styleOfStep = ""#progressbar "" + stepId + "":before{content:'"" + contentCount + ""'} "";
            var styleSheet = document.createElement(""style"")
            styleSheet.innerText = styleOfStep;
            document.head.appendChild(styleSheet)
            if (modelData.children[i].children.length > 0) {
                var fieldId = ""#fieldset_"" + modelData.chi");
            WriteLiteral(@"ldren[i].value.uiPageMetadata.id;
                currentGfgStep = $(fieldId);
                currentGfgStep.show();
                current = i + 1;
                activeCurrentStep(current)
            }
            else {
                var fieldId = ""#fieldset_"" + modelData.children[i].value.uiPageMetadata.id;
                $(fieldId).hide();
            }
        }
        setProgressBar(current);
        var workflow = $(""#workflowStageChecker"");
        //var isWorkflowWorking
        //Function To Set Progress Status Active
        function activeCurrentStep(stepNumber){
            for (var ind = 0; steps > ind; ind++) {
                var addInStep = stepNumber-1;
                if(ind<stepNumber){
                    var idOfStep = ""#step-"" + modelData.children[ind].value.uiPageMetadata.id;
                    var stepMakeActive = $(idOfStep);
                    stepMakeActive.addClass(""active"");
                } else if (ind > addInStep) {
                    var id");
            WriteLiteral(@"OfStep = ""#step-"" + modelData.children[ind].value.uiPageMetadata.id;
                    var stepMakeActive = $(idOfStep);
                    stepMakeActive.removeClass(""active"");
                }
            }
        }
        //Function To Handle Progress Status Clicks
        //$("".btn-step"").click(function () {
        //    var btnOfStep = $(this).children("".btn-select"");
        //    var currentFieldSetId = btnOfStep[0].value;
        //    var stepCount = btnOfStep[0].name;
        //    var x = parseInt(stepCount, 10); // you want to use radix 10
        //    var idModifiewithHash = ""#""+currentFieldSetId;
        //    nextGfgStep = $(idModifiewithHash);
        //    activeCurrentStep(x);
        //            currentGfgStep.css({
        //                'display': 'none',
        //                'position': 'relative',
        //                'opacity' : 0
        //            });
        //    nextGfgStep.css({ 'display': 'block', 'opacity': 1 });
        //    setP");
            WriteLiteral(@"rogressBar(x);
        //    current= x;
        //    currentGfgStep = nextGfgStep;
        //});
        ////Fuction To Handle Next Button Click
        //$("".next-step"").click(function () {
        //    currentGfgStep = $(this).parent();
        //    nextGfgStep = $(this).parent().next();
        //    $(""#progressbar li"").eq($(""fieldset"")
        //        .index(nextGfgStep)).addClass(""active"");
        //    currentGfgStep.css({
        //        'display': 'none',
        //        'position': 'relative',
        //        'opacity': 0
        //    });
        //    nextGfgStep.css({ 'display': 'block', 'opacity': 1 });
        //    setProgressBar(++current);
        //    currentGfgStep = nextGfgStep;
        //});
        ////Function To Handle Previous Button
        //$("".previous-step"").click(function () {
        //    currentGfgStep = $(this).parent();
        //    previousGfgStep = $(this).parent().prev();
        //    $(""#progressbar li"").eq($(""fieldset"")
        ");
            WriteLiteral(@"//        .index(currentGfgStep)).removeClass(""active"");
        //            currentGfgStep.css({
        //                'display': 'none',
        //                'position': 'relative',
        //                'opacity' : 0
        //            });
        //            previousGfgStep.css({ 'display' : 'block', 'opacity': 1 });
        //    setProgressBar(--current);
        //    currentGfgStep = previousGfgStep;
        //});
        //Fuction To Manage Progress Bar Line
        function setProgressBar(currentStep) {
            var percent = parseFloat(100 / steps) * currentStep;
            percent = percent.toFixed();
            $("".progress-bar"")
                .css(""width"", percent + ""%"")
        }
        $("".submit"").click(function () {
            return false;
        })
    });
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TestingAndCalibrationLabs.Web.UI.Models.Node<TestingAndCalibrationLabs.Web.UI.Models.LayoutDTO>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
