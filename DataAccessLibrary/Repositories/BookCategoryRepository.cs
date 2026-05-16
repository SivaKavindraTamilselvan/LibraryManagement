using LibraryManagement.ModelLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace NotificationAppDataAccessLibrary.Repositories;

public class BookCategoryRepository : AbstractRepository<int, BookCategory>
{
    public override BookCategory? Get(int key)
    {
        var bookCategory = libraryManagementContext.BookCategory.Where(b=>b.BookCategoryId == key).FirstOrDefault();
        return bookCategory;
    }
    public List<BookCategory>? GetBookByCategory(int id)
    {
        var booklist = libraryManagementContext.BookCategory.Where(b=>b.BookCategoryId==id).Include(b=>b.Books).ToList();
        return booklist;
    }
}