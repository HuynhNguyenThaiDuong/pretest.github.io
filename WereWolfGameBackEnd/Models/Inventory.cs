using System;
using System.Collections.Generic;

namespace WereWolfGameBackEnd.Models;

public partial class Inventory
{
    public string InventoryId { get; set; } = null!;

    public string ItemId { get; set; } = null!;

    public string? ItemDescription { get; set; }

    public int? Amount { get; set; }

    public string PlayerId { get; set; } = null!;

    public virtual Player Player { get; set; } = null!;
}
