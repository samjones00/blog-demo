using Blog.Core.Dto;
using Blog.Core.Model;
using System.Collections.Generic;

namespace Blog.Core.Services
{
    public interface IPostService
    {
        IEnumerable<PostDto> Get();
        CommentDto Map(BlogComment source);
        PostDto Map(BlogPost source);
        bool TryGetPost(int id, out PostDto post);
    }
}
