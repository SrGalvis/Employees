using Employees.Backend.Data;
using Employees.Backend.Repositories.Interfaces;
using Employees.Shared.DTOs;
using Employees.Shared.Entities;
using Employees.Shared.Responses;
using Microsoft.EntityFrameworkCore;
using Employees.Backend.Helpers;
using System.Diagnostics.Metrics;

namespace Employees.Backend.Repositories.Implementations;

public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
{
    private readonly DataContext _context;

    public CountriesRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<ActionResponse<IEnumerable<Country>>> GetAsync()
    {
        var countries = await _context.Countries
            .OrderBy(x => x.Name)
            .ToListAsync();
        return new ActionResponse<IEnumerable<Country>>
        {
            WasSuccess = true,
            Result = countries
        };
    }

    public override async Task<ActionResponse<Country>> GetAsync(int id)
    {
        var countries = await _context.Countries
             .FirstOrDefaultAsync(x => x.Id == id);

        if (countries == null)
        {
            return new ActionResponse<Country>
            {
                WasSuccess = false,
                Message = "Pais no existe"
            };
        }

        return new ActionResponse<Country>
        {
            WasSuccess = true,
            Result = countries
        };
    }

    public async Task<ActionResponse<IEnumerable<Country>>> GetAsync(PaginationDTO pagination)
    {
        var query = _context.Countries.AsQueryable();

        if (!string.IsNullOrWhiteSpace(pagination.Filter))
        {
            var filter = pagination.Filter.ToLower();
            query = query.Where(e =>
                e.Name.ToLower().Contains(filter));
        }

        var countries = await query
            .OrderBy(e => e.Name)
            .Skip((pagination.Page - 1) * pagination.RecordsNumber)
            .Take(pagination.RecordsNumber)
            .ToListAsync();

        return new ActionResponse<IEnumerable<Country>> { WasSuccess = true, Result = countries };
    }

}