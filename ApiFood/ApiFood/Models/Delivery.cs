using System;
using System.Collections.Generic;

namespace ApiFood.Models;

public partial class Delivery
{
    public int DeliveryId { get; set; }

    public int? OrderId { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public string? DeliveryAddress { get; set; }

    public string? DeliveryStatus { get; set; }

    public virtual Order? Order { get; set; }
}
