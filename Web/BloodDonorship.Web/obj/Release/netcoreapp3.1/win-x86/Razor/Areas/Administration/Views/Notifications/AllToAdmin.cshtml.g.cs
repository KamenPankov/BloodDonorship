#pragma checksum "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Notifications\AllToAdmin.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b53693c61fe93a45964940da893c316aae8d6359"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Administration_Views_Notifications_AllToAdmin), @"mvc.1.0.view", @"/Areas/Administration/Views/Notifications/AllToAdmin.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b53693c61fe93a45964940da893c316aae8d6359", @"/Areas/Administration/Views/Notifications/AllToAdmin.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f160449b265307173b56316518e7b43f8073fd00", @"/Areas/Administration/Views/_ViewImports.cshtml")]
    public class Areas_Administration_Views_Notifications_AllToAdmin : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BloodDonorship.Web.ViewModels.Administration.Notifications.AllNotificationsAdminViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Administration", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Dashboard", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Notifications", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Answer", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Notifications\AllToAdmin.cshtml"
 if (this.TempData["InfoMessage"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-success\">\r\n        ");
#nullable restore
#line 6 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Notifications\AllToAdmin.cshtml"
   Write(this.TempData["InfoMessage"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 8 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Notifications\AllToAdmin.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 10 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Notifications\AllToAdmin.cshtml"
  
    ViewData["Title"] = "Notifications";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-lg-6\">\r\n        <h4>");
#nullable restore
#line 16 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Notifications\AllToAdmin.cshtml"
       Write(this.ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(": ");
#nullable restore
#line 16 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Notifications\AllToAdmin.cshtml"
                                 Write(Model.Notifications.Count() == 0 ? "no notifications" : Model.Notifications.Count().ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n    </div>\r\n    <div class=\"col-lg-6 text-right\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b53693c61fe93a45964940da893c316aae8d63598686", async() => {
                WriteLiteral("Dashboard");
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
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n<hr />\r\n\r\n");
#nullable restore
#line 25 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Notifications\AllToAdmin.cshtml"
 foreach (var notification in Model.Notifications)
{
    string confirmDelete = string.Concat("confirmDelete", notification.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"card\">\r\n        <div class=\"card-header\">\r\n            Message\r\n        </div>\r\n        <div class=\"card-body\">\r\n            <h5 class=\"card-title\">From: ");
#nullable restore
#line 33 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Notifications\AllToAdmin.cshtml"
                                     Write(string.IsNullOrEmpty(notification.SenderUserName) ? string.Concat(notification.AnonymousEmail, ", unregistered") : notification.SenderUserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n            <p class=\"card-text\"><time");
            BeginWriteAttribute("datetime", " datetime=\"", 1186, "\"", 1234, 1);
#nullable restore
#line 34 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Notifications\AllToAdmin.cshtml"
WriteAttributeValue("", 1197, notification.CreatedOn.ToString("O"), 1197, 37, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></time></p>\r\n            <p class=\"card-text\">");
#nullable restore
#line 35 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Notifications\AllToAdmin.cshtml"
                            Write(notification.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <div class=\"card-text text-right\">\r\n\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b53693c61fe93a45964940da893c316aae8d635912482", async() => {
                WriteLiteral("\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b53693c61fe93a45964940da893c316aae8d635912761", async() => {
                    WriteLiteral("Answer");
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
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-email", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 39 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Notifications\AllToAdmin.cshtml"
                                                                                                          WriteLiteral(string.IsNullOrEmpty(notification.SenderUserName) ? notification.AnonymousEmail : notification.SenderUserName);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["email"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-email", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["email"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    <button class=\"btn btn-danger\" type=\"button\" data-toggle=\"modal\" data-target=\"#");
#nullable restore
#line 40 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Notifications\AllToAdmin.cshtml"
                                                                                              Write(confirmDelete);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" data-id=\"");
#nullable restore
#line 40 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Notifications\AllToAdmin.cshtml"
                                                                                                                       Write(notification.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral("\">Delete</button>\r\n\r\n                    <!-- The Modal -->\r\n                    <div class=\"modal\"");
                BeginWriteAttribute("id", " id=\"", 1979, "\"", 1998, 1);
#nullable restore
#line 43 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Notifications\AllToAdmin.cshtml"
WriteAttributeValue("", 1984, confirmDelete, 1984, 14, false);

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
                                    Are you sure you want to delete the message from <span class=""text text-primary"">");
#nullable restore
#line 55 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Notifications\AllToAdmin.cshtml"
                                                                                                                 Write(string.IsNullOrEmpty(notification.SenderUserName) ? notification.AnonymousEmail : notification.SenderUserName);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</span>?
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
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-notificationId", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 38 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Notifications\AllToAdmin.cshtml"
                                                                                  WriteLiteral(notification.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["notificationId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-notificationId", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["notificationId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 71 "C:\Users\Kamen\Box\Books\Programming\SoftUni\C# Web ASP.Net Core\BloodDonorship\BloodDonorship\Web\BloodDonorship.Web\Areas\Administration\Views\Notifications\AllToAdmin.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BloodDonorship.Web.ViewModels.Administration.Notifications.AllNotificationsAdminViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
