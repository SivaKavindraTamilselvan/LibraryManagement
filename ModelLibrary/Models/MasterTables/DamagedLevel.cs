namespace LibraryManagement.ModelLibrary.Models;

public class DamagedLevel
{
    public int DamagedLevelId {get;set;}
    public string DamagedLevelName {get;set;} = string.Empty;
    public decimal FineAmount {get;set;}
    public ICollection<DamagedBook>? DamagedBooks {get;set;}
}