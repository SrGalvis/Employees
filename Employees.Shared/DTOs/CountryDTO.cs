namespace Employees.Shared.DTOs;

public class CountryDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int StatesNumber { get; set; }
    public IEnumerable<StateDTO>? States { get; set; }
}