using LibraryManagement.BuisnessLayerLibrary.Services;
using LibraryManagement.PresentationLayer.Frontend;
using NotificationAppDataAccessLibrary.Repositories;

namespace LibraryManagement.PresentationLayer;

public class Program
{
    static void Main(string[] args)
    {
        MemberRepository memberRepository = new MemberRepository();
        BookCategoryRepository bookCategoryRepository = new BookCategoryRepository();
        BookRepository bookRepository = new BookRepository();
        BookISBNRepository bookISBNRepository = new BookISBNRepository();
        BookCopyRepository bookCopyRepository = new BookCopyRepository();
        BorrowingRepository borrowingRepository = new BorrowingRepository();
        AdminService adminService = new AdminService(memberRepository,bookRepository,bookCategoryRepository,bookISBNRepository,bookCopyRepository,borrowingRepository);

        MemberManagement memberManagement = new MemberManagement(adminService);
        BookManagement bookManagement = new BookManagement(adminService);
        BorrowingManagement borrowingManagement = new BorrowingManagement(adminService);
        AdminRole adminRole = new AdminRole(memberManagement,bookManagement,borrowingManagement);
        InitialPage initialPage = new InitialPage(adminRole);
        initialPage.RoleSelection();
    }
}