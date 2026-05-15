using LibraryManagement.BuisnessLayerLibrary.Inputs;
using LibraryManagement.BuisnessLayerLibrary.Interfaces;
using LibraryManagement.DataAccessLibrary.UniqueISBN;
using LibraryManagement.ModelLibrary.Exceptions;
using LibraryManagement.ModelLibrary.Models;
using NotificationAppDataAccessLibrary.Repositories;

namespace LibraryManagement.BuisnessLayerLibrary.Services;

public partial class AdminService : IAdminService
{
    protected readonly MemberRepository memberRepository;
    protected readonly BookRepository bookRepository;
    protected readonly BookISBNRepository bookISBNRepository;
    protected readonly BookCategoryRepository bookCategoryRepository;
    protected readonly BookCopyRepository bookCopyRepository;

    protected readonly GenerateUnique generateUnique;


    public AdminService(MemberRepository _memberRepository, BookRepository _bookRepository, BookCategoryRepository _bookCategoryRepository, BookISBNRepository _bookISBNRepository,BookCopyRepository _bookCopyRepository)
    {
        memberRepository = _memberRepository;
        bookRepository = _bookRepository;
        bookCategoryRepository = _bookCategoryRepository;
        bookISBNRepository = _bookISBNRepository;
        bookCopyRepository = _bookCopyRepository;
        generateUnique = new GenerateUnique();
    }
    InputsCheck inputsCheck = new InputsCheck();
    public Member? AddMemberService()
    {
        Member member = new Member();
        Console.WriteLine("Enter Your First Name");
        string FirstName = Console.ReadLine() ?? "";
        while (FirstName.Trim() == "")
        {
            Console.WriteLine("Inavlid Name.Name Should Not be Empty.Enter Valid Name");
            FirstName = Console.ReadLine() ?? "";
        }

        Console.WriteLine("Enter Your First Name");
        string LastName = Console.ReadLine() ?? "";
        while (LastName.Trim() == "")
        {
            Console.WriteLine("Inavlid Name.Name Should Not be Empty.Enter Valid Name");
            LastName = Console.ReadLine() ?? "";
        }

        Console.WriteLine("Enter Your Email");
        string Email = inputsCheck.EmailInputs();
        if (GetMemberByEmail(Email) != null)
        {
            throw new InvalidMemberException("Already the Email Is Registered. Try With Another Email");
        }

        Console.WriteLine("Enter Your PhoneNumber");
        string PhoneNumber = inputsCheck.PhoneNumberInputs();
        if (GetMemberByPhoneNumber(PhoneNumber) != null)
        {
            throw new InvalidMemberException("Already the PhoneNumber Is Registered. Try With Another PhoneNumber");
        }

        Console.WriteLine("Enter The RoleType");
        Console.WriteLine("Enter 1 To Add Admin");
        Console.WriteLine("Enter 2 To Add Member");
        int typechoice;
        while (!int.TryParse(Console.ReadLine(), out typechoice) || typechoice < 0 || typechoice > 2)
        {
            Console.WriteLine("Enter Vaild Role Type Input");
        }

        if (typechoice == 2)
        {
            int memberchoice;
            Console.WriteLine("Enter The MemberType");
            Console.WriteLine("Enter 1 To Basic");
            Console.WriteLine("Enter 2 To Student");
            Console.WriteLine("Enter 3 To Premium");
            while (!int.TryParse(Console.ReadLine(), out memberchoice) || memberchoice < 0 || memberchoice > 3)
            {
                Console.WriteLine("Enter Vaild Member Type Input");
            }
            member.MemberTypeId = memberchoice;
        }
        else
        {
            member.MemberTypeId = null;
        }

        //member detailed added to the object
        member.FirstName = FirstName;
        member.LastName = LastName;
        member.Email = Email;
        member.PhoneNumber = PhoneNumber;
        member.Password = FirstName + LastName + "123"; // initially added by the admin later can be changed by the user
        member.isActive = true;
        member.RoleId = typechoice;
        member.createdAt = DateTime.Now;
        var createdMember = memberRepository.Create(member);
        if (createdMember == null)
        {
            return null;
        }
        return createdMember;
    }
}
