using LibraryManagement.ModelLibrary.Exceptions;

namespace LibraryManagement.PresentationLayer.Frontend;

public partial class MemberManagement
{
    public void GetAllMembers()
    {
        Console.WriteLine("\n\n================ All Member Details ================\n");
        var memberList = adminService.GetAllMembers();
        if (memberList == null)
        {
            throw new InvalidMemberException("No members are Found in the list");
        }
        foreach (var member in memberList)
        {
            Console.WriteLine(member);
        }
        Console.WriteLine("\n====================================================\n\n");
    }
    public void GetMemberByEmail(string email)
    {
        Console.WriteLine("\n\n============== Member Details By Email ==============\n");
        var member = adminService.GetMemberByEmail(email);
        if (member == null)
        {
            throw new InvalidMemberException($"Member Not Found With the Email : {email}");
        }
        Console.WriteLine(member);
        Console.WriteLine("\n====================================================\n\n");
    }

    public void GetMemberByPhoneNumber(string PhoneNumber)
    {
        Console.WriteLine("\n\n========== Member Details By Phone Number ==========\n");
        var member = adminService.GetMemberByPhoneNumber(PhoneNumber);
        if (member == null)
        {
            throw new InvalidMemberException($"Member Not Found With the Phone Number : {PhoneNumber}");
        }
        Console.WriteLine(member);
        Console.WriteLine("\n====================================================\n\n");

    }
    public void GetMemberByRole(int RoleId)
    {
        Console.WriteLine("\n\n============== Member Details By Role =============\n");
        var memberList = adminService.GetMemberByRole(RoleId);
        if (memberList == null)
        {
            throw new InvalidMemberException($"Member Not Found With the Role");
        }
        foreach (var member in memberList)
        {
            Console.WriteLine(member);
        }
        Console.WriteLine("\n====================================================\n\n");

    }
    public void GetMemberById(int MemberId)
    {
        Console.WriteLine("\n\n============ Member Details By Member ID ============\n");
        var member = adminService.GetMemberById(MemberId);
        if (member == null)
        {
            throw new InvalidMemberException($"Member Not Found With the Member Id : {MemberId}");
        }
        Console.WriteLine(member);
        Console.WriteLine("\n====================================================\n\n");

    }
}