## LIBRARY MANAGEMENT SYSTEM

## STEPS

Creation of the Multi Tier Library and App

- Model Library
- Data Access Library
- Bisness Layer Library
- Presentation Layer App


## INSTALLATION

- dotnet add package Microsoft.EntityFrameworkCore
- dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
- dotnet add package Microsoft.EntityFrameworkCore.Tools
- dotnet add package Microsoft.EntityFrameworkCore.Design

Ensure All The Packages are of same version to void any of the conflicts or any kind of errors

## CREATE THE ER DIAGRAM

<img width="1198" height="2423" alt="image" src="https://github.com/user-attachments/assets/b8d636c9-829e-4ec4-a58b-e3e0680a6c64" />


The Model Library is created with master and the normal tables

Master Tables

- BookStatus (available,unavailable,lost,damaged)
- BorrowingStatus (borrowed,returned,overdue)
- DamagedLevel (little,medium,hard) - include the default cost for each level of damage and the cost is fetched from here
- FineCategory (overdue,lost,damaged)
- MemberType (only for the user role)(basic,premium,student)
- Payment Method (Differnet method of payment) (cod,upi,cards)
- Role (So For 2 Roles are created) (Admin,User)

Normal Tables

- BookCategory
- Book
- BookISBN
- BookCopy
- Borrowing
- Fine
- DamagedBook
- Payment
- Member

## Book

For The Book Initially the book table contains the very common details such as booktitle,bookauthor,category.

For Each editon published year the ISBN number will be changed so created the separate Table for the ISBN Book conating the book id to link between the book and book isbn

Each Book with some ISBN Number can have different copies

The physical details of the book that is included in the book status is found in book copy

Each Book Copy Will have unique copy number

The borrowing of book is mainly handled in book copy as it mention the physical data of the book.

## Borrowing

While Borrowing the needed requirments are checked and the only data are inserted into the table

Done Using the procedure in the database

If any error it raise exception and rollback

## Returning

The admin can check the book and update the book status

as lost,damaged for internal fine calculation

## Fine

While Returning the Book The return date will be updated

The Fine will be automatically genereted usinf functions and the date they submit and inserted into the fine table

This return is handled in procedure while returning the book

Only borrow id is needed for it

The fine can be of three types

- overdue
- lost
- damaged

The usage of both lost and overdue is also implemented

The fine amount are listed in the tables

## DamagedBook

It include the person who damaged the book,which book etc

It helps to maintain the records of the person who are responsible for damaging the book often and can deactivate the member

## Payment

The fine amount can be paid by the user

No need to pay fully

As per their needed they can split and pay

The Data will be updated

Example - 500 rupees can be paid and 100,200,200 in any days and in any amount

The reflection will happen in the backend

## Model Library

Folder Structure

- Exceptions
- Models
    - Normal Table
    - Master Table
- Procedure and Functions


Exceptions

- Borrowing Exception (Any exceptions or list empty while handling borrowing process)
- Email Exception (raise message for the invalid email)
- Phone Number Exception (raise message for the invalid phone number)
- Invalid Book Exception (Any exceptions or list empty while handling book process)
- Invalid Member Exception (Any exceptions or list empty while handling member managment process)
- Name Exception (avoid entry of emty name or numbers or symbols in the name)
- Password Exception (validation for the strong password)
- Year Exception (entry for invalid year input)

Models

Master Tables

- BookStatus (available,unavailable,lost,damaged)
- BorrowingStatus (borrowed,returned,overdue)
- DamagedLevel (little,medium,hard) - include the default cost for each level of damage and the cost is fetched from here
- FineCategory (overdue,lost,damaged)
- MemberType (only for the user role)(basic,premium,student)
- Payment Method (Differnet method of payment) (cod,upi,cards)
- Role (So For 2 Roles are created) (Admin,User)

Normal Tables

- BookCategory (category name and id)
- Book (basic details of the book)
- BookISBN (unique book based on year and edition)
- BookCopy (copy of book available in the library linked to isbn)
- Borrowing (borrow the book)
- Fine (fine for overdue,lost and damaged implemnted)
- DamagedBook (check while returning the status of book if damaged then the person details and book details will be added)
- Payment (payement for the fine) (not needed to pay fully each time)
- Member (handled all the member data include the role and the member type)

Procedure And Function

- CheckBorrowRuleProcedure
- DeactivateMemberProcedure
- GetAmountFunction
- NumberOfBookByBookId (Function)
- NumberOfBookByCategory (Function)
- NumberOfBookByISBN (Function)
- PayFineProcedure
- ReturnbookLogicProcedure

CheckBorrowRuleProcedure

