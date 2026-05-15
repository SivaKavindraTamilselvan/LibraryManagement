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

    public int RoleId {get;set;}
    public Role? Role {get;set;}

    public DateTime createdAt {get;set;}
    public DateTime updatedAt{get;set;}

    public ICollection<DamagedBook>? DamagedBooks {get;set;}
    public ICollection<Borrowing>? Borrowings {get;set;}

    public override string ToString()
    {
        return $"MemberId : {MemberId}";
    }
}