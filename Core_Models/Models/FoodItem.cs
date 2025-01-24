using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Core_Project.Models;

public partial class FoodItem
{
    public int IdFoodItem { get; set; }

    public int IdFoodGroup { get; set; }

    public string Label { get; set; } = null!;
    public string ImageUrl { get; set; }
    public string Description { get; set; }


  
    public virtual FoodGroup IdFoodGroupNavigation { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
