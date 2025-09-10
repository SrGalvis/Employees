using Employees.Backend.UnitsOfWork_Interfaces;
using Employees.Shared.Entities;
using Employees.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : GenericController<Employee>
{
    private readonly IGenericUnitOfWork<Employee> _unit;

    public EmployeesController(IGenericUnitOfWork<Employee> unit) : base(unit)
    {
        _unit = unit;
    }

    [HttpGet("search")]
    public async Task<ActionResult<ActionResponse<IEnumerable<Employee>>>> GetByName([FromQuery] string value)
    {
        var response = await _unit.GetByNameAsync(value);
        if (!response.WasSuccess)
        {
            return NotFound(response);
        }
        return Ok(response);
    }
}