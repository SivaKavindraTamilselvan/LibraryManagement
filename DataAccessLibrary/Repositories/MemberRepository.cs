
using LibraryManagement.ModelLibrary.Models;

namespace NotificationAppDataAccessLibrary.Repositories;

public class MemberRepository : AbstractRepository<int, Member>
{
    public override Member? Get(int MemberId)
    {
        var member = libraryManagementContext.Members.Where(m=>m.MemberId == MemberId).FirstOrDefault();
        return member;
    }
    public Member? GetMemberByEmail(string email)
    {
        var member = libraryManagementContext.Members.Where(m=>m.Email == email).FirstOrDefault();
        return member;
    }
    public Member? GetMemberByPhoneNumber(string PhoneNumber)
    {
        var member = libraryManagementContext.Members.Where(m=>m.PhoneNumber == PhoneNumber).FirstOrDefault();
        return member;
    }

    public Member? GetMemberByRole(int RoleId)
    {
        var member = libraryManagementContext.Members.Where(m=>m.RoleId == RoleId).FirstOrDefault();
        return member;
    }
}
