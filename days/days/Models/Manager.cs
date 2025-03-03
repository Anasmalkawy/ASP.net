﻿using System;
using System.Collections.Generic;

namespace days.Models;

public partial class Manager
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
