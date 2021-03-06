using AspNetCoreTemplate.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreTemplate.Data.Models
{
    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Posts = new HashSet<Post>();
        }

        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
