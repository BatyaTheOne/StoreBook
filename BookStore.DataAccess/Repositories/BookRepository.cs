using BookStore.Core.Model;
using BookStore.DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreDbContext _context;
        public BookRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAsync()
        {
            var bookEntites = await _context.Books
                .AsNoTracking()
                .ToListAsync();

            var books = bookEntites
                .Select(x => Book.Create(x.Id, x.Description, x.Title, x.Price).Book)
                .ToList();

            return books;
        }

        public async Task<Guid> Create(Book book)
        {
            var bookEntity = new BookEntity
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Price = book.Price
            };

            await _context.Books.AddAsync(bookEntity);
            await _context.SaveChangesAsync();

            return bookEntity.Id;
        }

        public async Task<Guid> Update(Guid Id, string title, string description, decimal price)
        {
            await _context.Books
                .Where(b => b.Id == Id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.Title, b => b.Title)
                    .SetProperty(b => b.Description, b => b.Description)
                    .SetProperty(b => b.Price, b => b.Price));
            return Id;
        }

        public async Task<Guid> Delete(Guid Id)
        {
            await _context.Books
                .Where(b => b.Id == Id)
                .ExecuteDeleteAsync();

            return Id;
        }
    }
}
