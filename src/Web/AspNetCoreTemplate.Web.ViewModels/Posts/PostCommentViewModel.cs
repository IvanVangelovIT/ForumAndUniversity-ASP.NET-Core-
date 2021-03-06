using AspNetCoreTemplate.Data.Models;
using AspNetCoreTemplate.Services.Mapping;
using Ganss.XSS;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreTemplate.Web.ViewModels.Posts
{
    public class PostCommentViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Content { get; set; }
        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);
        public string UserUserName { get; set; }
    }
}
