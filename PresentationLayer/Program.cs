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
        AdminService adminService = new AdminService(memberRepository,bookRepository,bookCategoryRepository,bookISBNRepository,bookCopyRepository);

        MemberManagement memberManagement = new MemberManagement(adminService);
        BookManagement bookManagement = new BookManagement(adminService);
        AdminRole adminRole = new AdminRole(memberManagement,bookManagement);
        InitialPage initialPage = new InitialPage(adminRole);
        initialPage.RoleSelection();
    }
}