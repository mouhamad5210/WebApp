using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core_Project.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;


    public bool IsAdmin { get; set; }
    // Foreign Key
    public int IdCompany { get; set; }
    public virtual Company Company { get; set; } = null!;

    [NotMapped]
    public string? CompanyName { get; set; }
}
