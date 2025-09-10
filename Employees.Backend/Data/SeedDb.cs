using Employees.Shared.Entities;
using Orders.Backend.Data;

namespace Employees.Backend.Data;

public class SeedDb
{
    private readonly DataContext _context;

    public SeedDb(DataContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        await _context.Database.EnsureCreatedAsync();
        await CheckEmployeesAsync();
    }

    private async Task CheckEmployeesAsync()
    {
        if (!_context.Employees.Any())
        {
            _context.Employees.Add(new Employee { FirstName = "Andres", LastName = "Gomez", IsActive = true, HireDate = new DateTime(2016, 1, 18, 19, 20, 0), Salary = 2500000 });
            _context.Employees.Add(new Employee { FirstName = "Juan", LastName = "Pérez", IsActive = true, HireDate = new DateTime(2018, 5, 10, 9, 0, 0), Salary = 2200000 });
            _context.Employees.Add(new Employee { FirstName = "María", LastName = "Rodríguez", IsActive = true, HireDate = new DateTime(2020, 3, 1, 8, 30, 0), Salary = 3000000 });
            _context.Employees.Add(new Employee { FirstName = "Carlos", LastName = "López", IsActive = true, HireDate = new DateTime(2017, 11, 25, 10, 15, 0), Salary = 2800000 });
            _context.Employees.Add(new Employee { FirstName = "Laura", LastName = "Martínez", IsActive = true, HireDate = new DateTime(2019, 2, 14, 14, 45, 0), Salary = 3100000 });
            _context.Employees.Add(new Employee { FirstName = "David", LastName = "Hernández", IsActive = true, HireDate = new DateTime(2021, 6, 5, 16, 20, 0), Salary = 2600000 });
            _context.Employees.Add(new Employee { FirstName = "Paula", LastName = "Ramírez", IsActive = true, HireDate = new DateTime(2015, 9, 30, 9, 40, 0), Salary = 2900000 });
            _context.Employees.Add(new Employee { FirstName = "Jorge", LastName = "Castro", IsActive = true, HireDate = new DateTime(2018, 7, 22, 11, 10, 0), Salary = 2700000 });
            _context.Employees.Add(new Employee { FirstName = "Diana", LastName = "Morales", IsActive = true, HireDate = new DateTime(2022, 4, 17, 13, 0, 0), Salary = 2400000 });
            _context.Employees.Add(new Employee { FirstName = "Felipe", LastName = "Ruiz", IsActive = true, HireDate = new DateTime(2016, 12, 2, 15, 35, 0), Salary = 3300000 });
            _context.Employees.Add(new Employee { FirstName = "Camila", LastName = "Jiménez", IsActive = true, HireDate = new DateTime(2017, 8, 9, 8, 25, 0), Salary = 2800000 });
            _context.Employees.Add(new Employee { FirstName = "Mateo", LastName = "Vargas", IsActive = true, HireDate = new DateTime(2019, 10, 4, 17, 50, 0), Salary = 2600000 });
            _context.Employees.Add(new Employee { FirstName = "Valentina", LastName = "Torres", IsActive = true, HireDate = new DateTime(2018, 1, 12, 7, 55, 0), Salary = 3200000 });
            _context.Employees.Add(new Employee { FirstName = "Esteban", LastName = "Rojas", IsActive = true, HireDate = new DateTime(2020, 9, 29, 12, 10, 0), Salary = 3000000 });
            _context.Employees.Add(new Employee { FirstName = "Natalia", LastName = "Cárdenas", IsActive = true, HireDate = new DateTime(2021, 11, 7, 18, 5, 0), Salary = 2700000 });
        }
        await _context.SaveChangesAsync();
    }
}