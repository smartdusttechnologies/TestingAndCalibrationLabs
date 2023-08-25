#pragma checksum "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\TestReport\TestReportView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9e9d9dd49ca529422fed06f2b43c7458017a3f44"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TestReport_TestReportView), @"mvc.1.0.view", @"/Views/TestReport/TestReportView.cshtml")]
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
#nullable restore
#line 1 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\TestReport\TestReportView.cshtml"
using AttachmentDTO = TestingAndCalibrationLabs.Web.UI.Models.AttachmentDTO;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e9d9dd49ca529422fed06f2b43c7458017a3f44", @"/Views/TestReport/TestReportView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87ea9b8a111f12a73c09d93ec0c20de57828e725", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_TestReport_TestReportView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TestingAndCalibrationLabs.Web.UI.Models.TestReportDTO>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""border width-full"" style=""margin:0;padding:0;border-bottom:2px solid !important;"">
    <div class=""row mb-1"">
        <div class=""col-xs-12 col-sm-7 col-md-8 col-lg-9 mt-2"">
            <h2 class=""mb-2 ms-1 me-1"" style=""padding:0px 12px;"">Test Details</h2>
        </div>
    </div>

    <div class=""table-responsive simple-pagination card shadow border-radius-grid"">
                                 
        <table id=""testDetailsGrid"" class=""table table-striped display"" style=""width:100%"">
            <thead>
                <tr>
                    <th>");
#nullable restore
#line 16 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\TestReport\TestReportView.cshtml"
                   Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n\r\n                    <th>");
#nullable restore
#line 18 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\TestReport\TestReportView.cshtml"
                   Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n\r\n                    <th>");
#nullable restore
#line 20 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\TestReport\TestReportView.cshtml"
                   Write(Html.DisplayNameFor(model => model.Client));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n\r\n                    <th>");
#nullable restore
#line 22 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\TestReport\TestReportView.cshtml"
                   Write(Html.DisplayNameFor(model => model.JobId));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n\r\n                    <th>");
#nullable restore
#line 24 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\TestReport\TestReportView.cshtml"
                   Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n\r\n                    <th>Actions</th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n\r\n");
#nullable restore
#line 31 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\TestReport\TestReportView.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td> ");
#nullable restore
#line 34 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\TestReport\TestReportView.cshtml"
                        Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td> ");
#nullable restore
#line 35 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\TestReport\TestReportView.cshtml"
                        Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td> ");
#nullable restore
#line 36 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\TestReport\TestReportView.cshtml"
                        Write(Html.DisplayFor(modelItem => item.Client));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td> ");
#nullable restore
#line 37 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\TestReport\TestReportView.cshtml"
                        Write(Html.DisplayFor(modelItem => item.JobId));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td> ");
#nullable restore
#line 38 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\TestReport\TestReportView.cshtml"
                        Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>\r\n                            <a");
            BeginWriteAttribute("id", " id=\"", 1726, "\"", 1752, 2);
            WriteAttributeValue("", 1731, "dataDownload_", 1731, 13, true);
#nullable restore
#line 40 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\TestReport\TestReportView.cshtml"
WriteAttributeValue("", 1744, item.Id, 1744, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 1753, "\"", 1791, 3);
            WriteAttributeValue("", 1763, "DwonloadReportAjax(", 1763, 19, true);
