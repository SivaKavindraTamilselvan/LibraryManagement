using LibraryManagement.ModelLibrary.Models;

namespace LibraryManagement.BuisnessLayerLibrary.Services;

public partial class AdminService
{
    public Payment? AddPayment()
    {
        Payment payment = new Payment();
        Console.WriteLine("Enter Fine Id");
        int fineId = inputsCheck.IdInputs();
        Console.WriteLine("Enter The Amount Paid");
        decimal amountPaid = Convert.ToDecimal(Console.ReadLine());
        Console.WriteLine("Enter The Mode Of Payment Id");
        int paymentId = inputsCheck.IdInputs();
        payment.FineId = fineId;
        payment.AmountPaid = amountPaid;
        payment.ModeOfPaymentId = paymentId;
        var createdPayment = paymentRepository.CreatePayment(payment);
        if(createdPayment == null)
        {
            return null;
        }
        return createdPayment;
    } 
}