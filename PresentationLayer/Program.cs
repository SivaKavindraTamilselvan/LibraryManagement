using LibraryManagement.PresentationLayer.Frontend;

namespace LibraryManagement.PresentationLayer;
public class Program
{
    static void main(string[] args)
    {
        AdminRole adminRole = new AdminRole();
        InitialPage initialPage = new InitialPage(adminRole);
        initialPage.RoleSelection();
    }
}