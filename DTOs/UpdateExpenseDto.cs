namespace WebApplication4.DTOs;

public class UpdateExpenseDto
{
    public string Title { get; set; } = "";

    public decimal Amount { get; set; }

    public string Category { get; set; } = "";

    public DateTime Date { get; set; }
}