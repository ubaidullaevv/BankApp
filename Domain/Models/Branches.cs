namespace Domain.Models;


public class Branch 
{
    public int BranchId { get; set; }
    public string? Name { get; set; }
    public string? Location { get; set; }
    public string? Phone { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Deleted_at { get; set; }

}