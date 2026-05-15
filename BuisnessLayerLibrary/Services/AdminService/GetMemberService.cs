using LibraryManagement.BuisnessLayerLibrary.Interfaces;
using LibraryManagement.ModelLibrary.Models;

namespace LibraryManagement.BuisnessLayerLibrary.Services;

public partial class AdminService :IAdminService
{
    public List<Member>? GetAllMembers()
    {
        var memberList = memberRepository.GetAll();
        return memberList;
    }

}