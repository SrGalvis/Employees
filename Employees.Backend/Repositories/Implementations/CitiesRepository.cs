using Employees.Backend.Data;
using Employees.Shared.DTOs;
using Employees.Shared.Entities;
using Employees.Shared.Responses;
using Employees.Backend.Repositories.Interfaces;
using Employees.Backend.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Employees.Backend.Repositories.Implementations;

public class CitiesRepository : GenericRepository<City>, ICitiesRepository
{
    private readonly DataContext _context;

    public CitiesRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<ActionResponse<IEnumerable<City>>> GetAsync()
    {
        var cities = await _context.Cities
            .OrderBy(x => x.Name)
            .ToListAsync();
        return new ActionResponse<IEnumerable<City>>
        {
            WasSuccess = true,
            Result = cities
        };
    }

    public override async Task<ActionResponse<City>> GetAsync(int id)
    {
        var cities = await _context.Cities
             .FirstOrDefaultAsync(s => s.Id == id);

        if (cities == null)
        {
            return new ActionResponse<City>
            {
                WasSuccess = false,
                Message = "Estado no existe"
            };
        }

        return new ActionResponse<City>
        {
            WasSuccess = true,
            Result = cities
        };
    }

    public override async Task<ActionResponse<IEnumerable<City>>> GetAsync(PaginationDTO pagination)
    {
        var queryable = _context.Cities
            .Where(x => x.State!.Id == pagination.Id)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(pagination.Filter))
        {
            queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
        }

        return new ActionResponse<IEnumerable<City>>
        {
            WasSuccess = true,
            Result = await queryable
                .OrderBy(x => x.Name)
                .Paginate(pagination)
                .ToListAsync()
        };
    }

    public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination)
    {
        var queryable = _context.Cities
            .Where(x => x.State!.Id == pagination.Id)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(pagination.Filter))
        {
            queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
        }

        double count = await queryable.CountAsync();
        return new ActionResponse<int>
        {
            WasSuccess = true,
            Result = (int)count
        };
    }
}

