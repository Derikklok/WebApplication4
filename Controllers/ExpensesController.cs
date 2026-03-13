using Microsoft.AspNetCore.Mvc;
using WebApplication4.Data;
using WebApplication4.DTOs;
using WebApplication4.Models;

namespace WebApplication4.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpensesController : ControllerBase
{
    // readonly - donot change the appdbcontext 
    // _ - to readability to ensure that it is private
    private readonly AppDbContext _context;

    public ExpensesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAllExpenses()
    {
        var expenses = _context.Expenses.ToList();
        return Ok(expenses);
    }

    // GET by id  , Task is similar to a promise in c#
    [HttpGet("{id}")]
    public async Task<ActionResult<Expense>> GetExpense(int id)
    {
        var expense = await _context.Expenses.FindAsync(id);

        if (expense == null)
        {
            return NotFound();
        }

        return Ok(expense);
    }

    // POST  api/expenses
    [HttpPost]
    public async Task<ActionResult<Expense>> CreateExpense(CreateExpenseDto dto)
    {
        var expense = new Expense
        {
            Title = dto.Title,
            Amount = dto.Amount,
            Category = dto.Category,
            Date = dto.Date
        };

        _context.Expenses.Add(expense);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetExpense), new { id = expense.Id }, expense);
    }

    // PUT: api/expense/1
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateExpense(int id, UpdateExpenseDto dto)
    {
        var expense = await _context.Expenses.FindAsync(id);

        if (expense == null)
        {
            return NotFound();
        }

        expense.Title = dto.Title;
        expense.Amount = dto.Amount;
        expense.Category = dto.Category;
        expense.Date = dto.Date;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // Delete : ape/expenses/4
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExpense(int id)
    {
        var expense = await _context.Expenses.FindAsync(id);

        if (expense == null)
            return NotFound();

        _context.Expenses.Remove(expense);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}