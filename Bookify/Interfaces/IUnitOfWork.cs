using Bookify.Data;
using Bookify.Models;
using Bookify.Repositories;

namespace Bookify.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IGenericRepository<Book> BookRepository { get; }
        public IGenericRepository<Genre> GenreRepository { get; }
        public IGenericRepository<Author> AuthorRepository { get; }
        public IGenericRepository<Order> OrderRepository { get; }
        public IGenericRepository<BookOrder> BookOrderRepository { get; }
        int Complete();

    }
}
