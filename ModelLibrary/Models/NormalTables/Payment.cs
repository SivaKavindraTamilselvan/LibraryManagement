namespace LibraryManagement.ModelLibrary.Models;

public class Payment
{
    public int PaymentId {get;set;}
    public int FineId {get;set;}
    public Fine? Fine {get;set;}
    public decimal AmountPaid {get;set;}
    public int ModeOfPaymentId {get;set;}
    public ModeOfPayment? ModeOfPayment {get;set;}
    public DateTime PaymentDate {get;set;}
    public DateTime createdAt {get;set;}
}