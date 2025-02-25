using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace task8._2.Models;

public partial class Day8
{
    public int Id { get; set; }




    public string? Name { get; set; }
    [Required]
    [EmailAddress]
    public string? Mail { get; set; }

    public string? Password { get; set; }

    public string? Rolee { get; set; }
}
