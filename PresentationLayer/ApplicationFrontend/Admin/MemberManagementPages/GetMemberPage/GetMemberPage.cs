using LibraryManagement.ModelLibrary.Exceptions;

namespace LibraryManagement.PresentationLayer.Frontend;

public partial class MemberManagement
{
    public void GetAllMembers()
    {
        var memberList = adminService.GetAllMembers();
        if(memberList == null)
        {
            throw new InvalidMemberException("No members are Found in the list");
        }
        foreach(var member in memberList)
        {
            Console.WriteLine(member);
        }
    }
}