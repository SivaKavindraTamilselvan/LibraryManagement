using LibraryManagement.ModelLibrary.Models;
using NotificationAppDataAccessLibrary.Repositories;

public class BookCategoryRepository : AbstractRepository<int, BookCategory>
{
    public override BookCategory? Get(int key)
    {
        var bookCategory = libraryManagementContext.BookCategory.Where(b=>b.BookCategoryId == key).FirstOrDefault();
        return bookCategory;
    }
}