namespace LibraryManagement.PresentationLayer.Frontend;
public partial class MemberManagement
{
    public void AddMember()
    {
        var member = adminService.AddMemberService();
        if(member == null)
        {
            Console.WriteLine("Member Not Added. Try Again");
            return;
        }
        Console.WriteLine("------- Member Added Successfully -------\n");
        Console.WriteLine($"MemberId : {member.MemberId}");
        Console.WriteLine($"Password : {member.Password}");
        Console.WriteLine($"User Can Change The Password As Per The Need. Initially Created By Admin\n\n");
    }
}