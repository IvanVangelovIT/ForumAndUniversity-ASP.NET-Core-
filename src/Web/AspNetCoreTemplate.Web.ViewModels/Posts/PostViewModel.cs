using AspNetCoreTemplate.Data.Models;
using AspNetCoreTemplate.Services.Mapping;
using AutoMapper;
using Ganss.XSS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspNetCoreTemplate.Web.ViewModels.Posts
{
    public class PostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);
        public string UserUserName { get; set; }
        public int VotesCount { get; set; }
        public IEnumerable<Vote> Votes { get; set; }

        public IEnumerable<PostCommentViewModel> Comments { get; set; }
        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(x => x.VotesCount, options =>
                {
                    options.MapFrom(p => p.Votes.Sum(v => (int)v.Type));
                });
        }
    }
}