- check the member is active
- member id is found
- select the number of books available
- check the borrowing limit of the person
- check the pending fine
- check if already borrwed
- once all these are checked then the book copy id that will be given is the latest year,edition available book
- so it is assigned in decreasing order of year,edition based on the availabilty
- this is also implemented in the procedure
- status updated
- borrowing is added

DeactivateMemberProcedure

- check if member id exist
- if already deactivated raise exception
- check if any book is ordered
- if not can be deactivated

NumberOfBookByBookId

- generate the number of books available by book id
- input given as title
- id is got from the service
- passed to procedure

NumberOfBookByCategoryId

- generate the number of books by the category id

NumberOfBookByISBN

- generate the number of ISBN Books

GetAmountFunction

- generate the fine amout for overdue
- base amount rs 10

ReturnBookLogicProcedure

- while returning check the status
- if not overdue,lost and damaged then status of boook, and borrowing will be changed
- if overdue calculate the fine amount and added to fine table
- if lost the fine amount is added to fine table
- if damaged the level of damaged is collected and based on that added to damaged book table and then to fine tble linked by the damagedbookid
- based on these the status is changed and then updated

## DataAccessLibrary

### Folder Structure

- DBContext
- GenerateNumber
- Interface
- Migrations
- Repositories

### DBContext
- (contains the efcore context)
- the dbset are mentioned here
- the onbuilder model is added for the each table
- constraints , keys and the seed data are added

### GenerateNumber
- generate the Unique ISBN and Copy Number
- random unique numbers are allocated

### Interface
- IRepository (basic functions of the repositores)

### Migrations
- consist of the database table model
- changes that are made in database structure and constraints

### Repositories

- AbstractRepository
- BookCategoryRepository
- BookCopyRepository
- BookISBNRepository
- BookRepository
- BorrowingRepositiory
- DamagedBookRepo
- FineRepo
- MemberRepo
- PaymentRepo

### Abstract Repository
- Getall
- Create
- Update
- Get(override)

Note - in some situatuons these fucntions are not used for all the cases so i have created the seperate functions for the specific one

### Member Repository

- Get Member By Member Id
- GetAll Member
- Get Member By Email
- Get Member By PhoneNumber
- Activate and deactivate the member
- for deactivation the procedure is runned
- for activation the update in the abstract repo is runned as no needed to check the book borrowed , fine etc
- create member
- update the member type if needed
- get the member based on the member role

These are in some cases used repeatedly as the usage are same

### BookCategory Repository

- Get all The Book By Category
- get book by category id
- get number of books by category id

### Book Repository

- contains the basic details author,title,category id
- create baasic book 
- update also there in abstract repo. but not yet implemneted in choices
- Get Book By Book Id
- Get All Book
- Get Book By Title
- Get Book By Author
- GetNumberOfBookByBookTitle(int id) usage of fucntion is done here
- GetAllBooksReport(int id) (all details) (book,bookisbn,bookcopy,borrowing,fine,damagedtable)

These are in some cases used repeatedly as the usage are same

### BookISBN Repository

- contains the unique ISBN for the Each book published year and edition
-  BookISBN? Get(int key)
-  List<BookISBN> GetBookByISBNNumber(string number)
- create
- mostly used in include in other repositories

### BookCopy Repository

- Creation Of The BookCopy
- Get The BookCopy
- GetBookCopy By Copy Number (copy number generated unique)
- get the book by book status (available,unavailable,lost,damaged)
- the availabilty of books are done in this table

These are in some cases used repeatedly as the usage are same

### BorrowingRepository

- create borrowing (call the procedure)(procedure information are mentioned above)
- get by borrowing id
- return borrwing (call the procedure)(procedure information mentioned above)
- get borrowing details by member id
- get borrowing details by member email
- get borrowing details by the status of borrowing
- get borrowing details by the borrowed date
- get borrowing details by the due date
- get borrowing details by the return date
- get borrowing details by the book that have due date tomorrow
- get the borrowing details by book title
- get the borrowing details by book copy id
- get the pending return books
- get the overdue book details

### FineRepository

- while returning the book status needed to be verified by the admin
- based on the entry of the book status the return book will be evaluated
- if lost,overdue,damaged the fine will be created
- createfine done in return book procedure
- get fine by fine id
- get all fine
- member with pending fines
- get the all pending fines

### DamagedBookRepo

- damaged book are craeted in the return procedure while evaluating
- get the damaged book by id
- get all daaged book details

### PaymentRepo
- create payment
- call the procedure to check the conditions
- amount paid not exceeded the total fine
- amount can be splitted and paid
- get all the payment history details
- get the payment history details by member id

## BuisnessLayerLibrary

### Folder Structure

- InputsCheck
- Objects
- Services
    - AdminService
    - UserService
- Validation
    - Email
    - Phone Number
    - Year
    - Name

