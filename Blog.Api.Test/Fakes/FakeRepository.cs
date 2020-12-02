using Blog.Core.Interfaces;
using Blog.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Api.Test.Fakes
{
    public class FakeRepository : IReadOnlyRepository<BlogPost>
    {
        public IEnumerable<BlogPost> Get()
        {
            var data = new List<BlogPost>
            {
                CreatePost(1),
                CreatePost(2),
                CreatePost(3),
                CreatePost(4),
                CreatePost(5),
            };

            return data;
        }

        public BlogPost Get(int id) => Get().FirstOrDefault(x=>x.BlogPostId == id);

        private BlogPost CreatePost(int index)
        {
            return new BlogPost
            {
                BlogPostId = index,
                Title = $"Post {index} title",
                Body = $"Post {index} body",
                PublishedOn = new DateTime(2020, index, index),
                BlogComments = Enumerable.Range(1, index).Select(commentIndex => CreateComment(index, commentIndex)).ToList()
            };
        }

        private BlogComment CreateComment(int postId, int index)
        {
            return new BlogComment
            {
                CommentId = index,
                BlogPostId = postId,
                CommentedOn = new DateTime(2020, index, index),
                Comment = $"Comment {index}"
            };
        }
    }
}
