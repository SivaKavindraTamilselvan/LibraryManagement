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

Member Type

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/2aa38b35-6ef2-4cae-8237-17f0c9f585b3" />

Book Status

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/454d8cee-cf83-4a52-a23b-82ac6afd81ca" />

Borrowing Status

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/4fc57b24-b766-4ce3-ba80-52ae413cd242" />

DamagedLevel

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/f7bc3d2f-dc26-4091-abb7-bf6d2fa05619" />

FineCategory

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/338af222-78d9-4b51-b034-c9c16bc71729" />

Mode Of Payment

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/212ba95c-9759-42ea-bfa4-203a64aca5f9" />

## Screenshots For Member Managment From Admin

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/33dfcb47-161c-47ad-9c75-a365340961d0" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/a9c01f3d-5c44-4ad4-8151-f4e9f9d5a094" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/e5503438-62a8-41fe-96d9-3d2225c6b0fb" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/752a5aeb-94b5-4a3c-9b6c-83abbb179d78" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/a2e1f58f-f7a0-48a2-9de2-42543719adbd" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/5230acd0-c805-4ba2-bfc5-0ef049559b63" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/675d01ce-9504-4c84-a037-ec10e5fc6336" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/e0390fdf-9b76-4f93-b4e5-4557762554e5" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/8dda184a-8acc-4404-acf6-33b433c0c25d" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/dc447270-dd8f-453c-88f4-557a645b735c" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/ee489eb2-0ce7-4bff-bcb1-008a9b4e6314" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/a43c622d-00bb-40a5-bd7a-ec638943a3c9" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/32755e80-32d8-4289-b6d9-082d52d67811" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/d581d29e-5e44-4958-b1c1-23980de2ce63" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/c6a8d82f-79b0-43b1-a170-141d17258dc6" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/e622a209-08e0-4646-9dfd-5ee13f50c792" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/d6424046-9fc5-4833-a35f-0b9f47bb6c12" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/9e164343-f981-4ec8-9a29-bd82e62e2061" />

## Screenshots For Book Managment
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/319c4d48-7f05-4def-ba7a-9e7d06d2de27" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/4ccba19a-9bb7-442c-93ca-f4dc305e7d6b" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/758b6348-7118-4f80-b585-9663fd1ee163" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/0e3453d8-9785-48ec-aafb-19709b976f9f" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/f67729d4-ac25-434d-b6d9-8da5ee782f50" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/55ec6d20-ec81-4f36-bb2e-7d9d8aca03c9" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/fed9a5d7-a58c-40e4-8ca5-2d03312d99de" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/97fa0c45-5130-4048-8ad9-8509631e9a4a" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/c4ce0682-574f-4447-8be5-8b06e4667281" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/fcd4bb39-44dc-4b92-bc2a-af6d8d59c423" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/68f852d8-97fc-4253-9f53-2e3d9c0c76de" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/d6a96afb-8347-4a4b-8310-7ea7b54c465d" />

## Screenshots For Borrowing Managment


- Note - While Returning the borrowing details the member email and Book Copy Number not displyed. Later Corrected in the code 
- var borrowing = libraryManagementContext.Borrowing.AsNoTracking().Include(b => b.Member).Include(b => b.BookCopy).Where(b => b.MemberId == memberId).OrderByDescending(b => b.BorrowedDate).FirstOrDefault();
- Not linked with other table initially later rectified**

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/646f8c20-42fc-4af3-a10e-96a6b028d769" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/89aea22a-bcad-44c4-ac66-7273c994c2ab" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/cfdb1fa7-1e52-471d-a071-a842b221a094" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/dce079da-bedd-4d16-af05-79a14d741307" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/f106c56d-8a2d-4f12-b907-fb52ae2dc4be" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/1f7c3d11-4a51-413d-ba93-01a5e33e1326" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/c1d4693a-0806-45ca-8f17-e964be8efbf4" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/f6549015-69b7-4d8a-86da-6cc9b0799c2d" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/1958228a-1b91-46e1-aa59-7addfbef43f8" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/5d6da22c-099c-4d8f-a3a8-77bd6241f57b" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/db74ae30-dad4-431e-b766-58a3959ec29b" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/e7cb0f5d-7f20-4fd6-8ca0-f4221527efc0" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/625611bb-9e25-4e29-a0ac-50d5cf3b7dc7" />

## Screenshots For Return Managment
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/3643e9f8-1b89-4455-8ffc-e9b180ec4ded" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/e3944434-0edc-4c1f-ae25-a2f6d3478bdf" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/6d4c57f4-e90b-43fc-a291-5d0594531ddc" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/d69bc375-786e-4cb7-b169-aa19b677d5dc" />

## Screenshot For Fine Managmnet

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/a26c7466-e7a5-488b-9fa9-5c6092a54e23" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/f91dfe89-ee80-40a2-9f37-2de81ac5bdd2" />

## Screenshot For Payment

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/d095c2c9-8d83-4940-9a11-0ce36031f877" />

## Screenshot For Report Managmnet
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/8cdc8f1d-1f03-494a-a809-f85eede0986a" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/64f6c62f-0019-4c3e-94d2-45bd34838cd9" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/f8a703a4-ae7b-4696-9ece-48d0ab203ef3" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/7c28a8e6-08ea-4d51-a455-61db998c6224" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/28b1b663-c039-4dc4-aef6-8a06e3257a36" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/1c54ef98-97ee-4257-af4f-cb4ff66d8d35" />



