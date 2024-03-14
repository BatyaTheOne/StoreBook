using BookStore.Core.Model;

namespace BookStore.DataAccess.Repositories
{
    public interface IBookRepository
    {
        Task<Guid> Create(Book book);
        Task<Guid> Delete(Guid Id);
        Task<List<Book>> GetAsync();
        Task<Guid> Update(Guid Id, string title, string description, decimal price);
    }
}