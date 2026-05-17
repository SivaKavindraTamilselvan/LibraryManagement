namespace LibraryManagement.PresentationLayer.Frontend;

public partial class BookManagement
{
    public void GetBookManagementRoles()
    {
        while (true)
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Enter 1 To Get All Book Details");
            Console.WriteLine("Enter 2 To Get Book By Category Id");
            Console.WriteLine("Enter 3 To Get Book By Book Id");
            Console.WriteLine("Enter 4 To Get All Book Details By BookTitle");
            Console.WriteLine("Enter 5 To Get All Book Details By Author");
            Console.WriteLine("Enter 6 To Get All Book Details By ISBN Number");
            Console.WriteLine("Enter 7 To Get All Book Details By Copy Number");
            Console.WriteLine("Enter 8 To Get All The Books By Status");
            //display by the each status
            Console.WriteLine("Enter 9 To Get The Number Of The Books By Category");
            Console.WriteLine("Enter 10 To Get The Number Of The Books By Book Title");
            Console.WriteLine("Enter 11 To Get The Number Of The Books By ISBN");
            Console.WriteLine("Enter 0 To Quit");
            Console.WriteLine("------------------------------------------------");

            int typechoice;
            while (!int.TryParse(Console.ReadLine(), out typechoice) || typechoice > 11 || typechoice < 0)
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
                            Console.WriteLine("Enter The Category Id To Display The Books");
                            int id = inputsCheck.IdInputs();
                            GetBookByCategoryId(id);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter The Book Id To Display The Books");
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
                            Console.WriteLine("Enter The Status Id\n");
                            Console.WriteLine("Enter 1 For Available");
                            Console.WriteLine("Enter 2 For UnAvailable");
                            Console.WriteLine("Enter 3 For Lost");
                            Console.WriteLine("Enter 4 For Damaged");
                            int id = inputsCheck.IdInputs();
                            GetBookByStatus(id);
                            break;
                        }
                    case 9:
                        {
                            Console.WriteLine("Enter The Category Id To Display The Books");
                            int id = inputsCheck.IdInputs();
                            Console.WriteLine("The Number Of Books In The Category Id");
                            Console.WriteLine(adminService.GetNumberOfBookByCategory(id));
                            break;
                        }
                    case 10:
                        {
                            Console.WriteLine("Enter The Book Title To Display The Books");
                            string title = Console.ReadLine()??"";
                            Console.WriteLine("The Number Of Books In The Book Title");
                            Console.WriteLine(adminService.GetNumberOfBookByBookTitle(title));
                            break;
                        }
                    case 11:
                        {
                            Console.WriteLine("Enter The ISBN To Display The Books");
                            string isbn = Console.ReadLine()??"";
                            Console.WriteLine("The Number Of Books In The ISBN Number");
                            Console.WriteLine(adminService.GetNumberOfBookByISBN(isbn));
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