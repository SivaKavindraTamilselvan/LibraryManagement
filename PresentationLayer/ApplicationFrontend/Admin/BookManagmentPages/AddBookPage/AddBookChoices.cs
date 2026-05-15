using LibraryManagement.BuisnessLayerLibrary.Inputs;
using LibraryManagement.BuisnessLayerLibrary.Services;

namespace LibraryManagement.PresentationLayer.Frontend;

public partial class BookManagement
{
    public void AddBookManagementRoles()
    {
        while (true)
        {
            Console.WriteLine("Enter 1 To Add Book");
            Console.WriteLine("Enter 2 To Add Book With Different Published year, edition (new ISBN)");
            Console.WriteLine("Enter 3 To Add Book Copies");
            Console.WriteLine("Enter 0 To Quit");

            int typechoice;
            while (!int.TryParse(Console.ReadLine(), out typechoice) || typechoice > 3 || typechoice < 0)
            {
                Console.WriteLine("Enter Vaild Input");
            }
            try
            {
                switch (typechoice)
                {
                    case 1:
                        {
                            AddBook();
                            break;
                        }
                    case 2:
                        {
                            break;
                        }
                    case 3:
                        {
                            break;
                        }
                    case 4:
                        {
                            break;
                        }
                    case 0:
                        {
                            return;
                        }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}