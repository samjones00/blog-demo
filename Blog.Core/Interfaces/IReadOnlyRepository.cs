using System.Collections.Generic;

namespace Blog.Core.Interfaces
{
    public interface IReadOnlyRepository<T>
    {
        public IEnumerable<T> Get();
        public T Get(int id);
    }
}
