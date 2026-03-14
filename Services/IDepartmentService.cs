using WebApplication4.Models;

namespace WebApplication4.Services;

public interface IDepartmentService
{
    Task<IEnumerable<Department>> GetAllAsync();
    Task<Department?> GetById(int id);
    Task<Department> CreateAsync(Department department);
    Task<bool> UpdateAsync(int id, Department department);
    Task<bool> DeleteAsync(int id);
}