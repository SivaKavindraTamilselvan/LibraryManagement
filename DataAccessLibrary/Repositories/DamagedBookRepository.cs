using LibraryManagement.ModelLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace NotificationAppDataAccessLibrary.Repositories;

public class DamagedBookRepository : AbstractRepository<int, DamagedBook>
{
    public override DamagedBook? Get(int key)
    {
        var book = libraryManagementContext.DamagedBook.Include(dl=>dl.DamagedLevel).Where(b => b.DamagedBookId == key).FirstOrDefault();
        return null;
    }
    public List<DamagedBook> GetAllDamagedBook()
    {
        var book = libraryManagementContext.DamagedBook.Include(dl=>dl.DamagedLevel).ToList();
        return book;
    }
}