namespace Domain.Models;


public class Customer 
{
    public int CustomerId { get; set; }
    public string? FullName { get; set; }
    public string? City { get; set; }
    public string? Phone { get; set; }
    public string? CardNumber { get; set; }
    public DateTime DOB { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Deleted_at { get; set; }

}