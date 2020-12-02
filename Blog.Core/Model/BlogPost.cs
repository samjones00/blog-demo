using System;
using System.Collections.Generic;

#nullable disable

namespace Blog.Core.Model
{
    public partial class BlogPost
    {
        public BlogPost()
        {
            BlogComments = new HashSet<BlogComment>();
        }

        public int BlogPostId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PublishedOn { get; set; }

        public virtual ICollection<BlogComment> BlogComments { get; set; }
    }
}
