using Blog.Core.Dto;
using Blog.Core.Interfaces;
using Blog.Core.Model;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Blog.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IReadOnlyRepository<BlogPost> _repository;

        public PostService(IReadOnlyRepository<BlogPost> repository)
        {
            _repository = repository;
        }

        public IEnumerable<PostDto> Get()
        {
            var entities = _repository.Get();

            if (entities == null)
            {
                throw new Exception($"Unable to retrieve blog posts.");
            }

            return entities.Select(Map);
        }

        public bool TryGetPost(int id, out PostDto post)
        {
            var entity = _repository.Get(id);

            if (entity != null)
            {
                post = Map(entity);
                return true;
            }
            post = null;
            return false;
        }

        public PostDto Map(BlogPost source)
        {
            var comments = source?.BlogComments?.Select(Map).ToList();

            return new PostDto
            {
                Id = source.BlogPostId,
                Body = source.Body,
                PublishedOn = source.PublishedOn,
                Title = source.Title,
                Comments = comments
            };
        }

        public CommentDto Map(BlogComment source)
        {
            return new CommentDto
            {
                Comment = source.Comment,
                CommentedOn = source.CommentedOn
            };
        }
    }
}
