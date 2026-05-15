using LibraryManagement.PresentationLayer.Frontend;

namespace LibraryManagement.PresentationLayer;
public class Program
{
    static void main(string[] args)
    {
        MemberManagement memberManagement = new MemberManagement();
        AdminRole adminRole = new AdminRole(memberManagement);
        InitialPage initialPage = new InitialPage(adminRole);
        initialPage.RoleSelection();
    }
}