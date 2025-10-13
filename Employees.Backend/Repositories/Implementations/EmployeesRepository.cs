using Employees.Backend.Data;
using Employees.Backend.Repositories.Interfaces;
using Employees.Shared.DTOs;
using Employees.Shared.Entities;
using Employees.Shared.Responses;
using Microsoft.EntityFrameworkCore;
using Employees.Backend.Helpers;
using System.Diagnostics.Metrics;

namespace Employees.Backend.Repositories.Implementations;

public class EmployeesRepository : GenericRepository<Employee>, IEmployeesRepository
{
    private readonly DataContext _context;

    public EmployeesRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<ActionResponse<IEnumerable<Employee>>> GetAsync()
    {
        var employees = await _context.Employees
            .OrderBy(x => x.FirstName)
            .ToListAsync();
        return new ActionResponse<IEnumerable<Employee>>
        {
            WasSuccess = true,
            Result = employees
        };
    }

    public override async Task<ActionResponse<Employee>> GetAsync(int id)
    {
        var employees = await _context.Employees
             .Include(x => x.FirstName!)
             .Include(x => x.LastName)
             .FirstOrDefaultAsync(x => x.Id == id);

        if (employees == null)
        {
            return new ActionResponse<Employee>
            {
                WasSuccess = false,
                Message = "Empleado no existe"
            };
        }

        return new ActionResponse<Employee>
        {
            WasSuccess = true,
            Result = employees
        };
    }

    public async Task<ActionResponse<IEnumerable<Employee>>> GetAsync(PaginationDTO pagination)
    {
        var query = _context.Employees.AsQueryable();

        if (!string.IsNullOrWhiteSpace(pagination.Filter))
        {
            var filter = pagination.Filter.ToLower();
            query = query.Where(e =>
                e.FirstName.ToLower().Contains(filter) ||
                e.LastName.ToLower().Contains(filter));
        }

        var employees = await query
            .OrderBy(e => e.FirstName)
            .Skip((pagination.Page - 1) * pagination.RecordsNumber)
            .Take(pagination.RecordsNumber)
            .ToListAsync();

        return new ActionResponse<IEnumerable<Employee>> { WasSuccess = true, Result = employees };
    }

}