### InputsCheck 

Check the inputs. If not entered crctly loop untill crct inputs are entered

Common to avoid repeated code everywhere

- EmailInputs
- PhonenumberInput
- IdInput
- year input
- name input

### Objects

Created to avoid large number of parameter passed from the Program.cs to other folder
Every repo and management and roles are craeted in the one single folder program.cs

class and Object for the collections of repo created

### Validation

- Email Valdation
- Name Validation
- PhoneNumber Validation
- Year Validation

If any is woring then the excpetions will be called

### Services

### Admin Service

- BookCategoryService
    - AddCategory
- BookService
    - AddBookService
        - AddBasicBook
        - AddISBNBook
        - AddBookCopy
    - GetBookService
        - GetAllBooks()
        - GetBookByBookId(int id)
        - GetBookByBookTitle(string Title)
        - GetBookByBookAuthor(string author)
        - GetBookByISBNNumber(string number)
        - GetBookByCopyNumber(string CopyNumber)
        - GetBookByCategory(int id)
        - GetBookByStatus(int id)
        - GetBookIdByTitle(string title)
        - GetNumberOfBookByCategory(int id)
        - GetNumberOfBookByBookTitle(string title)
        - GetNumberOfBookByISBN(string isbn)
- BorrowingService
    - AddBorrowingService
    - GetBorrowingService
        - GetBorrowingById(int id)
        - GetBorrowingByMemberId(int id)
        - GetBorrowingByMemberEmail(string email)
        - GetBorrowingByBorrowingStatus(int id)
        - GetBorrowingByBorrowingDate(DateTime dateTime)
        - GetBorrowingByDueDate(DateTime dateTime)
        - GetBorrowingByReturnDate(DateTime dateTime)
        - GetBorrowingTmrw()
        - GetBorrowingByBookTitle(string title)
        - GetBorrowingByBookCopy(int id)
- MemberService
    - ActicateMember
    - DeactiavteMember
    - AddMember
    - GetMemberService
    - UpdateMemberTypeService
- PaymentService
    - AddPaymentService Remaining View Are in ReportService
- ReturnService
    - AddReturn
    - list of pending
- report service
    - GetReportOfOverDueBook()
    - GetMemberWithPendingFine()
    - GetMemberWithPendingFine(int id)
    - GetReportOfBookHistory(int id)
    - GetReportOfPaymentHistory()
    - GetReportOfDamagedBook() 

### UserService

- GetBooksBorrowed(string email)
- GetBooksReturned(string email)
- GetBooksOverDue(string email)
- GetFinePending(int id)
- GetPayments(int id)

### Presentation Layer

### Folder Structure

ApplicationFrontend
- Admin
- InitialPage (like login)
- User

### Initial Page

- Console.WriteLine("Enter 1 For Library Admin");
- Console.WriteLine("Enter 2 For User");

### AdminPage

### Main Admin Choice

- Console.WriteLine("Enter 1 For Member Managment");
- Console.WriteLine("Enter 2 For Book Manegment");
- Console.WriteLine("Enter 3 For Borrowing Managment");
- Console.WriteLine("Enter 4 For Return Managment");
- Console.WriteLine("Enter 5 For Fine Managment");
- Console.WriteLine("Enter 6 For Report Managment");

### MemberManagmentChoice

- Main Member Managment

    - Console.WriteLine("Enter 1 To Add The Member");
    - Console.WriteLine("Enter 2 To Get Member Details By Different Category");
    - Console.WriteLine("Enter 3 To Update The Member Details");
    - Console.WriteLine("Enter 4 To Deactivate The Member");
    - Console.WriteLine("Enter 5 To Activate The Member");
- Add Member
- Get Member Mangament
    - Console.WriteLine("Enter 1 To Get All Member Details");
    - Console.WriteLine("Enter 2 To Get All The Member Details By Email");
    - Console.WriteLine("Enter 3 To Get All The Member Details By Phone Number");
    - Console.WriteLine("Enter 4 To Get All The Member Details By Admin Role");
    - Console.WriteLine("Enter 5 To Get All The Member Details By User Role");
    - Console.WriteLine("Enter 6 To Get All The Member Details By Member Id");

- Update Member Managment

    - Console.WriteLine("Enter 1 To Update The Member Type Details By Email");
    - Console.WriteLine("Enter 2 To Update The Member Type Details By Phone Number");
    - Console.WriteLine("Enter 3 To Update The Member Type Details By Member Id");

- Deactivate Member Managment
    - Console.WriteLine("Enter 1 To Deactivate The Member By Email");
    - Console.WriteLine("Enter 2 To Deactivate The Member By Phone Number");
    - Console.WriteLine("Enter 3 To Deactivate The Member By Member Id");

