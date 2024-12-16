namespace Domain.Models;


public class Loan 
{
    public int LoanId { get; set; }
    public int CustomerId { get; set; }
    public int BranchId { get; set; }
    public decimal Amount { get; set; }
    public DateTime issueddate { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Deleted_at { get; set; }

}