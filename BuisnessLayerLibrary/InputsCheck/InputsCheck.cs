using LibraryManagement.BuisnessLayerLibrary.Validation;
namespace LibraryManagement.BuisnessLayerLibrary.Inputs;

public class InputsCheck
{
    //email input is checked and validated
    public string EmailInputs()
    {
        string email = Console.ReadLine() ?? string.Empty;
        //loop until valid entry is entered
        while (true)
        {
            try
            {
                //call validation function
                EmailValidation.isValidEmail(email);
                return email;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Enter Valid Email Address Again");
                email = Console.ReadLine() ?? "";
            }
        }
    }
    public string PhoneNumberInputs()
    {
        string phone = Console.ReadLine() ?? string.Empty;
        //loop until valid entry is entered
        while (true)
        {
            try
            {
                //call validation function
                PhoneNumberValidation.isValidPhoneNumber(phone);
                return phone;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Enter Valid Phone Number Again");
                phone = Console.ReadLine() ?? "";
            }
        }
    }
    public int IdInputs()
    {
        Console.WriteLine("Enter Id");
        int id;
        //loop until valid entry is entered
        while (!int.TryParse(Console.ReadLine(), out id) || id < 0)
        {
            Console.WriteLine("Enter Vaild Input");
        }
        return id;
    }
    public int YearInputs()
    {
        Console.WriteLine("Enter the Year");
        int year = Convert.ToInt32(Console.ReadLine());
        while (true)
        {
            try
            {
                YearValidation.isValidYear(year);
                return year;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Enter Valid Year Again");
                year = Convert.ToInt32(Console.ReadLine());
            }
        }
    }
    public string NameInput()
    {
        string name = Console.ReadLine() ?? "";
        while (true)
        {
            try
            {
                NameValidation.isValidName(name);
                return name;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Enter Valid Name Again");
                name = Console.ReadLine() ?? "";
            }
        }
    }
}