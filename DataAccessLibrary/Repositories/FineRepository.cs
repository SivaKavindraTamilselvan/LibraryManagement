using LibraryManagement.ModelLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace NotificationAppDataAccessLibrary.Repositories;

public class FineRepository : AbstractRepository<int, Fine>
{
    public override Fine? Get(int key)
    {
        //var book = libraryManagementContext.Book.Include(b => b.BookCategory).Include(bi=>bi.BookISBNs).ThenInclude(bc=>bc.BookCopies).ThenInclude(bs=>bs.BookStatus).Where(b => b.BookId == key).FirstOrDefault();
        return null;
    }

    public List<Fine> GetReportOfMemberWithPendingFine()
    {
        var memberList = libraryManagementContext.Fine.Include(fc=>fc.FineCategory).Include(b=>b.Borrowing).ThenInclude(bc=>bc.BookCopy).ThenInclude(bi=>bi.BookISBN).ThenInclude(b=>b.Book).Include(b=>b.Borrowing).ThenInclude(m=>m.Member).ThenInclude(mt=>mt.MemberType).Where(b=>b.IsPaidFully == false).ToList();
        return memberList;
    }

    public List<Fine> GetReportOfMemberWithPendingFine(int id)
    {
        var memberList = libraryManagementContext.Fine.Include(fc=>fc.FineCategory).Include(b=>b.Borrowing).ThenInclude(bc=>bc.BookCopy).ThenInclude(bi=>bi.BookISBN).ThenInclude(b=>b.Book).Include(b=>b.Borrowing).ThenInclude(m=>m.Member).ThenInclude(mt=>mt.MemberType).Where(b=>b.IsPaidFully == false).Where(b=>b!.Borrowing!.Member!.MemberId == id).ToList();
        return memberList;
    }
}