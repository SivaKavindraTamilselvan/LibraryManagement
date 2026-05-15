namespace LibraryManagement.PresentationLayer.Frontend;
public partial class MemberManagement
{
    public void AddMember()
    {
        var member = adminService.AddMemberService();
        Console.WriteLine(member);
    }
}