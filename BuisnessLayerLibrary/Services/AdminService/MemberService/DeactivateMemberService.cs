using LibraryManagement.BuisnessLayerLibrary.Interfaces;
using LibraryManagement.ModelLibrary.Exceptions;
using LibraryManagement.ModelLibrary.Models;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LibraryManagement.BuisnessLayerLibrary.Services;

public partial class AdminService 
{
    public Member? DeactivateTheMemberByMemberId(int id)
    {
        var updatedMember = memberRepository.DeactivateMember(id);
        return updatedMember;
    }
    public Member? DeactivateTheMemberByEmail(string email)
    {
        var member = memberRepository.GetMemberByEmail(email);
        if(member == null)
        {
            throw new InvalidMemberException("Member Id Not Found");
        }
        var updatedMember = memberRepository.DeactivateMember(member.MemberId);
        return updatedMember;
    }
    public Member? DeactivateTheMemberByPhoneNumber(string PhoneNumber)
    {
        var member = memberRepository.GetMemberByPhoneNumber(PhoneNumber);
        if(member == null)
        {
            throw new InvalidMemberException("Member Id Not Found");
        }
        var updatedMember = memberRepository.DeactivateMember(member.MemberId);
        return updatedMember;
    }
}
