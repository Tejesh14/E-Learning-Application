#pragma checksum "C:\Users\tejesh.bharadwaj\Desktop\New folder\E-Learning\E-LearningMVC\Views\Faculty\Projects.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e0d933b3e846eee5b9b838651df3aee88e6a348d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Faculty_Projects), @"mvc.1.0.view", @"/Views/Faculty/Projects.cshtml")]
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
#line 1 "C:\Users\tejesh.bharadwaj\Desktop\New folder\E-Learning\E-LearningMVC\Views\_ViewImports.cshtml"
using E_LearningMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\tejesh.bharadwaj\Desktop\New folder\E-Learning\E-LearningMVC\Views\_ViewImports.cshtml"
using E_LearningMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0d933b3e846eee5b9b838651df3aee88e6a348d", @"/Views/Faculty/Projects.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ef11d102d34e0a34579ce8c3c2f73ebc7ba6fc8e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Faculty_Projects : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<E_Learning.DAL.Models.Project>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\tejesh.bharadwaj\Desktop\New folder\E-Learning\E-LearningMVC\Views\Faculty\Projects.cshtml"
  
    ViewData["Title"] = "Projects";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Projects</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e0d933b3e846eee5b9b838651df3aee88e6a348d3819", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Users\tejesh.bharadwaj\Desktop\New folder\E-Learning\E-LearningMVC\Views\Faculty\Projects.cshtml"
           Write(Html.DisplayNameFor(model => model.ProjectName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Users\tejesh.bharadwaj\Desktop\New folder\E-Learning\E-LearningMVC\Views\Faculty\Projects.cshtml"
           Write(Html.DisplayNameFor(model => model.FileNameAssigned));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "C:\Users\tejesh.bharadwaj\Desktop\New folder\E-Learning\E-LearningMVC\Views\Faculty\Projects.cshtml"
           Write(Html.DisplayNameFor(model => model.FileTypeAssigned));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "C:\Users\tejesh.bharadwaj\Desktop\New folder\E-Learning\E-LearningMVC\Views\Faculty\Projects.cshtml"
           Write(Html.DisplayNameFor(model => model.AssignBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 28 "C:\Users\tejesh.bharadwaj\Desktop\New folder\E-Learning\E-LearningMVC\Views\Faculty\Projects.cshtml"
           Write(Html.DisplayNameFor(model => model.AssignedAt));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 31 "C:\Users\tejesh.bharadwaj\Desktop\New folder\E-Learning\E-LearningMVC\Views\Faculty\Projects.cshtml"
           Write(Html.DisplayNameFor(model => model.FileNameSubmitted));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 34 "C:\Users\tejesh.bharadwaj\Desktop\New folder\E-Learning\E-LearningMVC\Views\Faculty\Projects.cshtml"
           Write(Html.DisplayNameFor(model => model.FileTypeSubmitted));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 37 "C:\Users\tejesh.bharadwaj\Desktop\New folder\E-Learning\E-LearningMVC\Views\Faculty\Projects.cshtml"
           Write(Html.DisplayNameFor(model => model.SubmittedAt));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 40 "C:\Users\tejesh.bharadwaj\Desktop\New folder\E-Learning\E-LearningMVC\Views\Faculty\Projects.cshtml"
           Write(Html.DisplayNameFor(model => model.AssignTo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 46 "C:\Users\tejesh.bharadwaj\Desktop\New folder\E-Learning\E-LearningMVC\Views\Faculty\Projects.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 49 "C:\Users\tejesh.bharadwaj\Desktop\New folder\E-Learning\E-LearningMVC\Views\Faculty\Projects.cshtml"
           Write(Html.DisplayFor(modelItem => item.ProjectName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 52 "C:\Users\tejesh.bharadwaj\Desktop\New folder\E-Learning\E-LearningMVC\Views\Faculty\Projects.cshtml"
           Write(Html.DisplayFor(modelItem => item.FileNameAssigned));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 55 "C:\Users\tejesh.bharadwaj\Desktop\New folder\E-Learning\E-LearningMVC\Views\Faculty\Projects.cshtml"
           Write(Html.DisplayFor(modelItem => item.FileTypeAssigned));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 58 "C:\Users\tejesh.bharadwaj\Desktop\New folder\E-Learning\E-LearningMVC\Views\Faculty\Projects.cshtml"
           Write(Html.DisplayFor(modelItem => item.AssignBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 61 "C:\Users\tejesh.bharadwaj\Desktop\New folder\E-Learning\E-LearningMVC\Views\Faculty\Projects.cshtml"
           Write(Html.DisplayFor(modelItem => item.AssignedAt));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 64 "C:\Users\tejesh.bharadwaj\Desktop\New folder\E-Learning\E-LearningMVC\Views\Faculty\Projects.cshtml"
           Write(Html.DisplayFor(modelItem => item.FileNameSubmitted));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 67 "C:\Users\tejesh.bharadwaj\Desktop\New folder\E-Learning\E-LearningMVC\Views\Faculty\Projects.cshtml"
           Write(Html.DisplayFor(modelItem => item.FileTypeSubmitted));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 70 "C:\Users\tejesh.bharadwaj\Desktop\New folder\E-Learning\E-LearningMVC\Views\Faculty\Projects.cshtml"
           Write(Html.DisplayFor(modelItem => item.SubmittedAt));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 73 "C:\Users\tejesh.bharadwaj\Desktop\New folder\E-Learning\E-LearningMVC\Views\Faculty\Projects.cshtml"
           Write(Html.DisplayFor(modelItem => item.AssignTo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 76 "C:\Users\tejesh.bharadwaj\Desktop\New folder\E-Learning\E-LearningMVC\Views\Faculty\Projects.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 77 "C:\Users\tejesh.bharadwaj\Desktop\New folder\E-Learning\E-LearningMVC\Views\Faculty\Projects.cshtml"
           Write(Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 78 "C:\Users\tejesh.bharadwaj\Desktop\New folder\E-Learning\E-LearningMVC\Views\Faculty\Projects.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 81 "C:\Users\tejesh.bharadwaj\Desktop\New folder\E-Learning\E-LearningMVC\Views\Faculty\Projects.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<E_Learning.DAL.Models.Project>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
