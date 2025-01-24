using System;
using System.Collections.Generic;

namespace Core_Project.Models;

public partial class Product
{
    public int IdProduct { get; set; }

    public int IdCompany { get; set; }

    public int IdFoodItem { get; set; }

    public string Label { get; set; } = null!;
    public string ImageUrl { get; set; }

    public decimal Prix { get; set; }
    public string Description { get; set; }


    public int? EnergyKcal { get; set; }

    public int? FatG { get; set; }

    public int? CarbohydratG { get; set; }

    public int? ProteinG { get; set; }

    public int? SodiumMg { get; set; }

    public int? SugarG { get; set; }
    public virtual Company IdCompanyNavigation { get; set; } = null!;

    public virtual FoodItem IdFoodItemNavigation { get; set; } = null!;
}
