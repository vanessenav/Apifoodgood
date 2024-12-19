using System;
using System.Collections.Generic;

namespace ApiFood.Models;

public partial class Menu
{
    public int MenuId { get; set; }

    public string DishName { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int? Calories { get; set; }

    public string? Category { get; set; }

    public bool? Available { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
