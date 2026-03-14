using WebApplication4.Models;
using WebApplication4.Repositories;

namespace WebApplication4.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _repository;

    public DepartmentService(IDepartmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Department>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Department?> GetById(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Department> CreateAsync(Department department)
    {
        return await _repository.CreateAsync(department);
    }

    public async Task<bool> UpdateAsync(int id, Department department)
    {
        var existingDepartment = await _repository.GetByIdAsync(id);

        if (existingDepartment == null)
        {
            return false;
        }

        existingDepartment.Name = department.Name;
        existingDepartment.Description = department.Description;

        await _repository.UpdateAsync(existingDepartment);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var departmentToBeTerminated = await _repository.GetByIdAsync(id);

        if (departmentToBeTerminated == null)
        {
            return false;
        }

        await _repository.DeleteAsync(departmentToBeTerminated);

        return true;
    }
}