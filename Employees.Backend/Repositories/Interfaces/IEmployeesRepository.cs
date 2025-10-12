using Employees.Shared.DTOs;
using Employees.Shared.Entities;
using Employees.Shared.Responses;
using System.Diagnostics.Metrics;

namespace Employees.Backend.Repositories.Interfaces;

public interface IEmployeesRepository
{
    Task<ActionResponse<Employee>> GetAsync(int id);

    Task<ActionResponse<IEnumerable<Employee>>> GetAsync();

    Task<ActionResponse<IEnumerable<Employee>>> GetAsync(PaginationDTO pagination);

    Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);

}