- Activate Member Managment
    - Console.WriteLine("Enter 1 To activate The Member By Email");
    - Console.WriteLine("Enter 2 To activate The Member By Phone Number");
    - Console.WriteLine("Enter 3 To activate The Member By Member Id");

### Book Management Choice

Main Book Management

- Console.WriteLine("Enter 1 To Add The Book");
- Console.WriteLine("Enter 2 To Get Book Details By Different Category");
- Console.WriteLine("Enter 0 To Quit");

Add Book
- Console.WriteLine("Enter 1 To Add Basic Book Details");
- Console.WriteLine("Enter 2 To Add Book With Different Published year, edition (new ISBN)");
- Console.WriteLine("Enter 3 To Add Book Copies");

Get Book

- Console.WriteLine("Enter 1 To Get All Book Details");
- Console.WriteLine("Enter 2 To Get Book By Category Id");
- Console.WriteLine("Enter 3 To Get Book By Book Id");
- Console.WriteLine("Enter 4 To Get All Book Details By BookTitle");
- Console.WriteLine("Enter 5 To Get All Book Details By Author");
- Console.WriteLine("Enter 6 To Get All Book Details By ISBN Number");
- Console.WriteLine("Enter 7 To Get All Book Details By Copy Number");
- Console.WriteLine("Enter 8 To Get All The Books By Status");
- Console.WriteLine("Enter 9 To Get The Number Of The Books By Category");
- Console.WriteLine("Enter 10 To Get The Number Of The Books By Book Title");
- Console.WriteLine("Enter 11 To Get The Number Of The Books By ISBN");
- Console.WriteLine("Enter 0 To Quit");

### BorrowingManagment

MainBorrowingChoice

- Console.WriteLine("Enter 1 To Add Borrowing");
- Console.WriteLine("Enter 2 To Get Borrowing Details By Different Category");

Add Borrowing

Get Borrowing

- Console.WriteLine("Enter 1 To Get Borrowing Details By Borrowing Id");
- Console.WriteLine("Enter 2 To Get Borrowing Details By Member Id");
- Console.WriteLine("Enter 3 To Get Borrowing Details By Member Email");
- Console.WriteLine("Enter 4 To Get Borrowing Details By Borrowing Status");
- Console.WriteLine("Enter 5 To Get Borrowing Details By Borrowing Date");
- Console.WriteLine("Enter 6 To Get Borrowing Details By Return Date");
- Console.WriteLine("Enter 7 To Get Borrowing Details By Due Date");
- Console.WriteLine("Enter 8 To Get Borrowing Details That Have The Due Date Tomorrow");
- Console.WriteLine("Enter 9 To Get Borrowing Details By Book Title");

### Return Managment

- Console.WriteLine("Enter 1 To Return The Book");
- Console.WriteLine("Enter 2 To Get All The Book Details That Is Not Yet Returned");

### Fine Managment

- Console.WriteLine("Enter 1 To Pay The Fine Book");

### ReportManagment
-  Console.WriteLine("Enter 1 To Get The Report Of The Book Borrowed");
- Console.WriteLine("Enter 2 To Get The Report Of The OverDue Book");
- Console.WriteLine("Enter 3 To Get The Report Of The Members With Pending Fine");
- Console.WriteLine("Enter 4 To Get The Report Of The Available Books");
- Console.WriteLine("Enter 5 To Get The Report Of The Member History");
- Console.WriteLine("Enter 6 To Get The Report Of The Book History");   
- Console.WriteLine("Enter 7 To Get All The Payment History");
- Console.WriteLine("Enter 8 To Get The Damaged Book Details");         

### UserPage

- Console.WriteLine("Enter 1 Get The Book Borrowed");
- Console.WriteLine("Enter 2 Get The Book Returned");
- Console.WriteLine("Enter 3 Get The OverDue Books");
- Console.WriteLine("Enter 4 For Pending Fine");
- Console.WriteLine("Enter 5 For Fine Paid/History");

## SCREENSHOTS 

## MasterTable

Every Datas In The Master Table Are added as the seed data in the master table

Role

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/c386a856-5eec-40e9-b680-a612af0e8026" />

MemberType

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/454d8cee-cf83-4a52-a23b-82ac6afd81ca" />

Book Status

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/4fc57b24-b766-4ce3-ba80-52ae413cd242" />

Borrowing Status

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/f7bc3d2f-dc26-4091-abb7-bf6d2fa05619" />

DamagedLevel

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/338af222-78d9-4b51-b034-c9c16bc71729" />

FineCategory

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/212ba95c-9759-42ea-bfa4-203a64aca5f9" />

Mode Of Payment

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/8655b53c-1ce7-40a4-864d-0857998d2111" />
