using BookApp.Business.Abstract;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.WebUI.Areas.Admin.TagHelpers
{
    [HtmlTargetElement("getWriter")]
    public class GetWriter : TagHelper
    {
        public int BookId { get; set; }
        private readonly IBookService _bookService;
        public GetWriter(IBookService bookService)
        {
            _bookService = bookService;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var writer = _bookService.GetBookListWriter(BookId);
            var html = $"{writer.Writer.Name}";
            output.Content.SetHtmlContent(html);
        }
    }
}
