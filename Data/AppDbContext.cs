using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Expense> Expenses { get; set; }
}