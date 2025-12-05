using Microsoft.EntityFrameworkCore;
using TestThiBackEnd.Models;
using TestThiBackEnd.Repository;
using TestThiBackEnd;

namespace LibraryAPI.Repositories // Đảm bảo namespace đúng với dự án của bạn
{
    public class BookRepository : IBookRepository<Book>
    {
        private readonly AppDbContext _context; // Nên để readonly

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        // 1. GetAll chuẩn Async
        public async Task<List<Book>> GetAll()
        {
            // Dùng ToListAsync để tận dụng bất đồng bộ thật sự
            return await _context.Books.ToListAsync();
        }

        // 2. GetById
        public async Task<Book?> GetById(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        // 3. Add
        public async Task<Book> Add(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync(); 
            return book;
        }

        // 4. Update (Sửa lại cho đúng tham số int id theo đề bài)
        public async Task<Book?> Update(Book book)
        {
            var existingBook = await _context.Books.FindAsync(book.Id);

            if (existingBook == null)
            {
                return null;
            }

            // Cập nhật dữ liệu
            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Price = book.Price;
            existingBook.GenreID = book.GenreID;
            existingBook.StockQuantity = book.StockQuantity;


            await _context.SaveChangesAsync(); // Lưu thay đổi
            return book;
        }

        // 5. Delete
        public async Task<bool> Delete(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return false;
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync(); // QUAN TRỌNG: Phải có dòng này mới xóa thật
            return true;
        }
        // 6. get Genre by id
        public async Task<List<Book>> GetByGerneId(int id)
        {
            var books = _context.Books.Where(b => b.GenreID == id);
            return await books.ToListAsync();
        }

        
    }
}