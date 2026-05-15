using LibraryManagement.DataAccessLibrary.DBContext;

namespace LibraryManagement.DataAccessLibrary.UniqueISBN;

public class GenerateUniqueISBN
{
    protected readonly LibraryManagementContext libraryManagementContext;
    public GenerateUniqueISBN()
    {
        libraryManagementContext = new LibraryManagementContext();
    }
    public string GenerateISBN()
    {
        Random random = new Random();

        string isbn;

        do
        {
            isbn = "";

            for (int i = 0; i < 13; i++)
            {
                isbn += random.Next(0, 10);
            }

        } while (libraryManagementContext.BookISBN.Any(b => b.ISBN == isbn));

        return isbn;
    }
}
