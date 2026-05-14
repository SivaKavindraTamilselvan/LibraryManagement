namespace LibraryManagement.ModelLibrary.Models;
public class Member
{
    public int MemberId {get;set;}
    public string FirstName {get;set;} = string.Empty;
    public string LastName {get;set;} = string.Empty;
    public string Email {get;set;} = string.Empty;
    public string PhoneNumber {get;set;} = string.Empty;
    public string Password {get;set;} = string.Empty;
    public bool isActive {get;set;}
    public int MemberTypeId {get;set;}
    public MemberType? MemberType {get;set;}

}