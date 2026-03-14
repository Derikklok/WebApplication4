using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;
using WebApplication4.Services;

namespace WebApplication4.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentService _departmentService;

    public DepartmentController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetDepartments()
    {
        var departments = await _departmentService.GetAllAsync();
        return Ok(departments);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDepartment(int id)
    {
        var department = await _departmentService.GetById(id);

        if (department == null)
            return NotFound();

        return Ok(department);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDepartment([FromBody] Department department)
    {
        // check the user inpput values [required] fields and pass nice errors
        /*
         * When the JSON data comes in from the user, ASP.NET immediately checks it against your Model's rules ([Required], [MaxLength]).

The result of that check is stored inside a dictionary called ModelState.

            if (!ModelState.IsValid): This translates to: "If the user broke ANY of our data rules..."

            return BadRequest(ModelState);: Instead of crashing the app or bothering the database, the Waiter stops right there and sends back an HTTP 400 Bad Request.

            Even better: Because you pass ModelState into the BadRequest(), the user gets a beautiful, automatic error message telling them exactly what they did wrong (e.g., "The Name field is required" or "The Name must be less than 100 characters").
         */
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var created = await _departmentService.CreateAsync(department);

        return CreatedAtAction(nameof(GetDepartment), new { id = created.Id }, created);
    }
}