#pragma checksum "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Dashboard\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2b8b23a1d2648ce8a03aba8b1818bd4de90a70bf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Administration_Views_Dashboard_Index), @"mvc.1.0.view", @"/Areas/Administration/Views/Dashboard/Index.cshtml")]
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
#line 1 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\_ViewImports.cshtml"
using BloodDonorship.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\_ViewImports.cshtml"
using BloodDonorship.Web.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b8b23a1d2648ce8a03aba8b1818bd4de90a70bf", @"/Areas/Administration/Views/Dashboard/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f160449b265307173b56316518e7b43f8073fd00", @"/Areas/Administration/Views/_ViewImports.cshtml")]
    public class Areas_Administration_Views_Dashboard_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BloodDonorship.Web.ViewModels.Administration.Dashboard.IndexViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Administration", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Notifications", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AllToAdmin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary float-right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Users", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AllDeleted", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-danger float-right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteUser", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Dashboard\Index.cshtml"
  
    this.ViewData["Title"] = "Admin dashboard";
    int count = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Dashboard\Index.cshtml"
 if (this.TempData["InfoMessage"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-success\">");
#nullable restore
#line 9 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Dashboard\Index.cshtml"
                                Write(this.TempData["InfoMessage"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 10 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Dashboard\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-lg-6\"><h3>");
#nullable restore
#line 13 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Dashboard\Index.cshtml"
                         Write(this.ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3></div>\r\n    <div class=\"col-lg-6\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2b8b23a1d2648ce8a03aba8b1818bd4de90a70bf8168", async() => {
                WriteLiteral("Notifications");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2b8b23a1d2648ce8a03aba8b1818bd4de90a70bf9827", async() => {
                WriteLiteral("Deleted Users");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n    <div class=\"clearfix\"></div>\r\n</div>\r\n<hr />\r\n\r\n\r\n<p>Today: <time");
            BeginWriteAttribute("datetime", " datetime=\"", 769, "\"", 810, 1);
#nullable restore
#line 23 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Dashboard\Index.cshtml"
WriteAttributeValue("", 780, DateTime.UtcNow.ToString("O"), 780, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></time></p>\r\n\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-sm-6\">\r\n        <div class=\"card\">\r\n            <div class=\"card-body\">\r\n                <p>Total users: ");
#nullable restore
#line 30 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Dashboard\Index.cshtml"
                           Write(Model.UsersCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p>Total requests: ");
#nullable restore
#line 31 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Dashboard\Index.cshtml"
                              Write(Model.RequestsCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p>Total donations: ");
#nullable restore
#line 32 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Dashboard\Index.cshtml"
                               Write(Model.DonationsCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"col-sm-6\">\r\n        <div class=\"card\">\r\n            <div class=\"card-body\">\r\n                <p>Most wanted blood type: ");
#nullable restore
#line 39 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Dashboard\Index.cshtml"
                                      Write(Model.MostWantedBloodType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p>Most donated blood type: ");
#nullable restore
#line 40 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Dashboard\Index.cshtml"
                                       Write(Model.MostDonatedBloodType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p>Available donors: ");
#nullable restore
#line 41 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Dashboard\Index.cshtml"
                                Write(Model.AvailableDonors);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
            </div>
        </div>
    </div>
</div>


<hr />

<table class=""table table-striped"">
    <thead>
        <tr>
            <th scope=""col"">#</th>
            <th scope=""col"">Registered On</th>
            <th scope=""col"">Username</th>
            <th scope=""col"">Blood Type</th>
            <th scope=""col"">Requests</th>
            <th scope=""col"">Donations</th>
            <th scope=""col""></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 63 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Dashboard\Index.cshtml"
         foreach (var user in Model.Users)
        {
            string confirmDelete = string.Concat("confirmDelete", user.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 67 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Dashboard\Index.cshtml"
               Write(count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td><time");
            BeginWriteAttribute("datetime", " datetime=\"", 2156, "\"", 2196, 1);
#nullable restore
#line 68 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Dashboard\Index.cshtml"
WriteAttributeValue("", 2167, user.CreatedOn.ToString("O"), 2167, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></time></td>\r\n                <td>");
#nullable restore
#line 69 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Dashboard\Index.cshtml"
               Write(user.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 70 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Dashboard\Index.cshtml"
                Write(string.Concat(user.BloodBloodType, " ", user.BloodRhFactor));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 71 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Dashboard\Index.cshtml"
               Write(user.Requests.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 72 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Dashboard\Index.cshtml"
               Write(user.Donations.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>\r\n                    \r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2b8b23a1d2648ce8a03aba8b1818bd4de90a70bf17990", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 76 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Dashboard\Index.cshtml"
                         if (user.UserName != "Admin")
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <button class=\"btn btn-danger\" type=\"button\" data-toggle=\"modal\" data-target=\"#");
#nullable restore
#line 78 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Dashboard\Index.cshtml"
                                                                                                      Write(confirmDelete);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" data-id=\"");
#nullable restore
#line 78 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Dashboard\Index.cshtml"
                                                                                                                               Write(user.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral("\">Delete</button>\r\n");
#nullable restore
#line 79 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Dashboard\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        <!-- The Modal -->\r\n                        <div class=\"modal\"");
                BeginWriteAttribute("id", " id=\"", 2971, "\"", 2990, 1);
#nullable restore
#line 82 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Dashboard\Index.cshtml"
WriteAttributeValue("", 2976, confirmDelete, 2976, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">
                            <div class=""modal-dialog"">
                                <div class=""modal-content"">

                                    <!-- Modal Header -->
                                    <div class=""modal-header"">
                                        <h4 class=""modal-title text-danger"">Warning!</h4>
                                        <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
                                    </div>

                                    <!-- Modal body -->
                                    <div class=""modal-body"">
                                        Are you sure you want to delete user: ");
#nullable restore
#line 94 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Dashboard\Index.cshtml"
                                                                         Write(user.UserName);

#line default
#line hidden
#nullable disable
                WriteLiteral("?\r\n                                        ");
#nullable restore
#line 95 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Dashboard\Index.cshtml"
                                   Write(user.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                    </div>

                                    <!-- Modal footer -->
                                    <div class=""modal-footer"">
                                        <button type=""button"" class=""btn btn-outline-primary"" data-dismiss=""modal"">Cancel</button>
                                        <input type=""submit"" class=""btn btn-danger text-white"" id=""delete"" value=""Delete"" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-userId", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 75 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Dashboard\Index.cshtml"
                                                                                                         WriteLiteral(user.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["userId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-userId", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["userId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 109 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Dashboard\Index.cshtml"
            count++;
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    </tbody>\r\n</table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BloodDonorship.Web.ViewModels.Administration.Dashboard.IndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591