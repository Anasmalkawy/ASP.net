using System;
using System.Collections.Generic;

namespace days.Models;

public partial class Taskk
{
    public int Id { get; set; }

    public string? TaskName { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int? EmployeeId { get; set; }

    public virtual Employee? Employee { get; set; }
}
