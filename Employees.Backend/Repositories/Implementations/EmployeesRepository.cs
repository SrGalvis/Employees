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
             .Include(c => c.FirstName!)
            // .ThenInclude(s => s.)
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

    public override async Task<ActionResponse<IEnumerable<Employee>>> GetAsync(PaginationDTO pagination)
    {
        var queryable = _context.Employees
            .Include(c => c.FirstName)
            .AsQueryable();

        return new ActionResponse<IEnumerable<Employee>>
        {
            WasSuccess = true,
            Result = await queryable
                .OrderBy(x => x.FirstName)
                .Paginate(pagination)
                .ToListAsync()
        };
    }

}
