namespace LibraryManagement.PresentationLayer.Frontend;

public partial class BookManagement
{
    public void GetBookManagementRoles()
    {
        while (true)
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Enter 1 To Get All Book Details");
            Console.WriteLine("Enter 2 To Get All Book Details By BookTitle");
            Console.WriteLine("Enter 3 To Get All Book Details By Author");
            Console.WriteLine("Enter 4 To Get All Book Details By ISBN Number");
            Console.WriteLine("Enter 5 To Get All Book Details By Copy Number");
            Console.WriteLine("Enter 6 To Get Book By Category Id");
            Console.WriteLine("Enter 7 To Get Book By Book Id");
            Console.WriteLine("Enter 0 To Quit");
            Console.WriteLine("------------------------------------------------");

            int typechoice;
            while (!int.TryParse(Console.ReadLine(), out typechoice) || typechoice > 7 || typechoice < 0)
            {
                Console.WriteLine("Enter Vaild Input");
            }
            try
            {
                switch (typechoice)
                {
                    case 1:
                        {
                            GetAllBook();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter The Book Title");
                            string title = Console.ReadLine() ?? "";
                            GetBookByBookTitle(title);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter The Book Author");
                            string author = Console.ReadLine() ?? "";
                            GetBookByBookAuthor(author);
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Enter The Book ISBN");
                            string isbn = Console.ReadLine() ?? "";
                            GetBookByBookISBNNumber(isbn);
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Enter The Book Copy Number");
                            string copy = Console.ReadLine() ?? "";
                            GetBookByBookCopyNumber(copy);
                            break;
                        }
                    case 6:
                        {
                            int id = inputsCheck.IdInputs();
                            GetBookByCategoryId(id);
                            break;
                        }
                    case 7:
                        {
                            int id = inputsCheck.IdInputs();
                            GetBookByBookId(id);
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