
using LibraryManagement.DataAccessLibrary.DBContext;
using LibraryManagement.ModelLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace NotificationAppDataAccessLibrary.Repositories;

public class MemberRepository : AbstractRepository<int, Member>
{
    public override Member? Get(int MemberId)
    {
        var member = libraryManagementContext.Member.Include(r=>r.Role).Include(mt=>mt.MemberType).Where(m=>m.MemberId == MemberId).FirstOrDefault();
        return member;
    }

    public List<Member>? GetAllMembers()
    {
        var member = libraryManagementContext.Member.Include(r=>r.Role).Include(mt=>mt.MemberType).ToList();
        return member;
    }
    public Member? GetMemberByEmail(string email)
    {
        var member = libraryManagementContext.Member.Include(r=>r.Role).Include(mt=>mt.MemberType).Where(m=>m.Email == email).FirstOrDefault();
        return member;
    }
    public Member? GetMemberByPhoneNumber(string PhoneNumber)
    {
        var member = libraryManagementContext.Member.Include(r=>r.Role).Include(mt=>mt.MemberType).Where(m=>m.PhoneNumber == PhoneNumber).FirstOrDefault();
        return member;
    }

    public List<Member>? GetMemberByRole(int RoleId)
    {
        var member = libraryManagementContext.Member.Include(r=>r.Role).Include(mt=>mt.MemberType).Where(m=>m.RoleId == RoleId).ToList();
        return member;
    }

    public Member? DeactivateMember(int memberId)
    {
        using var context = new LibraryManagementContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            context.Database.ExecuteSqlInterpolated($"CALL deactivate_member({memberId})");
            transaction.Commit();
            var member = context.Member.AsNoTracking().Where(b => b.MemberId == memberId).FirstOrDefault();
            return member;
        }
        catch (PostgresException ex)
        {
            Console.WriteLine(ex.MessageText);
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            Console.WriteLine(ex.Message);
        }
        return null;
    }

}
