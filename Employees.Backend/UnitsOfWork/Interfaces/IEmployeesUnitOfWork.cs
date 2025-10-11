using Employees.Shared.Entities;
using Employees.Shared.Responses;

namespace Employees.Backend.UnitsOfWork.Interfaces;

public interface IEmployeesUnitOfWork
{
    public interface IEmployeesUnitOfWork
    {
        Task<ActionResponse<Employee>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<Employee>>> GetAsync();
    }
}
