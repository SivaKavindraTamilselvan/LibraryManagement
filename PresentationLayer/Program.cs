using LibraryManagement.BuisnessLayerLibrary.Services;
using LibraryManagement.PresentationLayer.Frontend;
using NotificationAppDataAccessLibrary.Repositories;

namespace LibraryManagement.PresentationLayer;

public class Program
{
    static void Main(string[] args)
    {
        MemberRepository memberRepository = new MemberRepository();
        BookRepository bookRepository = new BookRepository();
        AdminService adminService = new AdminService(memberRepository,bookRepository);
        MemberManagement memberManagement = new MemberManagement(adminService);
        AdminRole adminRole = new AdminRole(memberManagement);
        InitialPage initialPage = new InitialPage(adminRole);
        initialPage.RoleSelection();
    }
}