using BookStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

namespace BookStore.Infrastructure
{	
	[HtmlTargetElement("div", Attributes = "page-model")]
	public class PageTagHelper : TagHelper
	{
		private IUrlHelperFactory urlHelperFactory;

		public PageTagHelper(IUrlHelperFactory urlHelper)
		{
			urlHelperFactory = urlHelper;
		}
		public bool PageClassesEnabled { get; set; } = false;
		public string PageClass { get; set; }
		public string PageClassNormal { get; set;}
		public string PageClassSelected { get; set; }

		[ViewContext]
		[HtmlAttributeNotBound]
		public ViewContext viewContext { get; set; }
		public PageInformation PageModel { get; set; }
		public string PageAction { get; set; }
		[HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
		public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();
		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			IUrlHelper helperFactory = urlHelperFactory.GetUrlHelper(viewContext);
			TagBuilder result = new TagBuilder("div");
			for (int i = 1;i<= PageModel.TotalPages; i++)
			{
				TagBuilder tag = new TagBuilder("a");
				PageUrlValues["book_p"] = i;
				//tag.Attributes["href"] = helperFactory.Action(PageAction, new { book_p = i });
				tag.Attributes["href"] = helperFactory.Action(PageAction, PageUrlValues);
				if (PageClassesEnabled)
				{
					tag.AddCssClass(PageClass);
					tag.AddCssClass(i == PageModel.Current_page ? PageClassSelected : PageClassNormal);

				}
				tag.InnerHtml.Append(i.ToString() + " ");
				result.InnerHtml.AppendHtml(tag);
			}
			output.Content.AppendHtml(result.InnerHtml);
		}
	}
	
}
