using Blog.Core.Model;
using System.Collections.Generic;
using System.Linq;
using Blog.Core.Interfaces;

namespace Blog.Core.Repositories
{
    public class PostRepository : IReadOnlyRepository<BlogPost>
    {
        InMemoryBlogContext _context;

        public PostRepository(InMemoryBlogContext context)
        {
            _context = context;
        }

        public IEnumerable<BlogPost> Get() => _context.BlogPosts;
        public BlogPost Get(int id) => _context.BlogPosts.FirstOrDefault(x => x.BlogPostId == id);
    }
}
