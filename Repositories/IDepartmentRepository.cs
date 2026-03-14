using WebApplication4.Models;

namespace WebApplication4.Repositories;

public interface IDepartmentRepository
{
    // IEnumerable is collection of features List is one of them
    Task<IEnumerable<Department>> GetAllAsync();
    Task<Department?> GetByIdAsync(int id);

    Task<Department> CreateAsync(Department department);

    // update and delete does not return data in here
    Task UpdateAsync(Department department);
    Task DeleteAsync(Department department);
}