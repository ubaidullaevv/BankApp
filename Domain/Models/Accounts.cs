namespace Domain.Models;


public class Account 
{
    public int AccountId { get; set; }
    public int CustomerId { get; set; }
    public decimal Balance { get; set; }
    public string? AccountStatus { get; set; }
    public string? AccountType { get; set; }
    public string? Currency { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Deleted_at { get; set; }

}