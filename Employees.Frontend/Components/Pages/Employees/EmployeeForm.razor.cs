using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Employees.Shared.Entities;
using System.Diagnostics.Metrics;

namespace Employees.Frontend.Components.Pages.Employees;

public partial class EmployeeForm
{
    private EditContext editContext = null!;

    [EditorRequired, Parameter] public Employee Employees { get; set; } = null!;
    [EditorRequired, Parameter] public EventCallback OnValidSubmit { get; set; }
    [EditorRequired, Parameter] public EventCallback ReturnAction { get; set; }

    protected override void OnInitialized()
    {
        editContext = new(Employees);
    }
}