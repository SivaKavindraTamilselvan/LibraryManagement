using LibraryManagement.BuisnessLayerLibrary.Services;
using LibraryManagement.PresentationLayer.Frontend;

namespace LibraryManagement.PresentationLayer;
public class Program
{
    static void main(string[] args)
    {
        AdminService adminService = new AdminService();
        MemberManagement memberManagement = new MemberManagement(adminService);
        AdminRole adminRole = new AdminRole(memberManagement);
        InitialPage initialPage = new InitialPage(adminRole);
        initialPage.RoleSelection();
    }
}