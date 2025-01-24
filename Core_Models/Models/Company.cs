using System;
using System.Collections.Generic;

namespace Core_Project.Models;

public partial class Company
{
    public int IdCompany { get; set; }

    public string Label { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    // Navigation Property
    public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
}
