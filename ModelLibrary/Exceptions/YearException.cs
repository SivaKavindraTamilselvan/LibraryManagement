namespace LibraryManagement.ModelLibrary.Exceptions;

public class YearException : Exception
{
    private static string message = "Year Entered Is Not Valid.";
    public YearException() : base(message)
    {
        
    }
}