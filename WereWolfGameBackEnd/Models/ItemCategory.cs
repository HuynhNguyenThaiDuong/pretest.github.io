using System;
using System.Collections.Generic;

namespace WereWolfGameBackEnd.Models;

public partial class ItemCategory
{
    public string Id { get; set; } = null!;

    public string? ItemCategoryName { get; set; }

    public virtual ICollection<ShopItem> ShopItems { get; set; } = new List<ShopItem>();
}
