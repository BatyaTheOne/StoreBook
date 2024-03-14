using BookStore.Core.Model;
using BookStore.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepositoriy)
        {
            _bookRepository = bookRepositoriy;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _bookRepository.GetAsync();
        }

        public async Task<Guid> CreateBook(Book book)
        {
            return await _bookRepository.Create(book);
        }

        public async Task<Guid> UpdateBook(Guid Id, string title, string description, decimal price)
        {
            return await _bookRepository.Update(Id, title, description, price);
        }

        public async Task<Guid> DeleteBook(Guid Id)
        {
            return await _bookRepository.Delete(Id);
        }
    }
}
