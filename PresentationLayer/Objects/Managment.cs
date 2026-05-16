using LibraryManagement.BuisnessLayerLibrary.Services;

namespace LibraryManagement.PresentationLayer.Frontend.Object;
public class MangmentManager
{
    public BookManagement bookManagement {get;set;}
    public MemberManagement memberManagement {get;set;}
    public BorrowingManagement borrowingManagement {get;set;}
    public ReturnManagement returnManagement {get;set;}
    public FineManagement fineManagement {get;set;}
    public ReportManagement reportManagement {get;set;}

    public MangmentManager(AdminService adminService)
    {
        bookManagement = new BookManagement(adminService);
        memberManagement = new MemberManagement(adminService);
        borrowingManagement = new BorrowingManagement(adminService);
        returnManagement = new ReturnManagement(adminService);
        fineManagement = new FineManagement(adminService);
        reportManagement = new ReportManagement(adminService);
    }
}