﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace task8._1.Models;

public partial class RegUser
{


    public int Id { get; set; }


    [Required]
    [EmailAddress]
    public string? Mail { get; set; }


    [Required]
    [StringLength(100, MinimumLength = 6)]

    public string? Name { get; set; }


    [Required]
    [StringLength(100, MinimumLength = 6)]
    public string? Pasword { get; set; }
}
