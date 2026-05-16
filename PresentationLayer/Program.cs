using LibraryManagement.BuisnessLayerLibrary.Services;
using LibraryManagement.DataAccessLibrary.Object;
using LibraryManagement.PresentationLayer.Frontend;
using LibraryManagement.PresentationLayer.Frontend.Object;

namespace LibraryManagement.PresentationLayer;

public class Program
{
    static void Main(string[] args)
    {
        RepositoryManagment repositoryManagment = new RepositoryManagment();
        AdminService adminService = new AdminService(repositoryManagment);

        MangmentManager mangmentManager = new MangmentManager(adminService);

        AdminRole adminRole = new AdminRole(mangmentManager);
        InitialPage initialPage = new InitialPage(adminRole);
        initialPage.RoleSelection();
    }
}