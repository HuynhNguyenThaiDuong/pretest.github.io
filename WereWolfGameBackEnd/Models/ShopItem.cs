using System;
using System.Collections.Generic;

namespace WereWolfGameBackEnd.Models;

public partial class ShopItem
{
    public string ShopItemId { get; set; } = null!;

    public string? ItemDescription { get; set; }

    public string ItemCategoryId { get; set; } = null!;

    public double? Price { get; set; }

    public string? CurrencyType { get; set; }

    public int? Amount { get; set; }

    public virtual ItemCategory ItemCategory { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
