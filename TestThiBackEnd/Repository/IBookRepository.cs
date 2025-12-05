
namespace TestThiBackEnd.Repository
{
    public interface IBookRepository<Book>
    {
        Task<List<Book>> GetAll();
        Task<Book?> GetById(int id);
        Task<Book> Add(Book book);
        Task<Book?> Update(Book book);
        Task<bool> Delete(int id);
        Task<List<Book>> GetByGerneId(int id);
    }
}
