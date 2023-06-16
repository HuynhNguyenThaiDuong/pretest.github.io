using System;
using System.Collections.Generic;

namespace WereWolfGameBackEnd.Models;

public partial class OrderDetail
{
    public string OrderDetailId { get; set; } = null!;

    public string? ShopItemId { get; set; }

    public int? Amount { get; set; }

    public string OrderId { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;

    public virtual ShopItem? ShopItem { get; set; }
}
