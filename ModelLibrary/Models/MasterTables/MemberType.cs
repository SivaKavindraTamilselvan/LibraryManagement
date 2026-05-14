namespace LibraryManagement.ModelLibrary.Models;

public class MemberType
{
    public int MemberTypeId {get;set;}
    public string MemberTypeName {get;set;} = string.Empty;
    public int Number_Of_Books {get;set;}
    public int Limit_Days {get;set;}
    public ICollection<Member> Members { get; set; } = new List<Member>();
}