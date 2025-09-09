using System.ComponentModel.DataAnnotations;

namespace Employees.Shared.Entities;

public class Employee
{
    public int Id { get; set; }

    [Display(Name = "Primer Nombre")]
    [MaxLength(30, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string? FirstName { get; set; }

    [Display(Name = "Primer Apellido")]
    [MaxLength(30, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string? LastName { get; set; }

    [Display(Name = "Está Activo")]
    public bool IsActive { get; set; }

    [Display(Name = "Fecha de Contratación")]
    public DateTime? HireDate { get; set; }

    [Display(Name = "Salario")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [Range(1000000, double.MaxValue, ErrorMessage = "El campo {0} debe ser mínimo {1:C0}.")]
    public decimal Salary { get; set; }
}