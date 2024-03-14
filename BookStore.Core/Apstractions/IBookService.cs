using BookStore.Core.Model;

namespace BookStore.Application.Services
{
    public interface IBookService
    {
        Task<Guid> CreateBook(Book book);
        Task<Guid> DeleteBook(Guid Id);
        Task<List<Book>> GetAllBooks();
        Task<Guid> UpdateBook(Guid Id, string title, string description, decimal price);
    }
}