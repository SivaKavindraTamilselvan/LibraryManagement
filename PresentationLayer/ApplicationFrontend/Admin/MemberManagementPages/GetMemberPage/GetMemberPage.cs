using LibraryManagement.ModelLibrary.Exceptions;

namespace LibraryManagement.PresentationLayer.Frontend;

public partial class MemberManagement
{
    public void GetAllMembers()
    {
        var memberList = adminService.GetAllMembers();
        if (memberList == null)
        {
            throw new InvalidMemberException("No members are Found in the list");
        }
        foreach (var member in memberList)
        {
            Console.WriteLine(member);
        }
    }
    public void GetMemberByEmail(string email)
    {
        var member = adminService.GetMemberByEmail(email);
        if (member == null)
        {
            throw new InvalidMemberException($"Member Not Found With the Email : {email}");
        }
        Console.WriteLine(member);
    }

    public void GetMemberByPhoneNumber(string PhoneNumber)
    {
        var member = adminService.GetMemberByPhoneNumber(PhoneNumber);
        if (member == null)
        {
            throw new InvalidMemberException($"Member Not Found With the Phone Number : {PhoneNumber}");
        }
        Console.WriteLine(member);
    }
    public void GetMemberByRole(int RoleId)
    {
        var member = adminService.GetMemberByRole(RoleId);
        if (member == null)
        {
            throw new InvalidMemberException($"Member Not Found With the Role");
        }
        Console.WriteLine(member);
    }
    public void GetMemberById(int MemberId)
    {
        var member = adminService.GetMemberById(MemberId);
        if (member == null)
        {
            throw new InvalidMemberException($"Member Not Found With the Member Id : {MemberId}");
        }
        Console.WriteLine(member);
    }
}