using System.Text.RegularExpressions;
using LibraryManagement.ModelLibrary.Exceptions;

namespace LibraryManagement.BuisnessLayerLibrary.Validation;

public class YearValidation
{
    //implementation of phone validation by using regex pattern
    public static void isValidYear(int year)
    {
        if(year<1000 || year>DateTime.Now.Year)
        {
            throw new YearException();
        }
    }
}