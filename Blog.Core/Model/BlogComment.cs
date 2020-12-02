using System;

#nullable disable

namespace Blog.Core.Model
{
    public partial class BlogComment
    {
        public int CommentId { get; set; }
        public int BlogPostId { get; set; }
        public string Comment { get; set; }
        public DateTime CommentedOn { get; set; }

        public virtual BlogPost BlogPost { get; set; }
    }
}