#nullable restore
#line 40 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\TestReport\TestReportView.cshtml"
WriteAttributeValue("", 1782, item.Id, 1782, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1790, ")", 1790, 1, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\'fa fa-cloud-download\'></i></a><b>||</b>\r\n                            <a");
            BeginWriteAttribute("id", " id=\"", 1874, "\"", 1896, 2);
            WriteAttributeValue("", 1879, "sendMail_", 1879, 9, true);
#nullable restore
#line 41 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\TestReport\TestReportView.cshtml"
WriteAttributeValue("", 1888, item.Id, 1888, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 1897, "\"", 1929, 3);
            WriteAttributeValue("", 1907, "sendMailAjax(", 1907, 13, true);
#nullable restore
#line 41 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\TestReport\TestReportView.cshtml"
WriteAttributeValue("", 1920, item.Id, 1920, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1928, ")", 1928, 1, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-envelope\"></i></a>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 44 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\TestReport\TestReportView.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </tbody>
        </table>
    </div>
    
    <div>
        <div class=""d-flex justify-content-center fixed-bottom"">
            <div class=""alert alert-success"" role=""alert"" id=""snackbarsuccess"">    
             <div class=""MuiPaper-root MuiPaper-elevation MuiPaper-rounded MuiPaper-elevation6 MuiAlert-root MuiAlert-filledSuccess MuiAlert-filled css-1lgz3mj"" role=""alert"">
                 <div class=""MuiAlert-icon css-1l54tgj""><svg class=""MuiSvgIcon-root MuiSvgIcon-fontSizeInherit css-1cw4hi4"" focusable=""false"" aria-hidden=""true"" viewBox=""0 0 24 24"">
                     <path d=""M20,12A8,8 0 0,1 12,20A8,8 0 0,1 4,12A8,8 0 0,1 12,4C12.76,4 13.5,4.11 14.2, 4.31L15.77,2.74C14.61,2.26 13.34,2 12,2A10,10 0 0,0 2,12A10,10 0 0,0 12,22A10,10 0 0, 0 22,12M7.91,10.08L6.5,11.5L11,16L21,6L19.59,4.58L11,13.17L7.91,10.08Z""></path>
                     </svg></div><div class=""MuiAlert-message css-1xsto0d"">Email sent successfully!, Thank You</div></div>
            </div>
       </div>
    </div>
");
            WriteLiteral(@"
    <div>
        <div class=""d-flex justify-content-center fixed-bottom"">
            <div class=""alert alert-success"" role=""alert"" id=""snackbarsuccessMail"">    
             <div class=""MuiPaper-root MuiPaper-elevation MuiPaper-rounded MuiPaper-elevation6 MuiAlert-root MuiAlert-filledSuccess MuiAlert-filled css-1lgz3mj"" role=""alert"">
                 <div class=""MuiAlert-icon css-1l54tgj""><svg class=""MuiSvgIcon-root MuiSvgIcon-fontSizeInherit css-1cw4hi4"" focusable=""false"" aria-hidden=""true"" viewBox=""0 0 24 24"">
                     <path d=""M20,12A8,8 0 0,1 12,20A8,8 0 0,1 4,12A8,8 0 0,1 12,4C12.76,4 13.5,4.11 14.2, 4.31L15.77,2.74C14.61,2.26 13.34,2 12,2A10,10 0 0,0 2,12A10,10 0 0,0 12,22A10,10 0 0, 0 22,12M7.91,10.08L6.5,11.5L11,16L21,6L19.59,4.58L11,13.17L7.91,10.08Z""></path>
                     </svg></div><div class=""MuiAlert-message css-1xsto0d"">File downloaded successfully!, Thank You</div></div>
            </div>
       </div>
    </div>

    <div >
            <div class=""d-flex ju");
            WriteLiteral(@"stify-content-center fixed-bottom"">
            <div class=""alert alert-danger"" role=""alert"" id=""snackbarerror"">
              <div class=""MuiPaper-root MuiPaper-elevation MuiPaper-rounded MuiPaper-elevation6 MuiAlert-root MuiAlert-filledError MuiAlert-filled css-1ufabz4"" role=""alert"">
                  <div class=""MuiAlert-icon css-1l54tgj""><svg class=""MuiSvgIcon-root MuiSvgIcon-fontSizeInherit css-1cw4hi4"" focusable=""false""  viewBox=""0 0 24 24"">
                      <path d=""M11 15h2v2h-2zm0-8h2v6h-2zm.99-5C6.47 2 2 6.48 2 12s4.47 10 9.99 10C17.52 22 22 17.52 22 12S17.52 2 11.99 2zM12 20c-4.42 0-8-3.58-8-8s3.58-8 8-8 8 3.58 8 8-3.58 8-8 8z""></path></svg></div>
              <div class=""MuiAlert-message css-1xsto0d"" id=""errormessage"">Request Can't be completed !! Please try again.</div></div>
            </div>
        </div>
     </div>
     
</div>

<script>
     //This function will display the success snackbar
      function myFunctionSuccess() {
          var x = document.getElementById(");
            WriteLiteral(@"""snackbarsuccess"");
          x.className = ""show"";
          setTimeout(function(){ x.className = x.className.replace(""show"", """"); }, 4000);
      }
      //This function will display the success snackbar on mail link send.
      function myFunctionMailReport() {
          var x = document.getElementById(""snackbarsuccessMail"");
          x.className = ""show"";
          setTimeout(function(){ x.className = x.className.replace(""show"", """"); }, 4000);
      }

       //This function will display the Failure snackbar
          function myFunctionError() {
          var x = document.getElementById(""snackbarerror"");
          x.className = ""show"";
          setTimeout(function(){ x.className = x.className.replace(""show"", """"); }, 4000);
      }
   </script>

  <script>
        oTable = $('#testDetailsGrid').DataTable({
            pageLength: 5,
            lengthMenu: [
            [5, 10, 25, 50, -1],
            [5, 10, 25, 50, 'All']
        ],
            scrollX: true,
        });
 ");
            WriteLiteral(@"       $('#TestDetailsGridSearch').keyup(function() {
            oTable.search($(this).val()).draw();
        })
  </script>
 
 <script type=""text/javascript"">
    function sendMailAjax(e) {
        var spinner = '<div class=""spinner-border text-primary"" role=""status""> <span class=""visually-hidden"">Loading...</span></div>';
        var linkData = ""#sendMail_"" + e;
        var originalLinkData = $(linkData).html();
        $(linkData).html(spinner);
        $.ajax({
            type: ""POST"",
            url: '");
#nullable restore
#line 128 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\TestReport\TestReportView.cshtml"
             Write(Url.Action("sendEmail", "TestReport"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
            data: {Id :e},
            success: function (response) { 
               $(linkData).html(originalLinkData);
               myFunctionSuccess();
            },
            error: function(response) {
                $(linkData).html(originalLinkData);
                myFunctionError();
            },
        });
    }
</script>

<script type=""text/javascript"">
    function DwonloadReportAjax(e) {
         var spinner = '<div class=""spinner-border text-primary"" role=""status""> <span class=""visually-hidden"">Loading...</span></div>';
         var linkData = ""#dataDownload_"" + e;
         var originalLinkData = $(linkData).html();
         $(linkData).html(spinner);   
        $.ajax({
            type: ""POST"",
            url: '");
#nullable restore
#line 150 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\TestReport\TestReportView.cshtml"
             Write(Url.Action("TestReportDownload", "TestReport"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\',\r\n            data: {Id :e},\r\n            success: function(response) {\r\n                location.href = \'");
#nullable restore
#line 153 "D:\SmartDust\Auth\TestingAndCalibrationLabs\TestingAndCalibrationLabs\TestingAndCalibrationLabs.Web.UI\Views\TestReport\TestReportView.cshtml"
                            Write(Url.Action("DownloadFile", "TestReport"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"?fileId=' + response;
                $(linkData).html(originalLinkData);
                myFunctionMailReport();
            }              
        });
    }
</script>
<style>
    .spinner-border {
    height: 15px;
    width: 15px;
}
</style>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TestingAndCalibrationLabs.Web.UI.Models.TestReportDTO>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
