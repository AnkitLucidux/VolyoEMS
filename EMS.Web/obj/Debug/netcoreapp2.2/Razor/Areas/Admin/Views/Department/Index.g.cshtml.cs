#pragma checksum "F:\Ankit\Project\VolyoEMS\EMS.Web\Areas\Admin\Views\Department\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bcdb66283a3333c19a66b47373aeb15b6ea2650a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Department_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Department/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Department/Index.cshtml", typeof(AspNetCore.Areas_Admin_Views_Department_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bcdb66283a3333c19a66b47373aeb15b6ea2650a", @"/Areas/Admin/Views/Department/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23ac09be4bcfaa7f9829a01d1a134874eaae1f3b", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Department_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EMS.Entities.Department>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Images/Icons/edit.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Edit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("icon"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Images/Icons/delete.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Delete"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(45, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "F:\Ankit\Project\VolyoEMS\EMS.Web\Areas\Admin\Views\Department\Index.cshtml"
  
    ViewData["Title"] = "Department Management";

#line default
#line hidden
            BeginContext(104, 6, true);
            WriteLiteral("\r\n<h1>");
            EndContext();
            BeginContext(111, 17, false);
#line 7 "F:\Ankit\Project\VolyoEMS\EMS.Web\Areas\Admin\Views\Department\Index.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(128, 53, true);
            WriteLiteral("</h1>\r\n\r\n<hr />\r\n\r\n<div class=\"validation-message\">\r\n");
            EndContext();
#line 12 "F:\Ankit\Project\VolyoEMS\EMS.Web\Areas\Admin\Views\Department\Index.cshtml"
     if (TempData["ErrorMessage"] != null)
    {

#line default
#line hidden
            BeginContext(232, 32, true);
            WriteLiteral("        <p class=\"alert-danger\">");
            EndContext();
            BeginContext(265, 24, false);
#line 14 "F:\Ankit\Project\VolyoEMS\EMS.Web\Areas\Admin\Views\Department\Index.cshtml"
                           Write(TempData["ErrorMessage"]);

#line default
#line hidden
            EndContext();
            BeginContext(289, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 15 "F:\Ankit\Project\VolyoEMS\EMS.Web\Areas\Admin\Views\Department\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(302, 4, true);
            WriteLiteral("    ");
            EndContext();
#line 16 "F:\Ankit\Project\VolyoEMS\EMS.Web\Areas\Admin\Views\Department\Index.cshtml"
     if (TempData["SuccessMessage"] != null)
    {

#line default
#line hidden
            BeginContext(355, 33, true);
            WriteLiteral("        <p class=\"alert-success\">");
            EndContext();
            BeginContext(389, 26, false);
#line 18 "F:\Ankit\Project\VolyoEMS\EMS.Web\Areas\Admin\Views\Department\Index.cshtml"
                            Write(TempData["SuccessMessage"]);

#line default
#line hidden
            EndContext();
            BeginContext(415, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 19 "F:\Ankit\Project\VolyoEMS\EMS.Web\Areas\Admin\Views\Department\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(428, 19, true);
            WriteLiteral("</div>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(447, 61, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bcdb66283a3333c19a66b47373aeb15b6ea2650a9241", async() => {
                BeginContext(494, 10, true);
                WriteLiteral("Create New");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(508, 145, true);
            WriteLiteral("\r\n</p>\r\n\r\n<table class=\"datatable table table-striped table-bordered table-hover\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(654, 50, false);
#line 30 "F:\Ankit\Project\VolyoEMS\EMS.Web\Areas\Admin\Views\Department\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DepartmentName));

#line default
#line hidden
            EndContext();
            BeginContext(704, 93, true);
            WriteLiteral("\r\n            </th>\r\n            <th>Actions</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 36 "F:\Ankit\Project\VolyoEMS\EMS.Web\Areas\Admin\Views\Department\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(846, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(907, 49, false);
#line 40 "F:\Ankit\Project\VolyoEMS\EMS.Web\Areas\Admin\Views\Department\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.DepartmentName));

#line default
#line hidden
            EndContext();
            BeginContext(956, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1023, 465, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bcdb66283a3333c19a66b47373aeb15b6ea2650a12092", async() => {
                BeginContext(1097, 26, true);
                WriteLiteral("\r\n                        ");
                EndContext();
                BeginContext(1123, 122, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bcdb66283a3333c19a66b47373aeb15b6ea2650a12502", async() => {
                    BeginContext(1178, 63, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "bcdb66283a3333c19a66b47373aeb15b6ea2650a12775", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#line 44 "F:\Ankit\Project\VolyoEMS\EMS.Web\Areas\Admin\Views\Department\Index.cshtml"
                                               WriteLiteral(item.DepartmentId);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1245, 47, true);
                WriteLiteral("\r\n                        <button type=\"submit\"");
                EndContext();
                BeginWriteAttribute("onclick", " onclick=\"", 1292, "\"", 1381, 12);
                WriteAttributeValue("", 1302, "return", 1302, 6, true);
                WriteAttributeValue(" ", 1308, "confirm(\'Are", 1309, 13, true);
                WriteAttributeValue(" ", 1321, "you", 1322, 4, true);
                WriteAttributeValue(" ", 1325, "sure", 1326, 5, true);
                WriteAttributeValue(" ", 1330, "you", 1331, 4, true);
                WriteAttributeValue(" ", 1334, "want", 1335, 5, true);
                WriteAttributeValue(" ", 1339, "to", 1340, 3, true);
                WriteAttributeValue(" ", 1342, "delete", 1343, 7, true);
                WriteAttributeValue(" ", 1349, "Role", 1350, 5, true);
                WriteAttributeValue(" ", 1354, ":", 1355, 2, true);
#line 45 "F:\Ankit\Project\VolyoEMS\EMS.Web\Areas\Admin\Views\Department\Index.cshtml"
WriteAttributeValue(" ", 1356, item.DepartmentName, 1357, 20, false);

#line default
#line hidden
                WriteAttributeValue(" ", 1377, "?\')", 1378, 4, true);
                EndWriteAttribute();
                BeginContext(1382, 1, true);
                WriteLiteral(">");
                EndContext();
                BeginContext(1383, 67, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "bcdb66283a3333c19a66b47373aeb15b6ea2650a17477", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1450, 31, true);
                WriteLiteral("</button>\r\n                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 43 "F:\Ankit\Project\VolyoEMS\EMS.Web\Areas\Admin\Views\Department\Index.cshtml"
                                                WriteLiteral(item.DepartmentId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1488, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 49 "F:\Ankit\Project\VolyoEMS\EMS.Web\Areas\Admin\Views\Department\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(1543, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EMS.Entities.Department>> Html { get; private set; }
    }
}
#pragma warning restore 1591
