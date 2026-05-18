using LibraryManagement.ModelLibrary.Exceptions;
using LibraryManagement.ModelLibrary.Models;

namespace LibraryManagement.PresentationLayer.Frontend;

public partial class ReportManagement
{
    public void GetReportOfBookBorrowed()
    {
        var bookList = adminService.GetBorrowingByBorrowingStatus(1);
        if(bookList.Count == 0)
        {
            throw new InvalidBorrowingException("No Book Is Borrowed Now");
        }
        foreach (var book in bookList)
        {
            Console.WriteLine(book.GetBorrowingByBook());
        }
    }
    public void GetReportOfOverDueBook()
    {
        var bookList = adminService.GetReportOfOverDueBook();
        if(bookList.Count == 0)
        {
            throw new InvalidBorrowingException("No Book Is Over Due Now");
        }
        foreach (var book in bookList)
        {
            Console.WriteLine(book.GetBorrowingByBook());
        }
    }
    public void GetReportOfMemberWithPendingFine()
    {
        var fine = adminService.GetMemberWithPendingFine();
        if (fine.Count == 0)
        {
            throw new InvalidBorrowingException("No Pending Fine Is Found");
        }
        foreach (var f in fine)
        {
            Console.WriteLine(f);
        }
    }

    public void GetReportOfAvailableBooks()
    {
        var bookList = adminService.GetBookByStatus(1);
        if (bookList.Count == 0)
        {
            throw new InvalidBookException("No Book Is Available");
        }
        foreach (var book in bookList)
        {
            Console.WriteLine(book.GetAllBookCopyByCopyNumber());
        }
    }
    public void GetReportOfMemberHistory()
    {
        Console.WriteLine("Enter The MemberId");
        int id = inputsCheck.IdInputs();
        var member = adminService.GetMemberById(id);
        if (member == null)
        {
            throw new InvalidMemberException("No Member Is Found With The Member Id");
        }
        Console.WriteLine(member);
        var borrowingList = adminService.GetBorrowingByMemberId(id);
        if (borrowingList.Count == 0)
        {
            throw new InvalidBorrowingException("No Borrowing Is Found With The Member Id");
        }
        foreach (var borrowing in borrowingList)
        {
            Console.WriteLine(borrowing.GetBorrowingByBook());
        }
        var fine = adminService.GetMemberWithPendingFine(id);
        if (fine.Count == 0)
        {
            throw new InvalidBorrowingException("No Pending Fine Is Found");
        }
        foreach (var f in fine)
        {
            Console.WriteLine(f);
        }
    }
    public void GetAllBooksReport()
    {
        Console.WriteLine("Enter The Book Id");

        int id = inputsCheck.IdInputs();

        var book = adminService.GetReportOfBookHistory(id);

        if (book == null)
        {
            Console.WriteLine("Book Not Found");
            return;
        }

        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine($"Book Id : {book.BookId}");
        Console.WriteLine($"Book Title : {book.BookTitle}");
        Console.WriteLine($"Category : {book.BookCategory?.BookCategoryName}");

        foreach (var isbn in book.BookISBNs)
        {
            Console.WriteLine($"\nISBN : {isbn.ISBN}");
            Console.WriteLine($"Edition : {isbn.Edition}");
            Console.WriteLine($"Published Year : {isbn.PublishedYear}");

            foreach (var copy in isbn.BookCopies)
            {
                Console.WriteLine($"\nBook Copy Id : {copy.BookCopyId}");
                Console.WriteLine($"Book Status : {copy.BookStatus?.BookStatusName}");

                foreach (var borrowing in copy.Borrowings)
                {
                    Console.WriteLine($"\nBorrowing Id : {borrowing.BorrowingId}");
                    Console.WriteLine($"Member Id : {borrowing.MemberId}");
                    Console.WriteLine($"Borrowed Date : {borrowing.BorrowedDate}");
                    Console.WriteLine($"Due Date : {borrowing.DueDate}");
                    Console.WriteLine($"Return Date : {borrowing.ReturnDate}");
                    Console.WriteLine($"Borrowing Status : {borrowing.BorrowingStatus?.BorrowingStatusName}");

                    foreach (var fine in borrowing.Fines)
                    {
                        Console.WriteLine($"\nFine Id : {fine.FineId}");
                        Console.WriteLine($"Fine Amount : {fine.FineAmount}");
                        Console.WriteLine($"Fine Category : {fine.FineCategory?.FineCategoryName}");

                        if (fine.DamagedBook != null)
                        {
                            Console.WriteLine($"Damaged Book Id : {fine.DamagedBook.DamagedBookId}");
                            Console.WriteLine($"Damage Level : {fine.DamagedBook.DamagedLevel?.DamagedLevelName}");
                        }
                    }
                }
            }
        }
    }
}