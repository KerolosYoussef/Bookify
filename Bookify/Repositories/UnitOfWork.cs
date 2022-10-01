using Bookify.Data;
using Bookify.Interfaces;
using Bookify.Models;

namespace Bookify.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IGenericRepository<Book> BookRepository { get; }
        public IGenericRepository<Genre> GenreRepository { get; }
        
        public IGenericRepository<Author> AuthorRepository { get; }
        
        public IGenericRepository<Order> OrderRepository { get; }

        public IGenericRepository<BookOrder> BookOrderRepository { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            BookRepository = new GenericRepository<Book>(_context);
            GenreRepository = new GenericRepository<Genre>(_context);
            AuthorRepository = new GenericRepository<Author>(_context);
            OrderRepository = new GenericRepository<Order>(_context);
            BookOrderRepository = new GenericRepository<BookOrder>(_context);

        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
