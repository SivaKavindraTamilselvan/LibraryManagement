namespace LibraryManagement.PresentationLayer.Frontend;

public partial class BookManagement
{
    public void UpdateBookManagementRoles()
    {
        while (true)
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Enter 1 To Update Basic Book Title");
            Console.WriteLine("Enter 2 To Update Basic Book Author");
            Console.WriteLine("Enter 3 To Update Book Status");
            Console.WriteLine("Enter 4 To Update Book Published Year");
            Console.WriteLine("Enter 5 To Update Book Edition");
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
                            int id = inputsCheck.IdInputs();
                            GetBookByCategoryId(id);
                            break;
                        }
                    case 3:
                        {
                            int id = inputsCheck.IdInputs();
                            GetBookByBookId(id);
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Enter The Book Title");
                            string title = Console.ReadLine() ?? "";
                            GetBookByBookTitle(title);
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Enter The Book Author");
                            string author = Console.ReadLine() ?? "";
                            GetBookByBookAuthor(author);
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Enter The Book ISBN");
                            string isbn = Console.ReadLine() ?? "";
                            GetBookByBookISBNNumber(isbn);
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Enter The Book Copy Number");
                            string copy = Console.ReadLine() ?? "";
                            GetBookByBookCopyNumber(copy);
                            break;
                        }
                    case 8:
                        {
                            Console.WriteLine("Enter The Status Id");
                            
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