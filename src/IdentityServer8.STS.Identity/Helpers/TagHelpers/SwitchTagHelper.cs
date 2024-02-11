/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace IdentityServer8.STS.Identity.Helpers.TagHelpers
{
    [HtmlTargetElement("toggle-button")]
    public class SwitchTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();

            var divSlider = new TagBuilder("div");
            divSlider.AddCssClass("slider round bg-primary");

            output.TagName = "label";
            output.Attributes.Add("class", "switch");
            output.Content.AppendHtml(childContent);
            output.Content.AppendHtml(divSlider);
            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}
