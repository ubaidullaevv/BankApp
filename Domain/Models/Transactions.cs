namespace Domain.Models;


public class Transaction 
{
    public int TransactionId { get; set; }
    public string? FromAccountId { get; set; }
    public string? TomAccountId { get; set; }
    public DateTime IssuedDate { get; set; }
    public decimal Amount { get; set; }
    public string? TransactionMedium { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Deleted_at { get; set; }

}