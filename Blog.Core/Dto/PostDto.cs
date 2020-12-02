using System;
using System.Collections.Generic;

namespace Blog.Core.Dto
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PublishedOn { get; set; }

        public List<CommentDto> Comments { get; set; } = new List<CommentDto>();
    }
}
