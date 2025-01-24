using System;
using System.Collections.Generic;

namespace Core_Project.Models;

public partial class FoodGroup
{
    public int IdFoodGroup { get; set; }

    public string Label { get; set; } = null!;

    public virtual ICollection<FoodItem> FoodItems { get; set; } = new List<FoodItem>();
}
