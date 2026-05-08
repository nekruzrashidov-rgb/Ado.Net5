namespace Domain.Models;

public class Orders
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; } = "";
    public int TotalAmount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
