using Employees.Shared.Entities;
using Employees.Backend.Data;

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
            _context.Employees.AddRange(new List<Employee>
        {
            new Employee { FirstName = "Andres", LastName = "Gomez", IsActive = true, HireDate = new DateTime(2016, 1, 18, 19, 20, 0), Salary = 2500000 },
            new Employee { FirstName = "Juan", LastName = "Pérez", IsActive = true, HireDate = new DateTime(2018, 5, 10, 9, 0, 0), Salary = 2200000 },
            new Employee { FirstName = "María", LastName = "Rodríguez", IsActive = true, HireDate = new DateTime(2020, 3, 1, 8, 30, 0), Salary = 3000000 },
            new Employee { FirstName = "Carlos", LastName = "López", IsActive = true, HireDate = new DateTime(2017, 11, 25, 10, 15, 0), Salary = 2800000 },
            new Employee { FirstName = "Laura", LastName = "Martínez", IsActive = true, HireDate = new DateTime(2019, 2, 14, 14, 45, 0), Salary = 3100000 },
            new Employee { FirstName = "David", LastName = "Hernández", IsActive = true, HireDate = new DateTime(2021, 6, 5, 16, 20, 0), Salary = 2600000 },
            new Employee { FirstName = "Paula", LastName = "Ramírez", IsActive = true, HireDate = new DateTime(2015, 9, 30, 9, 40, 0), Salary = 2900000 },
            new Employee { FirstName = "Jorge", LastName = "Castro", IsActive = true, HireDate = new DateTime(2018, 7, 22, 11, 10, 0), Salary = 2700000 },
            new Employee { FirstName = "Diana", LastName = "Morales", IsActive = true, HireDate = new DateTime(2022, 4, 17, 13, 0, 0), Salary = 2400000 },
            new Employee { FirstName = "Felipe", LastName = "Ruiz", IsActive = true, HireDate = new DateTime(2016, 12, 2, 15, 35, 0), Salary = 3300000 },
            new Employee { FirstName = "Camila", LastName = "Jiménez", IsActive = true, HireDate = new DateTime(2017, 8, 9, 8, 25, 0), Salary = 2800000 },
            new Employee { FirstName = "Mateo", LastName = "Vargas", IsActive = true, HireDate = new DateTime(2019, 10, 4, 17, 50, 0), Salary = 2600000 },
            new Employee { FirstName = "Valentina", LastName = "Torres", IsActive = true, HireDate = new DateTime(2018, 1, 12, 7, 55, 0), Salary = 3200000 },
            new Employee { FirstName = "Esteban", LastName = "Rojas", IsActive = true, HireDate = new DateTime(2020, 9, 29, 12, 10, 0), Salary = 3000000 },
            new Employee { FirstName = "Natalia", LastName = "Cárdenas", IsActive = true, HireDate = new DateTime(2021, 11, 7, 18, 5, 0), Salary = 2700000 },
            new Employee { FirstName = "Santiago", LastName = "Mejía", IsActive = true, HireDate = new DateTime(2014, 5, 21, 9, 10, 0), Salary = 3400000 },
            new Employee { FirstName = "Daniela", LastName = "Patiño", IsActive = true, HireDate = new DateTime(2022, 8, 13, 8, 0, 0), Salary = 2600000 },
            new Employee { FirstName = "Sebastián", LastName = "García", IsActive = true, HireDate = new DateTime(2020, 10, 9, 10, 30, 0), Salary = 3100000 },
            new Employee { FirstName = "Carolina", LastName = "Zapata", IsActive = true, HireDate = new DateTime(2019, 4, 4, 13, 45, 0), Salary = 2800000 },
            new Employee { FirstName = "Andrés", LastName = "Quintero", IsActive = true, HireDate = new DateTime(2017, 3, 19, 15, 50, 0), Salary = 3300000 },
            new Employee { FirstName = "Tatiana", LastName = "Cano", IsActive = true, HireDate = new DateTime(2023, 2, 1, 9, 0, 0), Salary = 2400000 },
            new Employee { FirstName = "Julian", LastName = "Sánchez", IsActive = true, HireDate = new DateTime(2015, 6, 27, 8, 30, 0), Salary = 2900000 },
            new Employee { FirstName = "Lucía", LastName = "Ortega", IsActive = true, HireDate = new DateTime(2018, 9, 15, 16, 10, 0), Salary = 3100000 },
            new Employee { FirstName = "Nicolás", LastName = "Giraldo", IsActive = true, HireDate = new DateTime(2016, 7, 20, 11, 0, 0), Salary = 2700000 },
            new Employee { FirstName = "Sara", LastName = "Bedoya", IsActive = true, HireDate = new DateTime(2021, 3, 3, 10, 15, 0), Salary = 2500000 },
            new Employee { FirstName = "Felipe", LastName = "Mendoza", IsActive = true, HireDate = new DateTime(2019, 11, 23, 14, 40, 0), Salary = 3000000 },
            new Employee { FirstName = "Luisa", LastName = "Arango", IsActive = true, HireDate = new DateTime(2017, 1, 8, 7, 30, 0), Salary = 2800000 },
            new Employee { FirstName = "Tomás", LastName = "Londoño", IsActive = true, HireDate = new DateTime(2020, 6, 17, 12, 0, 0), Salary = 2700000 },
            new Employee { FirstName = "Isabella", LastName = "Rincón", IsActive = true, HireDate = new DateTime(2022, 5, 22, 9, 25, 0), Salary = 2600000 },
            new Employee { FirstName = "Simón", LastName = "Castaño", IsActive = true, HireDate = new DateTime(2018, 12, 30, 13, 35, 0), Salary = 3100000 },
            new Employee { FirstName = "Gabriela", LastName = "Muñoz", IsActive = true, HireDate = new DateTime(2015, 8, 16, 11, 50, 0), Salary = 2950000 },
            new Employee { FirstName = "Juanita", LastName = "Ramírez", IsActive = true, HireDate = new DateTime(2016, 10, 5, 17, 45, 0), Salary = 3200000 },
            new Employee { FirstName = "Samuel", LastName = "Cardona", IsActive = true, HireDate = new DateTime(2019, 2, 25, 9, 10, 0), Salary = 2700000 },
            new Employee { FirstName = "Alejandra", LastName = "Cruz", IsActive = true, HireDate = new DateTime(2018, 11, 14, 14, 15, 0), Salary = 2600000 },
            new Employee { FirstName = "Diego", LastName = "Salazar", IsActive = true, HireDate = new DateTime(2021, 9, 9, 15, 30, 0), Salary = 2900000 },
            new Employee { FirstName = "Melissa", LastName = "Montoya", IsActive = true, HireDate = new DateTime(2017, 4, 13, 8, 0, 0), Salary = 3100000 },
            new Employee { FirstName = "Álvaro", LastName = "Valencia", IsActive = true, HireDate = new DateTime(2020, 12, 19, 13, 50, 0), Salary = 2750000 },
            new Employee { FirstName = "Vanessa", LastName = "Pérez", IsActive = true, HireDate = new DateTime(2016, 3, 11, 9, 45, 0), Salary = 3350000 },
            new Employee { FirstName = "Oscar", LastName = "Córdoba", IsActive = true, HireDate = new DateTime(2019, 7, 7, 10, 25, 0), Salary = 2800000 },
            new Employee { FirstName = "Catalina", LastName = "Molina", IsActive = true, HireDate = new DateTime(2018, 5, 19, 16, 0, 0), Salary = 3000000 },
            new Employee { FirstName = "Ricardo", LastName = "Agudelo", IsActive = true, HireDate = new DateTime(2022, 10, 3, 11, 10, 0), Salary = 2600000 },
            new Employee { FirstName = "Ana", LastName = "Fernández", IsActive = true, HireDate = new DateTime(2017, 2, 28, 9, 20, 0), Salary = 3200000 },
            new Employee { FirstName = "Julián", LastName = "Gómez", IsActive = true, HireDate = new DateTime(2015, 6, 14, 12, 40, 0), Salary = 2800000 },
            new Employee { FirstName = "Mónica", LastName = "Guerra", IsActive = true, HireDate = new DateTime(2021, 8, 11, 13, 30, 0), Salary = 2700000 },
            new Employee { FirstName = "Leandro", LastName = "Hurtado", IsActive = true, HireDate = new DateTime(2019, 5, 5, 10, 15, 0), Salary = 2900000 },
            new Employee { FirstName = "Rosa", LastName = "Velásquez", IsActive = true, HireDate = new DateTime(2018, 3, 18, 8, 0, 0), Salary = 3100000 },
            new Employee { FirstName = "Mauricio", LastName = "Serna", IsActive = true, HireDate = new DateTime(2016, 11, 21, 14, 10, 0), Salary = 2750000 },
            new Employee { FirstName = "Patricia", LastName = "Marín", IsActive = true, HireDate = new DateTime(2020, 9, 1, 9, 35, 0), Salary = 2850000 },
            new Employee { FirstName = "Hernán", LastName = "Ospina", IsActive = true, HireDate = new DateTime(2023, 3, 16, 10, 50, 0), Salary = 2500000 },
            new Employee { FirstName = "Mariana", LastName = "Suárez", IsActive = true, HireDate = new DateTime(2019, 1, 9, 13, 25, 0), Salary = 2950000 },
            new Employee { FirstName = "Pablo", LastName = "Restrepo", IsActive = true, HireDate = new DateTime(2017, 10, 6, 15, 15, 0), Salary = 3000000 },
        });

            await _context.SaveChangesAsync();
        }
    }
}
