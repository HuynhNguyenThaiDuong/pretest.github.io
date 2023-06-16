using System;
using System.Collections.Generic;

namespace WereWolfGameBackEnd.Models;

public partial class Order
{
    public string OrderId { get; set; } = null!;

    public string PlayerId { get; set; } = null!;

    public double? TotalCost { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Player Player { get; set; } = null!;
}
