using System;
using System.Collections.Generic;

namespace days.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? ImagePath { get; set; }

    public int? ManagerId { get; set; }

    public virtual Manager? Manager { get; set; }

    public virtual ICollection<Taskk> Taskks { get; set; } = new List<Taskk>();
}
